using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2.Controllers
{
    public static class SignUpLogic
    {
        public static Signup SignUp(Signup SignUp) {
            string duplicateLoginIDCheck = $"SELECT * FROM dbo.users where loginID='{SignUp.userName}'";
            string path = StaticPaths.dbPath();
            Signup dbResults = DataBase.UserTable(duplicateLoginIDCheck,path);
            if (dbResults == null || string.IsNullOrEmpty(dbResults.userName))
            {
                Signup results= InsertNewUser(SignUp);

                string getNewUser = $"SELECT * FROM dbo.users where loginID='{SignUp.userName}'";
                Signup newUser = DataBase.UserTable(getNewUser, path);
                MessageBox.Show($"Welcome {SignUp.name}!");
                return newUser;
            }
            else
            {
                MessageBox.Show($"Username already exists, Please pick a unique username");
                return null;
            }
        }


        public static Signup InsertNewUser(Signup SignUp)
        {
            string path= StaticPaths.dbPath();
            string insertIntoNewUser = $"INSERT into dbo.users (loginID,name,password) " +
            $"values ('{SignUp.userName}','{SignUp.name}','{SignUp.password}')";
            Signup dbResults = DataBase.UserTable(insertIntoNewUser, path);
            return dbResults;
        }

    }
}

