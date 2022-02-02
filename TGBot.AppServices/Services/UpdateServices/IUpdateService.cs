using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TGBot.Contracts.Base.Telegram;

namespace TGBot.AppServices.Services.UpdateServices
{
    /// <summary>
    /// Сервис для работы с обновлениями телеграм
    /// </summary>
    public interface IUpdateService
    {
        /// <summary>
        /// Возвращает сообщение
        /// </summary>
        /// <param name="update">обновление телеграм</param>
        /// <returns></returns>
        TelegramMessage Check(Update update);
    }
}
