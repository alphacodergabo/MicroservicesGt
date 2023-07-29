using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCars.Users.Domain.Models
{
    public class RentUsers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "char(8)")]
        public string Doc { get; set; }
        [Column(TypeName = "char(8)")]
        public string DriverLicence { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Email { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string RegistrationUser { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ModificationUser { get; set; }
    }
}
