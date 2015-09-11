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
    public class PortfolioCashTermDepositController : ApiController
    {
        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/CashTermDepositPortfolio/General")]
        public CashTermDepositGeneralInfoModel GetGeneralInfo_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.TermDeposit_GetGeneral_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.TermDeposit_GetGeneral_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/CashTermDepositPortfolio/General")]
        public CashTermDepositGeneralInfoModel GetGeneralInfo_Client()
        {
            return repo.TermDeposit_GetGeneral_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/CashTermDepositPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.TermDeposit_GetPortfolioRating_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.TermDeposit_GetPortfolioRating_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/CashTermDepositPortfolio/Rating")]
        public PortfolioRatingModel GetRatings_Client()
        {
            return repo.TermDeposit_GetPortfolioRating_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/CashTermDepositPortfolio/Price")]
        public TermDepositPriceChartModel GetPrice_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.TermDeposit_GetPriceData_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.TermDeposit_GetPriceData_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/CashTermDepositPortfolio/Price")]
        public TermDepositPriceChartModel GetPrice_Client()
        {
            return repo.TermDeposit_GetPriceData_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/CashTermDepositPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.TermDeposit_GetCashflowSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.TermDeposit_GetCashflowSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/CashTermDepositPortfolio/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Client()
        {
            return repo.TermDeposit_GetCashflowSummary_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/CashTermDepositPortfolio/Profiles")]
        public CashTermDepositProfileModel GetProfiles_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.TermDeposit_GetProfiles_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.TermDeposit_GetProfiles_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/CashTermDepositPortfolio/Profiles")]
        public CashTermDepositProfileModel GetProfiles_Client()
        {
            return repo.TermDeposit_GetProfiles_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/CashTermDepositPortfolio/Stats")]
        public IEnumerable<IncomeStatisticsModel> GetStats_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.TermDeposit_GetStats_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.TermDeposit_GetStats_Client(clientUserId);
            }
        }
        [HttpGet, Route("api/Client/CashTermDepositPortfolio/Stats")]
        public IEnumerable<IncomeStatisticsModel> GetStats_Client()
        {
            return repo.TermDeposit_GetStats_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/CashTermDepositPortfolio/Diversifications")]
        public IncomeDiversificationModel GetDiversification_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.TermDeposit_GetDiversification_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.TermDeposit_GetDiversification_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/CashTermDepositPortfolio/Diversifications")]
        public IncomeDiversificationModel GetDiversification_Client()
        {
            return repo.TermDeposit_GetDiversification_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/CashTermDepositPortfolio/CashflowDetailed")]
        public CashTermDepositCashflowDetailedModel GetDetailedCashflow_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.TermDeposit_GetCashflowDetails_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.TermDeposit_GetCashflowDetails_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/CashTermDepositPortfolio/CashflowDetailed")]
        public CashTermDepositCashflowDetailedModel GetDetailedCashflow_Client()
        {
            return repo.TermDeposit_GetCashflowDetails_Client(User.Identity.GetUserId());
        }

    }
}
