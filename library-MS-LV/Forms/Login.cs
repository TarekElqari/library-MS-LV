using library_MS_LV.Classes;
using library_MS_LV.DatabaseConf;
using System;
using System.Linq;
using System.Windows.Forms;

namespace library_MS_LV.Forms
{
    public partial class Login : Form
    {
        private int loginAttempts = 3;

        public Login()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            button1.Click += button1_Click;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome wl = new Welcome();
            wl.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new LibraryContext())
            {
                string username = textBox1.Text;
                string enteredPassword = textBox2.Text;
                string hashedEnteredPassword = Admin.HashPassword(enteredPassword);

                var admin = context.Admins.FirstOrDefault(a => a.Username == username);
            

                if (admin != null && admin.Password == hashedEnteredPassword)
                {
                    Dashboard dash = new Dashboard();
                    dash.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show($"Invalid username or password. Attempts left: {--loginAttempts}");

                    if (loginAttempts == 0)
                    {
                        MessageBox.Show("Too many failed attempts. Application will exit.");
                        Application.Exit();
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
