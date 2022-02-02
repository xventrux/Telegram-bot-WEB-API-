using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot.Contracts
{
    public static class TelegramUI
    {
        public static InlineKeyboardMarkup CreateTextInline(params string[] args)
        {
            List<List<InlineKeyboardButton>> listObjects = new List<List<InlineKeyboardButton>>();

            listObjects.Add(new List<InlineKeyboardButton>());
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "")
                    listObjects.Add(new List<InlineKeyboardButton>());
                else
                    listObjects[listObjects.Count - 1].Add(InlineKeyboardButton.WithCallbackData(args[i]));
            }

            return new InlineKeyboardMarkup(listObjects);
        }

        public static ReplyKeyboardMarkup CreateTextButton(params string[] args)
        {
            List<List<KeyboardButton>> listObjects = new List<List<KeyboardButton>>();

            listObjects.Add(new List<KeyboardButton>());
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "")
                    listObjects.Add(new List<KeyboardButton>());
                else
                    listObjects[listObjects.Count - 1].Add(new KeyboardButton(args[i]));
            }

            return new ReplyKeyboardMarkup(listObjects);
        }
    }
}
