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
    
    public partial class socialProfileLabel
    {
        public int Id { get; set; }
        public Nullable<int> uid { get; set; }
        public string label { get; set; }
    
        public virtual login login { get; set; }
    }
}
