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
    
    public partial class PreviousPasswords
    {
        public long Id { get; set; }
        public string PasswordHash { get; set; }
        public long UserId { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public string Hasher { get; set; }
        public Nullable<int> TenantId { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
