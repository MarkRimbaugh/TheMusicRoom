using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Numerics;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using TheMusicRoomDB;
using TheMusicRoomDBModels;
using TheMusicRoomDBModels.DTOs;

namespace TheMusicRoom
{
    public class Program
    {
        public static IConfigurationBuilder builder = new ConfigurationBuilder()
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

        public static void ReturnInstrument()
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
                    context.Equipment.SingleOrDefault(x => x.Id == selectedEquipmentId).IsAvailable = true;
                    context.SaveChanges();

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
        private static void MainMenu()
        {
            Console.WriteLine(new string('*', 35));
            Console.WriteLine("Welcome to the Music Room!");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Browse our instruments");
            Console.WriteLine("2. Rent an instrument");
            Console.WriteLine("3. Return an instrument");
            Console.WriteLine("4. Add new customer");
            Console.WriteLine("5. Modify a customer");
            Console.WriteLine("6. Add or edit employee");
            Console.WriteLine("7. Quit");
            Console.WriteLine(new string('*', 35));
            int selection = GetValidInput(7);
            if (selection == 7) return;
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
                case 4:
                    AddNewCustomer();
                    break;
                case 5:
                    EditCustomer();
                    break;
                default:
                    break;
            }
        }

        private static void EditCustomer()
        {
            using (var context = new TheMusicRoomDBContext(_optionsBuilder.Options))
            {
                var customerList = context.Customers.ToList();
                foreach (var c in customerList)
                {
                    Console.WriteLine($"Id: {c.Id} | Name: {c.Last}, {c.First} | Street: {c.Street} | City: {c.City} | State: {c.State} | Phone: {c.PhoneNumber}");
                }
                Console.WriteLine("\nChoose a customer to modify by Id:");
                int choice = GetValidInput(customerList.Max(x => x.Id));
                var selectedCustomer = context.Customers.SingleOrDefault(x => x.Id == choice);
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("1. First name");
                Console.WriteLine("2. Middle name");
                Console.WriteLine("3. Last name");
                Console.WriteLine("4. Street");
                Console.WriteLine("5. City");
                Console.WriteLine("6. State");
                Console.WriteLine("7. Phone");
                choice = GetValidInput(7);
                string newData = string.Empty;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Current first name -> {selectedCustomer.First}");
                        Console.Write($"What is the new first name? -> ");
                        newData = Console.ReadLine();
                        selectedCustomer.First = newData;
                        context.SaveChanges();
                        Console.WriteLine("\nCustomer successfully modified! Returning to main menu");
                        break;
                    case 2:
                        Console.WriteLine($"Current middle name -> {selectedCustomer.Middle}");
                        Console.Write($"What is the new middle name? -> ");
                        newData = Console.ReadLine();
                        selectedCustomer.Middle = newData;
                        context.SaveChanges();
                        Console.WriteLine("\nCustomer successfully modified! Returning to main menu");
                        break;
                    case 3:
                        Console.WriteLine($"Current last name -> {selectedCustomer.Last}");
                        Console.Write($"What is the new last name? -> ");
                        newData = Console.ReadLine();
                        selectedCustomer.Last = newData;
                        context.SaveChanges();
                        Console.WriteLine("\nCustomer successfully modified! Returning to main menu");
                        break;
                    case 4:
                        Console.WriteLine($"Current street address -> {selectedCustomer.Street}");
                        Console.Write($"What is the new street address? -> ");
                        newData = Console.ReadLine();
                        selectedCustomer.Street = newData;
                        context.SaveChanges();
                        Console.WriteLine("\nCustomer successfully modified! Returning to main menu");
                        break;
                    case 5:
                        Console.WriteLine($"Current city -> {selectedCustomer.City}");
                        Console.Write($"What is the new city? -> ");
                        newData = Console.ReadLine();
                        selectedCustomer.City = newData;
                        context.SaveChanges();
                        Console.WriteLine("\nCustomer successfully modified! Returning to main menu");
                        break;
                    case 6:
                        Console.WriteLine($"Current state -> {selectedCustomer.State}");
                        Console.Write($"What is the new state? -> ");
                        newData = Console.ReadLine();
                        selectedCustomer.State = newData;
                        context.SaveChanges();
                        Console.WriteLine("\nCustomer successfully modified! Returning to main menu");
                        break;
                    case 7:
                        Console.WriteLine($"Current phone number -> {selectedCustomer.PhoneNumber}");
                        Console.Write($"What is the new phone number? -> ");
                        newData = Console.ReadLine();
                        selectedCustomer.PhoneNumber = newData;
                        context.SaveChanges();
                        Console.WriteLine("\nCustomer successfully modified! Returning to main menu");
                        break;
                }
                MainMenu();
            }
        }

        public static void AddNewCustomer()
        {
            using (var context = new TheMusicRoomDBContext(_optionsBuilder.Options))
            {
                Console.WriteLine(new string('*', 35));
                Console.WriteLine("Enter new customer information:");
                Console.Write("Last Name -> ");
                string lastName = Console.ReadLine();
                Console.Write("FirstName -> ");
                string firstName = Console.ReadLine();
                Console.Write("Middle name -> ");
                string middleName = Console.ReadLine();
                Console.Write("Street -> ");
                string street = Console.ReadLine();
                Console.Write("City -> ");
                string city = Console.ReadLine();
                Console.Write("State -> ");
                string state = Console.ReadLine();
                Console.Write("Zip -> ");
                string zip = Console.ReadLine();
                Console.Write("Phone -> ");
                string phone = Console.ReadLine();
                var newCustomer = new Customer(firstName, middleName, lastName, street, city, state, zip, phone);

                Console.Write($"{firstName} {middleName} {lastName}, Address: {street} {city}, {state}, Phone: {phone}. Add this customer? y/n");
                bool choice = ValidateChoice();
                if (!choice)
                {
                    Console.WriteLine("\nAction canceled, returning to main menu.");
                    MainMenu();
                }

                context.Customers.Add(newCustomer);
                context.SaveChanges();
                Console.WriteLine("Cusomer succesfully added! Returning to main menu");
                MainMenu();
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
                if (confirmRental)
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
                        Console.WriteLine($"{item.Type} | {item.Brand} | {item.Model} | Condition: {(Condition)item.Condition} | Available: {item.IsAvailable}");
                    }
                    Console.WriteLine(new string('*', 50));
                }
            }
        }
    }
}
