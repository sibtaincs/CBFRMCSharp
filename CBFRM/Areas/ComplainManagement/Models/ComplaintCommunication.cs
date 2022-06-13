using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBFRM.Areas.ComplainManagement.Models
{
    public class ComplaintCommunication
    {
        public int CommunityBasedComplaintID { get; set; }
        public bool FromPersonFlag { get; set; }
        public string UpdateUser { get; set; }


        public int AckEDWPersonID { get; set; }
        public System.DateTime AckCommunicationDate { get; set; }
        public byte AckCommunicationStageID { get; set; }
        public Nullable<byte> AckCommunicationMethodID { get; set; }
   
        public string AckOtherCCMText { get; set; }


        public int InternalEDWPersonID { get; set; }
        public System.DateTime InternalCommunicationDate { get; set; }
        public System.DateTime InternaltxtHQCommunicationDate { get; set; }
        public byte InternalCommunicationStageID { get; set; }
        public Nullable<byte> InternalCommunicationMethodID { get; set; }
        public string InternalComment { get; set; }
      
        public string  InternalOtherCCMText { get; set; }




        public int FirstResponseEDWPersonID { get; set; }
        public Nullable<System.DateTime> FirstResponseCommunicationDate { get; set; }
        public byte FirstResponseCommunicationStageID { get; set; }
        public Nullable<byte> FirstResponseCommunicationMethodID { get; set; }
        //public string FirstResponseComment { get; set; }
        public string FirstResponseOtherCCMText { get; set; }

        public int AppealResponseEDWPersonID { get; set; }
        public int ResponseProvidedFlagAppeal { get; set; }
        public Nullable<System.DateTime> AppealResponseCommunicationDate { get; set; }
        public byte AppealResponseCommunicationStageID { get; set; }
        public Nullable<byte> AppealResponseCommunicationMethodID { get; set; }
        //public string AppealResponseComment { get; set; }
        public string AppealResponseOtherCCMText { get; set; }
    }
}