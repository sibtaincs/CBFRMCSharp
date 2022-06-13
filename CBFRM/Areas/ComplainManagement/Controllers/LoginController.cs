using CBFRM.AD;
using CBFRM.Areas.ComplainManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CBFRM.Areas.ComplainManagement.Controllers
{

    public class LoginController : Controller
    {
        // GET: ComplainManagement/Login
        // GET: UserManagement/Login
        //index metho is page load method where we call session abandon method to kill session 
        // than we have try login method which is called form view to controll when some one logins
        //inside try login method we are authenticating active directory of IMS once AD is atheticated true 
        //then we check user name from our ims database and get details then user role details according to role assiged 
        // user will be redirected to  Modules if user is general or only admin user than only IMS module will be shown to him after login 
        //if user is super admin he will see both Usermanagenemt and IMS midle 
        //to access data from database we use Stored procedures to get data from database


        UserViewModel uvm = new UserViewModel();
        EDWEntities db = new EDWEntities();
        public ActionResult Index()
        {

            Session.Abandon();
            //LogOutHistory();
            return View(uvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TryLogin(string UserLoginID, string Password ,string returnUrl)
        {
            string Domain = "IMC";
            bool isAuthenticated = true;
            if (Domain == "IMC")
            {
                string adPath = "LDAP://" + Domain;
                LdapAuthentication adAuth = new LdapAuthentication(adPath);
                try
                {
                    if (true == adAuth.IsAuthenticated(Domain, UserLoginID, Password))
                    {
                        FormsAuthentication.SetAuthCookie(UserLoginID, true);
                        if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return this.Redirect(returnUrl);
                        }

                        isAuthenticated = true;
                    }
                }
                catch (Exception ex)
                {
                    TempData["message"] = "Enter Valid Login ID or Password is not correct.";
                    return RedirectToAction("Index", "Login");
                }
                try
                {
                    if (isAuthenticated)
                    {  
                        uvm.spGetvvUserDetail = db.spGetvvUserDetails(UserLoginID).ToList();
                    
                        if (uvm.spGetvvUserDetail.Count != 0)
                        {
                            long PersonsID=0;
                            foreach (var item in uvm.spGetvvUserDetail)
                            {
                                PersonsID = Convert.ToInt64(item.EDWPersonID);

                            }
                            //uvm.spGetManagerRole = db.spGetvUserManager(PersonsID).ToList();
                           
                            //bool IsAdmin = false;
                            //if (uvm.spGetManagerRole.Count > 0)
                            //{
                            //    foreach (var item in uvm.spGetManagerRole)
                            //    {
                            //        if (item.GroupName != null)
                            //        {
                            //            IsAdmin = true;
                            //            //GroupName = item.RoleID.ToString();
                            //            //break;
                                       
                            //        }
                            //    }
                            //}
                            //if (uvm.spGetManagerRole.Count > 0 && IsAdmin == false)
                            //{

                            //    TempData["LoginID"] = UserLoginID;
                            //    TempData["Password"] = Password;
                            //    return View("Index", uvm);
                               
                            //}
                            Session["Email"] = uvm.spGetvvUserDetail[0].WorkEmailAddress;
                            Session["UserName"] = uvm.spGetvvUserDetail[0].FullName;
                            Session["saMAccountName"] = uvm.spGetvvUserDetail[0].saMAccountName;
                            Session["FullName"] = uvm.spGetvvUserDetail[0].FullName;
                            Session["FirstName"] = uvm.spGetvvUserDetail[0].FirstName;
                            Session["CPMasterEmployeeId"] = uvm.spGetvvUserDetail[0].CPMasterEmployeeId;
                            Session["EDWPersonID"] = uvm.spGetvvUserDetail[0].EDWPersonID;
                            //return RedirectToAction("Index", "ComplainDetails");
                        }

                        else
                        {
                            TempData["message"] = "Enter Valid Login ID or Password is not correct.";
                            return RedirectToAction("Index", "Login");
                        }
                    }
                }
                catch (Exception ex)
                {

                    TempData["message"] = ex.InnerException.Message;
                    return RedirectToAction("Index", "Login");
                }

            }
            return RedirectToAction("Index", "ComplainDetails");

        }
        


    }
}