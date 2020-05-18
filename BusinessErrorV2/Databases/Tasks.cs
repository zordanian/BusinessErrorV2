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
    
    public partial class Tasks
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public Nullable<long> AssignedToUserId { get; set; }
        public string FormLayout { get; set; }
        public string Data { get; set; }
        public string Action { get; set; }
        public int Type { get; set; }
        public int TenantId { get; set; }
        public long OrganizationUnitId { get; set; }
        public byte[] RowVersion { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<long> LastModifierUserId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<long> DeleterUserId { get; set; }
        public Nullable<System.DateTime> DeletionTime { get; set; }
        public Nullable<long> TaskCatalogId { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
    
        public virtual TaskCatalogs TaskCatalogs { get; set; }
        public virtual Users Users { get; set; }
    }
}
