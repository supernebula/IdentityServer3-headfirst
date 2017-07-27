using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewIdSClientMini
{
    class Program
    {
        static void Main(string[] args)
        {
            //var token = GetUserToken();
            //CallApi(token);
            CallApiNotAuth();

            Console.ReadKey();
        }

        static TokenResponse GetUserToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "carbon",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "api1").Result;
        }



        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            var apiResult = client.GetStringAsync("http://localhost:14869/api/newtest").GetAwaiter().GetResult();
            Console.WriteLine(apiResult);
        }


        static void CallApiNotAuth()
        {
            var client = new HttpClient();
            var apiResult = client.GetStringAsync("http://localhost:14869/api/newtest").GetAwaiter().GetResult();
            Console.WriteLine(apiResult);
        }
    }
}
