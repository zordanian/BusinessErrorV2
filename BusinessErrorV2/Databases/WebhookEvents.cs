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
    
    public partial class WebhookEvents
    {
        public long Id { get; set; }
        public long WebhookId { get; set; }
        public string EventType { get; set; }
    
        public virtual Webhooks Webhooks { get; set; }
    }
}
