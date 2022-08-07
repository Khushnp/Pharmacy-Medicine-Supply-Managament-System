using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PharmacyMediSupplyRepository.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyMediSupplyService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListenForIntegrationEvents();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void ListenForIntegrationEvents()
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (mode, ea) =>
            {
                var contextOptions = new DbContextOptionsBuilder<PharmacySupplyContext>().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=PharmacySupply; integrated security=true").Options;
                var dbContext = new PharmacySupplyContext(contextOptions);
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = JObject.Parse(message);
                var type = ea.RoutingKey;
                /*if (type == "schedule.add")
                {*/
                    if (type == "MedicineStock.add")
                    {
                        dbContext.MedicineStocks.Add(new MedicineStock()
                        {
                            MedicineId = data["MedicineId"].Value<string>(),
                            MedicineName = data["MedicineName"].Value<string>(),
                            NumberOfTabletsInStock = data["NumberOfTabletsInStock"].Value<int>()
                        });
                        dbContext.SaveChanges();
                    }

                    
                //}
                /*if (type == "schedule.delete")
                {
                    try
                    {
                        MedicineStock med2del = dbContext.MedicineStocks.First(b => b.MedicineId == data["MedicineId"].Value<string>());
                        dbContext.MedicineStocks.Remove(med2del);
                        dbContext.SaveChanges();
                    }
                    catch
                    {
                        Console.WriteLine("Delete the medicine of this schedule first");
                    }
                }*/
                if (type == "MedicineStock.delete")
                {
                    try
                    {
                        MedicineStock med2del = dbContext.MedicineStocks.First(c => c.MedicineId == data["MedicineId"].Value<string>());
                        dbContext.MedicineStocks.Remove(med2del);
                        dbContext.SaveChanges();
                    }
                    catch
                    {
                        Console.WriteLine("Delete the Demand for this medicine first");
                    }
                }
            };
            channel.BasicConsume(queue: "schedule.pharmacysupplysvc", autoAck: true, consumer: consumer);
        }
    }
}
