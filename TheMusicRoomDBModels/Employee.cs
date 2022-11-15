using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheMusicRoomDBModels
{
    public enum Position { Manager, Associate}

    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string First { get; set; }
        [Required, StringLength(20)]
        public string Middle { get; set; }
        [Required, StringLength(20)]
        public string Last { get; set; }
        public Position Position { get; set; }
        [Required]
        public int EmployeeAddressId { get; set; }
        [Required]
        public int EmployeePhoneId { get; set; }
    }
}
