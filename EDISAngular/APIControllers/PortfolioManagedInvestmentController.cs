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
    public class PortfolioManagedInvestmentController : ApiController
    {
        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/General")]
        public SummaryGeneralInfo GetGeneralInfo_Adviser()
        {
            return repo.ManagedInvestment_GetGeneral_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/ManagedInvestmentPortfolio/General")]
        public SummaryGeneralInfo GetGeneralInfo_Client()
        {
            return repo.ManagedInvestment_GetGeneral_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Adviser()
        {
            return repo.ManagedInvestment_GetCashflowSummary_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/ManagedInvestmentPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Client()
        {
            return repo.ManagedInvestment_GetCashflowSummary_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/AssetAllocation")]
        public InvestmentPortfolioModel GetAssetAllocationSummary_Adviser()
        {
            return repo.ManagedInvestment_GetAssetAllocation_Adviser(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/CompanyProfiles")]
        public ManagedInvestmentCompanyProfileModel GetCompanyProfiles_Adviser()
        {
            return repo.ManagedInvestment_GetCompanyProfiles_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/ManagedInvestmentPortfolio/CompanyProfiles")]
        public ManagedInvestmentCompanyProfileModel GetCompanyProfiles_Client()
        {
            return repo.ManagedInvestment_GetCompanyProfiles_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/QuickStats")]
        public IEnumerable<PortfolioQuickStatsModel> GetQuickStats_Adviser()
        {
            return repo.ManagedInvestment_GetQuickStats_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/ManagedInvestmentPortfolio/QuickStats")]
        public IEnumerable<PortfolioQuickStatsModel> GetQuickStats_Client()
        {
            return repo.ManagedInvestment_GetQuickStats_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Adviser()
        {
            return repo.ManagedInvestment_GetPortfolioRating_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/ManagedInvestmentPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Client()
        {
            return repo.ManagedInvestment_GetPortfolioRating_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/Diversification")]
        public EquityDiversificationModel GetDiversification_Adviser()
        {
            return repo.ManagedInvestment_GetDiversification_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/ManagedInvestmentPortfolio/Diversification")]
        public EquityDiversificationModel GetDiversification_Client()
        {
            return repo.ManagedInvestment_GetDiversification_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/DiversificationGroup")]
        public DiversificationGroupModel GetDiversificationGroupSummary_Adviser()
        {
            return repo.ManagedInvestment_GetDiversificationGroup_Adviser(User.Identity.GetUserId());
        }


        [HttpGet, Route("api/Adviser/ManagedInvestmentPortfolio/CashflowDetail")]
        public InvestmentCashflowDetailedModel GetCashflowDetailed_Adviser()
        {
            return repo.ManagedInvestment_GetSummaryCashflowDetailed_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/ManagedInvestmentPortfolio/CashflowDetail")]
        public InvestmentCashflowDetailedModel GetCashflowDetailed_Client()
        {
            return repo.ManagedInvestment_GetSummaryCashflowDetailed_Client(User.Identity.GetUserId());
        }





    }
}
