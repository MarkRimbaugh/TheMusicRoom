using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicRoomDB;
using TheMusicRoomDBModels;

namespace TheMusicRoom
{
    public class DbServices
    {
        public static void EnterNewRental(Rental rental)
        {
            using (var context = new TheMusicRoomDBContext(Program._optionsBuilder.Options))
            {
                context.Rentals.Add(rental);
                context.SaveChanges();
            }
        }
    }
}
