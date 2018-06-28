using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using sandwich_shack.Models;

namespace sandwich_shack
{
    public class Program
    {
        // public static List<Sandwich> Sandwiches = new List<Sandwich>()
        // {
        //     new Sandwich(6.99m, "Breakfast Sandwich", "Breakfast put nicely together.",new List<string>(){
        //             "Eggs",
        //             "Bacon",
        //             "Wheat Bread"
        //         }),
        //     new Sandwich(9.99m, "Meat Me", "Great sandwich for meat lovers to meat.", new List<string>(){
        //             "Bacon",
        //             "Beef",
        //             "Sausage",
        //             "Jalapeno Bread"

        //         }),
        //     new Sandwich(7.99m, "Honey Bacon Club", "Made simple.", new List<string>(){
        //             "Bacon",
        //             "Honey Ham",
        //             "White Bread",
                    
        //         })
        // };
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
