using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheMusicRoomDBModels
{
    public enum Condition { New, Good, Fair, Poor, Unknown}

    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EquipmentTypeId { get; set; }
        
        [Required]
        public int ModelId { get; set; }
        [Required]
        public Condition Condition { get; set; }
        public bool IsAvailable { get; set; } = true;

        public virtual EquipmentType Type { get; set; }
        public virtual Model Model { get; set; }

        public virtual List<EquipmentRental> EquipmentRentals { get; set; } = new List<EquipmentRental>();

    }
}
