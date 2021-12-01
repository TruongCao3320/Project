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

namespace SalesApp.Oder
{
    public partial class frmOrderDetail : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        IMemberRepository memberRepository = new MemberRepository();
        public frmOrderDetail()
        {
            InitializeComponent();
        }
        public IOrderRepository OrderRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public OrderObject OrderInfor { get; set; }
        public bool CheckIDMember(String s)
        {
            var members = memberRepository.GetMembers();
            foreach(MemberObject m in members)
            {
                if (s.Equals(m.MemberID.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<OrderObject> l = new List<OrderObject>();
            var orders = orderRepository.GetOrders();
            foreach (OrderObject m in orders)
            {
                if (txtOrderID.Text.Equals(m.OrderID))
                {
                    l.Add(m);
                }
            }
            if (txtMemberID.Text.Equals("") || CheckIDMember(txtMemberID.Text)==false)
            {
                MessageBox.Show("Member ID can not be empty or MemberID has choose in Member List.");
            }
            else if (l.Count() != 0)
            {
                MessageBox.Show("This ID is duplicated.");
            }
            else if (txtOrderID.Text.Equals(""))
            {
                MessageBox.Show("Order ID can not be empty.");
            }
            else if (txtFreight.Text.Equals(""))
            {
                MessageBox.Show("Freight can not be empty.");
            }else
            {
                try
                {
                    var order = new OrderObject
                    {
                        OrderID = int.Parse(txtOrderID.Text),
                        MemberID = int.Parse(txtMemberID.Text),
                        OrderDate = dtpOrderDate.Value,
                        RequiredDate = dtpRequriedDate.Value,
                        ShippedDate = dtpShippedDate.Value,
                        Freight = decimal.Parse(txtFreight.Text)
                    };
                    if (InsertOrUpdate == false)
                    {
                        OrderRepository.InsertOrder(order);
                    }
                    else
                    {
                        OrderRepository.UpdateOrder(order);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new order" : "Update order");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            txtOrderID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtOrderID.Text = OrderInfor.OrderID.ToString();
                txtMemberID.Text = OrderInfor.MemberID.ToString();
                txtFreight.Text = OrderInfor.Freight.ToString();
                dtpOrderDate.Value = OrderInfor.OrderDate;
                dtpRequriedDate.Value = OrderInfor.RequiredDate;
                dtpShippedDate.Value = OrderInfor.ShippedDate;
            }
        }
    }
}
