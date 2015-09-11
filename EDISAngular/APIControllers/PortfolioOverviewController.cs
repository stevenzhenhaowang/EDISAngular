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
    public class PortfolioOverviewController : ApiController
    {
        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/PortfolioOverview/Summary")]
        public PortfolioSummary GetPortfolioSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/PortfolioOverview/Summary")]
        public PortfolioSummary GetPortfolioSummary_Client()
        {
            return repo.Overview_GetSummary_Client(User.Identity.GetUserId());

        }
        [HttpGet, Route("api/Adviser/PortfolioOverview/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetCashflowSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetCashflowSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/PortfolioOverview/Cashflow")]
        public CashflowBriefModel GetCashflowSummary_Client()
        {
            return repo.Overview_GetCashflowSummary_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/PortfolioOverview/BestPerforming")]
        public IEnumerable<AssetPerformanceModel> GetBestPerforming_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetBestPerformingSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetBestPerformingSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Adviser/portfolioOverview/WorstPerforming")]
        public IEnumerable<AssetPerformanceModel> GetWorstPerforming_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetWorstPerformingSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetWorstPerformingSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/PortfolioOverview/BestPerforming")]
        public IEnumerable<AssetPerformanceModel> GetBestPerforming_Client()
        {
            return repo.Overview_GetBestPerformingSummary_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/portfolioOverview/WorstPerforming")]
        public IEnumerable<AssetPerformanceModel> GetWorstPerforming_Client()
        {
            return repo.Overview_GetWorstPerformingSummary_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/PortfolioOverview/General")]
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
        [HttpGet, Route("api/Client/PortfolioOverview/General")]
        public SummaryGeneralInfo GetGeneralInfo_Client()
        {
            return repo.Overview_GetGeneral_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/PortfolioOverview/Stastics")]
        public PortfolioStasticsModel GetStastics_Adviser(string clientUserId = null)
        {
            return repo.Overview_GetPortfolioStat_Adviser(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Client/PortfolioOverview/Stastics")]
        public PortfolioStasticsModel GetStastics_Client()
        {
            return repo.Overview_GetPortfolioStat_Client(User.Identity.GetUserId());
        }


        [HttpGet, Route("api/Adviser/PortfolioOverview/PortfolioRating")]
        public PortfolioRatingModel GetPortfolioRating_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetPortfolioRating_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetPortfolioRating_Client(clientUserId);
            }
        }
        [HttpGet, Route("api/Client/PortfolioOverview/PortfolioRating")]
        public PortfolioRatingModel GetPortfolioRating_Client()
        {
            return repo.Overview_GetPortfolioRating_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/PortfolioOverview/RecentStock")]
        public IEnumerable<StockDataModel> GetRecentStock()
        {
            return repo.Overview_GetRecentStockData();
        }
        [HttpGet, Route("api/Adviser/PortfolioOverview/InvestmentPortfolio")]
        public InvestmentPortfolioModel GetInvestmentPortfolio_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetInvestmentData_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetInvestmentData_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/PortfolioOverview/InvestmentPortfolio")]
        public InvestmentPortfolioModel GetInvestmentPortfolio_Client()
        {
            return repo.Overview_GetInvestmentData_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/PortfolioOverview/RegionalExposure")]
        public PortfolioRegionalExposureModel GetRegionalExposureSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetRegionSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetRegionSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/PortfolioOverview/RegionalExposure")]
        public PortfolioRegionalExposureModel GetRegionalExposureSummary_Client()
        {
            return repo.Overview_GetRegionSummary_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/PortfolioOverview/SectorialExposure")]
        public SectorialPortfolioModel GetSectorialExposureSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetSectorialSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetSectorialSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/PortfolioOverview/SectorialExposure")]
        public SectorialPortfolioModel GetSectorialExposureSummary_Client()
        {
            return repo.Overview_GetSectorialSummary_Client(User.Identity.GetUserId());
        }
        [HttpGet, Route("api/Adviser/PortfolioOverview/CashflowDetail")]
        public CashflowDetailedModel GetDetailedCashflowSummary_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Overview_GetSummaryCashflowDetailed_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Overview_GetSummaryCashflowDetailed_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/PortfolioOverview/CashflowDetail")]
        public CashflowDetailedModel GetDetailedCashflowSummary_Client()
        {
            return repo.Overview_GetSummaryCashflowDetailed_Client(User.Identity.GetUserId());
        }
    }
}
