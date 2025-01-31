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
    
    public partial class PackageDefinitions
    {
        public long Id { get; set; }
        public Nullable<int> TenantId { get; set; }
        public int Purpose { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> LastModifierUserId { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<long> DeleterUserId { get; set; }
        public Nullable<System.DateTime> DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Identifier { get; set; }
        public string Version { get; set; }
        public string ComparableVersion { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Owners { get; set; }
        public string IconUrl { get; set; }
        public string LicenseUrl { get; set; }
        public string ProjectUrl { get; set; }
        public bool RequireLicenseAcceptance { get; set; }
        public bool DevelopmentDependency { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string ReleaseNotes { get; set; }
        public string Language { get; set; }
        public string Tags { get; set; }
        public string Copyright { get; set; }
        public string MinClientVersion { get; set; }
        public string ReportAbuseUrl { get; set; }
        public int DownloadCount { get; set; }
        public bool Listed { get; set; }
        public bool IsSemVer2 { get; set; }
        public string Dependencies { get; set; }
        public long PackageSize { get; set; }
        public string PackageHash { get; set; }
        public string PackageHashAlgorithm { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public System.DateTime Created { get; set; }
        public string FullPath { get; set; }
        public string NormalizedVersion { get; set; }
        public bool SemVer1IsAbsoluteLatest { get; set; }
        public bool SemVer1IsLatest { get; set; }
        public bool SemVer2IsAbsoluteLatest { get; set; }
        public bool SemVer2IsLatest { get; set; }
        public bool IsPrerelease { get; set; }
        public System.DateTime Published { get; set; }
    }
}
