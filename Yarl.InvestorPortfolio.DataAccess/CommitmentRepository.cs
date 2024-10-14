using Yarl.InvestorPortfolio.Core;
using Dapper;
using Yarl.InvestorPortfolio.DataAccess.Interfaces;

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
    }
}
