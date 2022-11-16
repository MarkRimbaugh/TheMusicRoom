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
            Console.WriteLine("3. Return an instrument");
            Console.WriteLine("4. Quit");
            Console.WriteLine(new string('*', 35));
            int selection = GetValidInput(4);
            if (selection == 4) return;
            switch (selection)
            {
                case 1:
                    ListInstruments();
                    break;
                case 2:
                    RentInstrument();
                    break;
                case 3:
                    ReturnInstrument();
                    break;
                default:
                    break;
            }
        }

        private static void ReturnInstrument()
        {
            using (var context = new TheMusicRoomDBContext(_optionsBuilder.Options))
            {
                var equipmentList = new List<RentedEquipmentDTO>(context.RentedEquipmentDTOs
                    .FromSqlRaw("SELECT * FROM vwRentedEquipment").ToList());
                Console.WriteLine(new string('*', 100));
                foreach (var item in equipmentList)
                {
                    Console.WriteLine($"{item.Id} | {item.Model} | Rented to: {item.Customer} | On: {item.RentalDate.ToShortTimeString()}) | Due: {item.DueDate.ToShortDateString()}");
                }
                Console.WriteLine(new string('*', 100));
                Console.Write("Choose an instrument to return by ID:");
                var choice = GetValidInput(equipmentList.Max(x => x.Id));

                var model = equipmentList.SingleOrDefault(x => x.Id == choice).Model;
                var customer = equipmentList.SingleOrDefault(x => x.Id == choice).Customer;
                var selectedEquipmentId = equipmentList.SingleOrDefault(x => x.Id == choice).EquipmentId;

                Console.WriteLine($"{customer} is returning {model}. Is that correct?");
                bool confirmed = ValidateChoice();

                // if confirmed, set complete the rental and set the equipment availability to true
                if (confirmed)
                {
                    var rentalReturn = context.EquipmentRental.SingleOrDefault(x => x.Id == choice);
                    context.Remove(rentalReturn);
                    context.SaveChanges();
                    context.Equipment.SingleOrDefault(x => x.Id == selectedEquipmentId).IsAvailable = true;
                    Console.WriteLine("\nReturn was successful!");
                }

                // otherwise, return to main menu
                else
                {
                    Console.WriteLine("Transaction canceled, returning to main menu");
                    MainMenu();
                }
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

                // Display instruments and prompt to select one for rent
                var equipmentList = new List<EquipmentListDTO>(context.EquipmentListDTOs
                    .FromSqlRaw("SELECT * FROM vwEquipmentList WHERE TypeId = " + choice).ToList());
                foreach (var item in equipmentList)
                {
                    Console.WriteLine($"{item.Id} | {item.Type} | {item.Brand} | {item.Model} | Condition: {(Condition)item.Condition} | Available: {item.IsAvailable}");
                }
                Console.WriteLine(new string('*', 75));
                Console.Write("Choose an instrument by ID:");
                choice = GetValidInput(equipmentList.Max(x => x.Id));
                var selectedEquipmentId = choice;

                // Ensure item is available. If so, proceed. Otherwise, return to main menu
                if (context.Equipment.SingleOrDefault(x => x.Id == selectedEquipmentId).IsAvailable == false)
                {
                    Console.WriteLine("Sorry, that item is unavailable.");
                    MainMenu();
                }
                // Display customers and prompt to select renter
                var customerList = new List<CustomerListDTO>(context.CustomerListDTOs
                    .FromSqlRaw("SELECT * FROM vwCustomerList").ToList());
                foreach (var c in customerList)
                {
                    Console.WriteLine($"{c.Id} | {c.Name} | {c.Address} | {c.Phone}");
                }
                Console.Write("Select customer by ID:");
                choice = GetValidInput(customerList.Max(x => x.Id));
                var selectedCustomerId = choice;

                // Display employees and prompt to select employee
                var employeeList = new List<EmployeeListDTO>(context.EmployeeListDTOs
                    .FromSqlRaw("SELECT * FROM vwEmployeeList").ToList());
                foreach (var e in employeeList)
                {
                    Console.WriteLine($"{e.Id} | {e.Name} | {(Position)e.Position}");
                }
                Console.Write("Select employee by ID:");
                choice = GetValidInput(employeeList.Max(x => x.Id));
                var selectedEmployeeId = choice;

                // Display a recap to the user and ask for validation
                var customer = customerList.SingleOrDefault(x => x.Id == selectedCustomerId).Name;
                var equipment = equipmentList.SingleOrDefault(x => x.Id == selectedEquipmentId).Model;
                var employee = employeeList.SingleOrDefault(x => x.Id == selectedEmployeeId).Name;

                Console.WriteLine($"{employee} will rent the following to {customer}: {equipment}. ");
                Console.Write("Is this correct? y/n -> ");
                bool confirmRental = ValidateChoice();

                // if yes, add rental transaction and set the equipment availability to false
                if(confirmRental)
                {
                    var rental = new EquipmentRental(selectedCustomerId, selectedEmployeeId, selectedEquipmentId);
                    context.Equipment.SingleOrDefault(x => x.Id == selectedEquipmentId).IsAvailable = false;
                    context.Add(rental);
                    context.SaveChanges();

                    Console.WriteLine("\nSuccess!");
                    MainMenu();
                }
                // otherwise, return to main menu
                Console.WriteLine("\nTransaction canceled, returning to main menu.");
                MainMenu();
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