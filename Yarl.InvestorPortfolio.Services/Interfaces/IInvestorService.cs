using Yarl.InvestorPortfolio.Core;

namespace Yarl.InvestorPortfolio.Services.Interfaces
{
    public interface IInvestorService
    {
        Task<IEnumerable<Investor>> GetAll();
        Task Add(Investor investor);
    }
}
