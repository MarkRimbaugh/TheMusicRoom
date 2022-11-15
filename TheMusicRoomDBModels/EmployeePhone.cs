using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicRoomDBModels
{

    public class EmployeePhone
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public string Number { get; set; }
        [Required]
        public PhoneType Type { get; set; }
    }
}
