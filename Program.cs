using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UsersTestWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //fast fake fil:
            //UsersFastFakeFiller.CallFillRandomElementToDb(MainDataHolder.Instance.AppDbContextHolder.UsersItems);
            //MainDataHolder.Instance.AppDbContextHolder.SaveChanges();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
