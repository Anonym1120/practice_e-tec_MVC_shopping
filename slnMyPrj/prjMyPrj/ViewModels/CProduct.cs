using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using prjMyPrj.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMyPrj.ViewModels
{
    public class CProduct
    {
        private tProduct _product;
        public CProduct(tProduct p) 
        {
            _product = p;
        }
        public int fId { get { return _product.fId; } set { _product.fId = value; } }

        [DisplayName("產品編號")]
        public string fPId { get { return _product.fPId; } set { _product.fPId = value; } }

        [DisplayName("產品名稱")]
        public string fName { get { return _product.fName; } set { _product.fName = value; } }

        [DisplayName("產品價格")]
        public Nullable<int> fPrice { get { return _product.fPrice; } set { _product.fPrice = value; } }

        [DisplayName("產品圖片")]
        public string fImg { get { return _product.fImg; } set { _product.fImg = value; } }
    }
}