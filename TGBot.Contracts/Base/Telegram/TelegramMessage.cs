using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGBot.Contracts.Base.Telegram
{
    /// <summary>
    /// Телеграм сообщение
    /// </summary>
    public class TelegramMessage
    {
        string text;
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get => text.ToLower(); set { text = value; } }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Username пользователя
        /// </summary>
        public string Login { get; set; }
    }
}
