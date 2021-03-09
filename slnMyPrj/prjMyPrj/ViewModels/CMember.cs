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
        public int fId { get { return _member.fId; } set { _member.fId = value; } }

        [DisplayName("帳號")]
        public string fUserId { get { return _member.fUserId; } set { _member.fUserId = value; } }

        [DisplayName("密碼")]
        public string fPassword { get { return _member.fPassword; } set { _member.fPassword = value; } }

        [DisplayName("姓名")]
        public string fName { get { return _member.fName; } set { _member.fName = value; } }

        [DisplayName("信箱")]
        public string fEmail { get { return _member.fEmail; } set { _member.fEmail = value; } }

        [DisplayName("權限")]
        public string fLevel { get { return _member.fLevel; } set { _member.fLevel = value; } }
    }
    
}