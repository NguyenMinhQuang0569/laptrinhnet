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
    public partial class FormAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource foodcategorylist = new BindingSource();

        public Account loginAccount;
        public FormAdmin()
        {
            InitializeComponent();
            Load();
        }

        List<Food> SearchFoodByName(int id)
        {
            List<Food> listfood = FoodDAO.Instance.SearchFoodByName(id);

            return listfood;
        } 
        void Load()
        {
            dtgvfood.DataSource = foodList;
            dtgvtk.DataSource = accountList;
            dtgvcategory.DataSource = foodcategorylist;

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkfromdate.Value, dtpktodate.Value);
            LoadListFood();
            LoadAccount();
            LoadFoodCategory();
            LoadCategoryIntoCombobox();
            AddFoodBinding();
            AddAcountBinding();
            AddFoodCategoryBinding();


        }

        void AddFoodCategoryBinding()
        {
            txtiddanhmuc.DataBindings.Add(new Binding("Text", dtgvcategory.DataSource, "id", true, DataSourceUpdateMode.Never));
            txttendanhmuc.DataBindings.Add(new Binding("Text", dtgvcategory.DataSource, "name", true, DataSourceUpdateMode.Never));
      
        }

        void LoadFoodCategory()
        {
            foodcategorylist.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void AddAcountBinding()
        {
            txttentk.DataBindings.Add(new Binding("Text", dtgvtk.DataSource, "username", true, DataSourceUpdateMode.Never));
            txttenhienthi.DataBindings.Add(new Binding("Text", dtgvtk.DataSource, "displayname", true, DataSourceUpdateMode.Never));
            nmloaitk.DataBindings.Add(new Binding("value", dtgvtk.DataSource, "type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkfromdate.Value = new DateTime(today.Year, today.Month, 1);
            dtpktodate.Value = dtpkfromdate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillByDate(DateTime checkin, DateTime checkout)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkin, checkout);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkfromdate.Value, dtpktodate.Value);
        }

        private void tbfood_Click(object sender, EventArgs e)
        {

        }

        private void txtidhienthi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvfood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvfood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryByID(id);
                    cbboxdanhmuc.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbboxdanhmuc.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbboxdanhmuc.SelectedIndex = index;

                }
            }
            catch { }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvtk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void AddFoodBinding()
        {
            txttenmon.DataBindings.Add(new Binding("Text", dtgvfood.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtidhienthi.DataBindings.Add(new Binding("Text", dtgvfood.DataSource, "id", true, DataSourceUpdateMode.Never));
            nmgia.DataBindings.Add(new Binding("Value", dtgvfood.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCombobox()
        {
            cbboxdanhmuc.DataSource = CategoryDAO.Instance.GetListCategory();
            cbboxdanhmuc.DisplayMember = "name";
        }


        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetlistFood();
        }
        private void btnxemfood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        void InsertFoodCategory(string name)
        {
            if (CategoryDAO.Instance.InsertFoodCatergory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");
            }
            else
            {
                MessageBox.Show("Thêm danh mục không thành công");
            }
            LoadFoodCategory();
        }
        void UpdateFoodCategory(string name, int iddanhmuc)
        {
            if (CategoryDAO.Instance.UpdateFoodCategory(name, iddanhmuc))
            {
                MessageBox.Show("Sửa danh mục thành công");
                
            }
            else
            {
                MessageBox.Show("Sửa danh mục không thành công");
            }
            LoadFoodCategory();
        }
        void DeleteFoodCategory(int idfood, int id, int iddanhmuc)
        {
            if (CategoryDAO.Instance.DeleteFoodCategory(idfood, id, iddanhmuc))
            {
                MessageBox.Show("Xóa danh mục thành công");
            }
            else
            {
                MessageBox.Show("Xóa danh mục không thành công");
            }
            LoadFoodCategory();
        }


        void AddAcount(string username, string displayName, int type)
        {
            if(AccountDAO.Instance.InsertAccount(username, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản không thành công");
            }
            LoadAccount();
        }

        void EditAccount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(username, displayname, type))
            {
                MessageBox.Show("Sửa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Sửa tài khoản không thành công");
            }
            LoadAccount();
        }

        void DeleteAccount(string username)
        {
            if (loginAccount.Equals(username))
            {
                MessageBox.Show("Không thể xóa tài khoản đang hoạt động!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản không thành công");
            }
            LoadAccount();
        }

        void ResetPass(string username)
        {
            if (AccountDAO.Instance.ResetPassword(username))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu không thành công");
            }
        }

        private void btnaddfood_Click(object sender, EventArgs e)
        {
            string name = txttenmon.Text;
            int categoryID = (cbboxdanhmuc.SelectedItem as Category).ID;
            float price = (float)nmgia.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertfood != null)
                {
                    insertfood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món ăn");
            }
        }

        private void btnsuafood_Click(object sender, EventArgs e)
        {
            string name = txttenmon.Text;
            int categoryID = (cbboxdanhmuc.SelectedItem as Category).ID;
            float price = (float)nmgia.Value;
            int id = Convert.ToInt32(txtidhienthi.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updatefood != null)
                {
                    updatefood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa món ăn");
            }
        }

        private void btnxoafood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtidhienthi.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if(deletefood != null)
                {
                    deletefood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa món ăn");
            }
        }


        private event EventHandler insertfood;
        public event EventHandler Insertfood
        {
            add { insertfood += value; }
            remove { insertfood -= value; }
        }

        private event EventHandler deletefood;
        public event EventHandler Deletefood
        {
            add { deletefood += value; }
            remove { deletefood -= value; }
        }

        private event EventHandler updatefood;
        public event EventHandler Updatefood
        {
            add { updatefood += value; }
            remove { updatefood -= value; }
        }

        private void btntimfood_Click(object sender, EventArgs e)
        {
            foodList.DataSource =  SearchFoodByName(Convert.ToInt32(txttimkiem.Text));
        }

        private void btnxemtk_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnthemtk_Click(object sender, EventArgs e)
        {
            string username = txttentk.Text;
            string displayname = txttenhienthi.Text;
            int type = (int)nmloaitk.Value;

            AddAcount(username, displayname, type);
        }

        private void btnsautk_Click(object sender, EventArgs e)
        {
            string username = txttentk.Text;
            string displayname = txttenhienthi.Text;
            int type = (int)nmloaitk.Value;

            EditAccount(username, displayname, type);
        }

        private void btnxoatk_Click(object sender, EventArgs e)
        {
            string username = txttentk.Text;
            DeleteAccount(username);
        }

        private void btnresetpass_Click(object sender, EventArgs e)
        {
            string username = txttentk.Text;
            ResetPass(username);
        }

        private void btnxemdanhmuc_Click(object sender, EventArgs e)
        {
            LoadFoodCategory();
        }

        private void btnthemdanhmuc_Click(object sender, EventArgs e)
        {
            string name = txttendanhmuc.Text;
            InsertFoodCategory(name);
        }

        private void btnsuadanhmuc_Click(object sender, EventArgs e)
        {
            string name = txttendanhmuc.Text;
            int iddanhmuc = Convert.ToInt32(txtiddanhmuc.Text);
            UpdateFoodCategory(name, iddanhmuc);
        }

        private void btnxoadanhmuc_Click(object sender, EventArgs e)
        {
            int idfood = Convert.ToInt32(txtidhienthi.Text);
            int id = Convert.ToInt32(txtidhienthi.Text);
            int iddanhmuc = Convert.ToInt32(txtiddanhmuc.Text);
            DeleteFoodCategory(idfood, id, iddanhmuc);

        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
