using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarMaintenance.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserStatus { get; set; }
    }
}
