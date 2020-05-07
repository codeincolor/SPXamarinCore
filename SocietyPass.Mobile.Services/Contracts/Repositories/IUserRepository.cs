using SocietyPass.Mobile.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId, CancellationToken cancellationToken = default(CancellationToken));
        Task<User> GetUserByCredentials(string login, string password, CancellationToken cancellationToken = default(CancellationToken));
    }
}
