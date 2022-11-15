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
                var cnstr = config["ConnectionStrings:MusicRoomDB"];
                var options = new DbContextOptionsBuilder<TheMusicRoomDBContext>().UseSqlServer(cnstr);
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(x =>
            {
                x.HasData(
                new Customer() { Id = 1, First = "Mark", Middle = "Evan", Last = "Rimbaugh", AddressId = 1, PhoneId = 1 }
                );
            });

            modelBuilder.Entity<CustomerAddress>(x =>
            {
                x.HasData(
                    new CustomerAddress() { Id = 1, City = "Hope Mills", Street = "1915 Teesdale Drive", Zip = "28348-0000" }
                    );
            });

            modelBuilder.Entity<CustomerPhone>(x =>
            {
                x.HasData(
                    new CustomerPhone() { Id = 1, Number = "574-367-1006", Type = PhoneType.Mobile }
                    );
            });

            modelBuilder.Entity<Employee>(x =>
            {
                x.HasData(
                    new Employee() { Id = 1, First = "Patrick", Middle = "", Last = "Larson", Position = Position.Manager, EmployeeAddressId = 1, EmployeePhoneId = 1 }
                    );
            });

            modelBuilder.Entity<EmployeeAddress>(x =>
            {
                x.HasData(
                    new EmployeeAddress() { Id = 1, Street = "305 S. 29th Street", City = "South Bend", State = "Indiana", Zip = "46514-0000" });
            });

            modelBuilder.Entity<EmployeePhone>(x =>
            {
                x.HasData(
                    new EmployeePhone() { Id = 1, Number = "219-872-4312", Type = PhoneType.Office });
            });

            modelBuilder.Entity<EquipmentType>(x =>
            {
                x.HasData(
                    new EquipmentType() { Id = 1, Type = "Guitar" });
            });

            modelBuilder.Entity<Brand>(x =>
            {
                x.HasData(
                    new Brand() { Id = 1, Name = "Fender" });
            });

            modelBuilder.Entity<Model>(x =>
            {
                x.HasData(
                    new Model() { Id = 1, BrandId = 1, Name = "Stratocaster" });
            });

            modelBuilder.Entity<Equipment>(x =>
            {
                x.HasData(
                    new Equipment() { Id = 1, BrandId = 1, ModelId = 1, EquipmentTypeId = 1, Condition = Condition.New });
            });
        }
    }
}

