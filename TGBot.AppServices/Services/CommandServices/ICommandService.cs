using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGBot.Contracts.Base.Telegram;

namespace TGBot.AppServices.Services.CommandServices
{
    /// <summary>
    /// Сервис для работы с командами
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// Возвращает список команд
        /// </summary>
        /// <returns></returns>
        List<TelegramCommand> GetCommands();
    }
}
