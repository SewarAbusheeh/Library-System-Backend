using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.DTO
{
    public class UsersWithReservations
    {
        public decimal User_Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Location_Latitude { get; set; }
        public string? Location_Longitude { get; set; }
        public string? Phone_Number { get; set; }
        public string? Profile_Img_Path { get; set; }
        public DateTime? Registration_Date { get; set; }
        public string? Is_Activated { get; set; }

        public DateTime? Returned_Date { get; set; }


    }
}
