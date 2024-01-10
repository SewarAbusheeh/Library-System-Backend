using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        void IUserService.CreateUser(User user)
        {
            userRepository.CreateUser(user);
        }

        void IUserService.DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        List<User> IUserService.GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        User IUserService.GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        void IUserService.UpdateUser(int id, User user)
        {
            userRepository.UpdateUser(id, user);
        }
        public int NumberOfRegisteredUsers()
        {
            return userRepository.NumberOfRegisteredUsers();
        }
        public List<UsersWithReservations> GetUsersWithReservations()
        {
            return userRepository.GetUsersWithReservations();
        }
    }
}
