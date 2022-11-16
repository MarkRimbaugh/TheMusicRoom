using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicRoomDBModels;


namespace TheMusicRoomDBModels
{
    public class Rental
    {        
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime RentDate { get; set; }


        public virtual List<Customer> Customers { get; set; }

        public Rental() { }

        public Rental(int equipmentId, int customerId, int employeeId)
        {
            
            EquipmentId = equipmentId;
            CustomerId = customerId;
            EquipmentId = employeeId;
            RentDate = DateTime.Now;
        }
    }
}
