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
//using System.Net;
//using System.Net.Mail;

namespace X_Tour
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();   
        }
        OleDbConnection con = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=X-Tour_Users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

       // int vcode = 1000;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" && txtpassword.Text == "" && txtcompassword.Text == "" && txtemail.Text == "")
            {
                MessageBox.Show ("Username & Password field are empty" , "Registration Failed" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ( txtpassword.Text == txtcompassword.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_suers VALUES ('" + txtusername.Text + "' , '" + txtpassword.Text + "' , '" + txtemail.Text + "')";
                cmd = new OleDbCommand(register , con);
                cmd.ExecuteNonQuery ();
                con.Close();

                txtusername.Text = "";
                txtpassword.Text = "";
                txtcompassword.Text = "";
                txtemail.Text = "";

                MessageBox.Show ("Your Account has been successfully created" , "Registeration Sucess" , MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show ("Password doesn't match , please Re-enter" , "Registration Failed" , MessageBoxButtons .OK, MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtcompassword.Text = "";
                txtpassword.Focus ();
            }
           //* timevcode.Stop ();//*
           // string to, from, pass, mail;
            //to = txtemail.Text;
            //from = "samrahmyy@gmail.com"; // Your Gmail
            //mail = vcode.ToString ();
            //pass = ""; // Your Gmail Password
            //MailMessage message = new MailMessage ();
            //message.To.Add (to);
            //message.From = new MailAddress (from);
            //message.Subject = "X-Tour - Verfication Code"; // Mail Subject
            //SmtpClient smtp = new SmtpClient ("smtp.gmail.com");
            //smtp.EnableSsl = true;
            //smtp.Port = 587;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Credentials = new NetworkCredential(from, pass);
            //try
            //{
              //  smtp.Send (message);
                //MessageBox.Show ("Verfication Code Send Successful! Gonna Mail Box to Check it" ,"Information" , MessageBoxButtons.OK , MessageBoxIcon.Information);
               
           // }
            //catch (Exception ex)
            //{
              //  MessageBox.Show(ex.Message);
            //}




            //new Code_Verfication().Show();
            //this.Hide();
        }

        private void checkbxshowpas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxshowpas.Checked) {
                txtpassword.PasswordChar = '\0';
                txtcompassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
                txtcompassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtcompassword.Text = "";
            txtemail.Text = "";
            txtusername.Focus ();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new Form_Login().Show();
            this.Hide();
        }

       // private void timevcode_Tick(object sender, EventArgs e)
        //{
            //vcode += 10;
            //if (vcode == 9999)
            //{
             //   vcode = 1000;
            //}
        //}
    }
}
