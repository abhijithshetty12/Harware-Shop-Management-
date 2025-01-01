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


namespace Hardware
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            
        }
        Functions Con;
        public void ShowCustomer()
        {
            string Query = "Select *from CustomerTb1";
            CustomersList.DataSource = Con.GetData(Query);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (Cname.Text == "" || Cgender.SelectedIndex == -1 || Cphone.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Name = Cname.Text;
                    string Gender = Cgender.SelectedItem.ToString();
                    string Phone = Cphone.Text;
                    string Query = "insert into CustomerTb1 values('{0}','{1}','{2}' )";
                    Query = string.Format(Query, Name, Gender, Phone);
                    Con.Setdata(Query);
                    ShowCustomer();
                    MessageBox.Show("Customer Added!!");
                    Cname.Text = "";
                    Cphone.Text = "";
                    Cgender.SelectedIndex = -1;

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (Cname.Text == "" || Cgender.SelectedIndex == -1 || Cphone.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Name = Cname.Text;
                    string Gender = Cgender.SelectedItem.ToString();
                    string Phone = Cphone.Text;
                    string Query = "delete from CustomerTb1 where CustCode={0})";
                    Query = string.Format(Query, Key);
                    Con.Setdata(Query);
                    ShowCustomer();
                    MessageBox.Show("Customer Deleted!!");
                    Cname.Text = "";
                    Cphone.Text = "";
                    Cgender.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;
        private void Editbtn_Click(object sender, EventArgs e)
        {
          
            if (Cname.Text == "" || Cgender.SelectedIndex == -1 || Cphone.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Name = Cname.Text;
                    string Gender = Cgender.SelectedItem.ToString();
                    string Phone = Cphone.Text;
                    string Query = "update into CustomerTb1 set Name='{0}',Gender={1}',Phone='{2}' where CustCode={0})";
                    Query = string.Format(Query, Name, Gender, Phone,Key);
                    Con.Setdata(Query);
                    ShowCustomer();
                    MessageBox.Show("Customer Updated!!");
                    Cname.Text = "";
                    Cphone.Text = "";
                    Cgender.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void CustomerLists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cname.Text= CustomersList.SelectedRows[0].Cells[1].Value.ToString();
            Cgender.Text = CustomersList.SelectedRows[0].Cells[2].Value.ToString();
            Cphone.Text= CustomersList.SelectedRows[0].Cells[3].Value.ToString();
            if (Cname.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
   
}
