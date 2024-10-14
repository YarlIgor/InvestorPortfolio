using Yarl.InvestorPortfolio.Core;

public class AppConfiguration : IAppConfiguration
{
    private IConfigurationManager _configManager;
    public AppConfiguration(IConfigurationManager configManager)
    {
        _configManager = configManager;
    }
    public string ConnectionString => _configManager.GetConnectionString("InvestorPortfolio");
}