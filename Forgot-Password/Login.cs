using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Forgot_Password
{
    public partial class Login : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("");
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register rg = new Register();
            rg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forgot_Password fg = new Forgot_Password();
            fg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text.Length > 0 && password.Text.Length > 0)
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SELECT UserName, Password FROM Registration WHERE Email = '" + username.Text + "', AND Password =  '"+password.Text+"'");

                    dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        Menu mu = new Menu();
                        mu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect credentials, Please enter correct details!");
                        username.Clear();
                        password.Clear();
                        username.Focus();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Failed to connect to DB");
                }
                MessageBox.Show("Successfully registered");
            }
            else
            {
                MessageBox.Show("Fill in all entries!");
            }
        }
    }
}
