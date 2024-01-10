using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext context;
        public UserRepository(IDbContext _context)
        {
            context = _context;
        }
        public void CreateUser(User user)
        {
            var u = new DynamicParameters();
            u.Add("p_firstName",user.First_Name,dbType:DbType.String,direction:ParameterDirection.Input);
            u.Add("p_lastName", user.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_locationLatitude", user.Location_Latitude, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_locationLongitude", user.Location_Longitude, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_phoneNumber", user.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_profileImgPath", user.Profile_Img_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_registrationDate", user.Registration_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            u.Add("p_isActivated", user.Is_Activated, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.Connection.Execute("Users_Package.CreateUser", u,commandType:CommandType.StoredProcedure);
        }

        public void DeleteUser(int id)
        {
            var u = new DynamicParameters();
            u.Add("p_userId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.Connection.Execute("Users_Package.DeleteUser", u, commandType: CommandType.StoredProcedure);
        }

        public List<User> GetAllUsers()
        {
            IEnumerable<User> users = context.Connection.Query<User>("Users_Package.GetAllUsers",commandType:CommandType.StoredProcedure);
            return users.ToList();
        }

        public User GetUserById(int id)
        {
            var u = new DynamicParameters();
            u.Add("p_userId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.Connection.Query<User>("Users_Package.GetUserById",u, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateUser(int id, User user)
        {
            var u =new DynamicParameters();
            u.Add("p_userId",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            u.Add("p_firstName",user.First_Name,dbType:DbType.String,direction:ParameterDirection.Input);
            u.Add("p_lastName", user.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_locationLatitude", user.Location_Latitude, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_locationLongitude", user.Location_Longitude, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_phoneNumber", user.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_profileImgPath", user.Profile_Img_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_isActivated", user.Is_Activated, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.Connection.Execute("Users_Package.UpdateUser",u,commandType:CommandType.StoredProcedure);
        }
        public int NumberOfRegisteredUsers()
        {
            var p = new DynamicParameters();
            p.Add("p_user_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            
            context.Connection.Query("Users_Package.CountRegisteredUsers", p, commandType: CommandType.StoredProcedure);

            int usersCount = p.Get<int>("p_user_count"); 
            return usersCount;
        }
        
        public List<UsersWithReservations> GetUsersWithReservations()
        {
            IEnumerable<UsersWithReservations> users = context.Connection.Query<UsersWithReservations>("Users_Package.GetUsersWithReservations", commandType: CommandType.StoredProcedure);
            return users.ToList();
        }
        public void CreateUserLogin(UserLogin userLogin)
        {
            var u = new DynamicParameters();
            u.Add("p_firstName", userLogin.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_lastName", userLogin.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_email", userLogin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_locationLatitude", userLogin.Location_Latitude, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_locationLongitude", userLogin.Location_Longitude, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_phoneNumber", userLogin.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_profileImgPath", userLogin.Profile_Img_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_registrationDate", userLogin.Registration_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            u.Add("p_isActivated", userLogin.Is_Activated, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_username", userLogin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            u.Add("p_password", userLogin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            //u.Add("p_user_id", userLogin.User_Id, dbType: DbType.String, direction: ParameterDirection.Output);
            u.Add("p_role_id", userLogin.Role_Id , dbType: DbType.String, direction: ParameterDirection.Input);
            var result2 = context.Connection.Execute("CreateUserLogin", u, commandType: CommandType.StoredProcedure);
        }
    }
}
