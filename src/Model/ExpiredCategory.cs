using System;
using UBS.RiskRating.Interface;

namespace UBS.RiskRating.Model
{
    internal class ExpiredCategory : ICategory
    {
        private readonly DateTime _referenceDate;

        public ExpiredCategory(DateTime referenceDate)
        {
            _referenceDate = referenceDate;
        }

        public string Sort(Negotiation negotiation)
        {
            if ((negotiation.NextPaymentDate - _referenceDate).Days > 30)
            {
                return "EXPIRED";
            }
            return null;
        }
    }
}
