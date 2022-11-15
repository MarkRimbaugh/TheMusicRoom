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
    }
}