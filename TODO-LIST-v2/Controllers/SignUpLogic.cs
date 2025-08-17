using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2.Controllers
{
    public static class SignUpLogic
    {
        public static bool SignUp(Signup SignUp) {
            string str = "Data Source=LAPTOP-KFNM01SG\\SQLEXPRESS;Initial Catalog=Project1;"
            + "Integrated Security=True;TrustServerCertificate=True;";
            string duplicateLoginIDCheck = $"SELECT * FROM dbo.users where loginID='{SignUp.userName}'";
            List<List<object>> dbResults = DataBase.CreateCommand(duplicateLoginIDCheck, str);
            if (dbResults.Count == 0)
            {
                InsertNewUser(SignUp);
                MessageBox.Show($"Welcome {SignUp.name}!");
                return true;
            }
            else
            {
                MessageBox.Show($"Username already exists, Please pick a unique username");
                return false;
            }
            Console.WriteLine(dbResults);
        }



        public static void InsertNewUser(Signup SignUp)
        {
            string str = "Data Source=LAPTOP-KFNM01SG\\SQLEXPRESS;Initial Catalog=Project1;"
            + "Integrated Security=True;TrustServerCertificate=True;";
            string duplicateLoginIDCheck = $"INSERT into dbo.users (loginID,name,password) " +
            $"values ('{SignUp.userName}','{SignUp.name}','{SignUp.password}')";
            List<List<object>> dbResults = DataBase.CreateCommand(duplicateLoginIDCheck, str);

        }

    }
}

