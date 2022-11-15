using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicRoomDBModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string First { get; set; }
        [Required, StringLength(30)]
        public string Middle { get; set; }
        [Required, StringLength(30)]
        public string Last { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int PhoneId { get; set; }

    }
}
