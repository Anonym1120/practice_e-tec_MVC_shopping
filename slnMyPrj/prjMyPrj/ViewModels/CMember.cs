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
        public string fUserId { get; set; }
        public string fPassword { get; set; }
        public string fName { get; set; }
        public string fEmail { get; set; }
        public string fLevel { get; set; }
    }
    
}