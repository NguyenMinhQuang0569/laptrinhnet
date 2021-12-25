using Quananvat.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quananvat.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }
        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();
            string query = "select * from foodcategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }

            return listCategory;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;
            string query = "select * from foodcategory where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;

        }

        public bool InsertFoodCatergory(string name)
        {
            string query = string.Format("insert into dbo.foodcategory(name) values (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateFoodCategory(string name, int iddanhmuc)
        {
            string query = string.Format("update dbo.foodcategory set name = N'{0}' where id = {1}", name, iddanhmuc);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFoodCategory(int idfood, int id, int iddanhmuc)
        {
            BillinfoDAO.Instance.DeleteBillinfoByFoodID(idfood);
            FoodDAO.Instance.DeleteFood(id);
            string query = string.Format("delete foodcategory where id = {0}", iddanhmuc);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
