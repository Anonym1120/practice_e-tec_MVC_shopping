//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjMyPrj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tOrderDetail
    {
        public int fId { get; set; }
        public string fOrderId { get; set; }
        public string fUserId { get; set; }
        public string fPId { get; set; }
        public string fName { get; set; }
        public Nullable<int> fPrice { get; set; }
        public Nullable<int> fQty { get; set; }
        public string fIsApproved { get; set; }
    }
}
