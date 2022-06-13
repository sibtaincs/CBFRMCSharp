using CBFRM.Areas.ComplainManagement.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBFRM
{
   public class CustomActionAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            EDWEntities db = new EDWEntities();
           
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string AreaName = filterContext.RouteData.DataTokens["area"].ToString();
            var IPAddress = filterContext.HttpContext.Request.UserHostAddress;
            string filePath = filterContext.HttpContext.Request.FilePath.ToString();

            string AccessedForm = AreaName + '/' + controllerName + '/' + actionName;

            if (HttpContext.Current.Session["EDWPersonID"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {

                    filterContext.Result = new JsonResult
                    {
                        Data = "Session Time Out",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    return;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/ComplaintManagement/Login/Index");
                    return;
                }

            }
            ////AccessedForm.ToLower().Contains("existingonsiteincident") &&
            //else if (AccessedForm == "ComplainManagement/ComplainDetails/Index")
            //{
            //    HttpContext.Current.Session["FormID"] = 0;
            //    HttpContext.Current.Session["ModuleID"] = 0;
            //    HttpContext.Current.Session["ModuleName"] = 0;
            //    HttpContext.Current.Session["ModuleLogo"] = "/Content/assets/layouts/layout/img/IMS3.gif";
                

            //}
            //else if (AccessedForm == "ComplainManagement/ComplainForm/Index")
            //{
            //    HttpContext.Current.Session["FormID"] = 0;
            //    HttpContext.Current.Session["ModuleID"] = 0;
            //    HttpContext.Current.Session["ModuleName"] = 0;
            //    HttpContext.Current.Session["ModuleLogo"] = "/Content/assets/layouts/layout/img/IMS3.gif";


            //}
            //else if (Convert.ToInt64(HttpContext.Current.Session["ModuleID"]) > 0 && filterContext.HttpContext.Request.IsAjaxRequest() == false)
            else if (filterContext.HttpContext.Request.IsAjaxRequest() == false)
            {
                bool isAllowed = false;
                bool IsExistInFormList = true;
                
            


               

                if (isAllowed == false && IsExistInFormList == true)
                {
                    filterContext.Result = new RedirectResult("~/ComplaintManagement/Error/Index");
                    return;

                }
            }




            base.OnActionExecuting(filterContext);

        }
        

     }
}