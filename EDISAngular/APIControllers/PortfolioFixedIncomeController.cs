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
    public class PortfolioFixedIncomeController : ApiController
    {
        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/FixedIncomePortfolio/General")]
        public SummaryGeneralInfoFCL GetGeneralInfo_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.FixedIncome_GetGeneral_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.FixedIncome_GetGeneral_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/FixedIncomePortfolio/General")]
        public SummaryGeneralInfoFCL GetGeneralInfo_Client()
        {
            return repo.FixedIncome_GetGeneral_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/FixedIncomePortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.FixedIncome_GetPortfolioRating_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.FixedIncome_GetPortfolioRating_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/FixedIncomePortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Client()
        {
            return repo.FixedIncome_GetPortfolioRating_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/FixedIncomePortfolio/Price")]
        public CashPriceChartModel GetPrice_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.FixedIncome_GetPriceData_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.FixedIncome_GetPriceData_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/FixedIncomePortfolio/Price")]
        public CashPriceChartModel GetPrice_Client()
        {
            return repo.FixedIncome_GetPriceData_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/FixedIncomePortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.FixedIncome_GetCashflowSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.FixedIncome_GetCashflowSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/FixedIncomePortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Client()
        {
            return repo.FixedIncome_GetCashflowSummary_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/FixedIncomePortfolio/Profiles")]
        public FixedIncomeProfileModel GetProfiles_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.FixedIncome_GetProfiles_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.FixedIncome_GetProfiles_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/FixedIncomePortfolio/Profiles")]
        public FixedIncomeProfileModel GetProfiles_Client()
        {
            return repo.FixedIncome_GetProfiles_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/FixedIncomePortfolio/Stats")]
        public IEnumerable<IncomeStatisticsModel> GetStats_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.FixedIncome_GetStats_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.FixedIncome_GetStats_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/FixedIncomePortfolio/Stats")]
        public IEnumerable<IncomeStatisticsModel> GetStats_Client()
        {
            return repo.FixedIncome_GetStats_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/FixedIncomePortfolio/Diversifications")]
        public IncomeDiversificationModel GetDiversification_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.FixedIncome_GetDiversification_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.FixedIncome_GetDiversification_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/FixedIncomePortfolio/Diversifications")]
        public IncomeDiversificationModel GetDiversification_Client()
        {
            return repo.FixedIncome_GetDiversification_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/FixedIncomePortfolio/CashflowDetailed")]
        public FixedIncomeCashflowDetailedModel GetDetailedCashflow_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.FixedIncome_GetCashflowDetails_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.FixedIncome_GetCashflowDetails_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/FixedIncomePortfolio/CashflowDetailed")]
        public FixedIncomeCashflowDetailedModel GetDetailedCashflow_Client()
        {
            return repo.FixedIncome_GetCashflowDetails_Client(User.Identity.GetUserId());
        }


    }
}
