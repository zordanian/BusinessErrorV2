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
    
    public partial class RobotLicenseLogs
    {
        public long Id { get; set; }
        public Nullable<long> RobotId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int RobotType { get; set; }
        public int TenantId { get; set; }
        public int Scope { get; set; }
        public string Key { get; set; }
    
        public virtual Robots Robots { get; set; }
    }
}
