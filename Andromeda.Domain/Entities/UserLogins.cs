using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andromeda.Domain.Entities
{
    [Table("tbl_UserLogins")]
    public class UserLogins
    {
        [Key]
        [ForeignKey("EmployeeDetails")]
        public int ID { get; set; }

        public string Username { get; set; }

        public byte[] Salt { get; set; }

        public byte[] Password { get; set; }

        public EmployeeDetails EmployeeDetails { get; set; }

    }
}
