export enum AssetClasses {
  None = 0,
  HedgeFunds = 1 << 0,
  PrivateEquity = 1 << 1,
  RealEstate = 1 << 2,
  Infrastructure = 1 << 3,
  NaturalResources = 1 << 4,
  PrivateDebt = 1 << 5,
  All = HedgeFunds |
    PrivateEquity |
    RealEstate |
    Infrastructure |
    NaturalResources |
    PrivateDebt,
}

export const AssetClassToString: { [key in AssetClasses]: string } = {
  [AssetClasses.None]: "No Asset Class",
  [AssetClasses.HedgeFunds]: "Hedge Funds",
  [AssetClasses.Infrastructure]: "Infrastructure",
  [AssetClasses.NaturalResources]: "Natural Resources",
  [AssetClasses.PrivateEquity]: "Private Equity",
  [AssetClasses.RealEstate]: "Real Estate",
  [AssetClasses.PrivateDebt]: "Private Debt",
  [AssetClasses.All]: "All",
};

export enum InvestoryTypes {
  None = 0,
  FundManager = 1 << 0,
  AssetManager = 1 << 1,
  WealthManager = 1 << 2,
  Bank = 1 << 3,
}

export const InvestoryTypeToString: { [key in InvestoryTypes]: string } = {
  [InvestoryTypes.None]: "No Investory Type",
  [InvestoryTypes.AssetManager]: "asset manager",
  [InvestoryTypes.Bank]: "bank",
  [InvestoryTypes.FundManager]: "fund manager",
  [InvestoryTypes.WealthManager]: "wealth manager",
};
