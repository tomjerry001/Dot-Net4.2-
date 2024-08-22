using SqlServerConnectionLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClinicalMangementSystem.Repository
{
    public class LoginRepositoryImpl:ILoginRepository

    {
        //Connection String

        string connString = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        public async Task<int> GetRoleIdAsync(string userName, string password)
        {
            int roleId = 0;
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetUserNamePassword", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Username", userName);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlParameter roleIdParam = new SqlParameter("@RoleId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    /*
                 * sp_GetUserNamePassword is primarily performing a query
                 * that returns data via an output parameter
                 * rather than returning a result set of rows    
                 * 
                 * output Parameters : Even though ExecuteNonQueryAsync() does not return any rows,
                 * it can still interact with output parameters or return values set
                 * by the stored procedure
                 */

                    command.Parameters.Add(roleIdParam);
                    await command.ExecuteNonQueryAsync();

                    if (command.Parameters["@RoleId"].Value != DBNull.Value)
                    {
                        roleId = Convert.ToInt32(roleIdParam.Value);
                    }


                    return roleId;
                }
            }

        }
    }
}
