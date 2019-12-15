using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saitynas.Models;
using Saitynas.Helpers;

namespace Saitynas.Services
{
    public interface IUserService
    {
        Task<TblUser> Authenticate(string username, string password);
        Task<IEnumerable<TblUser>> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<TblUser> _users = new List<TblUser>
        {
            new TblUser { UserId = 1, Name = "Test", Username = "test", Password = "test", City = "Kaunas", Gender = "Male", UserRole = 1 }
        };

        public async Task<TblUser> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<TblUser>> GetAll()
        {
            return await Task.Run(() => _users.WithoutPasswords());
        }
    }
}