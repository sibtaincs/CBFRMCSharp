

using CBFRM.Areas.ComplainManagement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBFRM.Areas.ComplainManagement.Controllers
{

    public class ComplainDetailsController : Controller
    {

        // ComplainManagement/ComplainDetails
        UserViewModel uvm = new UserViewModel();
        EDWEntities db = new EDWEntities();
        public ActionResult Index()
        {
            uvm.spEditCBS = db.spEDITCommunityBasedComplaintDetails(0,"1888-12-12", "1888-12-12", "0","").ToList();
            uvm.spgetStatus = db.spGetComplaintStatus().ToList();
            uvm.spEditComplainDetails = db.spEDITComplainantDetail(0).ToList();
            uvm.spEditComplaintAppeal = db.spEDITComplaintAppeal(0).ToList();
            uvm.spEditComplaintCommunication = db.spEDITComplaintCommunication(0).ToList();
            uvm.spEditlocation = db.spEDITComplaintLocation(0).ToList();
            uvm.spEditResolution = db.spEDITComplaintResolution(0).ToList();
            uvm.spEditVulnerability = db.spEDITComplaintVulnerability(0).ToList();
            uvm.spEditExternal = db.spEDITExternalReferral(0).ToList();
            uvm.spEditFieldSector = db.spEDITFieldSector(0).ToList();
            uvm.spEditAppealCommittee = db.spEDITAppealCommittee2(0).ToList();
            uvm.spGetCountry = db.spGetCountriesforUserManager().ToList();
            return View(uvm);
        }

        public JsonResult GetData(string statusid, string SDate, string EDate,string CountryCode)
        {
            try
            {
                //string starttime = "";
                //string endtime = "";
                //if (SDate != "" && EDate != "")
                //{
                //    Session["EFSDate"] = DateTime.ParseExact(SDate, "dd/MM/yyy", null);
                //    Session["EFEDate"] = DateTime.ParseExact(EDate, "dd/MM/yyy", null);
                //    starttime = DateTime.ParseExact(SDate, "dd/MM/yyy", CultureInfo.InvariantCulture)
                //                      .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                //    endtime = DateTime.ParseExact(EDate, "dd/MM/yyy", CultureInfo.InvariantCulture)
                //                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                //}
                uvm.spEditCBS = db.spEDITCommunityBasedComplaintDetails(0, SDate, EDate, statusid, CountryCode).ToList();
            }
            catch (Exception e)
            {
                ViewBag["Error"] = e.Message;
            }


            return Json(uvm.spEditCBS, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            //ComplainManagement/ComplainDetailsDelete
            string msg = "Deleted";
            try
            {
                uvm.spdeleteCBC = db.spDelete_CBCDetails(ID).ToList(); ;

                uvm.spEditCBS = db.spEDITCommunityBasedComplaintDetails(0, "1888-12-12", "1888-12-12", "0", "").ToList();
                uvm.spgetStatus = db.spGetComplaintStatus().ToList();
                uvm.spEditComplainDetails = db.spEDITComplainantDetail(0).ToList();
                uvm.spEditComplaintAppeal = db.spEDITComplaintAppeal(0).ToList();
                uvm.spEditComplaintCommunication = db.spEDITComplaintCommunication(0).ToList();
                uvm.spEditlocation = db.spEDITComplaintLocation(0).ToList();
                uvm.spEditResolution = db.spEDITComplaintResolution(0).ToList();
                uvm.spEditVulnerability = db.spEDITComplaintVulnerability(0).ToList();
                uvm.spEditExternal = db.spEDITExternalReferral(0).ToList();
                uvm.spEditFieldSector = db.spEDITFieldSector(0).ToList();
                uvm.spEditAppealCommittee = db.spEDITAppealCommittee2(0).ToList();
                uvm.spGetCountries = db.spGetCountry().ToList();
            }
            catch (Exception e)
            {

                msg = e.Message;
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}