using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using prjMyPrj.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace prjMyPrj.ViewModels
{
    public class COrder
    {
        private tOrder _order;

        public COrder(tOrder o) 
        {
            _order = o;
        }

        public int fId { get; set; }

        [DisplayName("訂單編號")]
        public string fOrderId { get; set; }

        [DisplayName("會員帳號")]
        public string fUserId { get; set; }

        [DisplayName("收件人姓名")]
        public string fReceiver { get; set; }

        [DisplayName("收件人地址")]
        public string fAddress { get; set; }

        [DisplayName("訂單日期")]
        public Nullable<System.DateTime> fDate { get; set; }
    }
}