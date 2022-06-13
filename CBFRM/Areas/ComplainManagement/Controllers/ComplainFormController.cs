using CBFRM.Areas.ComplainManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CBFRM.Areas.ComplainManagement.Controllers
{

    public class ComplainFormController : Controller
    {

        // GET: ComplainManagement/ComplainForm

        UserViewModel uvm = new UserViewModel();
        EDWEntities db = new EDWEntities();
        public ActionResult Index()
        {
            TempData["ComplaintID"] = 0;

            //uvm.spGetSearchUser = db.spGetvSearchUser("").ToList();
            uvm.spGetAppealCommitteName = db.spGetAppealCommitteNames().ToList(); 
            uvm.spGetCommunicationMethod = db.spGetvCommunicationMethod().ToList();
            uvm.spGetCommunicationMethodGeneral = db.spGetvCommunicationMethodGenral().ToList();
            uvm.spGetvCMEthics = db.spGetvCommunicationMethodEthics().ToList();
            uvm.spGetCountries = db.spGetCountry().ToList();
            uvm.spGetCBCDcouments = db.spGetvCommunityBasedComplaintDocumentation(0).ToList();
            uvm.spGetReferrallevel = db.spGetReferrallevel().ToList();
            uvm.spGetCommunicationStage = db.spGetvCommunicationStage().ToList();
            uvm.spGetvProject = db.spGetvProject_Name().ToList();
            uvm.spGetVulnerabilityType = db.spGetPersonVulnerabilityType().ToList();
            uvm.spGetLanguageDialect = db.spGetvLanguageDialect().ToList();
            uvm.spGetComplaintCategory = db.spGetvComplaintCategory().ToList();
            uvm.spGetReferral = db.spGetReferralType().ToList();
            uvm.spGetClassification = db.spGetComplainClassification().ToList();
            uvm.spGetGender = db.spGetvGender().ToList();
            uvm.spGetFieldSector = db.spGetvFieldSector().ToList();
            uvm.spGetCategories = db.spGetCategory().ToList();
            uvm.spGetFSDetails = db.spGetFieldSiteDetails().ToList();
            uvm.spEditComplainDetails = db.spEDITComplainantDetail(0).ToList();
            spEDITCommunityBasedComplaintDetails_Result d = new spEDITCommunityBasedComplaintDetails_Result();

            uvm.spEditCBS.Add(d);
            spEDITComplainantDetail_Result a = new spEDITComplainantDetail_Result();
            uvm.spEditComplainDetails.Add(a);

            return View(uvm);


        }

    
        public JsonResult SaveComplaint(int compID,int edwID, vCommunityBasedComplaint CBC, List<vComplainantVulnerability> Vul,
        List<vCommunityBasedComplaintFieldSector> FieldSector, vCommunityBasedComplaintLocation Loc, vComplainantDetail CD,
        List<vComplaintAppealCommittee> AC, ComplaintCommunication CT, vComplaintResolution Resolution, vExternalReferral External, AppealClass ComAppeal,
        List<vCommunityBasedComplaintDocumentation> DeletedMedia, List<vCommunityBasedComplaintDocumentation> DeletedMediaAppeal
        )
        {
            string msg = "";
            long EntereBy = Convert.ToInt64(Session["EDWPersonID"]);
            string SessionUser = Convert.ToString(Session["UserName"]);
            int ComplaintID = 0;
            int EDWComplainantID = 0;
            try
            {

                 msg = (compID == 0 ? "Saved" : "Updated");
                uvm.spGetStage = db.spGetCommunicationStage().ToList();
                uvm.spgetStatus = db.spGetComplaintStatus().ToList();
                int ApplicationStatus = 0;
                int? ClosedBy = 0;

                #region Status region
                //10  Complaint Registered
                if (CBC.ComplaintCategoryID == null)
                {
                    ApplicationStatus = uvm.spgetStatus[0].ComplaintStatusID;
                }
                //11  Complaint Categorized
                if (CBC.ComplaintCategoryID >= 0)
                {
                    ApplicationStatus = uvm.spgetStatus[1].ComplaintStatusID;
                }
                //Referal
                if (CBC.InternalReferralLevelID >0)
                {
                    ApplicationStatus = uvm.spgetStatus[2].ComplaintStatusID;
                }
                else if (External.ReferralDate != null && External.ReferralAgencyName != null)
                {
                    ApplicationStatus = uvm.spgetStatus[2].ComplaintStatusID;
                }
                //12  Complaint Resolution
                if (Resolution.ResolutionDate != null)
                {
                    ApplicationStatus = uvm.spgetStatus[3].ComplaintStatusID;
                }
                //14  Complaint Closed
                if (CBC.ClosedDate != null)
                {
                    ApplicationStatus = uvm.spgetStatus[4].ComplaintStatusID;
                    ClosedBy = Convert.ToInt32(EntereBy);
                }
                else
                {
                    ClosedBy = null;
                }
                //15  Complaint Appealed
                if (ComAppeal.AppealDate != null)
                {
                    ApplicationStatus = uvm.spgetStatus[5].ComplaintStatusID;

                }
                //14  Complaint Closed
                if (ComAppeal.AppealResolutionDate != null)
                {
                    ApplicationStatus = uvm.spgetStatus[4].ComplaintStatusID;
                }
                if(CBC.AcknowledgementProvidedFlag==true)
                {
                    CBC.NoAcknowledgementReasonDescription = "";
                }
                if(CBC.ReferralRequiredFlag==true)
                {
                    CBC.NoReferralReasonDescription = "";
                }
                #endregion



                spSave_CommunityBasedComplaint_Result spSaveCommunityBasedComplaint = db.spSave_CommunityBasedComplaint(compID, CBC.CountryCode,CBC.FieldSiteCode,CBC.ComplaintCategoryID == null ? null:CBC.ComplaintCategoryID
                          ,CBC.ComplaintClassificationID == 0 ? null : CBC.ComplaintClassificationID, CBC.ComplaintCommunicationMethodID== 0?null:CBC.ComplaintCommunicationMethodID
                           , Convert.ToByte(ApplicationStatus), CBC.DonorCompanyCode,CBC.ProjectIdentifier,DateTime.Now, CBC.ReceivedDate
                           , CBC.ReceivedByEDWPersonID ==0?null: CBC.ReceivedByEDWPersonID, CBC.EnteredTimestamp, Convert.ToInt32(EntereBy), CBC.ClosedDate
                           , ClosedBy, CBC.ComplaintDescription, CBC.OtherComplaintCommunicationMethodText
                           , CBC.SubjectText, CBC.AcknowledgementProvidedFlag, CBC.AppealedFlag , CBC.ResponseProvidedFlag, CBC.ReferralRequiredFlag
                           , CBC.InternalReferralLevelID == 0 ? null : CBC.InternalReferralLevelID
                           , CBC.NoAcknowledgementReasonDescription, CBC.NoReferralReasonDescription, CBC.NoResponseReasonDescription
                          ,CBC.ReceivedByIMCStaffFlag,CBC.ReceivedByNonIMCName,CBC.ResponseByNonIMCName, Convert.ToString(SessionUser)).FirstOrDefault();
                ComplaintID = Convert.ToInt32(spSaveCommunityBasedComplaint.ComplaintID);


                if (Convert.ToInt32(ComplaintID) > 0 && Loc.LocationText !=null)
                {
                    uvm.spSaveLocation = db.spSave_CBCLocation(ComplaintID, Loc.LocationText, Loc.CommunityText, Loc.DistrictText, Loc.ProvinceText, Loc.UpdateUser = Convert.ToString(SessionUser)).ToList();

                }
                //Field sector table
                if (Convert.ToInt32(ComplaintID) > 0 && FieldSector != null)
                {
                    //delete first if exists 
                    uvm.spDeleteFieldSector = db.spDelete_CBFFieldSector(ComplaintID).ToList();
                    foreach (vCommunityBasedComplaintFieldSector fs in FieldSector)
                    {
                        uvm.spSaveFieldSector = db.spSave_CBCFieldSector(Convert.ToInt32(ComplaintID), fs.FieldSectorCode, fs.OtherSectorText).ToList();
                    }
                }
                //Complain Details
                if (Convert.ToInt32(ComplaintID) > 0 && CD.AgeYearNumber != null || CD.SexCode != null  || CD.PersonName != ""  || CD.AddressText != null || CD.PhoneNumber !=  null || CD.EmailAddress != null)
                {
                    spSave_vComplainantDetail_Result spSaveComplainDetail = db.spSave_vComplainantDetail(edwID, ComplaintID, CD.AgeYearNumber, CD.PrimaryLanguageDialectCode, CD.SexCode, CD.PersonName, CD.AddressText, CD.PhoneNumber, CD.EmailAddress, CD.ComplainantProgramRelationshipText
                                 , CD.OtherCommunicationAvenueText, CD.OtherLanguageDialectText, CD.ComplainantAllowContactFlag, CD.ComplainantAllowVisitFlag, CD.ComplainantQuestionsAddressedFlag, CD.FollowUpContactDetailsFlag,
                                  CD.HandlingProcessExplainedFlag, CD.ProcessTimelineDiscussedFlag, CD.ResponseReceivalExplainedFlag, Convert.ToString(SessionUser)).FirstOrDefault();

                    EDWComplainantID = Convert.ToInt32(spSaveComplainDetail.EDWComplainantID);
                }
                // vulnerability
                if (Convert.ToInt32(EDWComplainantID) > 0 && Vul  != null)
                {
                    //Vul[0].VulnerabilityTypeID != 0
                    //delete 
                    uvm.spDeleteVulnerability = db.spDelete_CBFVulnerability(EDWComplainantID).ToList();
                    foreach (vComplainantVulnerability vu in Vul)
                    {   // ComplaintantVulnerability  loop will be used 
                        uvm.spSaveVulnerability = db.spSave_CBCVulnerability(Convert.ToInt32(EDWComplainantID), vu.VulnerabilityTypeID).ToList();
                    }
                }
                //Acknowledgement
                if (Convert.ToInt32(ComplaintID) > 0 && Convert.ToInt32(CT.AckEDWPersonID) != 0 && CT.InternalCommunicationDate != null)
                {
                  
                    uvm.spGetStage = db.spGetCommunicationStage().ToList();
                    //CT.AckCommunicationStageID = uvm.spGetStage[0].CommunicationStageID
                    uvm.spSaveAcknowledgement = db.spSave_CBCAcknowledgement(ComplaintID, CT.AckEDWPersonID,
                                                CT.AckCommunicationDate, uvm.spGetStage[0].CommunicationStageID, CT.AckCommunicationMethodID, "",
                                               CT.AckOtherCCMText, Convert.ToString(SessionUser)).ToList();
                }
                //country level
                if (Convert.ToInt32(ComplaintID) > 0 && CBC.InternalReferralLevelID == 45 && Convert.ToInt32(CT.InternalEDWPersonID) != 0 && CT.InternalCommunicationDate != null)
                {
                    uvm.spSaveCountryLevel = db.spSave_CBCInternalReferralCountryLevel(ComplaintID, CT.InternalEDWPersonID,
                                                          CT.InternalCommunicationDate, uvm.spGetStage[1].CommunicationStageID, CT.InternalComment, false,
                                                          Convert.ToString(SessionUser)).ToList();
                }
                //HeadQuaterlevel  here we 
                if (Convert.ToInt32(ComplaintID) > 0 &&  CBC.InternalReferralLevelID == 46  && Convert.ToInt32(EntereBy) != 0 && CT.InternaltxtHQCommunicationDate != null)
                {
                    uvm.spSaveHQlevel = db.spSave_CBCInternalReferralHQLevel(ComplaintID, Convert.ToInt32(EntereBy),
                                                                  CT.InternaltxtHQCommunicationDate, uvm.spGetStage[2].CommunicationStageID, CT.InternalCommunicationMethodID, "",
                                                                  CT.InternalOtherCCMText, Convert.ToString(SessionUser)).ToList();
                }
                // external 
                if (Convert.ToInt32(ComplaintID) > 0 && External.ReferralDate != null && External.ReferralAgencyName != null)
                {
                    uvm.spSaveExternalReferral = db.spSave_CBCExternalReferral(ComplaintID, External.ReferralDate, External.ReferralAgencyName,
                                            External.ReferralPersonName, External.ReferralPersonPositionText, External.ContactComment,
                                            External.HQDisclosureAuthorizationText, Convert.ToString(SessionUser)).ToList();
                }
                //Resolution
                
                if (Convert.ToInt32(ComplaintID) > 0  &&  Resolution.ResolutionDate != null)
                {
                    uvm.spSaveResolution = db.spSave_CBCResolution(ComplaintID, Resolution.InvestigationDescription,
                                                   Resolution.InvestigationPointOfContactName, Resolution.CorrectiveActionDescription, Resolution.ResolutionDate,
                                                   Convert.ToString(SessionUser)).ToList();
                }
                //response
                if (Convert.ToInt32(ComplaintID) > 0 && CT.FirstResponseEDWPersonID != 0 && CT.FirstResponseCommunicationDate != null)
                {
                    uvm.spSaveResponse = db.spSave_CBCResponse(ComplaintID, CT.FirstResponseEDWPersonID, CT.FirstResponseCommunicationDate,
                                                   uvm.spGetStage[4].CommunicationStageID, CT.FirstResponseCommunicationMethodID, "",
                                                  CT.FirstResponseOtherCCMText, Convert.ToString(SessionUser)).ToList();
                }

                // Complain Appeal
                if (Convert.ToInt32(ComplaintID) > 0 && ComAppeal.AppealDate != null )
                {
                    uvm.spSaveComplaintAppeal = db.spSave_ComplaintAppeal(ComplaintID, ComAppeal.AppealDate, ComAppeal.ProcessDescription, ComAppeal.AppealReceivedCommunicationMethodID,
                                ComAppeal.OtherComplaintCommunicationMethodText, ComAppeal.AppealResolutionDescription, ComAppeal.AppealResolutionDate, Convert.ToString(SessionUser)).ToList();
                }
                //appeal committee if appeal
                if (Convert.ToInt32(ComplaintID) > 0 && AC != null)
                {


                    uvm.spDeleteAppealCommittee = db.spDelete_CBFAppealCommittee(ComplaintID, Convert.ToString(SessionUser)).ToList();
                    foreach (vComplaintAppealCommittee ac in AC)
                    {    //AppealCommittee  loop will be used 
                        uvm.spSaveAppealCommittee = db.spSave_CBFAppealCommittee(ComplaintID, ac.EDWPersonID, Convert.ToString(SessionUser)).ToList();
                    }
                }
                //response for Appeal 
                if (Convert.ToInt32(ComplaintID) > 0 &&  CT.AppealResponseCommunicationDate !=null)
                {
                    uvm.spSaveResponseAppeal = db.spSave_CBCResponseAppeal(ComplaintID, CT.AppealResponseEDWPersonID,
                                    CT.AppealResponseCommunicationDate, uvm.spGetStage[6].CommunicationStageID,
                                    CT.AppealResponseCommunicationMethodID, "", CT.AppealResponseOtherCCMText,
                                    Convert.ToString(SessionUser)).ToList();
                }
                //update media complain
                if (DeletedMedia != null)
                {
                    foreach (var item in DeletedMedia)
                    {
                        uvm.spUpdateCBCDocumentation = db.spUpdate_vCBCDocumentation(item.CommunityBasedComplaintDocID).ToList();
                    }
                }
                //appeal docs del
                if (DeletedMediaAppeal != null)
                {
                    foreach (var item in DeletedMediaAppeal)
                    {
                        uvm.spUpdateAppealDocs = db.spUpdate_vCBCDocumentationAppeal(item.CommunityBasedComplaintDocID).ToList();
                    }
                }

                msg = msg + "-" + Convert.ToString(ComplaintID);
             
            }
            catch (Exception ex)
            {

               msg = "Error-" + ex;
                
            }
            //List<int> A = new List<int>();
            //A.Add(ComplaintID);
            //A.Add(EDWComplainantID);
            //return Json(new { message = A }, JsonRequestBehavior.AllowGet);
            TempData["IsEdit"] = 0;
            return Json(msg, JsonRequestBehavior.AllowGet);

         
        }


        public ActionResult Edit(int ID)
        {
            
            uvm.spEditCBS = db.spEDITCommunityBasedComplaintDetails(ID,"1888-12-12", "1888-12-12","0","").ToList();
            uvm.spEditComplainDetails = db.spEDITComplainantDetail(ID).ToList();
          
            int VULID = uvm.spEditComplainDetails[0].EDWComplainantID;
            TempData["ComplaintDetailsID"] = VULID;
            uvm.spEditVulnerability = db.spEDITComplaintVulnerability(VULID).ToList();
            uvm.spEditComplaintAppeal = db.spEDITComplaintAppeal(ID).ToList();
            uvm.spEditComplaintCommunication = db.spEDITComplaintCommunication(ID).ToList();
            uvm.spEditComplaintCommunicationAck = db.spEDITComplaintCommunicationACK(ID).ToList();
            uvm.spEditComplaintCommunicationAR = db.spEDITComplaintCommunicationAR(ID).ToList();
            uvm.spEditComplaintCommunicationFR = db.spEDITComplaintCommunicationFR(ID).ToList();
            uvm.spEditComplaintCommunicationHQ = db.spEDITComplaintCommunicationHQ(ID).ToList();
            uvm.spEditlocation = db.spEDITComplaintLocation(ID).ToList();
            uvm.spEditResolution = db.spEDITComplaintResolution(ID).ToList();
            uvm.spEditExternal = db.spEDITExternalReferral(ID).ToList();
            uvm.spEditFieldSector = db.spEDITFieldSector(ID).ToList();
            uvm.spEditAppealCommittee = db.spEDITAppealCommittee2(ID).ToList();
            uvm.spGetCBCDcouments = db.spGetvCommunityBasedComplaintDocumentation(ID).ToList();

            //dropdown
            uvm.spGetAppealCommitteName = db.spGetAppealCommitteNames().ToList();
            uvm.spGetCommunicationMethod = db.spGetvCommunicationMethod().ToList();
            uvm.spGetCommunicationMethodGeneral = db.spGetvCommunicationMethodGenral().ToList();
            uvm.spGetvCMEthics = db.spGetvCommunicationMethodEthics().ToList();
            uvm.spGetCountries = db.spGetCountry().ToList();
        
            uvm.spGetReferrallevel = db.spGetReferrallevel().ToList();
            uvm.spGetCommunicationStage = db.spGetvCommunicationStage().ToList();
           // uvm.spGetvProject = db.spGetvProject_Name().ToList();
            uvm.spGetVulnerabilityType = db.spGetPersonVulnerabilityType().ToList();
            uvm.spGetLanguageDialect = db.spGetvLanguageDialect().ToList();
            uvm.spGetComplaintCategory = db.spGetvComplaintCategory().ToList();
            uvm.spGetReferral = db.spGetReferralType().ToList();
            uvm.spGetClassification = db.spGetComplainClassification().ToList();
            uvm.spGetGender = db.spGetvGender().ToList();
            uvm.spGetFieldSector = db.spGetvFieldSector().ToList();
            //uvm.spGetFSDetails = db.spGetFieldSiteDetails().ToList();
            uvm.spGetCategories = db.spGetCategory().ToList();
            string fs = uvm.spEditCBS[0].CountryCode;
            uvm.spGetFieldSiteCode = db.spGetFieldSiteByID(fs).ToList();
            uvm.spGetvProjectByID = db.spGetvProjectByID(fs).ToList();
            TempData["IsEdit"] = 1;
           return View("Index",uvm);
        }

        
        public JsonResult UploadFile()
        {
            string msg = "";
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i]; //Uploaded file

                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    string KeyTitle = fileName + "-Title";
                    string KeyRemarks = fileName + "-Remarks";
                    string Title = Request.Form.GetValues(KeyTitle)[0].ToString();
                    string Remarks = Request.Form.GetValues(KeyRemarks)[0].ToString();
                    string CommunityBasedComplaintID = Request.Form.GetValues("CommunityBasedComplaintID")[0].ToString();
                    string Path = "~/Areas/ComplainManagement/Media/" + CommunityBasedComplaintID + "/";
                    bool folderExists = Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(Path));
                    if (!folderExists)
                        System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(Path));
                    //System.IO.Stream fileContent = file.InputStream;

                    file.SaveAs(Server.MapPath(Path) + CommunityBasedComplaintID + "_" + fileName);
                    string FilePath = "../../../Areas/ComplainManagement/Media/" + CommunityBasedComplaintID + "/" + CommunityBasedComplaintID + "_" + fileName;
                    string SessionUser = Convert.ToString(Session["saMAccountName"]);
                    //below is file file insert documentations 

                    uvm.spInsertCBCDocumentation = db.spInsert_vCBCDocumentation(Convert.ToInt32(CommunityBasedComplaintID), FilePath, CommunityBasedComplaintID + "_" + fileName, SessionUser, false).ToList();

                }
                msg = "Uploaded";
            }
            catch (Exception e)
            {

                msg = e.Message;
            }

            return Json(msg, JsonRequestBehavior.AllowGet);

        }
        public JsonResult UploadFileAppeal()
        {
            string msg = "";
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i]; //Uploaded file

                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    string KeyTitle = fileName + "-Title";
                    string KeyRemarks = fileName + "-Remarks";
                    string Title = Request.Form.GetValues(KeyTitle)[0].ToString();
                    string Remarks = Request.Form.GetValues(KeyRemarks)[0].ToString();
                    string CommunityBasedComplaintID = Request.Form.GetValues("CommunityBasedComplaintID")[0].ToString();

                    string Path = "~/Areas/ComplainManagement/MediaAppeal/" + CommunityBasedComplaintID + "/";
                    bool folderExists = Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(Path));
                    if (!folderExists)
                        System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(Path));
                    //System.IO.Stream fileContent = file.InputStream;



                    file.SaveAs(Server.MapPath(Path) + CommunityBasedComplaintID + "_" + fileName);

                    string FilePath = "../../../Areas/ComplainManagement/MediaAppeal/" + CommunityBasedComplaintID + "/" + CommunityBasedComplaintID + "_" + fileName;
                    string SessionUser = Convert.ToString(Session["saMAccountName"]);

                    uvm.spInsertCBCDocumentationAppeal = db.spInsert_vCBCDocumentationAppeal(Convert.ToInt32(CommunityBasedComplaintID), FilePath, fileName, true, SessionUser).ToList();

                }



                msg = "Uploaded";
            }
            catch (Exception e)
            {

                msg = e.Message;
            }

            return Json(msg, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetCategoryRefral(int ClassificationID)
        {
            try
            {
                if (ClassificationID > 0)
                {
                    uvm.spGetCategoryRefral = db.spGetCategoryRefral(Convert.ToByte(ClassificationID)).ToList();
                }
                else
                {
                    TempData["message"] = "Please select  category";
                }

            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spGetCategoryRefral, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUsers(string UserName)
        {
            try
            {
                if (UserName != null)
                {
                    var items = UserName.Split('-');
                   
                    uvm.spGetSearchUser = db.spGetvSearchUser(items[0]).ToList();
                }
                else
                {
                    TempData["message"] = "Please search Name";
                }
                //  uvm.spGetEmployeeDetails = db.IMCspGetEmployeeDetails(UserName).ToList();
            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spGetSearchUser, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserDetails(string UserName)
        {
            try
            {
                var items = UserName.Split('-');
                uvm.spGetvvUser = db.spGetvUserAssign2(items[0]).ToList();
                //  uvm.spGetEmployeeDetails = db.IMCspGetEmployeeDetails(UserName).ToList();
            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spGetvvUser, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Acknowledge(string UserName)
        {
            try
            {
                var items = UserName.Split('-');
                uvm.spGetvvUser = db.spGetvUserAssign2(items[0]).ToList();
                //  uvm.spGetEmployeeDetails = db.IMCspGetEmployeeDetails(UserName).ToList();
            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spGetvvUser, JsonRequestBehavior.AllowGet);
        }
        public JsonResult spGetCategory(int catid)
        {
            try
            {
                if (catid > 0)
                {
                    uvm.spGetCategoryByID = db.spGetCategoryByID(Convert.ToByte(catid)).ToList();
                }
                else
                {
                    TempData["message"] = "Please select  category";
                }

            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spGetCategoryByID, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFieldSite(string CountryCode)
        {
            try
            {
                if (CountryCode != null)
                {
                    uvm.spgetfs = db.spGetFieldSite(CountryCode).ToList();
                }
                else
                {
                    TempData["message"] = "Please select  category";
                }

            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spgetfs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProject(string CountryCode)
        {
            try
            {
                if (CountryCode != null)
                {
                    uvm.spGetvProjectByID = db.spGetvProjectByID(CountryCode).ToList();
                }
                else
                {
                    TempData["message"] = "Please select  project";
                }

            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spGetvProjectByID, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetFiles(int CommunityBasedComplaintID)
        {
            string msg = "";
            try
            {

                uvm.spGetCBCDcouments = db.spGetvCommunityBasedComplaintDocumentation(CommunityBasedComplaintID).ToList();

            }
            catch (Exception e)
            {
                msg = e.Message;
            }


            return Json(uvm.spGetCBCDcouments, JsonRequestBehavior.AllowGet);


        }
        public JsonResult FetchUsers(string UserName)
        {
            try
            {
                if (UserName != null)
                {
                    var items = UserName.Split('-');

                    uvm.spGetSearchUser = db.spGetvSearchUser(items[0]).ToList();
                }
                else
                {
                    TempData["message"] = "Please search Name";
                }
                //  uvm.spGetEmployeeDetails = db.IMCspGetEmployeeDetails(UserName).ToList();
            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
            }


            return Json(uvm.spGetSearchUser, JsonRequestBehavior.AllowGet);
        }
    }
}