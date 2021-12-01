using BusinessObject;
using DataAccess.Repository;
using SalesApp.Member;
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

namespace SalesApp
{
    public partial class MemberSalesManagement : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        IOrderRepository orderRepository = new OrderRepository();
        List<MemberObject> list = new List<MemberObject>();
        List<OrderObject> l = new List<OrderObject>();
        BindingSource source;
        public static List<OrderObject> orderID = new List<OrderObject>();
        public MemberSalesManagement()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetail frm = new frmMemberDetail
            {
                Text = "Update car",
                InsertOrUpdate = true,
                MemberInfor = GetMemberObject(),
                MemberRepository = memberRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }

        }
        private MemberObject GetMemberObject()
        {
            MemberObject member = null;
            try
            {
                member = new MemberObject
                {
                    MemberID = int.Parse(txtMemberID.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return member;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }
        public void LoadMemberList()
        {
            var members = memberRepository.GetMembers();
           
            foreach(MemberObject m in members)
            {
                if (Login.name.Equals(m.Email))
                {
                    list.Add(m);
                }
            }
            try
            {
                source = new BindingSource();
                source.DataSource = list;
                txtCity.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtPassword.DataBindings.Add("Text", source, "Password");
                dgvMember.DataSource = null;
                dgvMember.DataSource = source;
              /*  if (members.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void MemberSalesManagement_Load(object sender, EventArgs e)
        {
        }

        private void sttName_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }
        public void LoadOrderList()
        {
            var orders = orderRepository.GetOrders();
            
            int memberID=0;
            foreach (MemberObject a in list)
            {
                memberID = a.MemberID;
            }
            foreach(OrderObject o in orders)
            {
                if (o.MemberID.ToString().Equals(memberID.ToString()))
                {
                    l.Add(o);
                }
            }
            try
            {
                source = new BindingSource();
                source.DataSource = l;
                txtOrderID.DataBindings.Clear();
                txtMemberIDOrder.DataBindings.Clear();
                txtFreight.DataBindings.Clear();
                dtpOrderDate.DataBindings.Clear();
                dtpRequiredDate.DataBindings.Clear();
                dtpShippedDate.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderID");
                txtMemberIDOrder.DataBindings.Add("Text", source, "MemberID");
                txtFreight.DataBindings.Add("Text", source, "Freight");
                dtpOrderDate.DataBindings.Add("Text", source, "OrderDate");
                dtpRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                dtpShippedDate.DataBindings.Add("Text", source, "ShippedDate");

                dgvOrder.DataSource = null;
                dgvOrder.DataSource = source;
              /*  if (orders.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }*/
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

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            foreach(OrderObject o in l)
            {
                orderID.Add(o);
            }

            frmShowOrderDetailManagement frm = new frmShowOrderDetailManagement();
            frm.Show();

        }
    }
}
