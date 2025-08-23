using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2.Controllers
{
    public static class SigninLogic
    {

        public static Signup SignIn(Signin SignIn) {
            string path = StaticPaths.dbPath();
            string SignInCheck = $"SELECT * FROM dbo.users where loginID='{SignIn.userName}' and password='{SignIn.password}'";

            Signup dbResults = DataBase.UserTable(SignInCheck, path);

            if (dbResults == null || string.IsNullOrEmpty(dbResults.userName))
            {
                MessageBox.Show("Wrong Username or Password");
                return null;
            }
            else
            {
                MessageBox.Show($"Welcome! {dbResults.name}");
                return dbResults;
            }

        }


    }
}
