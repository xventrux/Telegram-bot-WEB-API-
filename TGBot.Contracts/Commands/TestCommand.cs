using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TGBot.Contracts.Base.Telegram;
using TGBot.Domain.Entities;

namespace TGBot.Contracts.Commands
{
    public class TestCommand : TelegramCommand
    {
        public override string Name => "/start";

        public override string Description => "Тестовая команда";

        public override async Task<User> Execute(User user, TelegramMessage msg, ITelegramBotClient client)
        {
            await client.SendTextMessageAsync(user.Id, "Hello world!!!");
            return user;
        }
    }
}
