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
    public partial class frmProductManagement : Form
    {
        IProductRepository productRepository = new ProductRepository();
        BindingSource source;
        public frmProductManagement()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        

        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmProductDetail productDetail = new frmProductDetail
            {
                Text = "Add member",
                InsertOrUpdate = false,
                ProductRepository = productRepository
            };
            if (productDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        private void ClearText()
        {
            txtProductID.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtUnitInStock.Text = string.Empty;
        }
        public void LoadProductList()
        {
            var products =productRepository.GetProducts();
            try
            {
                source = new BindingSource();
                source.DataSource = products;
                txtProductID.DataBindings.Clear();
                txtCategoryID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitInStock.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtCategoryID.DataBindings.Add("Text", source, "CategoryID");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitInStock.DataBindings.Add("Text", source, "UnitsInStock");
                dgvProduct.DataSource = null;
                dgvProduct.DataSource = source;
                if (products.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Update car",
                InsertOrUpdate = true,
                ProductInfor = GetProductObject(),
                ProductRepository = productRepository
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }

        }
        private ProductObject GetProductObject()
        {
            ProductObject product = null;
            try
            {
                product = new ProductObject
                {
                    ProductID=int.Parse(txtProductID.Text),
                    CategoryID=int.Parse(txtCategoryID.Text),
                    ProductName=txtProductName.Text,
                    Weight=txtWeight.Text,
                    UnitPrice=decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock=int.Parse(txtUnitInStock.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return product;
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvProduct.CellDoubleClick += dgvProduct_CellDoubleClick;
        }

        private void frmProductManagement_Load_1(object sender, EventArgs e)
        {

        }
    }
}
