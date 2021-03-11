﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using prjMyPrj.Models;

namespace prjMyPrj.ActionFilter
{
    public class CLoginActionFilter : ActionFilterAttribute
    {
        public bool check = false;
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            HttpContext httpcontext = HttpContext.Current;
            var user = httpcontext.Session[CDictionary.SK_LOGINED_USER];

            if (check)
            {
                if (user == null)
                {
                    httpcontext.Response.Redirect("/Home/LogIn");
                }
            }
            

            base.OnResultExecuting(filterContext);
        }
    }
}