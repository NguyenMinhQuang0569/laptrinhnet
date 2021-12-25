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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btbdangnhap_Click(object sender, EventArgs e)
        {
            string username = txtid.Text;
            string password = txtpass.Text;
            if(Login(username, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                FormTableManager form = new FormTableManager(loginAccount);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu, Vui lòng kiểm tra lại!");
            }
  
        }
        bool Login (string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn Có Chắc Chắn Muốn Thoát Chương Trình?","Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }    
           
        }
    }
}
