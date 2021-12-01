using SalesApp.Member;
using SalesApp.Oder;
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
    public partial class SaleManagement : Form
    {
        public SaleManagement()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            frmMemberManagement frm = new frmMemberManagement();
            frm.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrderManagement frm = new frmOrderManagement();
            frm.Show();
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            frmShowOrderDetailManagement frm = new frmShowOrderDetailManagement();
            frm.Show();
        }
    }
}
