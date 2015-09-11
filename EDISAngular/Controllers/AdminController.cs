using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDISAngular.Services;
using EDISAngular;
using EDISAngular.Models.ViewModels;
using EDISAngular.Models;
using EDISAngular.Models.BindingModels;
using EDISAngular.Infrastructure.Authorization;
using EDIS_DOMAIN;
using EDISAngular.Infrastructure.DatabaseAccess;
using EDISAngular.Infrastructure.DbFirst;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SqlRepository;
using System.Security.Claims;


namespace EDISAngular.Controllers
{
    //[Authorize(Roles = AuthorizationRoles.Role_Administrator)]
    public class AdminController : Controller
    {

        private edisDbEntities db;
        private EdisRepository edisRepo;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
            db = new edisDbEntities();
            edisRepo = new EdisRepository();
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Route("Admin/Pending/{page:int?}")]
        public ActionResult PendingProfiles(int page = 0)
        {

            List<AdviserBriefListView> models = new List<AdviserBriefListView>();
            db.Advisers.Where(a => a.VerifiedId == BusinessLayerParameters.verificationStatus_NotVerified).ToList()
                .ForEach(item =>
                {
                    models.Add(new AdviserBriefListView
                    {
                        AcnAbn = item.ABNACN,
                        AdviserId = item.AdviserNumber,
                        Name = item.FirstName + (string.IsNullOrEmpty(item.MiddleName) ? "" : " " + item.MiddleName) + " " + item.LastName,
                        PostCode = item.PostCode,
                        State = item.State,
                        Suburb = item.Suburb
                    });
                });

            return View("PendingProfiles", models);



        }

        [Route("Admin/Adviser/{id}")]
        public ActionResult AdviserDetails(string id)
        {

            var adviser = db.Advisers.FirstOrDefault(a => a.AdviserNumber == id);
            //var adviser = edisRepo.GetAdviser(id, DateTime.Now).Result;
            if (adviser == null)
            {
                return HttpNotFound();
            }
            AdviserRegistrationBindingModel model = new AdviserRegistrationBindingModel();
            #region personal details
            model.ABN = adviser.ABNACN;
            model.addressLine1 = adviser.AddressLn1;
            model.addressLine2 = adviser.AddressLn2;
            model.addressLine3 = adviser.AddressLn3;
            model.adviserUserId = adviser.AdviserNumber;
            model.businessFax = adviser.Fax;
            model.businessMobile = adviser.Mobile;
            model.businessPhone = adviser.Phone;
            model.companyName = adviser.CompanyName;
            model.country = adviser.Country;
            model.currentPositionTitle = adviser.CurrentTitle;
            model.firstName = adviser.FirstName;
            model.gender = adviser.Gender;
            model.lastName = adviser.LastName;
            model.middleName = adviser.MiddleName;
            model.postCode = adviser.PostCode;
            model.industryExperienceStartDate = adviser.ExperienceStartDate;
            model.GeoString = NullableDoubleToString(adviser.Lat, null) + " " + NullableDoubleToString(adviser.Lng, null);

            model.dealerGroupName = adviser.GroupName;
            model.dealerGroup_addressLine1 = adviser.DAddressLine1;
            model.dealerGroup_addressLine2 = adviser.DAddressLine2;
            model.dealerGroup_addressLine3 = adviser.DAddressLine3;
            model.dealerGroup_country = adviser.DCountry;
            model.dealerGroup_postCode = adviser.DPostcode;
            model.dealerGroup_suburb = adviser.DSuburb;
            model.dealerGroup_state = adviser.DState;
            model.asfl = adviser.Asfl;
            model.dealerGroupHasDerivativesLicense = adviser.DealerGroupHasDerivativesLicense;
            model.isAuthorizedRepresentative = adviser.IsAuthorizedRepresentative;
            model.authorizedRepresentativeNumber = adviser.AuthorizedRepresentativeNumber;




            #endregion
            #region target clients
            //var targetClient = db.Adviser_TargetClients.FirstOrDefault(t => t.UserId == id);

            //if (targetClient != null)
            //{
            //    if (targetClient.AnnualIncomeLevelsId.HasValue
            //        && comRepo.GetAllAnnualIncomeLevels().FirstOrDefault(a => a.AnnualIncomeLevelsId == targetClient.AnnualIncomeLevelsId.Value) != null)
            //    {
            //        model.AnnualIncomeLevel = comRepo.GetAllAnnualIncomeLevels()
            //            .FirstOrDefault(a => a.AnnualIncomeLevelsId == targetClient.AnnualIncomeLevelsId.Value).AnnualIncomeLevels;
            //    }

            //    if (targetClient.TotalAssetsLevelId.HasValue
            //        && comRepo.GetAllTotalAssetLevels().FirstOrDefault(t => t.TotalAssetsLevelId == targetClient.TotalAssetsLevelId.Value) != null)
            //    {
            //        model.TotalAssetLevel = comRepo.GetAllTotalAssetLevels()
            //            .FirstOrDefault(t => t.TotalAssetsLevelId == targetClient.TotalAssetsLevelId.Value).TotalAssetsLevel1;
            //    }

            //    if (targetClient.InvestibleAssetsLevelId.HasValue
            //        && comRepo.GetAllInvestibleAssetLevels().FirstOrDefault(t => t.InvestibleAssetsLevelId == targetClient.InvestibleAssetsLevelId.Value) != null)
            //    {
            //        model.InvestibleAssetLevelString = comRepo.GetAllInvestibleAssetLevels()
            //            .FirstOrDefault(t => t.InvestibleAssetsLevelId == targetClient.InvestibleAssetsLevelId.Value).InvestibleAssetsLevel1;
            //    }
            //}
            //#endregion
            //#region asset management details
            //var adviserManagementDetails = db.Adviser_ManagementDetails.FirstOrDefault(a => a.UserId == id);
            //if (adviserManagementDetails != null)
            //{
            //    if (adviserManagementDetails.ApproxClientNumbersId.HasValue
            //        && comRepo.GetApproxClientNumbers().FirstOrDefault(d => d.ApproxClientNumbersId == adviserManagementDetails.ApproxClientNumbersId.Value) != null)
            //    {
            //        model.approximateNumberOfClients = comRepo.GetApproxClientNumbers()
            //            .FirstOrDefault(d => d.ApproxClientNumbersId == adviserManagementDetails.ApproxClientNumbersId.Value).ApproxClientNumbers;
            //    }
            //    model.totalAssetUnderManagement = NullableDoubleToString(adviserManagementDetails.TotalAssets, "C0");
            //    model.totalDirectAustralianEquitiesUnderManagement = NullableDoubleToString(adviserManagementDetails.TotalDirectAustralianEquities, "C0");
            //    model.totalDirectFixedInterestUnderManagement = NullableDoubleToString(adviserManagementDetails.TotalFixedInterest, "C0");
            //    model.totalDirectInterantionalEquitiesUnderManagement = NullableDoubleToString(adviserManagementDetails.TotalDirectInternational, "C0");
            //    model.totalDirectLendingBookInterestUnderManagement = NullableDoubleToString(adviserManagementDetails.TotalLendingBook, "C0");
            //    model.totalInvestmentUndermanagement = NullableDoubleToString(adviserManagementDetails.TotalManagedInvestments, "C0");
            //}
            //#endregion
            //#region dealer group details
            //var dealerGroupDetails = db.Adviser_DealerGroupDetails.FirstOrDefault(d => d.UserId == id);
            //if (dealerGroupDetails != null)
            //{
            //    model.asfl = dealerGroupDetails.AFSL;
            //    model.authorizedRepresentativeNumber = dealerGroupDetails.AuthorisedRepNumber;
            //    model.dealerGroup_addressLine1 = dealerGroupDetails.AddressLn1;
            //    model.dealerGroup_addressLine2 = dealerGroupDetails.AddressLn2;
            //    model.dealerGroup_addressLine3 = dealerGroupDetails.AddressLn3;
            //    model.dealerGroup_country = dealerGroupDetails.Country;
            //    model.dealerGroup_postCode = dealerGroupDetails.PostCode;
            //    model.dealerGroup_state = dealerGroupDetails.State;
            //    model.dealerGroup_suburb = dealerGroupDetails.Suburb;
            //    model.dealerGroupHasDerivativesLicense = dealerGroupDetails.HasDerivativesLicense.HasValue && dealerGroupDetails.HasDerivativesLicense.Value == 1 ? true : false;
            //    model.dealerGroupName = dealerGroupDetails.DealerGroupName;
            //    model.isAuthorizedRepresentative = dealerGroupDetails.IsAuthorisedRep.HasValue && dealerGroupDetails.IsAuthorisedRep.Value == 1 ? true : false;
            //}
            //#endregion
            //#region services provided
            //var services = db.Adviser_ServicesProviding
            //    .Where(s => s.UserId == id && s.SubServiceProvideYesNo == "True")
            //    .Select(s => db.SubServices
            //        .Where(ss => ss.SubServiceId == s.SubServiceId)
            //        .FirstOrDefault() != null ?
            //        db.SubServices
            //        .Where(ss => ss.SubServiceId == s.SubServiceId).FirstOrDefault().SubServiceName : "")
            //    .ToList().ToArray();
            //model.ProvidedServicesString = String.Join(",", services);
            //#endregion
            //#region educations
            //model.educations = new List<EducationCreationModel>();
            //db.Adviser_Education.Where(ae => ae.UserId == id)
            //    .ToList()
            //    .ForEach(ed =>
            //    {
            //        model.educations.Add(new EducationCreationModel
            //        {
            //            courseStatus = ed.CurrentlyStudying == 1,
            //            courseTitle = ed.CourseName,
            //            institution = ed.Institution
            //        });
            //    });


            #endregion
            return View(model);

        }


        private string NullableDoubleToString(double? value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.HasValue ? value.Value.ToString() : "";
            }
            else
            {
                return value.HasValue ? value.Value.ToString(format) : "";
            }
        }


        [Route("Admin/Adviser/Approve/{id}")]
        public ActionResult AdviserApprove(string id)
        {

            var adviser = db.Advisers.SingleOrDefault(s => s.AdviserNumber == id);
            adviser.VerifiedId = BusinessLayerParameters.verificationStatus_Verified;



            UserManager.RemoveFromRole(id, AuthorizationRoles.Role_Preadviser);
            UserManager.AddToRole(id, AuthorizationRoles.Role_Adviser);

            UserManager.RemoveClaim(id, UserManager.GetClaimsAsync(id).Result[0]);
            UserManager.AddClaim(id, new Claim(AuthorizationClaims.ClaimType_VerificationStatus, AuthorizationClaims.ClaimValue_VerificationStatus_Verified));
            
            db.SaveChanges();
            TempData["success"] = "Adviser has been successfully verified";
            return RedirectToAction("PendingProfiles");

        }
        [Route("Admin/Adviser/Block/{id}")]

        public ActionResult AdviserBlock(string id)
        {

            var adviser = db.Advisers.SingleOrDefault(s => s.AdviserNumber == id);
            adviser.VerifiedId = BusinessLayerParameters.verificationStatus_Block;
            db.SaveChanges();
            TempData["success"] = "Adviser has been successfully blocked";
            return RedirectToAction("PendingProfiles");

        }

    }
}