using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TGBot.Contracts.Base.Telegram;
using TGBot.Domain.Entities;

namespace TGBot.Contracts.Processes
{
    public class RegistrationProcess : TelegramProcess
    {
        public override string Name => "reg";

        public override async Task<User> Execute(User user, TelegramMessage msg, ITelegramBotClient client)
        {
            if(user.Step == 0)
            {
                if(msg.Text == "регистрация")
                {
                    await client.SendTextMessageAsync(user.Id, "Отлично. Введите свой псевдоним");
                    user.Step++;
                }
                else
                {
                    var buttons = TelegramUI.CreateTextInline("Регистрация");
                    await client.SendTextMessageAsync(user.Id, "Чтобы продолжить, вам нужно пройти регистрацию", replyMarkup:buttons);
                }
                
            }
            else if(user.Step == 1)
            {
                user.UserName = msg.Text;
                await client.SendTextMessageAsync(user.Id, "Регистрация успешно пройдена!");
                user.ClearProcess();
            }

            return user;
        }
    }
}
