using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBFRM.Areas.ComplainManagement
{
    public class ComplainManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ComplainManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ComplainManagement_default",
                "ComplainManagement/{controller}/{action}/{id}",
                 new { controller = "ComplainManagement/ComplainDetails", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}