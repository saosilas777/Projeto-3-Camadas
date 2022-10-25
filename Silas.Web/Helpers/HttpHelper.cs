using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Silas.Web.Helpers
{
    public static class HttpHelper
    {
        public static dynamic POST(string url, object obj)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", obj, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static dynamic GET(string url)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
            
        }

    }
}
