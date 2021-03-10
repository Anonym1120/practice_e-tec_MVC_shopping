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

        public ActionResult SelectOut(string fUserId)
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("Login");
            }

            var order = from o in db.tOrder
                        select o;

            if (!string.IsNullOrEmpty(fUserId))
            {
                order = order
                    .Where(o => o.fUserId.Contains(fUserId));

            }

            List<COrder> list = new List<COrder>();
            foreach (var o in order)
            {
                list.Add(new COrder(o));
            }

            return View(list);
        }

        public ActionResult SelectOrder()
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("Login");
            }

            return View("SelectOrder", "_LayoutAdmin");
        }

        [HttpPost]
        public ActionResult AddUser(tMember m)
        {
            if (string.IsNullOrEmpty(m.fUserId))
            {
                return RedirectToAction("Index");
            }

            db.tMember.Add(m);
            db.SaveChanges();

            return RedirectToAction("UserList");
        }

        public ActionResult AddUser()
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null) 
            {
                return RedirectToAction("LogIn");
            }

            return View("AddUser", "_LayoutAdmin");
        }
        public ActionResult UserList()
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("LogIn");
            }

            var user = db.tMember.ToList();

            List<CMember> list = new List<CMember>();
            foreach (tMember m in user)
            {
                list.Add(new CMember(m));
            }

            return View("UserList", "_LayoutAdmin", list);
        }

        public ActionResult SelectProduct(string selectItem)
        {
            var productItem = from p in db.tProduct
                              select p;

            if (!string.IsNullOrEmpty(selectItem))
            {
                productItem = productItem
                    .Where(s => s.fName.Contains(selectItem));
            }

            List<CProduct> list = new List<CProduct>();
            foreach (tProduct p in productItem)
            {
                list.Add(new CProduct(p));
            }

            return View(list);
        }

        public ActionResult DeleteProduct(int fId)
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("LogIn");
            }

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
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("LogIn");
            }

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
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("LogIn");
            }

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
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("LogIn");
            }

            return View("AddProduct", "_LayoutAdmin");
        }

        public ActionResult DeleteCart(int fId)
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("LogIn");
            }

            var od = db.tOrderDetail
                .Where(d => d.fId == fId)
                .FirstOrDefault();

            db.tOrderDetail.Remove(od);
            db.SaveChanges();

            return RedirectToAction("ShoppingCart");
        }

        public ActionResult AddCart(string fPId)
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                return RedirectToAction("LogIn");
            }
            
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

            if (level == "1")
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

            if (level == "1")
                return View("OrderDetail", "_LayoutMember", list);

            return View("OrderDetail", "_LayoutAdmin", list);
        }
        public ActionResult LogOut()
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
                string level = (Session[CDictionary.SK_LOGINED_USER] as tMember).fLevel;
                if (level == "1")
                {
                    return View("Index", "_LayoutMember", list);
                }
            }

            return View("Index", "_LayoutAdmin", list);
        }

    }
}