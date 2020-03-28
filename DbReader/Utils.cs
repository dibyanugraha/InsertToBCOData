using Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DbReader
{
    class AdoNetReader
    {
        public List<Item> GetNotYetInterfacedItem()
        {
            List<Item> hasilTarik = new List<Item>();
            var sqlselect = $"select * from dbo.ItemIwpi where interfaced = 0";

            string connectionString = @"server=ARIES-T450;Database=Testing;Trusted_Connection=True;";
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlselect, con);
                cmd.CommandType = CommandType.Text;  

                // Assumes that customerConnection is a valid SqlConnection object.
                var dataAdapter = new SqlDataAdapter(sqlselect, connectionString); 
                
                var items = new DataSet();  
                
                dataAdapter.Fill(items, "ItemIwpi");
                
                foreach (DataRow row in items.Tables["ItemIwpi"].Rows)  
                {
                    hasilTarik.Add(new Item
                    { 
                        No = row["No"].ToString(), 
                        Description = row["Description"].ToString(), 
                        // BaseUnitofMeasure = row["BaseUnitofMeasure"].ToString()
                    });
                }  

                return hasilTarik;
                // con.Open();
                // cmd.ExecuteReader();
                // con.Close();
            }
                
        }
    }
}