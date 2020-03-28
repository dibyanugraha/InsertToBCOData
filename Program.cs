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
            SendData data = new SendData();

            var insertedItem = new Item { No = "Test Aries 04", Description = "Test 04"};

            var hasil = data.SendItem(insertedItem);

            Console.Out.WriteLine(hasil.StatusCode);

            switch (hasil.StatusCode)
            {
                case HttpStatusCode.Created:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.GatewayTimeout:
                    break;
                default:
                    break;
            }
        }
    }
}
