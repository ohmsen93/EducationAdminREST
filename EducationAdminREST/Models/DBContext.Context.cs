﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EducationAdminREST.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class roll_call_dbEntities : DbContext
    {
        public roll_call_dbEntities()
            : base("name=roll_call_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<address> addresses { get; set; }
        public virtual DbSet<attendance_record> attendance_record { get; set; }
        public virtual DbSet<campu> campus { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<@class> classes { get; set; }
        public virtual DbSet<classroom> classrooms { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<faculty> faculties { get; set; }
        public virtual DbSet<gps_coordinates> gps_coordinates { get; set; }
        public virtual DbSet<lecture> lectures { get; set; }
        public virtual DbSet<network> networks { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<teacher> teachers { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<authority> authorities { get; set; }
    }
}