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
    public class PortfolioAustralianEquityController : ApiController
    {
     

        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/AustralianEquityPortfolio/General")]
        public SummaryGeneralInfo GetGeneralInfo_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetGeneral_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetGeneral_Client(clientUserId);
            }
        }
        [HttpGet, Route("api/Client/AustralianEquityPortfolio/General")]
        public SummaryGeneralInfo GetGeneralInfo_Client()
        {
            return repo.Overview_GetGeneral_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/AustralianEquityPortfolio/EvaluationModel")]
        public IEnumerable<EvaluationModel> GetEvaluationModel_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.AustralianEquity_GetModelEvaluation_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.AustralianEquity_GetModelEvaluation_Client(clientUserId);
            }
        }
        [HttpGet, Route("api/Client/AustralianEquityPortfolio/EvaluationModel")]
        public IEnumerable<EvaluationModel> GetEvaluationModel_Client()
        {
            return repo.AustralianEquity_GetModelEvaluation_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/AustralianEquityPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {

                //return repo.AustralianEquity_GetCashflowSummary_Adviser(User.Identity.GetUserId());
                return null;
            }
            else
            {
                //return repo.AustralianEquity_GetCashflowSummary_Client(clientUserId);
                return null;
            }
        }
        [HttpGet, Route("api/Client/AustralianEquityPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Client()
        {
            return repo.AustralianEquity_GetCashflowSummary_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/AustralianEquityPortfolio/CompanyProfiles")]
        public EquityCompanyProfileModel GetCompanyProfiles_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.AustralianEquity_GetCompanyProfiles_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.AustralianEquity_GetCompanyProfiles_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/AustralianEquityPortfolio/CompanyProfiles")]
        public EquityCompanyProfileModel GetCompanyProfiles_Client()
        {
            return repo.AustralianEquity_GetCompanyProfiles_Client(User.Identity.GetUserId());
        }


        [HttpGet, Route("api/Adviser/AustralianEquityPortfolio/QuickStats")]
        public IEnumerable<PortfolioQuickStatsModel> GetQuickStats_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.AustralianEquity_GetQuickStats_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.AustralianEquity_GetQuickStats_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/AustralianEquityPortfolio/QuickStats")]
        public IEnumerable<PortfolioQuickStatsModel> GetQuickStats_Client()
        {
            return repo.AustralianEquity_GetQuickStats_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/AustralianEquityPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.AustralianEquity_GetPortfolioRating_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.AustralianEquity_GetPortfolioRating_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/AustralianEquityPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Client()
        {
            return repo.AustralianEquity_GetPortfolioRating_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/AustralianEquityPortfolio/Diversification")]
        public EquityDiversificationModel GetDiversification_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.AustralianEquity_GetDiversification_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.AustralianEquity_GetDiversification_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/AustralianEquityPortfolio/Diversification")]
        public EquityDiversificationModel GetDiversification_Client()
        {
            return repo.AustralianEquity_GetDiversification_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/AustralianEquityPortfolio/CashflowDetail")]
        public EquityCashflowDetailedModel GetCashflowDetailed_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.AustralianEquity_GetSummaryCashflowDetailed_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.AustralianEquity_GetSummaryCashflowDetailed_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/AustralianEquityPortfolio/CashflowDetail")]
        public EquityCashflowDetailedModel GetCashflowDetailed_Client()
        {
            return repo.AustralianEquity_GetSummaryCashflowDetailed_Client(User.Identity.GetUserId());
        }

    }
}
