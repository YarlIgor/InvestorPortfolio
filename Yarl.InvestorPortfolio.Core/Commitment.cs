using Yarl.InvestorPortfolio.Core.Enums;

namespace Yarl.InvestorPortfolio.Core
{
    public class Commitment
    {
        public long Id { get; set; }
        public AssetClasses AssetClass { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public long InvestorId { get; set; }
    }
}
