using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using AcornHealth.Api;

namespace AcornHealth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "sql.acorn";
            var sqlData = File.ReadAllText(path);
            Environment.SetEnvironmentVariable("sql", sqlData);

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
