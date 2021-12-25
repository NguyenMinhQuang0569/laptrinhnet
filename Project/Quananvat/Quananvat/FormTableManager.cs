using Quananvat.DAO;
using Quananvat.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quananvat
{
    public partial class FormTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount 
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public FormTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
        }

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.Displayname + ")";
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbcategory.DataSource = listCategory;
            cbcategory.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listfood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbfood.DataSource = listfood;
            cbfood.DisplayMember = "Name";
        }


        void LoadTable()
        {
            flptable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach(Table item in tableList)
            {
                Button btn = new Button() {Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;

                btn.Click += Btn_Click;
                btn.Tag = item;

                switch(item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightGray;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }    
                flptable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvbill.Items.Clear();
            List<DTO.Menu> listBillinfo = MenuDAO.Instance.GetListMenu(id);
            float TotalPrice = 0;
            foreach (DTO.Menu item in listBillinfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                TotalPrice += item.TotalPrice;
                lsvbill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
           // Thread.CurrentThread.CurrentCulture = culture;
            txttongtien.Text = TotalPrice.ToString("c", culture);

        
        }





        private void Btn_Click(object sender, EventArgs e)
        {
            int TableID= ((sender as Button).Tag as Table).ID;
            lsvbill.Tag = (sender as Button).Tag;
            ShowBill(TableID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc Chắn Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAccountProfile form = new FormAccountProfile(LoginAccount);
            form.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.loginAccount = LoginAccount;
            form.Insertfood += Form_Insertfood;
            form.Updatefood += Form_Updatefood;
            form.Deletefood += Form_Deletefood;
            form.ShowDialog();
        }

        private void Form_Deletefood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbcategory.SelectedItem as Category).ID);
            if(lsvbill.Tag!=null)
                ShowBill((lsvbill.Tag as Table).ID);
            LoadTable();
        }

        private void Form_Updatefood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbcategory.SelectedItem as Category).ID);
            if (lsvbill.Tag != null)
                ShowBill((lsvbill.Tag as Table).ID);
        }

        private void Form_Insertfood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbcategory.SelectedItem as Category).ID);
            if (lsvbill.Tag != null)
                ShowBill((lsvbill.Tag as Table).ID);
        }

        private void flptable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lsvbill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txttongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;
  
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void btnaddfood_Click(object sender, EventArgs e)
        {
            Table table = lsvbill.Tag as Table;
            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn để thêm món");
                return;
            }
            int idbill = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
            int idfood = (cbfood.SelectedItem as Food).ID;
            int count = (int)nmfoodcount.Value;
            if(idbill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillinfoDAO.Instance.InsertBillinfo(BillDAO.Instance.GetMaxIdBill(),idfood,count);
            }    
            else
            {
                BillinfoDAO.Instance.InsertBillinfo(idbill, idfood, count);
            }
            ShowBill(table.ID);
            LoadTable();
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            Table table = lsvbill.Tag as Table;

            int idbill = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
            int discount = (int)nmgiamgia.Value;

            double totalPrice = Convert.ToDouble(txttongtien.Text.Split(',')[0]);
            double finaltotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idbill != -1)
            {
                if(MessageBox.Show(string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho {0}\nTổng Tiền - (Tổng Tiền/100) x Giảm Giá \n=> {1} - ({1} / 100) x {2} = {3}",table.Name, totalPrice, discount, finaltotalPrice), "Thông báo", MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idbill, discount, (float)finaltotalPrice);
                    ShowBill(table.ID);

                    LoadTable();
                }    
            }

        }
    }
}
