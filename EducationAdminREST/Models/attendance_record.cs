//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class attendance_record
    {
        public int student_id { get; set; }
        public int lecture_id { get; set; }
        public sbyte is_attending { get; set; }
        public System.DateTime registred_at { get; set; }
    
        public virtual lecture lecture { get; set; }
        public virtual student student { get; set; }
    }
}
