using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGBot.Contracts.Base.Telegram;
using TGBot.Contracts.Processes;

namespace TGBot.AppServices.Services.ProcessServices
{
    public class ProcessService : IProcessService
    {
        public readonly List<TelegramProcess> processes;

        public ProcessService()
        {
            processes = new List<TelegramProcess>()
            {
                //Сюда нужно добавить существующие команды
                new RegistrationProcess()
            };
        }

        public List<TelegramProcess> GetProcesses() => processes;
    }
}
