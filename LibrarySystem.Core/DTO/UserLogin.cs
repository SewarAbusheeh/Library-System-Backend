using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.DTO
{
    public class UserLogin
    {
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Location_Latitude { get; set; }
        public string? Location_Longitude { get; set; }
        public string? Phone_Number { get; set; }
        public string? Profile_Img_Path { get; set; }
        public DateTime? Registration_Date { get; set; }
        public string? Is_Activated { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public decimal? User_Id { get; set; }
        public decimal? Role_Id { get; set; }

    }
}
