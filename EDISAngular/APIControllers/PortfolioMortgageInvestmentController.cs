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
    public class PortfolioMortgageInvestmentController : ApiController
    {
        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/MortgageInvestmentPortfolio/General")]
        public MortgageInvestmentGeneralInfo GetGeneralInfo_Adviser()
        {
            return repo.Mortgate_GetGeneralInfo_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/MortgageInvestmentPortfolio/General")]
        public MortgageInvestmentGeneralInfo GetGeneralInfo_Client()
        {
            return repo.Mortgate_GetGeneralInfo_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/MortgageInvestmentPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Adviser()
        {
            return repo.Mortgate_GetCashflowSummary_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/MortgageInvestmentPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Client()
        {
            return repo.Mortgate_GetCashflowSummary_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/MortgageInvestmentPortfolio/CashflowDetailed")]
        public CashflowBriefModel GetDetailedCashflow_Adviser()
        {
            return repo.Mortgate_GetCashflowDetails_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/MortgageInvestmentPortfolio/CashflowDetailed")]
        public MortgageCashflowDetailedModel GetDetailedCashflow_Client()
        {
            return repo.Mortgate_GetCashflowDetails_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/MortgageInvestmentPortfolio/Stats")]
        public MortgageInvestmentStatModel GetStats_Adviser()
        {
            return repo.Mortgage_GetStats_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/MortgageInvestmentPortfolio/Stats")]
        public MortgageInvestmentStatModel GetStats_Client()
        {
            return repo.Mortgage_GetStats_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/MortgageInvestmentPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Adviser()
        {
            return repo.Mortgage_GetPortfolioRating_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/MortgageInvestmentPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Client()
        {
            return repo.Mortgage_GetPortfolioRating_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/MortgageInvestmentPortfolio/Profiles")]
        public MortgageInvestmentProfileModel GetProfiles_Adviser()
        {
            return repo.Mortgage_GetProfiles_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/MortgageInvestmentPortfolio/Profiles")]
        public MortgageInvestmentProfileModel GetProfiles_Client()
        {
            return repo.Mortgage_GetProfiles_Client(User.Identity.GetUserId());
        }


    }
}
