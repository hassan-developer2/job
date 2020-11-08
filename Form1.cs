using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace job
{
    public partial class Form1 : Form
    {
        public static int setValurForId;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            if (txtUserName.Text==""| txtPassword.Text=="")
            {
                MessageBox.Show("please enter the username or password");
                txtUserName.Focus();
                return;
            }
            username = txtUserName.Text;
            password = txtPassword.Text;
            if (IsUserValid(username,password))
            {
                this.Hide();
                MDIParent mDIParent = new MDIParent();
                mDIParent.Show();
            }
            else
            {
                MessageBox.Show(txtUserName.Text + " is invalid");
                return;
            }

        }

        private Boolean IsUserValid(string username, string password)
        {
            DataClassesJobDataContext db = new DataClassesJobDataContext();
            var queryResults = from u in db.Users
                               where u.UserName == username && u.Password == password
                               select u;
            if (queryResults.Any())
            {
                setValurForId = queryResults.FirstOrDefault().id;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
