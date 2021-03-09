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

        public int fId { get { return _order.fId; } set { _order.fId = value; } }

        [DisplayName("訂單編號")]
        public string fOrderId { get { return _order.fOrderId; } set { _order.fOrderId = value; } }

        [DisplayName("會員帳號")]
        public string fUserId { get { return _order.fUserId; } set { _order.fUserId = value; } }

        [DisplayName("收件人姓名")]
        public string fReceiver { get { return _order.fReceiver; } set { _order.fReceiver = value; } }

        [DisplayName("收件人地址")]
        public string fAddress { get { return _order.fAddress; } set { _order.fAddress = value; } }

        [DisplayName("訂單日期")]
        public Nullable<System.DateTime> fDate { get { return _order.fDate; } set { _order.fDate = value; } }
    }
}