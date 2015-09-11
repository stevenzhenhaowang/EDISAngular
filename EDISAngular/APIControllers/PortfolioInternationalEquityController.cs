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
    public class PortfolioInternationalEquityController : ApiController
    {
        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/InternationalEquityPortfolio/General")]
        public SummaryGeneralInfo GetGeneralInfo_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.InternationalEquity_GetGeneral_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.InternationalEquity_GetGeneral_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/InternationalEquityPortfolio/General")]
        public SummaryGeneralInfo GetGeneralInfo_Client()
        {
            return repo.InternationalEquity_GetGeneral_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InternationalEquityPortfolio/EvaluationModel")]
        public IEnumerable<EvaluationModel> GetEvaluationModel_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.InternationalEquity_GetModelEvaluation_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.InternationalEquity_GetModelEvaluation_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/InternationalEquityPortfolio/EvaluationModel")]
        public IEnumerable<EvaluationModel> GetEvaluationModel_Client()
        {
            return repo.InternationalEquity_GetModelEvaluation_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InternationalEquityPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.InternationalEquity_GetCashflowSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.InternationalEquity_GetCashflowSummary_Client(clientUserId);
            }
        }
        [HttpGet, Route("api/Client/InternationalEquityPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Client()
        {
            return repo.InternationalEquity_GetCashflowSummary_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InternationalEquityPortfolio/CompanyProfiles")]
        public EquityCompanyProfileModel GetCompanyProfiles_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.InternationalEquity_GetCompanyProfiles_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.InternationalEquity_GetCompanyProfiles_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/InternationalEquityPortfolio/CompanyProfiles")]
        public EquityCompanyProfileModel GetCompanyProfiles_Client()
        {
            return repo.InternationalEquity_GetCompanyProfiles_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InternationalEquityPortfolio/QuickStats")]
        public IEnumerable<PortfolioQuickStatsModel> GetQuickStats_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.InternationalEquity_GetQuickStats_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.InternationalEquity_GetQuickStats_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/InternationalEquityPortfolio/QuickStats")]
        public IEnumerable<PortfolioQuickStatsModel> GetQuickStats_Client()
        {
            return repo.InternationalEquity_GetQuickStats_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InternationalEquityPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.InternationalEquity_GetPortfolioRating_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.InternationalEquity_GetPortfolioRating_Client(clientUserId);
            }
        }
        [HttpGet, Route("api/Client/InternationalEquityPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Client()
        {
            return repo.InternationalEquity_GetPortfolioRating_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InternationalEquityPortfolio/Diversification")]
        public EquityDiversificationModel GetDiversification_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.InternationalEquity_GetDiversification_Client(User.Identity.GetUserId());
            }
            else
            {
                return repo.InternationalEquity_GetDiversification_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/InternationalEquityPortfolio/Diversification")]
        public EquityDiversificationModel GetDiversification_Client()
        {
            return repo.InternationalEquity_GetDiversification_Adviser(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InternationalEquityPortfolio/CashflowDetail")]
        public EquityCashflowDetailedModel GetCashflowDetailed_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.InternationalEquity_GetSummaryCashflowDetailed_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.InternationalEquity_GetSummaryCashflowDetailed_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/InternationalEquityPortfolio/CashflowDetail")]
        public EquityCashflowDetailedModel GetCashflowDetailed_Client()
        {
            return repo.InternationalEquity_GetSummaryCashflowDetailed_Client(User.Identity.GetUserId());
        }


    }
}
