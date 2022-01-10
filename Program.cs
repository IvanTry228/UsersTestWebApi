using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersTestApi;
using UsersTestApi.OperationLogicImplement;

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
