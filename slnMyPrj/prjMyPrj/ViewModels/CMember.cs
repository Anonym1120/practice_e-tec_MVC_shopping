using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using prjMyPrj.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMyPrj.ViewModels
{
    public class CMember
    {
        private tMember _member;
        public CMember(tMember m)
        {
            _member = m;
        }
        public int fId { get; set; }

        [DisplayName("帳號")]
        public string fUserId { get; set; }

        [DisplayName("密碼")]
        public string fPassword { get; set; }

        [DisplayName("姓名")]
        public string fName { get; set; }

        [DisplayName("信箱")]
        public string fEmail { get; set; }

        [DisplayName("權限")]
        public string fLevel { get; set; }
    }
    
}