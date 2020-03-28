using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Models;
namespace HttpClient.Utils
{
    public class SendData
    {
        private string username = "admin";
        private string password = "e4+1IDevw8mIVlwi89xNENUFnnVFAvvNsqJQ14hSASo=";

        public HttpResponseMessage SendItem(Item item)
        {
            Console.WriteLine("Inserting Data");

            using (var client = new System.Net.Http.HttpClient())
            {
                var userPassInBytes = System.Text.ASCIIEncoding.ASCII.GetBytes($"{username}:{password}");
                var encodedUserPass = Convert.ToBase64String(userPassInBytes);
                client.BaseAddress = new Uri(@"https://api.businesscentral.dynamics.com/v2.0/9fa7c13f-5edb-418a-858d-e4384253eb21/Sandbox/ODataV4/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedUserPass);

                var jsonData = JsonSerializer.Serialize(item);
                HttpContent httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = 
                    client.PostAsync(
                        @"https://api.businesscentral.dynamics.com/v2.0/9fa7c13f-5edb-418a-858d-e4384253eb21/Sandbox/ODataV4/Company('CRONUS AU')/MasterItem", 
                        httpContent).Result;
                
                return response;
            }
        }
    }
}