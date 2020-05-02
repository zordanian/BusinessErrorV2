//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessErrorV2.Databases
{
    using System;
    using System.Collections.Generic;
    
    public partial class Releases
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Releases()
        {
            this.AssetValues = new HashSet<AssetValues>();
            this.Jobs = new HashSet<Jobs>();
            this.ProcessSchedules = new HashSet<ProcessSchedules>();
            this.ReleaseVersions = new HashSet<ReleaseVersions>();
        }
    
        public long Id { get; set; }
        public int TenantId { get; set; }
        public System.Guid Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProcessKey { get; set; }
        public bool Unattended { get; set; }
        public bool AllowMultiInstance { get; set; }
        public long EnvironmentId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<long> DeleterUserId { get; set; }
        public Nullable<System.DateTime> DeletionTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<long> LastModifierUserId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public long OrganizationUnitId { get; set; }
        public string InputArguments { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetValues> AssetValues { get; set; }
        public virtual Environments Environments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jobs> Jobs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcessSchedules> ProcessSchedules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReleaseVersions> ReleaseVersions { get; set; }
    }
}
