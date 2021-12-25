using Quananvat.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quananvat.DAO
{
    public class BillinfoDAO
    {
        private static BillinfoDAO instance;

        public static BillinfoDAO Instance
        {
            get { if (instance == null) instance = new BillinfoDAO(); return BillinfoDAO.instance; }
            private set { BillinfoDAO.instance = value; }
        }
        private BillinfoDAO() { }

        public void DeleteBillinfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete from dbo.billinfo where idfood = " + id);
        }

        public List<Billinfo> GetListBillinfo(int id)
        {
            List<Billinfo> listBillinfo = new List<Billinfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.billinfo where idbill = " + id);

            foreach (DataRow item in data.Rows)
            {
                Billinfo info = new Billinfo(item);
                listBillinfo.Add(info);
            }

            return listBillinfo;
        }
        public void InsertBillinfo (int idbill, int idfood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("usp_insertbillinfo @idbill , @idfood , @count ", new object[] { idbill, idfood, count });
        }

        
    }
}
