using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TGBot.Contracts.Base.Telegram;

namespace TGBot.AppServices.Services.UpdateServices
{
    public class UpdateService : IUpdateService
    {
        public TelegramMessage Check(Update update)
        {
            if (update == null) return null;

            if (update.Message != null && !String.IsNullOrEmpty(update.Message.Text))
            {
                TelegramMessage tm = new TelegramMessage()
                {
                    Id = update.Message.From.Id,
                    Login = update.Message.From.Username,
                    Text = update.Message.Text.ToLower()
                };
                return tm;
            }
            else if (update.CallbackQuery != null && !String.IsNullOrEmpty(update.CallbackQuery.Data))
            {
                TelegramMessage tcm = new TelegramMessage()
                {
                    Id = update.CallbackQuery.From.Id,
                    Login = update.CallbackQuery.From.Username,
                    Text = update.CallbackQuery.Data.ToLower(),
                };
                return tcm;
            }
            return null;
        }
    }
}
