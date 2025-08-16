using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2.Controllers
{
    public static class DataBase
    {
        public static void DataBaseQuery()
        {

        }



        public static List<List<object>> CreateCommand(string queryString, string connectionString)
        {
            var results = new List<List<object>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new List<object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader[i]);
                        }
                        results.Add(row);
                    }
                }
                command.ExecuteNonQuery();
            }
            return results;
        }

    }
}

