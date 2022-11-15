using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicRoomDBModels
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }
    }
}
