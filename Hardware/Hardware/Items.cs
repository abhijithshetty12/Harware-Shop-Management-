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
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            Con = new Functions();
            GetCategories();

        }
        Functions Con;
        private void GetCategories()
        {
            string Query = "Select * from CategoryTb1";
            Cat.ValueMember = Con.GetData(Query).Columns["CatCode"].ToString();
            Cat.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            Cat.DataSource = Con.GetData(Query);
        }
        public void ShowItems()
        {
            string Query = "Select * from Item";
            ItemsList.DataSource = Con.GetData(Query);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Items_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (Itname.Text == "" || Cat.SelectedIndex == -1 || Price.Text == "" || Stock.Text == "" || manufacturer.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Name = Itname.Text;
                    string cat = Cat.SelectedValue.ToString();
                    string price = Price.Text;
                    string stock = Stock.Text;
                    string man = manufacturer.Text;

                    string Query = "insert into Item values('{0}',{1},{2},{3},'{4}')";
                    Query = string.Format(Query, Name, cat, price, stock, man);
                    Con.Setdata(Query);
                    ShowItems();
                    MessageBox.Show("Item Added!!");
                    Itname.Text = "";
                    Cat.SelectedIndex = -1;
                    Price.Text = "";
                    Stock.Text = "";
                    manufacturer.Text = "";



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;

        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Itname.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            Cat.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            Price.Text = ItemsList.SelectedRows[0].Cells[3].Value.ToString();
            Stock.Text = ItemsList.SelectedRows[0].Cells[4].Value.ToString();
            manufacturer.Text = ItemsList.SelectedRows[0].Cells[5].Value.ToString();
            if (Itname.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
            this.Hide();
        }
    } }
    
    

