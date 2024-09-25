using System;

namespace UBS.RiskRating.Model
{
    public class Negotiation
    {
        public double Value { get; set; }
        public string Sector { get; set; }
        public DateTime NextPaymentDate { get; set; }
    }
}
