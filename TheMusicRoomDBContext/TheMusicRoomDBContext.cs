using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheMusicRoomDBModels;

namespace TheMusicRoomDB
{
    public class TheMusicRoomDBContext : DbContext
    {
        // Database tables
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPhone> CustomerPhones { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePhone> EmployeePhones { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }


        public TheMusicRoomDBContext() { }

        public TheMusicRoomDBContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var config = builder.Build();
                var cnstr = config["ConnectionStrings:TheMusicRoomDB"];
                var options = new DbContextOptionsBuilder<TheMusicRoomDBContext>().UseSqlServer(cnstr);
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(x =>
            {
                x.HasData(
                new Customer() { Id = 1, First = "Mark", Middle = "", Last = "Rimbaugh", AddressId = 1, PhoneId = 1 },
                new Customer() { Id = 2, First = "Joshua", Middle = "", Last = "Benson", AddressId = 2, PhoneId = 2 },
                new Customer() { Id = 3, First = "Drew", Middle = "", Last = "Nelson", AddressId = 3, PhoneId = 3 }, 
                new Customer() { Id = 4, First = "Rico", Middle = "", Last = "Rodriguez", AddressId = 4, PhoneId = 4 },
                new Customer() { Id = 5, First = "Jackson", Middle = "", Last = "Freiburg", AddressId = 5, PhoneId = 5 }
                );
            });

            modelBuilder.Entity<CustomerAddress>(x =>
            {
                x.HasData(
                    new CustomerAddress() { Id = 1, City = "Hope Mills", Street = "892 Some Road", State = "North Carolina", Zip = "12345-0000" },
                    new CustomerAddress() { Id = 2, City = "Fayetteville", Street = "429 That Avenue", State = "North Carolina", Zip = "67891-0000" },
                    new CustomerAddress() { Id = 3, City = "South Bend", Street = "403 S. 29th Street", State = "Indiana", Zip = "89172-0000" },
                    new CustomerAddress() { Id = 4, City = "Anchorage", Street = "123 Fake Street", State = "Alaska", Zip = "68981-0000" },
                    new CustomerAddress() { Id = 5, City = "Leesville", Street = "456 Another Street", State = "Louisiana", Zip = "01597-0000" }
                    );
            });

            modelBuilder.Entity<CustomerPhone>(x =>
            {
                x.HasData(
                    new CustomerPhone() { Id = 1, Number = "123-456-7890", Type = PhoneType.Mobile },
                    new CustomerPhone() { Id = 2, Number = "234-567-8901", Type = PhoneType.Office},
                    new CustomerPhone() { Id = 3, Number = "345-678-9012", Type = PhoneType.Home}, 
                    new CustomerPhone() { Id = 4, Number = "456-789-0123", Type = PhoneType.Mobile },
                    new CustomerPhone() { Id = 5, Number = "567-890-1234", Type = PhoneType.Mobile }
                    );
            });

            modelBuilder.Entity<Employee>(x =>
            {
                x.HasData(
                    new Employee() { Id = 1, First = "Brian", Middle = "", Last = "Gorman", Position = Position.Manager, EmployeeAddressId = 1, EmployeePhoneId = 1 },
                    new Employee() { Id = 2, First = "Patrick", Middle = "", Last = "Larson", Position = Position.Associate, EmployeeAddressId = 2, EmployeePhoneId = 2 },
                    new Employee() { Id = 3, First = "Ahmad", Middle = "Rohin", Last = "Qaderyan", Position = Position.Associate, EmployeeAddressId = 3, EmployeePhoneId = 3 },
                    new Employee() { Id = 4, First = "Mursal", Middle = "", Last = "Qaderyan", Position = Position.Associate, EmployeeAddressId = 4, EmployeePhoneId = 4 },
                    new Employee() { Id = 5, First = "Alex", Middle = "", Last = "Robinson", Position = Position.Associate, EmployeeAddressId = 5, EmployeePhoneId = 5 }
                    );
            });

            modelBuilder.Entity<EmployeeAddress>(x =>
            {
                x.HasData(
                    new EmployeeAddress() { Id = 1, Street = "123 Sample Street", City = "Fayetteville", State = "North Carolina", Zip = "46514-0000" },
                    new EmployeeAddress() { Id = 2, Street = "249 MadeUp Road", City = "Fayetteville", State = "North Carolina", Zip = "46514-0000" },
                    new EmployeeAddress() { Id = 3, Street = "903 Imaginary Circle", City = "Raeford", State = "North Carolina", Zip = "46514-0000" },
                    new EmployeeAddress() { Id = 4, Street = "191 Nonexistent Lane", City = "Sanford", State = "North Carolina", Zip = "46514-0000" },
                    new EmployeeAddress() { Id = 5, Street = "902 Fake Street", City = "Southern Pines", State = "North Carolina", Zip = "46514-0000" });
            });

            modelBuilder.Entity<EmployeePhone>(x =>
            {
                x.HasData(
                    new EmployeePhone() { Id = 1, Number = "123-456-7890", Type = PhoneType.Office },
                    new EmployeePhone() { Id = 2, Number = "234-567-8901", Type = PhoneType.Office },
                    new EmployeePhone() { Id = 3, Number = "345-678-9012", Type = PhoneType.Office },
                    new EmployeePhone() { Id = 4, Number = "456-789-0123", Type = PhoneType.Office },
                    new EmployeePhone() { Id = 5, Number = "567-890-1234", Type = PhoneType.Office });
            });

            modelBuilder.Entity<EquipmentType>(x =>
            {
                x.HasData(
                    new EquipmentType() { Id = 1, Type = "Guitar" },
                    new EquipmentType() { Id = 2, Type = "Keyboard"},
                    new EquipmentType() { Id = 3, Type = "Drums"});
            });

            modelBuilder.Entity<Brand>(x =>
            {
                x.HasData(
                    new Brand() { Id = 1, Name = "Fender" },
                    new Brand() { Id = 2, Name = "Gibson"},
                    new Brand() { Id = 3, Name = "Line 6"},
                    new Brand() { Id = 4, Name = "Taylor"},
                    new Brand() { Id = 5, Name = "Yamaha"},
                    new Brand() { Id = 6, Name = "Korg"},
                    new Brand() { Id = 7, Name = "Casio"},
                    new Brand() { Id = 8, Name = "Tama"});
            });

            modelBuilder.Entity<Model>(x =>
            {
                x.HasData(
                    new Model() { Id = 1, BrandId = 1, Name = "Stratocaster" },
                    new Model() { Id = 2, BrandId = 1, Name = "Telecaster" },
                    new Model() { Id = 3, BrandId = 1, Name = "Acoustasonic" },
                    new Model() { Id = 4, BrandId = 2, Name = "Les Paul" },
                    new Model() { Id = 5, BrandId = 2, Name = "SG" },
                    new Model() { Id = 6, BrandId = 3, Name = "JTV-89F" },
                    new Model() { Id = 7, BrandId = 4, Name = "214ce" },
                    new Model() { Id = 8, BrandId = 5, Name = "DGX670B" },
                    new Model() { Id = 9, BrandId = 6, Name = "i3 Arranger" },
                    new Model() { Id = 10, BrandId = 7, Name = "WK-7600" },
                    new Model() { Id = 11, BrandId = 8, Name = "Superstar Classic" });
            });

            modelBuilder.Entity<Equipment>(x =>
            {
                x.HasData(
                    new Equipment() { Id = 1, ModelId = 1, EquipmentTypeId = 1, Condition = Condition.New },
                    new Equipment() { Id = 2, ModelId = 1, EquipmentTypeId = 1,Condition = Condition.Good},
                    new Equipment() { Id = 3, ModelId = 7, EquipmentTypeId = 2, Condition = Condition.Good},
                    new Equipment() { Id = 4, ModelId = 8, EquipmentTypeId = 3, Condition = Condition.Fair},
                    new Equipment() { Id = 5, ModelId = 10, EquipmentTypeId = 2, Condition = Condition.Unknown});
            });
        }
    }
}

