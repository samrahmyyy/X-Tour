using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace X_Tour
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=X-Tour_Users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "Select * FROM tbl_suers WHERE username= '" + txtusername.Text + "' and password = '" + txtpassword.Text + "'";
            cmd = new OleDbCommand(login , con);
            OleDbDataReader dr = cmd.ExecuteReader();
            

            if (dr.Read() == true)
            {
                new Main_Application().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invaliad Username or Password , Please Try Again" , "Login Faild" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtusername.Text = "";
                txtpassword.Text = "";
                txtusername.Focus();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtusername.Focus();
        }

        private void checkbxshowpas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxshowpas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                
            }
            else
            {
                txtpassword.PasswordChar = '•';
                
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }
    }
}
