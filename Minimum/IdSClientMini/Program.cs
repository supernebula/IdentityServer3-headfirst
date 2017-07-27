using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;

namespace IdSClientMini
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = GetClientToken();
            CallApi(token);

            Console.ReadKey();
        }

        static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("api1").GetAwaiter().GetResult();
        }


        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            var apiResult = client.GetStringAsync("http://localhost:14869/api/test").GetAwaiter().GetResult();
            Console.WriteLine(apiResult);
        }

    }
}
