using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.AppServices.Services.CommandServices;
using TGBot.AppServices.Services.ProcessServices;
using TGBot.AppServices.Services.UpdateServices;
using TGBot.AppServices.Services.UserServices;
using TGBot.Contracts;
using TGBot.Contracts.Base.Telegram;

namespace TGBot.Controllers
{
    /// <summary>
    /// Контроллер для работы с ботом
    /// </summary>
    [ApiController]
    [Route("api/message/update")]
    public class BotController : ControllerBase
    {
        private readonly ITelegramBotClient telegramBotClient;
        private readonly ICommandService commandService;
        private readonly IProcessService processService;
        private readonly IUpdateService updateService;
        private readonly IUserService userService;

        public BotController(ITelegramBotClient telegramBotClient,
            ICommandService commandService,
            IProcessService processService,
            IUpdateService updateService,
            IUserService userService)
        {
            this.telegramBotClient = telegramBotClient;
            this.commandService = commandService;
            this.processService = processService;
            this.updateService = updateService;
            this.userService = userService;

            List<BotCommand> botCommands = new List<BotCommand>();
            foreach (var item in commandService.GetCommands())
            {
                botCommands.Add(new BotCommand()
                {
                    Command = item.Name,
                    Description = item.Description
                });
            }

            telegramBotClient.SetMyCommandsAsync(botCommands);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Started");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            TelegramMessage message = updateService.Check(update);

            if (message == null) return Ok();

            Domain.Entities.User user = await userService.Login(message.Id);

            if (user == null)
            {
                user = await userService.Registration(message.Id);

                var buttons = TelegramUI.CreateTextInline("Регистрация");
                await telegramBotClient.SendTextMessageAsync(message.Id, "Для того чтобы продолжить, вам необходимо зарегистрироваться", replyMarkup: buttons);
                return Ok();
            }

            //Если у него есть какой-либо процесс, то запускаем его и больше ничего не делаем
            if (!String.IsNullOrEmpty(user.ProcessName))
            {
                foreach (var process in processService.GetProcesses())
                {
                    if (process.Contains(user.ProcessName))
                    {
                        user = await process.Execute(user, message, telegramBotClient);
                        await userService.Update(user);
                        return Ok();
                    }
                }
            }

            //Иначе смотрим какую команду он написал и выполняем ее
            foreach (var command in commandService.GetCommands())
            {
                if (command.Contains(message.Text))
                {
                    user = await command.Execute(user, message, telegramBotClient);
                    await userService.Update(user);
                    return Ok();
                }
            }

            //Если нет такой команды, то отправляем соответсвующие сообщение
            await telegramBotClient.SendTextMessageAsync(message.Id, "Я вас не понимаю");
            return Ok();
        }
    }
}
