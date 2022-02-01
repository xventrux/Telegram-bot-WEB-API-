using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGBot.AppServices.Services.CommandServices
{
    /// <inheritdoc/>
    public class CommandService : ICommandService
    {
        /// <summary>
        /// Список команд
        /// </summary>
        private readonly List<TelegramCommand> commands;

        public CommandService()
        {
            commands = new List<TelegramCommand>()
            {
                //Сюда нужно добавить существующие команды
            };
        }

        /// <inheritdoc/>
        public List<TelegramCommand> GetCommands() => commands;
    }
}
