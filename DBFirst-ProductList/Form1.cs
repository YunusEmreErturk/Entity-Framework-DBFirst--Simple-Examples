using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFirst_ProductList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();

            dataGridView1.DataSource = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.Category.CategoryName

            }).ToList();  
            
        }
    }
}
