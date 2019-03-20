using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFirst_CategoryList
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
            // Tüm Kategori tablosunun getirilmesi. 1.YOL

            //dataGridView1.DataSource= db.Categories.Select(x => x).ToList(); 1.YOL
            //dataGridView1.DataSource = db.Categories.ToList(); 2.YOL



            //1.YOL
            //Kategori tablosundaki categoryid ve name getirilmesi
            //dataGridView1.DataSource= db.Categories.Select(x => new
            //{
            //    x.CategoryID,
            //    x.CategoryName
            //}).ToList();

            //2.YOL
            //dataGridView1.DataSource = db.Categories.Select(x => x).ToList();
            //dataGridView1.Columns["Description"].Visible = false;
            //dataGridView1.Columns["Picture"].Visible = false;






        }
    }
}
