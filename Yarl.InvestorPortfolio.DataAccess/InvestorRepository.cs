using Yarl.InvestorPortfolio.Core;
using Dapper;
using Yarl.InvestorPortfolio.DataAccess.Interfaces;

namespace Yarl.InvestorPortfolio.DataAccess
{
    public class InvestorRepository : IInvestorRepository
    {
        private DataContext _context;

        public InvestorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Investor>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT i.*, t.TotalCommitmentAmount  FROM Investors i INNER JOIN (SELECT c.InvestorId, SUM(c.Amount) AS TotalCommitmentAmount FROM Commitments c GROUP BY c.InvestorId) t ON i.Id = t.InvestorId";
            return await connection.QueryAsync<Investor>(sql);
        }

        public async Task Add(Investor investor)
        {
            using var connection = _context.CreateConnection();
            var sql = "INSERT INTO Investors(Id, Name, Type, Country, CreatedOn, ModifiedOn) VALUES (@Id, @Name, @Type, @Country, @CreatedOn, @ModifiedOn)";
            await connection.ExecuteAsync(sql, investor);
        }

        public async Task<IEnumerable<AssetClassSummary>> GetAssetsSummmaries(long investorId)
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT c.AssetClass, SUM(c.Amount) AS Amount FROM Commitments c WHERE c.InvestorId = @investorId GROUP BY c.AssetClass;";
            return await connection.QueryAsync<AssetClassSummary>(sql, new { investorId });
        }
    }
}
