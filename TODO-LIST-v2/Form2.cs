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

        public Tasks task = new Tasks();
        List<Tasks> tasks = new List<Tasks>();

        public Form2(Signup user)
        {
            InitializeComponent();
            task.userID = user.ID;
            tasks = DataBase.GetTasks($"select * from tasks where userID='{task.userID}'", StaticPaths.dbPath());
            listBox.Items.Clear();
            foreach (var t in tasks)
            {
                listBox.Items.Add(t.title);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            listBox.Enabled = true;
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
            tasks = DataBase.GetTasks($"select * from tasks where userID='{task.userID}'", StaticPaths.dbPath());
            listBox.Items.Clear();
            foreach (var t in tasks)
            {
                listBox.Items.Add(t.title);
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index < 0 || index >= tasks.Count) return;
            textBox3.Text = tasks[index].description;
            button2.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                button2.Enabled = false;
                return;
            }

            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateTasks.UpdateTask(new Tasks { id = tasks[listBox.SelectedIndex].id, description = textBox3.Text });
            tasks = DataBase.GetTasks($"select * from tasks where userID='{task.userID}'", StaticPaths.dbPath());
            button2.Enabled = false;
            textBox3.ReadOnly = true;

        }
    }
}
