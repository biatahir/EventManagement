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
    
    public partial class Notification
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTime> AddedON { get; set; }
        public Nullable<int> AddedBY { get; set; }
        public Nullable<bool> Status { get; set; }
        public int AttendesID { get; set; }
    
        public virtual Attende Attende { get; set; }
        public virtual Event Event { get; set; }
    }
}
