using Yarl.InvestorPortfolio.Core;
using Dapper;
using Yarl.InvestorPortfolio.DataAccess.Interfaces;
using Yarl.InvestorPortfolio.Core.Enums;

namespace Yarl.InvestorPortfolio.DataAccess
{
    public class CommitmentRepository : ICommitmentRepository
    {
        private DataContext _context;

        public CommitmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Commitment commitment)
        {
            using var connection = _context.CreateConnection();
            var sql = "INSERT INTO Commitments(Id, InvestorId, AssetClass, Amount, Currency) VALUES (@Id, @InvestorId, @AssetClass, @Amount, @Currency)";
            await connection.ExecuteAsync(sql, commitment);
        }

        public async Task<IEnumerable<Commitment>> GetCommitments(long investorId)
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT c.* FROM Commitments c WHERE c.InvestorId = @investorId";
            return await connection.QueryAsync<Commitment>(sql, new { investorId});
        }

        public async Task<IEnumerable<Commitment>> GetCommitments(long investorId, AssetClasses assetClass, int pageSize, int pageNumber)
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT c.* FROM Commitments c WHERE c.InvestorId = @investorId AND (c.AssetClass & @assetClass) > 0 ORDER BY c.Id DESC LIMIT @pageSize OFFSET (@pageNumber - 1) * @pageSize";
            return await connection.QueryAsync<Commitment>(sql, new { investorId, pageSize, pageNumber, assetClass });
        }

        public async Task<long> GetCommitmentsCount(long investorId, AssetClasses assetClass)
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT COUNT(1) FROM Commitments c WHERE c.InvestorId = @investorId AND (c.AssetClass & @assetClass) > 0";
            return await connection.ExecuteScalarAsync<long>(sql, new { investorId, assetClass });
        }
    }
}
