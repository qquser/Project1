using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Client
{
    internal class City : StandardEntity
    {
        private readonly string _name;
        private readonly string _accessToken;
        private readonly Guid _id;
        public City(string accessToken, Guid id, string name)
        {
            _accessToken = accessToken;
            _name = name;
            _id = id;
        }

        public override async Task Add()
        {
            var request = new RestRequest($"api/city", Method.POST);
            request.AddParameter("Authorization", string.Format("Bearer " + _accessToken),
            ParameterType.HttpHeader);
            request.AddParameter("Id", _id);
            request.AddParameter("Name", _name);
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
