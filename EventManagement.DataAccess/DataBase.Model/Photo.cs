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
    
    public partial class Photo
    {
        public int ID { get; set; }
        public Nullable<int> EventID { get; set; }
        public string URL { get; set; }
        public Nullable<System.DateTime> UploadON { get; set; }
        public Nullable<int> UploadBY { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Event Event { get; set; }
    }
}