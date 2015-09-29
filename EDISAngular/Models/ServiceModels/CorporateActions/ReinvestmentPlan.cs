using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDISAngular.Models.ServiceModels.CorporateActions
{
    public class ReinvestmentPlan
    {
        public string actionId { get; set; }
        public string actionCode { get; set; }
        public string reinvestmentShares { get; set; }
        public DateTime DRPDate { get; set; }
        public List<DRPParticipant> participant { get; set; }
    }

    public class DRPParticipant
    {
        public string edisAccountNumber { get; set; }

    }
}
