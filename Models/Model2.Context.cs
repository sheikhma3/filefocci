﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Database1Entities2 : DbContext
    {
        public Database1Entities2()
            : base("name=Database1Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<address> addresses { get; set; }
        public DbSet<addressLabel> addressLabels { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<contactCTag> contactCTags { get; set; }
        public DbSet<contact1> contacts1 { get; set; }
        public DbSet<ctagofcontct> ctagofcontcts { get; set; }
        public DbSet<dateLabel> dateLabels { get; set; }
        public DbSet<date> dates { get; set; }
        public DbSet<email> emails { get; set; }
        public DbSet<emailLabel> emailLabels { get; set; }
        public DbSet<ftag> ftags { get; set; }
        public DbSet<ftagdetail> ftagdetails { get; set; }
        public DbSet<fTagDetail1> fTagDetails1 { get; set; }
        public DbSet<login> logins { get; set; }
        public DbSet<mobileNo> mobileNoes { get; set; }
        public DbSet<mobileNoLabel> mobileNoLabels { get; set; }
        public DbSet<relativeName> relativeNames { get; set; }
        public DbSet<relativeNameLabel> relativeNameLabels { get; set; }
        public DbSet<socialProfile> socialProfiles { get; set; }
        public DbSet<socialProfileLabel> socialProfileLabels { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<urlLabel> urlLabels { get; set; }
        public DbSet<url> urls { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<userCTag> userCTags { get; set; }
        public DbSet<userFTag> userFTags { get; set; }
    }
}