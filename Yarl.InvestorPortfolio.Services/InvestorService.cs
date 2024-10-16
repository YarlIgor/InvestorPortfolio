using Yarl.InvestorPortfolio.Core;
using Yarl.InvestorPortfolio.DataAccess.Interfaces;
using Yarl.InvestorPortfolio.Services.Interfaces;

namespace Yarl.InvestorPortfolio.Services
{
    public class InvestorService : IInvestorService
    {
        private IInvestorRepository _repository;
        public InvestorService(IInvestorRepository repository) 
        { 
            _repository = repository;
        }

        public async Task Add(Investor investor)
        {
            await _repository.Add(investor);
        }

        public async Task<IEnumerable<Investor>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<AssetClassSummary>> GetAssetsSummmaries(long investorId)
        {
            return await _repository.GetAssetsSummmaries(investorId);
        }
    }
}
