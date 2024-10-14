using System.Text.Json.Serialization;
using Yarl.InvestorPortfolio.Core.Enums;

namespace Yarl.InvestorPortfolio.Core
{
    public class Investor
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public string Country { get; set; }
        public InvestoryTypes Type { get; set; }
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public DateTime ModifiedOn { get; set; }
        public decimal TotalCommitmentAmount { get; set; }
        
        [JsonIgnore]
        public IList<Commitment> Commitments { get; set; }
    }
}
