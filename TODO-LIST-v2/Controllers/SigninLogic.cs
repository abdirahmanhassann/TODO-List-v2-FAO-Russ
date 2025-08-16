using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2.Controllers
{
    public static class SigninLogic
    {

        public static void SignIn(Signin SignIn) {
            string str = "Data Source=LAPTOP-KFNM01SG\\SQLEXPRESS;Initial Catalog=Project1;"
+ "Integrated Security=True;TrustServerCertificate=True;";
            
            string SignInCheck = $"SELECT * FROM dbo.users where loginID='{SignIn.userName}' and password='{SignIn.password}'";

            List<List<object>> dbResults= DataBase.CreateCommand(SignInCheck,str);
            if (dbResults.Count == 0)
            {
                MessageBox.Show("Wrong Username or Password");
            }
            else
            {
                MessageBox.Show($"Welcome! {dbResults[0][2]}");
            }
                Console.WriteLine(dbResults);
        }


    }
}
