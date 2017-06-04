using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Client
{
    internal class BaseRestSharp
    {

        public static RestClient Client => new RestClient("http://localhost:49987/");

        public static Task<IRestResponse> GetResponseContentAsync(RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            Client.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
