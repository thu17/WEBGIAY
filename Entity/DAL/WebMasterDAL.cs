using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
//using Entity.ViewModel;
using System.Data.SqlClient;

namespace Entity.DAL
{
    public class WebMasterDAL
    {
        WEBGIAYEntities db = null;
        public WebMasterDAL()
        {
            db = new WEBGIAYEntities();
        }
        public string getpasswordbytk(string tk)
        {
            using (db)
            {
                object parmeter = new SqlParameter("@TENDANGNHAP", tk);
                //List<byte[]> pwd = db.Database.SqlQuery<byte[]>("sp_login @EMAIL", parmeter).ToList();
                var pwd = db.WEBMASTERs.Where(c => c.TENDANGNHAP == tk).FirstOrDefault().MATKHAU;
                if (pwd != null)
                    return pwd;
                return null;
            }
        }
        public WEBMASTER getuserbytk(string tk)
        {
            using (db = new WEBGIAYEntities())
            {
                return db.WEBMASTERs.Where(c => c.TENDANGNHAP == tk).SingleOrDefault();
            }
        }
    }
}
