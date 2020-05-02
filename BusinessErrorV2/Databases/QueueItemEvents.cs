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
    
    public partial class QueueItemEvents
    {
        public long Id { get; set; }
        public int TenantId { get; set; }
        public long OrganizationUnitId { get; set; }
        public long QueueItemId { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public int Action { get; set; }
        public long UserId { get; set; }
        public int Status { get; set; }
        public int ReviewStatus { get; set; }
        public Nullable<long> ReviewerUserId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
    
        public virtual QueueItems QueueItems { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
