using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TGBot.Domain.Entities;

namespace TGBot.Contracts.Base.Telegram
{
    public abstract class TelegramProcess
    {
        public abstract string Name { get; }

        public abstract Task<User> Execute(User user, TelegramMessage msg, ITelegramBotClient client);
        public bool Contains(string name)
        {
            return name.ToLower().Contains(Name.ToLower());
        }
    }
}
