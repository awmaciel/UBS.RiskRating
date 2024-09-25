using System;
using UBS.RiskRating.Interface;

namespace UBS.RiskRating.Model
{
    internal class HighRiskCategory : ICategory
    {
        public string Sort(Negotiation negotiation)
        {
            if (negotiation.Value > 1000000 && negotiation.Sector.Equals("Private", StringComparison.OrdinalIgnoreCase))
            {
                return "HIGH RIK";
            }
            return null;
        }
    }
}
