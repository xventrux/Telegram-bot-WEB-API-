using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGBot.Domain.Entities;

namespace TGBot.AppServices.Services.UserServices
{
    /// <summary>
    /// Сервис для работы с пользователем
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Возвращает пользователя из базы данных, либо регистрирует его
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        public Task<User> Login(long id);

        /// <summary>
        /// Регистрирует пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="login">Username пользователя</param>
        /// <returns></returns>
        public Task<User> Registration(long id);

        /// <summary>
        /// Обновляет пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public Task Update(User user);

        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public Task Delete(User user);
    }
}
