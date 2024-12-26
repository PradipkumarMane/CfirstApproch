using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CfirstApproch.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Column("EmployeeName",TypeName ="varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column("EmployeeGender", TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }
        [Required]
        public int? Age { get; set; }

        [Column("CityName", TypeName = "varchar(20)")]
        [Required]
        public string City { get; set; }

    }
}
