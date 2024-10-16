using Yarl.InvestorPortfolio.Core;
using Yarl.InvestorPortfolio.Core.Enums;

namespace Yarl.InvestorPortfolio.DataAccess.Interfaces
{
    public interface ICommitmentRepository
    {
        Task<IEnumerable<Commitment>> GetCommitments(long investorId);
        Task<IEnumerable<Commitment>> GetCommitments(long investorId, AssetClasses assetClass, int pageSize, int pageNumber);
        Task<long> GetCommitmentsCount(long investorId, AssetClasses assetClass);
        Task Add(Commitment commitment);
    }
}
