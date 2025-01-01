using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = Uname.Text;
            string password = Upass.Text;
            if(username ==""||password=="")
            {
                MessageBox.Show("Missing  Data");
            }else if (username =="Admin"&&password=="Admin")
            {
                Items items = new Items();
                items.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(" Wrong Username or Password");
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            Upass.Text = "";
        }
    }
}
