using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EDISAngular.Infrastructure.DatabaseAccess;
using EDISAngular.Models.ServiceModels.CorporateActions;
using EDISAngular.Models.ServiceModels;
using Microsoft.AspNet.Identity;



namespace EDISAngular.APIControllers
{
    public class CorporateActionController : ApiController
    {
        private CorporateActionRepository corpRepo = new CorporateActionRepository();
        private CommonReferenceDataRepository comRepo = new CommonReferenceDataRepository();
        [HttpGet, Route("api/Adviser/CorporateAction/IPO")]
        public List<IPOActionData> GetAllIpoActionsForAdviser()
        {
            return corpRepo.GetAllIpoActionsForAdviser(User.Identity.GetUserId());
        }
        [HttpGet,Route("api/Adviser/CorporateAction/Other")]
        public List<OtherCorporateActionData> GetAllOtherCorporateActionsForAdviser()
        {
            return corpRepo.GetAllOtherActionsForAdviser(User.Identity.GetUserId());
        }
        [HttpPost, Route("api/Adviser/CorprateAction/IPO")]
        public IHttpActionResult CreateNewIPO(IPOActionData model)
        {
            if (model != null && ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost, Route("api/Adviser/CorprateAction/Other")]
        public IHttpActionResult CreateNewOther(OtherActionCreationModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet, Route("api/Adviser/CorporateAction/Company")]
        public List<CompanyBriefModel> GetAllCompanies()
        {
            return comRepo.GetAllCompanyBriefDetails();
        }
        [HttpGet, Route("api/Adviser/CorprateAction/Ticker")]
        public List<TickerBriefModel> GetAllTickers()
        {
            return comRepo.GetAllTIckers();
        }
        [HttpPost, Route("api/Adviser/CorporateAction/IPO/Allocation")]
        public IHttpActionResult AllocateIPO(IPOActionData model)
        {
            if (model != null && ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}
