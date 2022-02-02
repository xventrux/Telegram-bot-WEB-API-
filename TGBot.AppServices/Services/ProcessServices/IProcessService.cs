using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGBot.Contracts.Base.Telegram;

namespace TGBot.AppServices.Services.ProcessServices
{
    /// <summary>
    /// Сервис для работы с процессом
    /// </summary>
    public interface IProcessService
    {
        List<TelegramProcess> GetProcesses();
    }
}
