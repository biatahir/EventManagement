//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventManagement.DataAccess.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class QRHistory
    {
        public int ID { get; set; }
        public int QRid { get; set; }
        public int AttendesID { get; set; }
        public Nullable<System.DateTime> CommentON { get; set; }
    
        public virtual Attende Attende { get; set; }
        public virtual QRCode QRCode { get; set; }
    }
}
