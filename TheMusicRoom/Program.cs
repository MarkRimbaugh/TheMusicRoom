using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using TheMusicRoomDB;
using TheMusicRoomDBModels;
using TheMusicRoomDBModels.DTOs;

namespace TheMusicRoom
{
    public class Program
    {
        static IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        public static IConfigurationRoot _configuration = builder.Build();
        public static readonly string _cnstr = _configuration["ConnectionStrings:TheMusicRoomDB"];
        public static DbContextOptionsBuilder _optionsBuilder = new DbContextOptionsBuilder<TheMusicRoomDBContext>().UseSqlServer(_cnstr);

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
            
            MainMenu();

        }
        public static int GetValidInput(int max)
        {
            bool validInput = false;
            int selection = 0;
            while (!validInput)
            {
                Console.Write("\nYour selection: ");
                string input = Console.ReadLine();
                validInput = Int32.TryParse(input, out selection) && (selection > 0 && selection <= max);
                if (!validInput)
                {
                    Console.WriteLine("Bad input, please try again");
                    continue;
                }
            }
            return selection;
        }

        
        
        private static void MainMenu()
        {
            Console.WriteLine(new string('*', 35));
            Console.WriteLine("Welcome to the Music Room!");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Browse our instruments");
            Console.WriteLine("2. Rent an instrument");
            Console.WriteLine("3. Manage customer data");
            Console.WriteLine(new string('*', 35));
            int selection = GetValidInput(3);
            switch (selection)
            {
                case 1:
                    ListInstruments();
                    break;
                case 2:
                    RentInstrument();
                    break;
                case 3:
                    //ManageCustomerData();
                    break;
                default:
                    break;
            }
        }

        public static void RentInstrument()
        {
            using (var context = new TheMusicRoomDBContext(_optionsBuilder.Options))
            {
                Console.WriteLine("\nWhat type of instrument are you looking for?");
                Console.WriteLine("1. Guitar");
                Console.WriteLine("2. Keyboards");
                Console.WriteLine("3. Drums");
                Console.WriteLine("4. Return to main menu");
                int choice = GetValidInput(4);
                if (choice == 4) return;
                var equipmentList = new List<EquipmentListDTO>(context.EquipmentListDTOs
                    .FromSqlRaw("SELECT * FROM vwEquipmentList WHERE TypeId = " + choice).ToList());
                foreach (var item in equipmentList)
                {
                    Console.WriteLine($"{item.Type} | {item.Brand} | {item.Model} | Condition: {(Condition)item.Condition}");
                }
                Console.WriteLine(new string('*', 50));
                Console.Write("Choose an instrument by ID -> ");
                choice = GetValidInput(equipmentList.Count);
            }
        }
        

        public static void ListInstruments()
        {
            bool returnToMainMenu = false;

            while (!returnToMainMenu)
            {
                Console.WriteLine("\nWhat type of instrument are you looking for?");
                Console.WriteLine("1. Guitar");
                Console.WriteLine("2. Keyboards");
                Console.WriteLine("3. Drums");
                Console.WriteLine("4. Return to main menu");
                using (var context = new TheMusicRoomDBContext(_optionsBuilder.Options))
                {
                    int choice = GetValidInput(4);
                    if (choice == 4) return;

                    var equipmentList = new List<EquipmentListDTO>(context.EquipmentListDTOs
                        .FromSqlRaw("SELECT * FROM vwEquipmentList WHERE TypeId = " + choice).ToList());
                    Console.WriteLine(new string('*', 50));
                    foreach (var item in equipmentList)
                    {
                        Console.WriteLine($"{item.Type} | {item.Brand} | {item.Model} | Condition: {(Condition)item.Condition}");
                    }
                    Console.WriteLine(new string('*', 50));
                }
            }
        }
        
        

        /*private static void RentInstrument()
        {
            using (var context = new TheMusicRoomDBContext(_optionsBuilder.Options))
            {
                var customerList = context.Customers.ToList();
                foreach (var customer in customerList)
                {
                    Console.WriteLine(customer);
                }
                Console.Write("\nChoose a customer by ID:");

                int selection = GetValidInput(customerList.Count);
                var selectedCustomer = context.Customers.SingleOrDefault(customer => customer.Id == selection);

                Console.WriteLine("What kind of instrument do you want?");
                Console.WriteLine("1. Guitar");
                Console.WriteLine("2. Keyboard");
                Console.WriteLine("3. Drums");
                selection = GetValidInput(3);
                Equipment selectedEquipment = null;
                switch (selection)
                {
                    case 1:
                        var equipmentList = context.Equipment.ToList();
                        foreach (var instrument in equipmentList)
                        {
                            Console.WriteLine(instrument);
                        }
                        Console.Write("\nChoose an instrument by ID");
                        selection = GetValidInput(equipmentList.Count);
                        selectedEquipment = context.Equipment.SingleOrDefault(x => x.Id == selection);
                        break;
                }
                Console.WriteLine("Selected customer: " + selectedCustomer);
                Console.WriteLine("Selected instrument: " + selectedEquipment);

                bool confirmed = ValidateChoice();
                if (confirmed)
                {
                    CompleteRentalTransaction(context, selectedCustomer, selectedInstrument, confirmed);
                }
                else
                {
                    Console.WriteLine("\nTransaction canceled, returning to main menu.");
                    MainMenu();
                }
            }
        }*/
        /*private static void CompleteRentalTransaction(MusicRoomDBContext context, Customer selectedCustomer, Instrument selectedInstrument, bool confirmed)
        {
            // create association

            var rental = context.EquipmentRentals;

            EquipmentRental equipmentRental = new EquipmentRental();
            equipmentRental.CustomerId = selectedCustomer.Id;
            equipmentRental.InstrumentId = selectedInstrument.Id;
            rental.Add(equipmentRental);

            context.SaveChanges();

        }*/
        private static bool ValidateChoice()
        {
            bool confirmed = false;
            Console.Write("Continue? y/n -> ");

            while (!confirmed)
            {
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.Write("Please enter y or n -> ");
                }
            }
            return false;
        }
        
    }
}