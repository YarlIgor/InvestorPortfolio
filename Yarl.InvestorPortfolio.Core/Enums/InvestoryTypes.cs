namespace Yarl.InvestorPortfolio.Core.Enums
{
    public enum InvestoryTypes
    {
        None = 0,
        FundManager = 1 << 0,
        AssetManager = 1 << 1,
        WealthManager = 1 << 2,
        Bank = 1 << 3
    }
}
