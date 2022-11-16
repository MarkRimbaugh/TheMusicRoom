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
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }

        public Customer()
        {

        }

        public Customer(string first, string middle, string last, string street, string city, string state, string zip, string phone)
        {
            First = first;
            Middle = middle;
            Last = last;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phone;
        }

        //public virtual CustomerAddress Address { get; set; }
        //public virtual CustomerPhone Phone { get; set; }

        public virtual List<Rental> Rentals { get; set; }

    }
}
