using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBFRM.Areas.ComplainManagement.Models
{
    public class UserViewModel
    {

        public List<spGetvUserManager_Result> spGetManagerRole = new List<spGetvUserManager_Result>();
        public List<spGetvvUserDetails_Result> spGetvvUserDetail = new List<spGetvvUserDetails_Result>();
        public List<spGetvUserAssign_Result> spGetvvUserr = new List<spGetvUserAssign_Result>();
        public List<spGetCountriesforUserManager_Result> spGetCountry = new List<spGetCountriesforUserManager_Result>();
        //DROPDOWNS BIND STORED PROCEDURES 
        public List<spGetvCommunicationMethod_Result> spGetCommunicationMethod = new List<spGetvCommunicationMethod_Result>();
        public List<spGetComplainClassification_Result> spGetClassification = new List<spGetComplainClassification_Result>();
        public List<spGetReferrallevel_Result> spGetReferrallevel = new List<spGetReferrallevel_Result>();
        public List<spGetComplaintStatus_Result> spgetStatus = new List<spGetComplaintStatus_Result>();
        public List<spGetCommunicationStage_Result> spGetStage = new List<spGetCommunicationStage_Result>();
        public List<spGetFieldSite_Result> spgetfs = new List<spGetFieldSite_Result>();
        public List<spGetvCommunicationMethodEthics_Result> spGetvCMEthics = new List<spGetvCommunicationMethodEthics_Result>();
        public List<spGetvCommunicationMethodGenral_Result> spGetCommunicationMethodGeneral = new List<spGetvCommunicationMethodGenral_Result>();
        public List<spGetCountry_Result> spGetCountries = new List<spGetCountry_Result>();
        
      
        public List<spGetvSearchUser_Result> spGetSearchUser = new List<spGetvSearchUser_Result>();
        public List<spGetAppealCommitteNames_Result> spGetAppealCommitteName = new List<spGetAppealCommitteNames_Result>();
        public List<spGetvUserAssign2_Result> spGetvvUser = new List<spGetvUserAssign2_Result>();
        public List<spGetvCommunicationStage_Result> spGetCommunicationStage = new List<spGetvCommunicationStage_Result>();
        public List<spGetvProject_Name_Result> spGetvProject = new List<spGetvProject_Name_Result>();
        public List<spGetPersonVulnerabilityType_Result> spGetVulnerabilityType = new List<spGetPersonVulnerabilityType_Result>();
        public List<spGetvGender_Result> spGetGender = new List<spGetvGender_Result>();
        public List<spGetCategoryRefral_Result> spGetCategoryRefral = new List<spGetCategoryRefral_Result>();
        public List<spGetvLanguageDialect_Result> spGetLanguageDialect = new List<spGetvLanguageDialect_Result>();
        public List<spGetvComplaintCategory_Result> spGetComplaintCategory = new List<spGetvComplaintCategory_Result>();
        public List<spGetReferralType_Result> spGetReferral = new List<spGetReferralType_Result>();
        public List<spGetvFieldSector_Result> spGetFieldSector = new List<spGetvFieldSector_Result>();
        public List<spGetCategoryByID_Result> spGetCategoryByID = new List<spGetCategoryByID_Result>();
        public List<spGetCategory_Result> spGetCategories = new List<spGetCategory_Result>();
        public List<spGetvProjectByID_Result> spGetvProjectByID = new List<spGetvProjectByID_Result>();
        public List<spGetFieldSiteDetails_Result> spGetFSDetails = new List<spGetFieldSiteDetails_Result>();

        public List<spGetFieldSiteByID_Result> spGetFieldSiteCode = new List<spGetFieldSiteByID_Result>();
        public List<spMealCordinator_Result> spMealCordinator = new List<spMealCordinator_Result>();
        

        //delete  MULTISELECT DRODDOWNS 
        public List<spDelete_CBFFieldSector_Result> spDeleteFieldSector= new List<spDelete_CBFFieldSector_Result>();
        public List<spDelete_CBFVulnerability_Result> spDeleteVulnerability = new List<spDelete_CBFVulnerability_Result>();
        
        //INSERT UPDATE STORED PROCEDURES 
        public List<spSave_CBCLocation_Result> spSaveLocation = new List<spSave_CBCLocation_Result>();
        public List<spSave_CBCAcknowledgement_Result> spSaveAcknowledgement = new List<spSave_CBCAcknowledgement_Result>();
        public List<spSave_CBCExternalReferral_Result> spSaveExternalReferral = new List<spSave_CBCExternalReferral_Result>();
        public List<spSave_CBCFieldSector_Result> spSaveFieldSector = new List<spSave_CBCFieldSector_Result>();
        public List<spSave_CBCInternalReferralCountryLevel_Result> spSaveCountryLevel = new List<spSave_CBCInternalReferralCountryLevel_Result>();
        public List<spSave_CBCInternalReferralHQLevel_Result> spSaveHQlevel = new List<spSave_CBCInternalReferralHQLevel_Result>();
        public List<spSave_CBCResponse_Result> spSaveResponse = new List<spSave_CBCResponse_Result>();
        public List<spSave_CBCResponseAppeal_Result> spSaveResponseAppeal = new List<spSave_CBCResponseAppeal_Result>();
        public List<spSave_CBCVulnerability_Result> spSaveVulnerability = new List<spSave_CBCVulnerability_Result>();
        public List<spDelete_CBFAppealCommittee_Result> spDeleteAppealCommittee = new List<spDelete_CBFAppealCommittee_Result>();
        public List<spSave_ComplaintAppeal_Result> spSaveComplaintAppeal = new List<spSave_ComplaintAppeal_Result>();
        public List<spUpdate_vCBCDocumentation_Result> spUpdateCBCDocumentation = new List<spUpdate_vCBCDocumentation_Result>();
        public List<spUpdate_vCBCDocumentationAppeal_Result> spUpdateAppealDocs = new List<spUpdate_vCBCDocumentationAppeal_Result>();
        public List<spSave_vComplainantDetail_Result> spSaveComplainDetail = new List<spSave_vComplainantDetail_Result>();
        public List<spSave_CBCResolution_Result> spSaveResolution = new List<spSave_CBCResolution_Result>();
        public List<spSave_CommunityBasedComplaint_Result> spSaveCommunityBasedComplaint = new List<spSave_CommunityBasedComplaint_Result>();
        public List<spInsert_vCBCDocumentation_Result> spInsertCBCDocumentation = new List<spInsert_vCBCDocumentation_Result>();
        public List<spInsert_vCBCDocumentationAppeal_Result> spInsertCBCDocumentationAppeal = new List<spInsert_vCBCDocumentationAppeal_Result>();
        public List<spSave_CBFAppealCommittee_Result> spSaveAppealCommittee = new List<spSave_CBFAppealCommittee_Result>();
        
             public List<spSave_CBFAdminGroup_Result> spSave_CBFAdminGroup = new List<spSave_CBFAdminGroup_Result>();
        public List<spDelete_CBFAdminGroup_Result> spDelete_CBFAdminGroup = new List<spDelete_CBFAdminGroup_Result>();
        public List<spEDITAdminGroup_Result> spEDITAdminGroup = new List<spEDITAdminGroup_Result>();



        public List<spSave_CBFITGroup_Result> spSave_CBFITGroup = new List<spSave_CBFITGroup_Result>();
        public List<spDelete_CBFITGroup_Result> spDelete_CBFITGroup = new List<spDelete_CBFITGroup_Result>();
        public List<spEDITITGroup_Result> spEDITITGroup = new List<spEDITITGroup_Result>();



        public List<spSave_CBFHQGroup_Result> spSave_CBFHQGroup = new List<spSave_CBFHQGroup_Result>();
        public List<spDelete_CBFHQGroup_Result> spDelete_CBFHQGroup = new List<spDelete_CBFHQGroup_Result>();
        public List<spEDITHQGroup_Result> spEDITHQGroup = new List<spEDITHQGroup_Result>();

        
        public List<spSave_CBFOfficer_Result> spSave_CBFOfficer = new List<spSave_CBFOfficer_Result>();
        public List<spDelete_CBFOfficers_Result> spDelete_CBFOfficers = new List<spDelete_CBFOfficers_Result>();
        public List<spEditOfficer_Result> spEditOfficer = new List<spEditOfficer_Result>();

        /// /
        public List<spSave_CBFMealCordinator_Result> spSave_CBFMealCordinator= new List<spSave_CBFMealCordinator_Result>();
        public List<spDelete_CBFMealCordinator_Result> spDelete_CBFMealCordinator = new List<spDelete_CBFMealCordinator_Result>();
        public List<spEDITMealCordinator_Result> spEDITMealCordinator = new List<spEDITMealCordinator_Result>();

        //get documents for insert update
        public List<spGetvCommunityBasedComplaintDocumentation_Result> spGetCBCDcouments = new List<spGetvCommunityBasedComplaintDocumentation_Result>();
        //EDIT FORM STORED PROCEDURES 
        public List<spEDITCommunityBasedComplaintDetails_Result> spEditCBS=new List<spEDITCommunityBasedComplaintDetails_Result>();
        public List<spEDITComplainantDetail_Result> spEditComplainDetails = new List<spEDITComplainantDetail_Result>();
        public List<spEDITComplaintAppeal_Result> spEditComplaintAppeal = new List<spEDITComplaintAppeal_Result>();
        public List<spEDITComplaintCommunication_Result> spEditComplaintCommunication = new List<spEDITComplaintCommunication_Result>();
        public List<spEDITComplaintCommunicationACK_Result> spEditComplaintCommunicationAck = new List<spEDITComplaintCommunicationACK_Result>();
        
        public List<spEDITComplaintCommunicationAR_Result> spEditComplaintCommunicationAR = new List<spEDITComplaintCommunicationAR_Result>();
        public List<spEDITComplaintCommunicationFR_Result> spEditComplaintCommunicationFR = new List<spEDITComplaintCommunicationFR_Result>();
        public List<spEDITComplaintCommunicationHQ_Result> spEditComplaintCommunicationHQ = new List<spEDITComplaintCommunicationHQ_Result>();

        public List<spEDITComplaintLocation_Result> spEditlocation = new List<spEDITComplaintLocation_Result>();
        public List<spEDITComplaintResolution_Result> spEditResolution = new List<spEDITComplaintResolution_Result>();
        public List<spEDITComplaintVulnerability_Result> spEditVulnerability = new List<spEDITComplaintVulnerability_Result>();
        public List<spEDITExternalReferral_Result> spEditExternal = new List<spEDITExternalReferral_Result>();
        public List<spEDITFieldSector_Result> spEditFieldSector = new List<spEDITFieldSector_Result>();
        public List<spEDITAppealCommittee2_Result> spEditAppealCommittee = new List<spEDITAppealCommittee2_Result>();

        public List<spDelete_CBCDetails_Result> spdeleteCBC = new List<spDelete_CBCDetails_Result>();

        

    }

    public class MYList
    {
        public int CompID { get; set; }
        public int CompDetailID { get; set; }


    }

}