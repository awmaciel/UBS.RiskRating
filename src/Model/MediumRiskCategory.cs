using System;
using UBS.RiskRating.Interface;

namespace UBS.RiskRating.Model
{
    internal class MediumRiskCategory : ICategory
    {
        public string Sort(Negotiation negotiation)
        {
            if (negotiation.Value > 1000000 && negotiation.Sector.Equals("Público", StringComparison.OrdinalIgnoreCase))
            {
                return "MEDIUM RISK";
            }
            return null;
        }
    }
}
