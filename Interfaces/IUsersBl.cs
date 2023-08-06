using Cyberbit.TaskManager.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cyberbit.TaskManager.Server.AuthorizeHelpers;
using Cyberbit.TaskManager.Server.Models.Enums;

namespace Cyberbit.TaskManager.Server.Interfaces
{
    public interface IUsersBl
    {
        Task<IList<User>> GetAllUser();

        Task<User> GetUserById(int id);

        Task<User> AddUser(User user);

        Task<User> UpdateUser(User user);

        Task<User> DeleteUserById(int id);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    }
}
