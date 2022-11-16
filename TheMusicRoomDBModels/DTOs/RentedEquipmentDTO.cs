using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicRoomDBModels.DTOs
{
    public class RentedEquipmentDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Customer { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CustomerId { get; set; }
        public int EquipmentId { get; set; }
        public int EmployeeId { get; set; }
    }
}
