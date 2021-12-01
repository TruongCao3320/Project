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

namespace SalesApp.OderDetail
{
    public partial class frmShowOrderDetailManagement : Form
    {
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        BindingSource source;
     
        public frmShowOrderDetailManagement()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrderDetailList();
        }
        public void LoadOrderDetailList()
        {
            var orders = orderDetailRepository.GetOrderDetail();
            try
            {
                source = new BindingSource();
                source.DataSource = orders;
                txtOrderID.DataBindings.Clear();
                txtProductID.DataBindings.Clear();
                txtQuantity.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderID");
                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtQuantity.DataBindings.Add("Text", source, "Quantity");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtDiscount.DataBindings.Add("Text", source, "Discount");


                dgvOrderDetail.DataSource = null;
                dgvOrderDetail.DataSource = source;
                if (orders.Count() == 0)
                {
                    ClearText();
                    //btnDelete.Enabled = false;
                }
                else
                {
                    //btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Order list");
            }
        }
        private void ClearText()
        {
            txtProductID.Text = string.Empty;
            txtOrderID.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDiscount.Text = string.Empty;
           txtUnitPrice.Text = string.Empty;
           // dtpShippedDate.Value = DateTime.Today;
        }

        private void frmShowOrderDetailManagement_Load(object sender, EventArgs e)
        {
            List<OrderDetailObject> detailList = new List<OrderDetailObject>();
            var orders = orderDetailRepository.GetOrderDetail();
            foreach (OrderDetailObject o in orders)
            {
               foreach(OrderObject i in MemberSalesManagement.orderID)
                {
                    if (o.OrderID.ToString().Equals(i.OrderID.ToString()))
                    {
                        detailList.Add(o);
                    }
                }
            }
            //MessageBox.Show(detailList.Count().ToString());
            try
            {
                source = new BindingSource();
                source.DataSource = detailList;
                txtOrderID.DataBindings.Clear();
                txtProductID.DataBindings.Clear();
                txtQuantity.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderID");
                txtProductID.DataBindings.Add("Text", source, "ProductID");
                txtQuantity.DataBindings.Add("Text", source, "Quantity");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtDiscount.DataBindings.Add("Text", source, "Discount");


                dgvOrderDetail.DataSource = null;
                dgvOrderDetail.DataSource = source;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
