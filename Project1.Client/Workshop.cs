using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Client
{
    internal class Workshop : StandardEntity
    {
        private readonly string _name;
        private readonly Guid _id;
        private readonly Guid _cityId;
        public Workshop(string accessToken, Guid id, string name, Guid cityId) : base(accessToken)
        {
            _name = name;
            _id = id;
            _cityId = cityId;
        }
        public override async Task Add()
        {
            var request = new RestRequest($"api/workshop", Method.POST);
            request.AddParameter("Authorization", string.Format("Bearer " + AccessToken), ParameterType.HttpHeader);
            request.AddParameter("Id", _id);
            request.AddParameter("Name", _name);
            request.AddParameter("CityId", _cityId);   
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
