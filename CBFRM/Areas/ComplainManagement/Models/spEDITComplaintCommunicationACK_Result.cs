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
    
    public partial class spEDITComplaintCommunicationACK_Result
    {
        public int CommunityBasedComplaintID { get; set; }
        public int EDWPersonID { get; set; }
        public string CommunicationDate { get; set; }
        public byte CommunicationStageID { get; set; }
        public Nullable<byte> CommunicationMethodID { get; set; }
        public string Comment { get; set; }
        public string OtherComplaintCommunicationMethodText { get; set; }
        public bool FromPersonFlag { get; set; }
        public string UpdateUser { get; set; }
        public string FullName { get; set; }
    }
}
