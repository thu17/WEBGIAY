using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
using System.Data.SqlClient;
namespace Entity.DAL
{
    public class CUSTOMERDAL
    {
        WEBGIAYEntities db = null;
        public CUSTOMERDAL()
        {
            db = new WEBGIAYEntities();
        }
        public bool checkemail(string email)
        {
            return db.CUSTOMERS.Count(c => c.EMAIL == email) > 0;
        }
        
        public int AddCustomer(CUSTOMER c)
        {
            db = new WEBGIAYEntities();
            db.CUSTOMERS.Add(c);
            db.SaveChanges();
            return c.MACUSTOMER;
        }


        public CUSTOMER getcustomer(int idcustomer)
        {
            db = new WEBGIAYEntities();
            return db.CUSTOMERS.Find(idcustomer);
        }

        public bool thaydoitrangthai(int idcustomer)
        {
            var c = db.CUSTOMERS.Find(idcustomer);
            if(c!=null)
            {
                c.TINHTRANG = 1;
                db.SaveChanges();
                return true;
            }
            return false;           
        }

        public string getpasswordbyemail(string email)
        {
            using (db)
            {
                //object parmeter = new SqlParameter("@EMAIL",email);
                //List<byte[]> pwd = db.Database.SqlQuery<byte[]>("sp_login @EMAIL", parmeter).ToList();
                var pwd = db.CUSTOMERS.Where(c => c.EMAIL == email).FirstOrDefault().MATKHAU;
                if(pwd!=null)                
                return pwd;
                return null;
            }
        }
        public CUSTOMER getuserbyemail(string email)
        {
            using (db=new WEBGIAYEntities())
            {
                return db.CUSTOMERS.Where(c => c.EMAIL == email).SingleOrDefault();
            }
                
            
        }
        public bool doimatkhau(int idcutomer,string password)
        {
            db.CUSTOMERS.Where(c => c.MACUSTOMER == idcutomer).SingleOrDefault().MATKHAU = password;
            db.SaveChanges();
            return true;
        }
    }
}
