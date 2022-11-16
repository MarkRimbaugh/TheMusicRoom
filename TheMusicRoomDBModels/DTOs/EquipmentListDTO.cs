using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicRoomDBModels.DTOs
{
    public class EquipmentListDTO
    {
        public int TypeId { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Condition { get; set; }
    }
}
