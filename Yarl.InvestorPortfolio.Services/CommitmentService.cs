using Yarl.InvestorPortfolio.Core;
using Yarl.InvestorPortfolio.DataAccess.Interfaces;
using Yarl.InvestorPortfolio.Services.Interfaces;

namespace Yarl.InvestorPortfolio.Services
{
    public class CommitmentService : ICommitmentService
    {
        private ICommitmentRepository _repository;
        public CommitmentService(ICommitmentRepository repository) 
        { 
            _repository = repository;
        }

        public async Task Add(Commitment commitment)
        {
            await _repository.Add(commitment);
        }

        public async Task<IEnumerable<Commitment>> GetCommitments(long investorId)
        {
            return await _repository.GetCommitments(investorId);
        }
    }
}
