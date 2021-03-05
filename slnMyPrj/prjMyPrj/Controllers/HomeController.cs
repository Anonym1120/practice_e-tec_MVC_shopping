using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjMyPrj.Models;
using prjMyPrj.ViewModels;

namespace prjMyPrj.Controllers
{
    public class HomeController : Controller
    {
        dbmyDBEntities db = new dbmyDBEntities();

        public ActionResult DeleteProduct(int fId)
        {
            var prod = db.tProduct
                .Where(p => p.fId == fId)
                .FirstOrDefault();

            if (prod != null) 
            {
                db.tProduct.Remove(prod);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditProduct(tProduct modify)
        {
            var prod = db.tProduct
                .Where(p => p.fId == modify.fId)
                .FirstOrDefault();

            if (prod != null) 
            {
                prod.fPId = modify.fPId;
                prod.fName = modify.fName;
                prod.fPrice = modify.fPrice;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditProduct(int fId) 
        {
            var prod = db.tProduct
                .Where(p => p.fId == fId)
                .FirstOrDefault();

            if (prod == null) 
            {
                return RedirectToAction("Index");
            }
            return View("EditProduct", "_LayoutAdmin", prod);
        }

        [HttpPost]
        public ActionResult AddProduct(tProduct p, HttpPostedFileBase fImgFile)
        {
            int point = fImgFile.FileName.IndexOf(".");
            string extention = fImgFile.FileName.Substring(point, fImgFile.FileName.Length - point);
            string photoName = p.fPId + extention;
            fImgFile.SaveAs(Server.MapPath("../Content/" + photoName));
            p.fImg = "../Content/" + photoName;

            if (string.IsNullOrEmpty(p.fName)) 
            {
                return RedirectToAction("Index");
            }

            db.tProduct.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AddProduct() 
        {
            return View("AddProduct", "_LayoutAdmin");
        }

        public ActionResult DeleteCart(int fId) 
        {
            var od = db.tOrderDetail
                .Where(d => d.fId == fId)
                .FirstOrDefault();

            db.tOrderDetail.Remove(od);
            db.SaveChanges();

            return RedirectToAction("ShoppingCart");
        }

        public ActionResult AddCart(string fPId) 
        {
            string user = (Session[CDictionary.SK_LOGINED_USER] as tMember).fUserId;

            var cart = db.tOrderDetail
                .Where(m => m.fPId == fPId && m.fIsApproved == "N" && m.fUserId == user)
                .FirstOrDefault();

            if (cart == null)
            {
                var product = db.tProduct
                    .Where(p => p.fPId == fPId)
                    .FirstOrDefault();

                string guid = Guid.NewGuid().ToString();

                tOrderDetail od = new tOrderDetail();
                od.fUserId = user;
                od.fOrderId = guid;
                od.fPId = product.fPId;
                od.fName = product.fName;
                od.fPrice = product.fPrice;
                od.fQty = 1;
                od.fIsApproved = "N";

                db.tOrderDetail.Add(od);
            }
            else 
            {
                cart.fQty += 1;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ShoppingCart(CShoppingCartViewModel buy) 
        {
            string user = (Session[CDictionary.SK_LOGINED_USER] as tMember).fUserId;

            string guid = Guid.NewGuid().ToString();

            tOrder o = new tOrder();
            o.fUserId = user;
            o.fOrderId = guid;
            o.fReceiver = buy.fReceiver;
            o.fAddress = buy.fAddress;
            o.fDate = DateTime.Now;

            db.tOrder.Add(o);

            var cart = db.tOrderDetail
                .Where(od => od.fUserId == user && od.fIsApproved == "N").ToList();

            foreach (var item in cart) 
            {
                item.fIsApproved = "Y";
            }

            db.SaveChanges();

            return RedirectToAction("OrderDetail");
        }

        public ActionResult ShoppingCart()
        {
            string user = (Session[CDictionary.SK_LOGINED_USER] as tMember).fUserId;
            string level = (Session[CDictionary.SK_LOGINED_USER] as tMember).fLevel;

            var table = db.tOrderDetail
                .Where(m => m.fUserId == user && m.fIsApproved == "N").ToList();
            List<COrderDetail> list = new List<COrderDetail>();
            foreach (tOrderDetail od in table) 
            {
                list.Add(new COrderDetail(od));
            }
            
            if(level == "1")
            return View("ShoppingCart", "_LayoutMember", list);

            return View("ShoppingCart", "_LayoutAdmin", list);
        }

        public ActionResult OrderDetail() 
        {
            string userId = (Session[CDictionary.SK_LOGINED_USER] as tMember).fUserId;
            string level = (Session[CDictionary.SK_LOGINED_USER] as tMember).fLevel;

            var orderDetail = db.tOrderDetail
                .Where(m => m.fUserId == userId && m.fIsApproved == "Y").ToList();

            List<COrderDetail> list = new List<COrderDetail>();
            foreach (tOrderDetail od in orderDetail) 
            {
                list.Add(new COrderDetail(od));
            }

            if(level == "1")
            return View("OrderDetail", "_LayoutMember", list);

            return View("OrderDetail", "_LayoutAdmin", list);
        }
        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult LogIn(CLoginViewModel login)
        {
            string userId = login.fUserId;
            string password = login.fPassword;

            var member = db.tMember
                .Where(m => m.fUserId == userId && m.fPassword == password)
                .FirstOrDefault();

            if (member == null)
            {
                ViewBag.Message = "請重新輸入帳號密碼";
                return View();
            }
            Session[CDictionary.SK_LOGINED_USER] = member;

            return RedirectToAction("Index");
        }

        public ActionResult LogIn()
        {
            return View();
        }
        
        
        public ActionResult Index()
        {

            string level = (Session[CDictionary.SK_LOGINED_USER] as tMember).fLevel;

            var table = db.tProduct.ToList();
            List<CProduct> list = new List<CProduct>();
            foreach (tProduct p in table) 
            {
                list.Add(new CProduct(p));
            }

            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return View("Index", "_Layout", list);
            }
            else
            {
                if (level == "1") 
                {
                    return View("Index", "_LayoutMember", list);
                }
            }
            return View("Index", "_LayoutAdmin", list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}