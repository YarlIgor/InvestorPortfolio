using Yarl.InvestorPortfolio.Core;

namespace Yarl.InvestorPortfolio.DataAccess.Interfaces
{
    public interface ICommitmentRepository
    {
        Task<IEnumerable<Commitment>> GetCommitments(long investorId);
        Task Add(Commitment commitment);
    }
}
