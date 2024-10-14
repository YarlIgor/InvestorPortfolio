using Microsoft.Data.Sqlite;
using Yarl.InvestorPortfolio.Core;
using System.Data;

namespace Yarl.InvestorPortfolio.DataAccess
{
    public class DataContext
    {
        protected readonly IAppConfiguration Configuration;

        public DataContext(IAppConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(Configuration.ConnectionString);
        }
    }
}
