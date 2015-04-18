//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class contact1
    {
        public contact1()
        {
            this.addresses = new HashSet<address>();
            this.contactCTags = new HashSet<contactCTag>();
            this.dates = new HashSet<date>();
            this.emails = new HashSet<email>();
            this.fTagDetails = new HashSet<fTagDetail1>();
            this.mobileNoes = new HashSet<mobileNo>();
            this.relativeNames = new HashSet<relativeName>();
            this.socialProfiles = new HashSet<socialProfile>();
            this.urls = new HashSet<url>();
        }
    
        public int Id { get; set; }
        public Nullable<int> uid { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dob { get; set; }
        public string note { get; set; }
        public string phoneticFirstName { get; set; }
        public string phoneticMiddleName { get; set; }
        public string phoneticLastName { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public string nickName { get; set; }
        public string jobTitle { get; set; }
        public string company { get; set; }
        public string department { get; set; }
    
        public virtual ICollection<address> addresses { get; set; }
        public virtual ICollection<contactCTag> contactCTags { get; set; }
        public virtual login login { get; set; }
        public virtual ICollection<date> dates { get; set; }
        public virtual ICollection<email> emails { get; set; }
        public virtual ICollection<fTagDetail1> fTagDetails { get; set; }
        public virtual ICollection<mobileNo> mobileNoes { get; set; }
        public virtual ICollection<relativeName> relativeNames { get; set; }
        public virtual ICollection<socialProfile> socialProfiles { get; set; }
        public virtual ICollection<url> urls { get; set; }
    }
}
