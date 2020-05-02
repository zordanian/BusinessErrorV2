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
    
    public partial class QueueProcessingRecordsOld
    {
        public long Id { get; set; }
        public long QueueDefinitionId { get; set; }
        public System.DateTime ProcessingTime { get; set; }
        public int ReportType { get; set; }
        public int NumberOfApplicationExceptions { get; set; }
        public int NumberOfBusinessExceptions { get; set; }
        public int NumberOfSuccessfulTransactions { get; set; }
        public int NumberOfRetriedItems { get; set; }
        public decimal ApplicationExceptionsProcessingTime { get; set; }
        public decimal BusinessExceptionsProcessingTime { get; set; }
        public decimal SuccessfulTransactionsProcessingTime { get; set; }
        public int TenantId { get; set; }
        public long OrganizationUnitId { get; set; }
        public int NumberOfRemainingTransactions { get; set; }
        public int NumberOfInProgressTransactions { get; set; }
    
        public virtual QueueDefinitions QueueDefinitions { get; set; }
    }
}
