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
    
    public partial class fTagDetail1
    {
        public int Id { get; set; }
        public Nullable<int> uid { get; set; }
        public Nullable<int> fid { get; set; }
        public Nullable<int> cid { get; set; }
        public string orignalName { get; set; }
        public string virtualName { get; set; }
        public string url { get; set; }
    
        public virtual contact1 contact { get; set; }
        public virtual login login { get; set; }
        public virtual userFTag userFTag { get; set; }
    }
}
