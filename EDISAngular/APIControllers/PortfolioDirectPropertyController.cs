using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EDISAngular.Models.ServiceModels;
using EDISAngular.Infrastructure.DatabaseAccess;
using EDISAngular.Models.ServiceModels.PortfolioModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace EDISAngular.APIControllers
{
    public class PortfolioDirectPropertyController : ApiController
    {

        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/DirectPropertyPortfolio/General")]
        public SummaryGeneralInfo GetGeneralInfo_Adviser()
        {
            return repo.DirectProperty_GetGeneral_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/DirectPropertyPortfolio/General")]
        public SummaryGeneralInfo GetGeneralInfo_Client()
        {
            return repo.DirectProperty_GetGeneral_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/DirectPropertyPortfolio/GeoInfo")]
        public DirectPropertyGeoModel GetGeoInfo_Adviser()
        {
            return repo.DirectProperty_GetGeoInfo_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/DirectPropertyPortfolio/GeoInfo")]
        public DirectPropertyGeoModel GetGeoInfo_Client()
        {
            return repo.DirectProperty_GetGeoInfo_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/DirectPropertyPortfolio/QuickStats")]
        public IEnumerable<PortfolioQuickStatsModel> GetQuickStats_Adviser()
        {
            return repo.DirectProperty_GetQuickStats_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/DirectPropertyPortfolio/QuickStats")]
        public IEnumerable<PortfolioQuickStatsModel> GetQuickStats_Client()
        {
            return repo.DirectProperty_GetQuickStats_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/DirectPropertyPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Adviser()
        {
            return repo.DirectProperty_GetPortfolioRating_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/DirectPropertyPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Client()
        {
            return repo.DirectProperty_GetPortfolioRating_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/DirectPropertyPortfolio/CashflowDetail")]
        public CashflowBriefModel GetCashflowDetailed_Adviser()
        {
            return repo.DirectProperty_GetSummaryCashflowDetailed_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/DirectPropertyPortfolio/CashflowDetail")]
        public DirectPropertyCashflowDetailedModel GetCashflowDetailed_Client()
        {
            return repo.DirectProperty_GetSummaryCashflowDetailed_Client(User.Identity.GetUserId());
        }
    }
}
