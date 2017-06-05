using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Client
{
    internal class Test
    {
        public static void CreateCityWorkshopAndJobTest(string token)
        {
            //var cityId = Guid.NewGuid();
            //var city = new City(token, cityId, "NY3");
            //Task.Run(() => city.Add()).Wait();

            //var workshopId = Guid.NewGuid();
            //var workshop = new Workshop(token, workshopId, "WS2", cityId);
            //Task.Run(() => workshop.Add()).Wait();

            var jobId = Guid.NewGuid();
            var job = new Job(token, jobId, "FirstJob", new Guid("183D4679-499B-F461-9446-DCA9A46025E6"), new Guid("FD8813BB-7F51-447B-B94E-7142CC9A6CCB"));
            Task.Run(() => job.Add()).Wait();


        }
    }
}
