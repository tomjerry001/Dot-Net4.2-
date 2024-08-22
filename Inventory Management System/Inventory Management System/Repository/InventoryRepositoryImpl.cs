using Inventory_Management_System.Model;
using SqlServerConnectionLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Repository
{
    public class InventoryRepositoryImpl : IInventoryRepository
    {
        // connection string
        string winconnString = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;
        public async Task AddInventoryAsync(Inventory inventory) 
        {
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {

                //Perform Insert Query
                string query = "INSERT INTO Inventory(ProductName,Category,Quantity,UnitPrice)" +
                    "VALUES(@PdtNam,@Cat,@Quan,@UniPr)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PdtNam", inventory.ProductName);
                    command.Parameters.AddWithValue("@Cat", inventory.Category);
                    command.Parameters.AddWithValue("@Quan", inventory.Quantity);
                    command.Parameters.AddWithValue("@UniPr", inventory.UnitPrice);

                    // await conn.OpenAsync();
                    await command.ExecuteNonQueryAsync();  

                }
            }
        }
    }
}
