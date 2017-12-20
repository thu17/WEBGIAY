using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBGIAY.Areas.Webmaster.Models
{
    public class WebmasterLoginViewModel
    {
        
        public string TENDANGNHAP;
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        //[StringLength(5000, MinimumLength = 5, ErrorMessage = "Độ dài tối thiểu là 5 kí tự")]
        public string MATKHAU { get; set; }
    }
}
