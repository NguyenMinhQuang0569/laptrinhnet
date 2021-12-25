using Quananvat.DAO;
using Quananvat.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quananvat
{
    public partial class FormAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public FormAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            txtid.Text = LoginAccount.Username;
            txtidhienthi.Text = LoginAccount.Displayname;

        }

        void UpdateAccount()
        {
            string displayname = txtidhienthi.Text;
            string password = txtpass.Text;
            string newpass = txtnewpass.Text;
            string reenterpass = txtnhaplai.Text;
            string username = txtid.Text;

            if(!newpass.Equals(reenterpass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.updateaccount(username, displayname, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }

        private event EventHandler updateaccount;


        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }
    }
}
