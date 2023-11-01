using ERP.Models;

namespace ERP.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
    }
}