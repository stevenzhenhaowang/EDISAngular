using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDISAngular.Models.BindingModels;
using Microsoft.AspNet.Identity;
using EDISAngular.Services;
using Microsoft.AspNet.Identity.Owin;
using EDISAngular.Infrastructure.DatabaseAccess;
using EDISAngular.Infrastructure.Authorization;
using SqlRepository;
using Domain.Portfolio;
using System.Threading.Tasks;
using Edis.Db;
using Adviser = Domain.Portfolio.AggregateRoots.Adviser;
using GoogleGeoService = SqlRepository.GoogleGeoService;

namespace EDISAngular.Controllers
{
    [Authorize]
    public class AdviserController : Controller
    {
        //private AdviserRepository adviserRepo = new AdviserRepository();

        private CommonReferenceDataRepository cmRepo = new CommonReferenceDataRepository();

        private EdisRepository edisRepo = new EdisRepository();

        [Authorize(Roles = AuthorizationRoles.Role_Adviser)]
        //[ClaimsAccessFilter(ClaimType = AuthorizationClaims.ClaimType_VerificationStatus,
        //    Value = AuthorizationClaims.ClaimValue_VerificationStatus_Verified,
        //    Issuer = AuthorizationProviders.EdisDynamicProvider)]
        public ActionResult Index()
        {
            return View();
        }



        [Authorize(Roles = AuthorizationRoles.Role_Preadviser)]
        public ActionResult Create()
        {

            //Adviser adviser = edisRepo.CreateAdviser("First Name", "Last Name", User.Identity.GetUserId()).Result;

            AdviserRegistrationBindingModel adviserModel = new AdviserRegistrationBindingModel();

            adviserModel.adviserUserId = User.Identity.GetUserId();




            ViewBag.professTypes = cmRepo.GetAllProfessionTypes().Select(p => new SelectListItem
            {
                Text = p.ProfessionType1,
                Value = p.ProfessionTypeId.ToString()
            }).ToList();

            #region add education level select drop down list
            List<SelectListItem> educationLevelSelect = new List<SelectListItem>();
            educationLevelSelect.Add(new SelectListItem()
            {
                Text = "Please select",
                Value = ""
            });
            cmRepo.GetAllEducationLevels().ToList().ForEach(level =>
            {
                SelectListItem item = new SelectListItem();
                item.Text = level.EducationLevels;
                item.Value = level.EducationLevelsId.ToString();
            });
            ViewBag.educationLevelSelect = educationLevelSelect;

            //generate number of education viewbag details
            checkEducationList(adviserModel);

            #endregion

            return View(adviserModel);


            //AdviserRegistrationBindingModel model = new AdviserRegistrationBindingModel();

            //var adviserId = User.Identity.GetUserId();

            //model.adviserUserId = adviserId;

            //Adviser adviser = edisRepo.GetAdviser(User.Identity.GetUserId(), DateTime.Now).Result;

            //if (adviser != null)
            //{
            //    model.adviserUserId = adviserId;
            //    model.ABN = adviser.ABNACN;
            //    model.addressLine1 = adviser.AddressLn1;
            //    model.addressLine2 = adviser.AddressLn2;
            //    model.addressLine3 = adviser.AddressLn3;
            //    model.businessFax = adviser.Fax;
            //    model.businessMobile = adviser.Mobile;
            //    model.businessPhone = adviser.Phone;
            //    model.companyName = adviser.CompanyName;
            //    model.country = adviser.Country;
            //    model.currentPositionTitle = adviser.CurrentTitle;
            //    model.firstName = adviser.FirstName;
            //    model.gender = adviser.Gender;
            //    model.industryExperienceStartDate = adviser.ExperienceStartDate;
            //    model.lastName = adviser.LastName;
            //    model.middleName = adviser.MiddleName;
            //    model.postCode = adviser.PostCode;
            //    model.state = adviser.State;
            //    model.suburb = adviser.Suburb;
            //    model.title = adviser.Title;
            //}


            //AdviserRegistrationBindingModel model = adviserRepo.GetAdviserProfile_Complete(User.Identity.GetUserId());

            //ViewBag.professTypes = cmRepo.GetAllProfessionTypes().Select(p => new SelectListItem
            //{
            //    Text = p.ProfessionType1,
            //    Value = p.ProfessionTypeId.ToString()
            //}).ToList();


            //#region add education level select drop down list
            //List<SelectListItem> educationLevelSelect = new List<SelectListItem>();
            //educationLevelSelect.Add(new SelectListItem()
            //{
            //    Text = "Please select",
            //    Value = ""
            //});
            //cmRepo.GetAllEducationLevels().ToList().ForEach(level =>
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = level.EducationLevels;
            //    item.Value = level.EducationLevelsId.ToString();
            //});
            //ViewBag.educationLevelSelect = educationLevelSelect;

            ////generate number of education viewbag details
            //checkEducationList(model);

            //#endregion

            //return View(model);
        }
        private void checkEducationList(AdviserRegistrationBindingModel model)
        {
            if (model.educations == null || model.educations.Count == 0)
            {
                ViewBag.numberOfEducations = 0;
            }
            else
            {   
                ViewBag.numberOfEducations = model.educations.Count;
            }
        }

        //[Authorize(Roles = AuthorizationRoles.Role_Preadviser)]
        //[HttpPost]
        //public ActionResult Create(AdviserRegistrationBindingModel model)   //AdviserRegistrationBindingModel model  -->  string userId
        //{
            

            //ViewBag.professTypes = cmRepo.GetAllProfessionTypes().Select(p => new SelectListItem
            //{
            //    Text = p.ProfessionType1,
            //    Value = p.ProfessionTypeId.ToString()
            //}).ToList();

            //var allErrors = ModelState.Values.Where(v => v.Errors.Count > 0).ToList();
            //if (ModelState.IsValid)
            //{



                //adviserRepo.InsertOrUpdateAdviserProfile_Complete(model);
                //try
                //{
                //    adviserRepo.Save();
                //    var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //    userManager.AddToRole(User.Identity.GetUserId(), AuthorizationRoles.Role_Adviser);
                //    userManager.RemoveFromRole(User.Identity.GetUserId(), AuthorizationRoles.Role_Preadviser);
                //    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                //    authenticationManager.SignOut();
                //    return RedirectToAction("Index", "Adviser");

                //}
                //catch (Exception ex)
                //{
                //    ModelState.AddModelError("", "Cannot store information: " + ex.Message);
                //}


            //}

            //checkEducationList(model);
            //return View(model);
        //}



        [Authorize(Roles = AuthorizationRoles.Role_Preadviser)]
        [HttpPost]
        public ActionResult Create(AdviserRegistrationBindingModel model)
        {


            //ViewBag.professTypes = cmRepo.GetAllProfessionTypes().Select(p => new SelectListItem
            //{
            //    Text = p.ProfessionType1,
            //    Value = p.ProfessionTypeId.ToString()
            //}).ToList();

            var allErrors = ModelState.Values.Where(v => v.Errors.Count > 0).ToList();
            if (ModelState.IsValid)
            {

                Adviser adviser = new Adviser(edisRepo)
                {
                    AdviserNumber = User.Identity.GetUserId(),
                    ABNACN = model.ABN,
                    CompanyName = model.companyName,
                    Country = model.country,
                    AddressLn1 = model.addressLine1,
                    AddressLn2 = model.addressLine2,
                    AddressLn3 = model.addressLine3,
                    CreatedOn = DateTime.Now,
                    CurrentTitle = model.currentPositionTitle,
                    ExperienceStartDate = model.industryExperienceStartDate,
                    Fax = model.businessFax,
                    FirstName = model.firstName,
                    Gender = model.gender,
                    LastName = model.lastName,
                    LastUpdate = DateTime.Now,
                    Lat = new GoogleGeoService(model.addressLine1 + " "
                    + model.addressLine2 + " " + model.addressLine3 + " " + model.suburb + " "
                    + model.state + " " + model.country).GetCoordinatesLat(),
                    Lng = new GoogleGeoService(model.addressLine1 + " "
                    + model.addressLine2 + " " + model.addressLine3 + " " + model.suburb + " "
                    + model.state + " " + model.country).GetCoordinatesLng(),
                    MiddleName = model.middleName,
                    Mobile = model.businessMobile,
                    Phone = model.businessPhone,
                    PostCode = model.postCode,
                    State = model.state,
                    Suburb = model.suburb,
                    Title = model.title,
                    VerifiedId = BusinessLayerParameters.verificationStatus_NotVerified,
                    
                    IndustryExperienceStartDate = model.industryExperienceStartDate,
                    BusinessPhone = model.businessPhone,
                    BusinessMobile = model.businessMobile,
                    BusinessFax = model.businessFax,

                    DAddressLine1 = model.dealerGroup_addressLine1,
                    DAddressLine2 = model.dealerGroup_addressLine2,
                    DAddressLine3 = model.dealerGroup_addressLine3,
                    DPostcode = model.dealerGroup_postCode,
                    DState = model.dealerGroup_state,
                    DSuburb = model.dealerGroup_suburb,
                    DCountry = model.dealerGroup_country,
                    Asfl = model.asfl,
                    AuthorizedRepresentativeNumber = model.authorizedRepresentativeNumber,
                    DealerGroupName = model.dealerGroupName,
                    DealerGroupHasDerivativesLicense = model.dealerGroupHasDerivativesLicense ? true : false,
                    IsAuthorizedRepresentative = model.isAuthorizedRepresentative ? true : false,
                    
                    TotalAssetUnderManagement = model.totalAssetUnderManagement,
                    TotalInvestmentUndermanagement = model.totalInvestmentUndermanagement,
                    TotalDirectAustralianEquitiesUnderManagement = model.totalDirectAustralianEquitiesUnderManagement,
                    TotalDirectInterantionalEquitiesUnderManagement = model.totalDirectInterantionalEquitiesUnderManagement,
                    TotalDirectFixedInterestUnderManagement = model.totalDirectFixedInterestUnderManagement,
                    TotalDirectLendingBookInterestUnderManagement = model.totalDirectLendingBookInterestUnderManagement,
                    ApproximateNumberOfClients = model.approximateNumberOfClients,

                    ProfessiontypeId = model.professiontypeId,
                    RemunerationMethodSpecified = model.remunerationMethodSpecified,
                    RemunerationMethod = model.remunerationMethod,
                    NumberOfClientsId = model.numberOfClientsId,
                    AnnualIncomeLevelId = model.annualIncomeLevelId,
                    InvestibleAssetLevel = model.investibleAssetLevel,
                    TotalAssetLevel = model.TotalAssetLevel,
                    
                };

                if(model.educations != null && model.educations.Count != 0)
                {
                    adviser.Institution = model.educations[0].institution;
                    adviser.CourseTitle = model.educations[0].courseTitle;
                    adviser.CourseStatus = model.educations[0].courseStatus;
                    adviser.EducationLevelId = model.educations[0].educationLevelId;
                }

                Adviser insertedAdviser = edisRepo.CreateAdviser(adviser).Result;
                
            }

            checkEducationList(model);
            return View(model);
        }
        private double? getDoubleFromProperty(string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return null;
            }
            else
            {
                try
                {
                    return Convert.ToDouble(property);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        [Authorize(Roles = AuthorizationRoles.Role_Administrator)]
        public ActionResult UpdateImage()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = AuthorizationRoles.Role_Adviser)]
        public ActionResult UpdateImage(HttpPostedFileBase image = null)
        {
            if (image != null)
            {

                var userId = User.Identity.GetUserId();
                //var adviser = adviserRepo.GetAdviserDetails().FirstOrDefault(ad => ad.AdvisorUserId == userId);
                var adviser = edisRepo.GetAdviser(User.Identity.GetUserId(), DateTime.Now).Result;
                if (adviser != null)
                {
                    adviser.ImageMimeType = image.ContentType;
                    adviser.Image = new byte[image.ContentLength];

                    image.InputStream.Read(adviser.Image, 0, image.ContentLength);
                    adviser.LastUpdate = DateTime.Now;
                    //edisRepo.CreateAdviser(adviser, DateTime.Now);
                    TempData["success"] = "Profile image has been updated";

                }
                else
                {
                    TempData["error"] = "Adviser profile cannot be found.";
                }



            }
            else
            {
                TempData["error"] = "No image is selected";
            }
            return View();

        }

        public FileContentResult GetImage(string adviseruserId = "")
        {
            //if (!string.IsNullOrEmpty(adviseruserId))
            //{

            //    var adviser = adviserRepo.GetAdviserDetails().FirstOrDefault(ad => ad.AdvisorUserId == adviseruserId);

            //    //var adviser = edisRepo.GetAdviser(adviseruserId, DateTime.Now);
            //    if (adviser != null)
            //    {
            //        return File(adviser.Image, adviser.ImageMimeType);
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //else
            //{

            //    var userid = User.Identity.GetUserId();
            //    var adviser = adviserRepo.GetAdviserDetails().FirstOrDefault(ad => ad.AdvisorUserId == userid);
            //    if (adviser != null)
            //    {
            //        return File(adviser.Image, adviser.ImageMimeType);
            //    }
            //    else
            //    {
            //        return null;
            //    }

            //}

            return null;   //  ready to be deleted if finished this function
        }

        [Authorize(Roles = AuthorizationRoles.Role_Preadviser)]         //Role_Adviser   --> Role_Preadviser
        public ActionResult AdviserProfile(string userId)
        {
            Adviser adviser = edisRepo.GetAdviser(userId, DateTime.Now).Result;

            AdviserRegistrationBindingModel adviserModel = new AdviserRegistrationBindingModel();

            adviserModel.adviserUserId = adviser.Id;

            return View(adviserModel);
        }


        [HttpPost, Authorize(Roles = AuthorizationRoles.Role_Preadviser)]           //Role_Adviser   --> Role_Preadviser
        public ActionResult AdviserProfile(AdviserRegistrationBindingModel model)
        {

            //ViewBag.professTypes = cmRepo.GetAllProfessionTypes().Select(p => new SelectListItem
            //{
            //    Text = p.ProfessionType1,
            //    Value = p.ProfessionTypeId.ToString()
            //}).ToList();

            //if (model != null)
            //{
            //    checkEducationList(model);
            //}
            //if (ModelState.IsValid && model != null)
            //{
            //    var userid = User.Identity.GetUserId();

            //    try
            //    {
            //        adviserRepo.InsertOrUpdateAdviserProfile_Complete(model);
            //        adviserRepo.Save();
            //        TempData["success"] = "Profile has been successfully updated";
            //    }
            //    catch (Exception e)
            //    {

            //        TempData["error"] = "Update failed: " + e.Message;
            //    }

            //}
            return View(model);

        }



        //public string Test()
        //{
        //    var adviser = repo.GetAdviserDetails().FirstOrDefault();
        //    adviser.FirstName = "9999999999999999999";
        //    repo.Save();
        //    var secondAdviser = repo.GetAdviserDetails().FirstOrDefault();
        //    return "Good";
        //}


    }
}