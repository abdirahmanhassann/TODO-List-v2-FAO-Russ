using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2.Controllers
{
    public class AddTask
    {
        public void AddTasks(Tasks task) {
            //need to add ID prop to user model so I can inner join tasks to users via UserID
            string query = $"insert into tasks (title,description,userID) values ('{task.title}','{task.description}',{task.userID})";
            string path = StaticPaths.dbPath();
            DataBase.ModifyTasks(query, path);
        }
    }
}
