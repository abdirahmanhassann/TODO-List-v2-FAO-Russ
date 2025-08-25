using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2.Controllers
{
    internal class UpdateTasks
    {
        public static void UpdateTask(Tasks task)
        {
            string query = $"update tasks set description='{task.description}' where id={task.id}";
            string path = StaticPaths.dbPath();
            DataBase.ModifyTasks(query, path);
        }
    }
}
