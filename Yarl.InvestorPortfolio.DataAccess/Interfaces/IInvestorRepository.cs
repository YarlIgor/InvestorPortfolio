using Yarl.InvestorPortfolio.Core;

namespace Yarl.InvestorPortfolio.DataAccess.Interfaces
{
    public interface IInvestorRepository
    {
        Task<IEnumerable<Investor>> GetAll();
        Task Add(Investor investor);
    }
}
