using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMyPrj.ViewModels
{
    public class CShoppingCartViewModel
    {
        [Required(ErrorMessage = "請輸入收件人姓名")]
        public string fReceiver { get; set; }

        [Required(ErrorMessage = "請輸入收件人地址")]
        public string fAddress { get; set; }
    }
}