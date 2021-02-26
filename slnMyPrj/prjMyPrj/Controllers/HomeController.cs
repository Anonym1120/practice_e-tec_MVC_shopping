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

        //[HttpPost]
        //public ActionResult ShoppingCart() 
        //{
        //    return View();
        //}
        public ActionResult ShoppingCart()
        {
            string user = (Session[CDictionary.SK_LOGINED_USER] as tMember).fUserId;

            var table = db.tOrderDetail
                .Where(m => m.fUserId == user && m.fIsApproved == "N").ToList();
            List<COrderDetail> list = new List<COrderDetail>();
            foreach (tOrderDetail o in table) 
            {
                list.Add(new COrderDetail(o));
            }
            
            return View("ShoppingCart", "_LayoutMember", list);
        }
        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult LogIn()
        {
            return View();
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

            return View("Index", "_LayoutMember", list);
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