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
    
    public partial class network
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public network()
        {
            this.students = new HashSet<student>();
        }
    
        public int id { get; set; }
        public string ssid { get; set; }
        public string ip_address { get; set; }
        public int faculty_id { get; set; }
    
        public virtual faculty faculty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student> students { get; set; }
    }
}
