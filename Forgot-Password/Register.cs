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
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection("Data Source=sqlserver.dynamicdna.co.za;Initial Catalog=User-Management-System-Lerato;Persist Security Info=True;User ID=BBD;Password=***********");
        public Register()
        {
            InitializeComponent();
        }

        private void llLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (fname.Text.Length > 0 && email.Text.Length > 0 && id.Text.Length > 0 && department.Text.Length > 0 && username.Text.Length > 0 && password.Text.Length > 0) 
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO Registration VALUES('"+fname.Text+"', '"+email.Text+"', '"+id.Text+"','"+department.Text+"', '"+username.Text+"', '"+password.Text+"')",con);
                    try
                    {
                        com.ExecuteNonQuery();
                        MessageBox.Show("Successfully Registered");
                        fname.Clear();
                        email.Clear();
                        id.Clear();
                        department.Clear();
                        username.Clear();
                        password.Clear();
                        fname.Focus();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Failed to Register");
                    }
                    con.Close();
                }
                catch (Exception exx)
                {

                    MessageBox.Show("Failed to Connect to DB");
                }
            }
            else
            {
                MessageBox.Show("Fill in all entries!");
            }
        }
    }
}
