using CBFRM.Areas.ComplainManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBFRM.Areas.ComplainManagement.Controllers
{
    public class DashboardController : Controller
    {
        // GET: ComplainManagement/Dashboard
        UserViewModel uvm = new UserViewModel();
        // this class is use to call all usermanagement stored procedure in which usermanagement procdure instances are created
        EDWEntities db = new EDWEntities(); // user management entiies are use to call all database model of UMS where we have db model of UMS
        public ActionResult Index()
        {
            uvm.spGetCountry = db.spGetCountriesforUserManager().ToList();
            uvm.spGetAppealCommitteName = db.spGetAppealCommitteNames().ToList();
        
            uvm.spEDITAdminGroup = db.spEDITAdminGroup().ToList();

            uvm.spEDITITGroup = db.spEDITITGroup().ToList();

            uvm.spEDITHQGroup = db.spEDITHQGroup().ToList();
            uvm.spEDITMealCordinator = db.spEDITMealCordinator().ToList();
            uvm.spEditOfficer = db.spEditOfficer("").ToList();
            return View(uvm);
        }

        public JsonResult SaveAdminGroup(List<vComplaintAppealCommittee> AC)
        {
            string msg = "";
            try
            {
                msg = "Saved";


                uvm.spDelete_CBFAdminGroup = db.spDelete_CBFAdminGroup().ToList();
                foreach (vComplaintAppealCommittee ac in AC)
                {    //AppealCommittee  loop will be used 
                    uvm.spSave_CBFAdminGroup = db.spSave_CBFAdminGroup(Convert.ToInt32(ac.EDWPersonID)).ToList();

                }
            }
            catch (Exception ex)
            {

                msg = "Error-" + ex;

            }

            return Json(msg, JsonRequestBehavior.AllowGet);


        }

        public JsonResult SaveITGroup(List<vComplaintAppealCommittee> AC)
        {
            string msg = "";
            try
            {
                msg = "Saved";

                ////
                uvm.spDelete_CBFITGroup = db.spDelete_CBFITGroup().ToList();
                foreach (vComplaintAppealCommittee ac in AC)
                {    //AppealCommittee  loop will be used 
                    uvm.spSave_CBFITGroup = db.spSave_CBFITGroup(Convert.ToInt32(ac.EDWPersonID)).ToList();

                }
            }
            catch (Exception ex)
            {

                msg = "Error-" + ex;

            }

            return Json(msg, JsonRequestBehavior.AllowGet);


        }
        public JsonResult SaveHQGroup(List<vComplaintAppealCommittee> AC)
        {
            string msg = "";
            try
            {
                msg = "Saved";


                uvm.spDelete_CBFHQGroup = db.spDelete_CBFHQGroup().ToList();
                foreach (vComplaintAppealCommittee ac in AC)
                {
                    uvm.spSave_CBFHQGroup = db.spSave_CBFHQGroup(Convert.ToInt32(ac.EDWPersonID)).ToList();

                }
            }
            catch (Exception ex)
            {

                msg = "Error-" + ex;

            }

            return Json(msg, JsonRequestBehavior.AllowGet);


        }
        public JsonResult SaveMealCord(List<MealCordinatorClass> AC)
        {
            string msg = "";
            try
            {
                msg = "Saved";



                uvm.spDelete_CBFMealCordinator = db.spDelete_CBFMealCordinator(AC[0].CountryCode).ToList();
                foreach (MealCordinatorClass ac in AC)
                {
                    uvm.spSave_CBFMealCordinator = db.spSave_CBFMealCordinator(ac.EDWPersonID, ac.CountryCode).ToList();

                }
            }
            catch (Exception ex)
            {

                msg = "Error-" + ex;

            }

            return Json(msg, JsonRequestBehavior.AllowGet);


        }

        public JsonResult SaveOfficers(List<OfficrClass> AC)
        {
            string msg = "";
            try
            {
                msg = "Saved";



                uvm.spDelete_CBFOfficers = db.spDelete_CBFOfficers(AC[0].CountryCode).ToList();
                foreach (OfficrClass item in AC)
                {
                    uvm.spSave_CBFOfficer = db.spSave_CBFOfficer(item.EDWPersonID, item.CountryCode, item.FieldSiteCode).ToList();
                }



        
                //public List<spEditOfficer_Result> spEditOfficer = new List<spEditOfficer_Result>();




            }
            catch (Exception ex)
            {

                msg = "Error-" + ex;

            }

            return Json(msg, JsonRequestBehavior.AllowGet);


        }


        public JsonResult OfficersEdit(string id)
        {
          
            try
            {
                if (id != null)
                {
                    uvm.spGetFieldSiteCode = db.spGetFieldSiteByID(id).ToList();
                    uvm.spEditOfficer = db.spEditOfficer(id).ToList();

                }
                else
                {
                    TempData["message"] = "Please search Name";
                }
            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }
            return Json(uvm, JsonRequestBehavior.AllowGet);

        }
        public JsonResult MealCodinators(string id)
        {

            try
            {
                if (id != null)
                {
                    uvm.spGetAppealCommitteName = db.spGetAppealCommitteNames().ToList();
                    uvm.spMealCordinator = db.spMealCordinator(id).ToList();
                }
                else
                {
                    TempData["message"] = "Please search Name";
                }
            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }
            return Json(uvm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Officers(string UserName)
        {
            try
            {
                var items = UserName.Split('-');
                uvm.spGetvvUser = db.spGetvUserAssign2(items[0]).ToList();

            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spGetvvUser, JsonRequestBehavior.AllowGet);
        }
    }
}