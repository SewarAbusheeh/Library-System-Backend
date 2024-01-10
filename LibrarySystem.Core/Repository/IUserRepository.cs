using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repository
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(int id);
        void UpdateUser(int id, User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        public int NumberOfRegisteredUsers();
        public List<UsersWithReservations> GetUsersWithReservations();
        void CreateUserLogin(UserLogin userLogin);

    }
}
