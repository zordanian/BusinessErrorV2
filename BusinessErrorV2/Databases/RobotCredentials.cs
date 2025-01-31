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
    
    public partial class RobotCredentials
    {
        public long RobotId { get; set; }
        public string UserName { get; set; }
        public string PasswordKey { get; set; }
        public int TenantId { get; set; }
        public Nullable<long> OrganizationUnitId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<long> DeleterUserId { get; set; }
        public Nullable<System.DateTime> DeletionTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<long> LastModifierUserId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public int Type { get; set; }
        public string ExternalName { get; set; }
        public long CredentialStoreId { get; set; }
    
        public virtual CredentialStores CredentialStores { get; set; }
        public virtual Robots Robots { get; set; }
    }
}
