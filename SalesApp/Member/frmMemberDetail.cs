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

namespace SalesApp.Member
{
    public partial class frmMemberDetail : Form
    {
        IMemberRepository memberRepository = new MemberRepository();

        public frmMemberDetail()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public MemberObject MemberInfor { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<MemberObject> l = new List<MemberObject>();
            var members = memberRepository.GetMembers();
            if (txtMemberID.Text.Equals(""))
            {
                MessageBox.Show("asdada");
            }
            else if (l.Count() != 0)
            {
                MessageBox.Show("This ID is duplicated.");
            }
            else if (txtCompanyName.Text.Equals(""))
            {
                MessageBox.Show("Company Name can not be empty.");
            }
            else if (txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Email can not be empty.");
            }
            else if (txtCity.Text.Equals(""))
            {
                MessageBox.Show("City can not be empty.");
            }
            else if (txtCountry.Text.Equals(""))
            {
                MessageBox.Show("Country can not be empty.");
            }
            else if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Password can not be empty.");
            }
            else
            {
                try
                {
                    var member = new MemberObject
                    {

                        MemberID = int.Parse(txtMemberID.Text),
                        CompanyName = txtCompanyName.Text,
                        Email = txtEmail.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                        Password = txtPassword.Text
                    };
                    if (InsertOrUpdate == false)
                    {
                        MemberRepository.InsertMember(member);
                    }
                    else
                    {
                        MemberRepository.UpdateMember(member);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new member" : "Update member");
                }
            }
        }

        private void MemberDetail_Load(object sender, EventArgs e)
        {
            txtMemberID.Enabled = !InsertOrUpdate;
            if(InsertOrUpdate == true)
            {
                txtMemberID.Text = MemberInfor.MemberID.ToString();
                txtCompanyName.Text = MemberInfor.CompanyName;
                txtEmail.Text = MemberInfor.Email;
                txtCity.Text = MemberInfor.City;
                txtCountry.Text = MemberInfor.Country;
                txtPassword.Text = MemberInfor.Password;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
