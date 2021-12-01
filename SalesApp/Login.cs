using BusinessObject;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
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
    public partial class Login : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        public static string name;
        
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            var list = memberRepository.GetMembers();
            List<MemberObject> l = new List<MemberObject>();
            string s="";
            bool flag = false;
            foreach(MemberObject m in list)
            {
                if(txtEmail.Text.Equals(m.Email) && txtPassword.Text.Equals(m.Password))
                {
                    flag = true;
                }
            }
            if (flag==true)
            {
                foreach(MemberObject m in list)
                {
                    if(txtEmail.Text.Equals(m.Email) && txtPassword.Text.Equals(m.Password))
                    {
                        s = m.Email;
                    }
                }
                if (s.Equals("admin@fstore.com"))
                {
                    MessageBox.Show("Login Successfully(Admin)");
                    SaleManagement admin = new SaleManagement();
                    admin.Show();
                    name = "admin@fstore.com";
                }
                else
                {
                    MessageBox.Show("Login Successfully");
                    MemberSalesManagement member = new MemberSalesManagement();
                    member.Show();
                    name = s;
                }
               
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }
    }
}
