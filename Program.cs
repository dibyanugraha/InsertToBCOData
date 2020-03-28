using System;
using System.Net;
using HttpClient.Utils;
using System.Text.Json;
using DbReader;

namespace TestInsertToBCOData
{
    class Program
    {
        static void Main(string[] args)
        {
            // ambil data dan tampung dari database
            AdoNetReader reader = new AdoNetReader();
            var itemYgAkanDikirim = reader.GetNotYetInterfacedItem();

            foreach (var item in itemYgAkanDikirim)
            {
                // send ke BC
                SendData data = new SendData();

                var hasil = data.SendItem(item);
                var errorBody = JsonSerializer.Deserialize<ErrorBC>(hasil.Content.ReadAsStringAsync().Result);

                // tangkap hasil
                switch (hasil.StatusCode)
                {
                    case HttpStatusCode.Created:
                        Console.Out.WriteLine(hasil.StatusCode + ". " + item.No + " berhasil diinterface");
                        break;
                    case HttpStatusCode.BadRequest:
                        Console.Out.WriteLine(hasil.StatusCode + ". " + item.No + " gagal diinterface.\nError code: " + errorBody.error.code + "\nError Message: " + errorBody.error.message);
                        break;
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.BadGateway:
                    case HttpStatusCode.GatewayTimeout:
                        Console.Out.WriteLine(hasil.StatusCode + ". " + item.No + " gagal diinterface.\nError code: " + errorBody.error.code + "\nError Message: " + errorBody.error.message);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
