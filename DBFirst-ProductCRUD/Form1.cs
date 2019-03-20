using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFirst_ProductCRUD
{
    public partial class Form1 : Form
    {
        NorthwindEntities db = new NorthwindEntities();
        
        public Form1()
        {
            InitializeComponent();
        }
        public void FillSuplier()
        {
            var list = db.Suppliers.Select(x => new
            {
                x.SupplierID,
                x.CompanyName

            }).ToList();

            comboBox2.DisplayMember = "CompanyName";
            comboBox2.ValueMember = "SupplierID";
            comboBox2.DataSource = list;
        }

        public void FillCategory()
        {
            var list = db.Categories.Select(x => new
            {
                x.CategoryID,
                x.CategoryName

            }).ToList();

            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DataSource = list;

        }

        public void FillDataGridView() {

            dataGridView1.DataSource = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.Category.CategoryName,
                x.Supplier.CompanyName,
                x.UnitPrice,
                x.UnitsInStock


            }).ToList();

            //Arama yapılarak datagridview doldurma işlemi.
            var plist = db.Products.Where(x => x.ProductName.Contains(textBox4.Text)).Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.Category.CategoryName,
                x.Supplier.CompanyName,
                x.UnitPrice,
                x.UnitsInStock

            }).ToList();

            dataGridView1.DataSource = plist;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FillSuplier();
            FillCategory();
            FillDataGridView();
         
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product() // tek tek p.name p.added_date yapmadan bu şekildede yapabiliriz.
            {

                ProductName = textBox1.Text,
                CategoryID = Convert.ToInt32(comboBox1.SelectedValue),
                UnitsInStock =Convert.ToInt16(textBox2.Text),
                SupplierID = Convert.ToInt32(comboBox2.SelectedValue),
                UnitPrice =Convert.ToDecimal(textBox3.Text)

            };

            db.Products.Add(newProduct);
            db.SaveChanges();

            FillDataGridView();
        }
        int secid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secid = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Product p = db.Products.Where(x => x.ProductID == secid).FirstOrDefault();
            textBox1.Text = p.ProductName.ToString();
            textBox2.Text = p.UnitsInStock.ToString();
            textBox3.Text = p.UnitPrice.ToString();
            comboBox1.SelectedValue = p.CategoryID;
            comboBox2.SelectedValue = p.SupplierID;
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var a = db.Products.Where(x => x.ProductID == secid);
            foreach (var urun in a)
            {
                urun.ProductName = textBox1.Text;
                urun.UnitsInStock =Convert.ToInt16(textBox2.Text);
                urun.UnitPrice = Convert.ToDecimal(textBox3.Text);
                urun.CategoryID = Convert.ToInt32(comboBox1.SelectedValue);
                urun.SupplierID = Convert.ToInt32(comboBox2.SelectedValue);
            }
            db.SaveChanges();
            FillDataGridView();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Referential Integritiy Koruma yapıyor.FK olanları silemiyoruz oku araştır.
            Product urun = db.Products.Where(x => x.ProductID == secid).FirstOrDefault();
            db.Products.Remove(urun);
            db.SaveChanges();
            FillDataGridView();
        }
    }
}
