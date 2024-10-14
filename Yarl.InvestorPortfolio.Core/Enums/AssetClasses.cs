namespace Yarl.InvestorPortfolio.Core.Enums
{
    [Flags]
    public enum AssetClasses
    {
        None = 0,
        HedgeFunds = 1 << 0,
        PrivateEquity = 1 << 1,
        RealEstate = 1 << 2,
        Infrastructure = 1 << 3,
        NaturalResources = 1 << 4,
        PrivateDebt = 1 << 5,
        All = HedgeFunds | PrivateEquity | RealEstate | Infrastructure | NaturalResources
    }
}
