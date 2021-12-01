using BusinessObject;
using DataAccess.Repository;
using SalesApp.OderDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp.Oder
{
    public partial class frmOrderManagement : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source;
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public frmOrderManagement()
        {
            InitializeComponent();
        }

        private void frmOrderManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail
            {
                Text = "Add member",
                InsertOrUpdate = false,
                OrderRepository = orderRepository
            };
            if (frmOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }
        }
        private OrderObject GetOrderObject()
        {
            OrderObject order = null;
            try
            {
                order = new OrderObject
                {
                    OrderID=int.Parse(txtOrderID.Text),
                    MemberID = int.Parse(txtMemberID.Text),
                    Freight=decimal.Parse(txtFreight.Text),
                    OrderDate=dtpOrderDate.Value,
                    RequiredDate=dtpRequiredDate.Value,
                    ShippedDate=dtpShippedDate.Value
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return order;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var orders = orderDetailRepository.GetOrderDetail();
            List<OrderDetailObject> l = new List<OrderDetailObject>();
            foreach(OrderDetailObject m in orders)
            {
                if (txtOrderID.Text.Equals(m.OrderID.ToString()))
                {
                    l.Add(m);
                }
            }
            if (l.Count() != 0)
            {
                MessageBox.Show("This OrderID does exist in OrderDetail table!Can not Delete");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Do you want to delete", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        var order = GetOrderObject();
                        orderRepository.DeletOrder(order.OrderID);
                        LoadOrderList();
                    }
                    else
                    {
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a member");
                }
            }
        }

        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadOrderList()
        {
            var orders = orderRepository.GetOrders();
            try
            {
                source = new BindingSource();
                source.DataSource = orders;
                txtOrderID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtFreight.DataBindings.Clear();
               dtpOrderDate.DataBindings.Clear();
               dtpRequiredDate.DataBindings.Clear();
                dtpShippedDate.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderID");
                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtFreight.DataBindings.Add("Text", source, "Freight");
                dtpOrderDate.DataBindings.Add("Text", source, "OrderDate");
                dtpRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                dtpShippedDate.DataBindings.Add("Text", source, "ShippedDate");
 
                dgvOrder.DataSource = null;
                dgvOrder.DataSource = source;
                if (orders.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load Order list");
            }
        }
        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtOrderID.Text = string.Empty;
            txtFreight.Text = string.Empty;
            dtpOrderDate.Value = DateTime.Today;
            dtpRequiredDate.Value = DateTime.Today;
            dtpShippedDate.Value = DateTime.Today;
        }

        private void btShowDetail_Click(object sender, EventArgs e)
        {
            frmShowOrderDetailManagement frm = new frmShowOrderDetailManagement();
            frm.Show();
        }
    }
}
