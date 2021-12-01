using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp.Product
{
    public partial class frmProductDetail : Form
    {
        public frmProductDetail()
        {
            InitializeComponent();
        }
        public IProductRepository ProductRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public ProductObject ProductInfor { get; set; }
        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtProductID.Text = ProductInfor.ProductID.ToString();
                txtCategoryID.Text = ProductInfor.CategoryID.ToString();
                txtProductName.Text = ProductInfor.ProductName;
                txtWeight.Text = ProductInfor.Weight;
                txtUnitPrice.Text = ProductInfor.UnitPrice.ToString();
                txtUnitInStock.Text = ProductInfor.UnitsInStock.ToString();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new ProductObject
                {
                    ProductID = int.Parse(txtProductID.Text),
                   CategoryID=int.Parse(txtCategoryID.Text),
                   ProductName=txtProductName.Text,
                   Weight=txtWeight.Text,
                   UnitPrice=decimal.Parse(txtUnitPrice.Text),
                   UnitsInStock=int.Parse(txtUnitInStock.Text)
                };
                if (InsertOrUpdate == false)
                {
                    ProductRepository.InsertProduct(product);
                }
                else
                {
                    ProductRepository.UpdateProduct(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new product" : "Update product");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
