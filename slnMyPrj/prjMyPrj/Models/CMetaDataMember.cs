using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMyPrj.Models
{
    [MetadataType(typeof(CMetaDataMember))]
    public partial class tMember
    {
        public class CMetaDataMember
        {
            //[DisplayName("自動編號")]
            public int fId { get; set; }

            [DisplayName("帳號")]
            [Required(ErrorMessage = "請輸入帳號")]
            public string fUserId { get; set; }

            [DisplayName("密碼")]
            [Required(ErrorMessage = "請輸入密碼")]
            public string fPassword { get; set; }

            [DisplayName("姓名")]
            [Required(ErrorMessage = "請輸入姓名")]
            public string fName { get; set; }

            [DisplayName("信箱")]
            [Required(ErrorMessage = "請輸入信箱")]
            public string fEmail { get; set; }

            [DisplayName("權限")]
            public string fLevel { get; set; }

            [DisplayName("帳號狀態")]
            public string fUsing { get; set; }
        }
    }
    
}