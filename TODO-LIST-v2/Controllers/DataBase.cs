using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Net.Http.Headers;
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



        public static Signup UserTable(string queryString, string connectionString)
        {
            DataTable dataTable = new DataTable();
            Signup results= new Signup();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, connection);
                dataAdapter.Fill(dataTable);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                results.ID = Convert.ToInt16(row["id"]);
                results.userName = row["loginID"].ToString();
                results.name = row["name"].ToString();
                results.password = row["password"].ToString();
            }
            return results;
        }
        public static bool ModifyTasks(string queryString, string connectionString)
        { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public static List<Tasks> GetTasks(string queryString, string connectionString)
        {
            List<Tasks> tasks = new List<Tasks>();
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, connection);
                dataAdapter.Fill(dataTable);

            } 
            foreach(DataRow row in dataTable.Rows)
            {
                Tasks task = new Tasks();
                task.title = row["title"].ToString();
                task.description = row["description"].ToString();
                task.isCompleted = Convert.ToInt16(row["isCompleted"]);
                task.userID = Convert.ToInt16(row["userID"]);
                tasks.Add(task);
            }
            return tasks;
        }
    }
}

