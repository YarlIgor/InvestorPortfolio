using Yarl.InvestorPortfolio.Core;
using Yarl.InvestorPortfolio.Core.Enums;
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

        public async Task<IEnumerable<Commitment>> GetCommitments(long investorId, AssetClasses assetClass = AssetClasses.All, int? pageSize = null, int? pageNumber = null)
        {
            if (pageSize.HasValue && pageNumber.HasValue)
            {
                return await _repository.GetCommitments(investorId, assetClass, pageSize.Value, pageNumber.Value);
            }
                
            return await _repository.GetCommitments(investorId);
        }

        public async Task<long> GetCommitmentsCount(long investorId, AssetClasses assetClass)
        {
            return await _repository.GetCommitmentsCount(investorId, assetClass);
        }
    }
}
