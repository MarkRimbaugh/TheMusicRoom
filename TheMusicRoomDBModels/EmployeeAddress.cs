using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicRoomDBModels
{
    public class EmployeeAddress
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Street { get; set; }
        [Required, StringLength(30)]
        public string City { get; set; }
        [Required, StringLength(30)]
        public string State { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#####-####}")]
         public string Zip { get; set; }

    }
}
