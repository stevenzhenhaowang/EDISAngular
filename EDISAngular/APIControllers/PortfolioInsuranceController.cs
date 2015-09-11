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
    public class PortfolioInsuranceController : ApiController
    {
        private PortfolioRepository repo = new PortfolioRepository();
        [HttpGet, Route("api/Adviser/InsurancePortfolio/CashflowDetail")]
        public CashflowBriefModel GetCashflow_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Insurance_GetCashflowSummary_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Insurance_GetCashflowSummary_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/InsurancePortfolio/CashflowDetail")]
        public CashflowBriefModel GetCashflow_Client()
        {
            return repo.Insurance_GetCashflowSummary_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InsurancePortfolio/Statistics")]
        public InsuranceStatisticsModel GetStatistics_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Insurance_GetStatistics_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Insurance_GetStatistics_Client(clientUserId);
            }
        }
        [HttpGet, Route("api/Client/InsurancePortfolio/Statistics")]
        public InsuranceStatisticsModel GetStatistics_Client()
        {
            return repo.Insurance_GetStatistics_Client(User.Identity.GetUserId());
        }

        [HttpGet, Route("api/Adviser/InsurancePortfolio/InsuranceList")]
        public List<InsuranceListItemModel> GetInsuranceList_Adviser(string clientUserId = null)
        {
            if (string.IsNullOrEmpty(clientUserId))
            {
                return repo.Insurance_GetInsuranceList_Adviser(User.Identity.GetUserId());
            }
            else
            {
                return repo.Insurance_GetInsuranceList_Client(clientUserId);
            }

        }
        [HttpGet, Route("api/Client/InsurancePortfolio/InsuranceList")]
        public List<InsuranceListItemModel> GetInsuranceList_Client()
        {
            return repo.Insurance_GetInsuranceList_Client(User.Identity.GetUserId());
        }

        //[HttpGet, Route("api/Adviser/InsurancePortfolio/Conditions")]
        //public List<InsuranceConditionModel> GetConditions_Adviser(string clientUserId = null)
        //{
        //    if (string.IsNullOrEmpty(clientUserId))
        //    {
        //        return repo.Insurance_GetConditions_Adviser(User.Identity.GetUserId());
        //    }
        //    else
        //    {
        //        return repo.Insurance_GetConditions_Client(clientUserId);
        //    }
        //}
        //[HttpGet, Route("api/Client/InsurancePortfolio/Conditions")]
        //public List<InsuranceConditionModel> GetConditions_Client()
        //{
        //    return repo.Insurance_GetConditions_Client(User.Identity.GetUserId());
        //}

    }
}
