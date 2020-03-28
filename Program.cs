using System;
using System.Threading.Tasks;
using Simple.OData.Client;
using System.Net;
using HttpClient.Utils;
using Models;

namespace TestInsertToBCOData
{
    class Program
    {
        static void Main(string[] args)
        {
            // NetworkCredential myCred = new NetworkCredential(
            //     "admin","e4+1IDevw8mIVlwi89xNENUFnnVFAvvNsqJQ14hSASo=","");
            
            // CredentialCache myCache = new CredentialCache();
            
            // myCache.Add(new Uri(@"https://api.businesscentral.dynamics.com"), "Basic", myCred);
            
            // var odataSetting = new ODataClientSettings();
            // odataSetting.Credentials = myCache;
            // odataSetting.BaseUri = new Uri(@"https://api.businesscentral.dynamics.com/v2.0/9fa7c13f-5edb-418a-858d-e4384253eb21/Sandbox/ODataV4/");
            // odataSetting.IgnoreResourceNotFoundException = true;
            // odataSetting.OnTrace = (x, y) => Console.WriteLine(string.Format(x, y));
            // var client = new ODataClient(odataSetting);
            
            // var packages = await client
            // .For("Company")
            // .Key("CRONUS AU")
            // .Set(new {No = "TestAries02", Description = "Item Coba 02" })
            //     .InsertEntryAsync(true);

            SendData data = new SendData();

            var insertedItem = new Item { No = "Test Aries 04", Description = "Test 04"};

            var hasil = data.SendItem(insertedItem);

            Console.Out.WriteLine(hasil.StatusCode);
        }
    }
}
