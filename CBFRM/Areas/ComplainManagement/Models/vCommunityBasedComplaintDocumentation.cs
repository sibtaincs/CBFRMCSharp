//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CBFRM.Areas.ComplainManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vCommunityBasedComplaintDocumentation
    {
        public int CommunityBasedComplaintDocID { get; set; }
        public int CommunityBasedComplaintID { get; set; }
        public string DocumentHyperlink { get; set; }
        public string SupportingDocumentDescription { get; set; }
        public string UpdateUser { get; set; }
        public bool SourceDeletedFlag { get; set; }
        public System.DateTime CreateTimestamp { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime LastUpdateTimestamp { get; set; }
        public string LastUpdateUser { get; set; }
        public bool AppealDocumentFlag { get; set; }
    }
}