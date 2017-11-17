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
    
    public partial class SocialForum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SocialForum()
        {
            this.ForumSocialComments = new HashSet<ForumSocialComment>();
            this.PostUserLikes = new HashSet<PostUserLike>();
        }
    
        public int ID { get; set; }
        public int EventID { get; set; }
        public string URL { get; set; }
        public Nullable<System.DateTime> UploadON { get; set; }
        public Nullable<int> UploadBY { get; set; }
        public string Description { get; set; }
        public int PostTypeid { get; set; }
        public Nullable<System.DateTime> ApprovedON { get; set; }
        public Nullable<int> ApprovedBY { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> TotalLikes { get; set; }
        public int AttendesID { get; set; }
    
        public virtual Attende Attende { get; set; }
        public virtual Event Event { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumSocialComment> ForumSocialComments { get; set; }
        public virtual PostType PostType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostUserLike> PostUserLikes { get; set; }
    }
}