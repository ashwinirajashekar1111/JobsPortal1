//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostJobTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PostJobTable()
        {
            this.JobRequirementDetailsTables = new HashSet<JobRequirementDetailsTable>();
        }
    
        public int PostJobID { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public int JobCategoryID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public string Location { get; set; }
        public int Vacancy { get; set; }
        public int JobNatureID { get; set; }
        public System.DateTime PostDate { get; set; }
        public System.DateTime ApplicationDeadline { get; set; }
        public System.DateTime LastDate { get; set; }
        public int JobStatusID { get; set; }
    
        public virtual CompanyTable CompanyTable { get; set; }
        public virtual JobCategoryTable JobCategoryTable { get; set; }
        public virtual JobNatureTable JobNatureTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobRequirementDetailsTable> JobRequirementDetailsTables { get; set; }
        public virtual JobStatusTable JobStatusTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
