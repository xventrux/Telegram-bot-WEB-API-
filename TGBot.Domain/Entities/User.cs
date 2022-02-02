using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGBot.Domain.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Псевдоним пользователя
        /// </summary>
        public string UserName { get; set; }

        //Процесс в контексте нашей программы - это
        //набор последовательных сообщений бота пользователю
        //с возможным изменением данных пользователя
        #region Процесс
        /// <summary>
        /// Наименование текущего процесса пользователя
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// Шаг процесса пользователя
        /// </summary>
        public int Step { get; set; }

        public void ClearProcess()
        {
            ProcessName = "";
            Step = 0;
        }
        #endregion
    }
}
