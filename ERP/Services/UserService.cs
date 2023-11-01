using ERP.Data;
using ERP.Models;
using ERP.Services.Interfaces;
using Microsoft.Extensions.Configuration; 

namespace ERP.Services
{
    public class UserService : IUserService
    {
        private readonly CosmosContext<User> _context;
        private readonly string containerName; 

        public UserService(IConfiguration configuration) 
        {
            _context = new CosmosContext<User>(configuration);
            containerName = "ERP"; 
        }

        public async Task AddUser(User user)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Email = user.Email,
                PassWord = user.PassWord,
            };

            await _context.Add(containerName, newUser, newUser.Id.ToString());
        }
    }
}
