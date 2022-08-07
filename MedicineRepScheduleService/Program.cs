using MedicineRepScheduleRepository.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineRepScheduleService
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
                var contextOptions = new DbContextOptionsBuilder<MedicineReprScheduleContext>().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=MedicineReprSchedule; integrated security=true").Options;
                var dbContext = new MedicineReprScheduleContext(contextOptions);
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = JObject.Parse(message);
                var type = ea.RoutingKey;
                if (type == "MedicineStock.add")
                {
                    dbContext.MedicineStocks.Add(new MedicineStock() { MedicineId = data["MedicineId"].Value<string>(), MedincineName = data["MedicineName"].Value<string>() });
                    dbContext.SaveChanges();
                }
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
                        Console.WriteLine("Delete the schedule for this medicine first");
                    }
                }
            };
            channel.BasicConsume(queue: "MedicineStokS.RepSvc", autoAck: true, consumer: consumer);
        }
    }
}
