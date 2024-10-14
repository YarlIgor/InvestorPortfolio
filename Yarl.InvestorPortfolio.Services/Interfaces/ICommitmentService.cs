using Yarl.InvestorPortfolio.Core;

namespace Yarl.InvestorPortfolio.Services.Interfaces
{
    public interface ICommitmentService
    {
        Task<IEnumerable<Commitment>> GetCommitments(long investorId);
        Task Add(Commitment commitment);
    }
}
