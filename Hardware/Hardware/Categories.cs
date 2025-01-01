using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;


namespace Hardware
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
            Con = new Functions();
        }
        Functions Con;
        public void ShowCategories()
        {
            string Query = "Select *from CategoryTb1";
            CategoryList.DataSource = Con.GetData(Query);
        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (Catname.Text == "" )
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Name = Catname.Text;
                   
                    string Query = "insert into CategoryTb1 values('{0}')";
                    Query = string.Format(Query,Name);
                    Con.Setdata(Query);
                    ShowCategories();
                    MessageBox.Show("Category Added!!");
                    Catname.Text = "";
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;
        private void CategoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Catname.Text = CategoryList.SelectedRows[0].Cells[1].Value.ToString();
            
            if (Catname.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoryList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {

            if (Catname.Text == "" )
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Name = Catname.Text;
                   
                    string Query = "update into CategoryTb1 set Name='{0}'where Catcode={1})";
                    Query = string.Format(Query, Name, Key);
                    Con.Setdata(Query);
                    ShowCategories();
                    MessageBox.Show("Customer Updated!!");
                    Catname.Text = "";
                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (Catname.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Name = Catname.Text;
                    
                    string Query = "delete from CategoryTb1 where CatCode={0})";
                    Query = string.Format(Query, Key);
                    Con.Setdata(Query);
                    ShowCategories();
                    MessageBox.Show("Customer Deleted!!");
                    Catname.Text = "";
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
