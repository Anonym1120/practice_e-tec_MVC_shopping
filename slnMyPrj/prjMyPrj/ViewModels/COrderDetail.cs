using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using prjMyPrj.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMyPrj.ViewModels
{
    public class COrderDetail
    {
        private tOrderDetail _orderDetail;

        public COrderDetail(tOrderDetail o) 
        {
            _orderDetail = o;
        }

        public int fId { get { return _orderDetail.fId; } set { _orderDetail.fId = value; } }

        [DisplayName("訂單編號")]
        public string fOrderId { get { return _orderDetail.fOrderId; } set { _orderDetail.fOrderId = value; } }

        [DisplayName("會員帳號")]
        public string fUserId { get { return _orderDetail.fUserId; } set { _orderDetail.fUserId = value; } }

        [DisplayName("產品編號")]
        public string fPId { get { return _orderDetail.fPId; } set { _orderDetail.fPId = value; } }
        
        [DisplayName("產品名稱")]
        public string fName { get { return _orderDetail.fName; } set { _orderDetail.fName = value; } }
        
        [DisplayName("產品價格")]
        public Nullable<int> fPrice { get { return _orderDetail.fPrice; } set { _orderDetail.fPrice = value; } }
        
        [DisplayName("產品數量")]
        public Nullable<int> fQty { get { return _orderDetail.fQty; } set { _orderDetail.fQty = value; } }
        
        [DisplayName("Y/N")]
        public string fIsApproved { get { return _orderDetail.fIsApproved; } set { _orderDetail.fIsApproved = value; } }
    }
}