using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheMusicRoomDB;

namespace TheMusicRoom
{
    public class Program
    {
        static IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        public static IConfigurationRoot _configuration = builder.Build();
        public static readonly string _cnstr = _configuration["ConnectionStrings:MusicRoomDB"];
        static DbContextOptionsBuilder _optionsBuilder = new DbContextOptionsBuilder<TheMusicRoomDBContext>().UseSqlServer(_cnstr).EnableSensitiveDataLogging();

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();

            using (var context = new TheMusicRoomDBContext(_optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }
        
            

            

        }
    }
}