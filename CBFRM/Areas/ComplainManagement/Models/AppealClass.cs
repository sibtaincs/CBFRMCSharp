using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBFRM.Areas.ComplainManagement.Models
{
    public class AppealClass
    {
        public int CommunityBasedComplaintID { get; set; }

       
        public Nullable<System.DateTime> AppealDate { get; set; }
        public string ProcessDescription { get; set; }
        public Nullable<byte> AppealReceivedCommunicationMethodID { get; set; }
        public string AppealResolutionDescription { get; set; }
        public Nullable<System.DateTime> AppealResolutionDate { get; set; }
        public string UpdateUser { get; set; }
        public bool SourceDeletedFlag { get; set; }
        public System.DateTime CreateTimestamp { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime LastUpdateTimestamp { get; set; }
        public string LastUpdateUser { get; set; }
        public string OtherComplaintCommunicationMethodText { get; set; }
    }

    public class MealCordinatorClass
    {
        public int EDWPersonID { get; set; }

        public string CountryCode { get; set; }
       
    }


    public class OfficrClass
    {
        public int EDWPersonID { get; set; }

        public string CountryCode { get; set; }

        public string FieldSiteCode { get; set; }
    }
}