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
            var city = new City(token, cityId, "EKB");
            Task.Run(() => city.Add()).Wait();

            //var workshopId = Guid.NewGuid();
            //var workshop = new Workshop(workshopId, "FirstWS", cityId);
            //Task.Run(() => workshop.Add()).Wait();

            //var jobId = Guid.NewGuid();
            //var job = new Job(jobId, "FirstWS", ,);
            //Task.Run(() => job.Add()).Wait();


        }
    }
}
