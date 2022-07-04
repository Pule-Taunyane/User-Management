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
    public partial class Forgot_Password : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("");
        public Forgot_Password()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void btnShow_User_Name_Click(object sender, EventArgs e)
        {
            if (email.Text.Length > 0)
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SELECT Password FROM Registration WHERE Email = '" + email.Text + "'");

                    dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        MessageBox.Show("Your Password is : " + dr["Password"].ToString());
                    }

                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Failed to connect to DB");
                }
            }
            else
            {
                MessageBox.Show("Email is required to retrieve password!");
            }
        }
    }
}
