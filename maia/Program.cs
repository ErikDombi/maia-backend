using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace maia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!File.Exists("patients.json"))
                File.Create("patients.json").Close();
            if (File.ReadAllBytes("patients.json").Length == 0)
                File.WriteAllText("patients.json", "[]");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseUrls("http://localhost:8432");
                });
    }
}
