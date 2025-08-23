using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_LIST_v2.Models
{
    internal static class StaticPaths
    {
        public static string dbPath() {
            return "Data Source=LAPTOP-KFNM01SG\\SQLEXPRESS;Initial Catalog=Project1;"
            + "Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}
