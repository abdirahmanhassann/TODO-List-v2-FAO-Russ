using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TODO_LIST_v2.Controllers;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2
{
    public partial class Form2 : Form
    {
    
        public Tasks task= new Tasks();
        public Form2(Signup user)
        {
            InitializeComponent();
            task.userID = user.ID;    
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            task.description = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            task.title = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTask newTask = new AddTask();
            newTask.AddTasks(task);
        }
    }
}
