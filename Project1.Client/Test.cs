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
            var cityId = Guid.NewGuid();
            var city = new City(token, cityId, "NY2");
            Task.Run(() => city.Add()).Wait();

            var workshopId = Guid.NewGuid();
            var workshop = new Workshop(token, workshopId, "FirstWS", cityId);
            Task.Run(() => workshop.Add()).Wait();

            //var jobId = Guid.NewGuid();
            //var job = new Job(token, jobId, "FirstWS", userId, workshopId);
            //Task.Run(() => job.Add()).Wait();


        }
    }
}
