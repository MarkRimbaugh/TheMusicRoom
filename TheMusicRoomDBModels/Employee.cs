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
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        //[Required]
        //public int EmployeeAddressId { get; set; }
        //[Required]
        //public int EmployeePhoneId { get; set; }

        //public virtual EmployeeAddress Address { get; set; }
        //public virtual EmployeePhone Phone { get; set; }

        

    }
}
