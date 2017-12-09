using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.ViewModel
{
    public class CHITIETSANPHAMViewModel
    {
        public SANPHAM sp{get;set;}
        public List<ANHCHITIET> listanh{get;set;}
    }
}
