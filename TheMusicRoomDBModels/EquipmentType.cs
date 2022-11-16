using System.ComponentModel.DataAnnotations;

namespace TheMusicRoomDBModels
{
    public class EquipmentType
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Type { get; set; }

        

        

    }
}