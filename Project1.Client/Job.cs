using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Client
{
    internal class Job : StandardEntity
    {
        private readonly string _name;
        private readonly Guid _id;
        private readonly Guid _userId;
        private readonly Guid _workshopId;
        public Job(string accessToken, Guid id, string name, Guid userId, Guid workshopId) : base(accessToken)
        {
            _name = name;
            _id = id;
            _userId = userId;
            _workshopId = workshopId;
        }

        public override async Task Add()
        {
            var request = new RestRequest($"api/job", Method.POST);
            request.AddParameter("Authorization", string.Format("Bearer " + AccessToken), ParameterType.HttpHeader);
            request.AddParameter("JobId", _id);
            request.AddParameter("Name", _name);
            request.AddParameter("UserId", _userId);
            request.AddParameter("WorkshopId", _workshopId);
            var response = new RestResponse();
            response = await GetResponseContentAsync(request) as RestResponse;

            Console.WriteLine(response.Content);
        }

        public override async Task MakeInActive()
        {
            throw new NotImplementedException();
        }

        public override async Task Rename()
        {
            throw new NotImplementedException();
        }
    }
}
