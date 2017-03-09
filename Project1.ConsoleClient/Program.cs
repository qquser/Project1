﻿using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace Project1.ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Console.WriteLine(ApiTest(new Guid("5dd11855-cb5d-4bc9-85d8-9e517e0c5b25"))); 
            ProjectRename(new Guid("5dd11855-cb5d-4bc9-85d8-9e517e0c5b25"));
            Console.ReadKey();
        }

        private static void ProjectRename(Guid id)
        {
            var client = new RestClient("http://localhost:49987/");
            var request = new RestRequest($"api/project/{id.ToString()}/name", Method.POST);
            request.AddParameter("NewName", "NewProject");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            Console.WriteLine(response.Content);
            Console.ReadKey();
        }

        public static string ApiTest(Guid id)
        {
            var client = new RestClient("http://localhost:49987/");
            var request = new RestRequest("api/values/1", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            return response.Content;
            //var jsonResponse = JsonConvert.DeserializeObject<string>(response.Content);

        }

        public static  Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
        static void PostCustomerAsync()
        {
            var restClient = new RestClient("http://localhost:49722/")
            {
                //Authenticator = new NtlmAuthenticator()
            };
            var request = new RestRequest("api/values/5", Method.GET);
            //request.AddParameter("Id", Guid.NewGuid());
            //request.AddParameter("Name", "NewOne");
            //var response = restClient.(request);
            //Console.WriteLine(response.Content);
            Console.ReadKey();
        }

    }

    public static class Calculator
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int Multiply(int x, int y) => x * y;
        public static int Divide(int x, int y) => x / y;
    }
}