using UBS.RiskRating.Model;

namespace UBS.RiskRating.Interface
{
    public interface ICategory
    {
        string Sort(Negotiation negotiation);
    }
}
