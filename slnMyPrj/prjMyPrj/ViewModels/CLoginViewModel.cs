using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMyPrj.ViewModels
{
    public class CLoginViewModel
    {
        [Required(ErrorMessage ="請輸入帳號")]
        public string fUserId { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        public string fPassword { get; set; }
        
    }
}