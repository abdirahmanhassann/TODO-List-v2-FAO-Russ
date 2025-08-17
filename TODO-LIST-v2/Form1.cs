using TODO_LIST_v2.Controllers;
using TODO_LIST_v2.Models;

namespace TODO_LIST_v2
{
    public partial class Form1 : Form
    {
        //private string signInUsername = "";
        //private string signInPassword = "";
        //private string SignUpUserName = "";
        //private string SignUpPassword = "";
        //private string SignUpRePassword = "";
        public Signin Signin = new Signin();
        public Signup Signup = new Signup();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Signin.userName = textBox1.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Signin.password = textBox2.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Signup.userName = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Signup.password = textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           bool isSignedIn=SigninLogic.SignIn(Signin);
            if (isSignedIn)
            {
                Form2 form2 = new Form2(Signin);
                form2.Show();
                this.Hide();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Signup.name = textBox6.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isSignedUp =SignUpLogic.SignUp(Signup);
            if (isSignedUp)
            {
                Form2 form2 = new Form2(Signup);
                form2.Show();
                this.Hide();
            }

        }
    }
}
