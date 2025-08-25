using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TODO_LIST_v2.Models
{
    public class Tasks
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int isCompleted { get; set; }
        public int userID {get; set; }
    }
}
