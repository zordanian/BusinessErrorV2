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
    
    public partial class OrganizationUnitRoles
    {
        public long Id { get; set; }
        public Nullable<int> TenantId { get; set; }
        public int RoleId { get; set; }
        public long OrganizationUnitId { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
    }
}
