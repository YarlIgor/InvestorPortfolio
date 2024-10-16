using Yarl.InvestorPortfolio.Core;
using Yarl.InvestorPortfolio.Core.Enums;

namespace Yarl.InvestorPortfolio.Services.Interfaces
{
    public interface ICommitmentService
    {
        Task<IEnumerable<Commitment>> GetCommitments(long investorId, AssetClasses assetClass, int? pageSize = null, int? pageNumber = null);
        Task<long> GetCommitmentsCount(long investorId, AssetClasses assetClass);
        Task Add(Commitment commitment);
    }
}
