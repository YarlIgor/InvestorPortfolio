import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import AssetSummaryCart from "./AssetSummaryCart.tsx";
import "./Commitments.css";
import { AssetClasses, AssetClassToString } from "../types/enums.ts";
import { formatNumber } from "../utils/numberHelper.ts";

interface Commitment {
  id: number;
  investorId: number;
  amount: number;
  assetClass: AssetClasses;
  currency: string;
}

type Dictionary<TValue> = {
  [key: number]: TValue;
};

function Commitments() {
  const [commitments, setCommitments] = useState<Commitment[]>([]);
  const [assetSummaries, setAssetSummaries] = useState<Dictionary<number>>([]);
  const { investorId } = useParams();
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [assetClass, setAssetClass] = useState<number>(AssetClasses.All);

  function updateFilteredAssets(toggleAssetClass: AssetClasses) {
    let newAssetClass = assetClass ^ toggleAssetClass;
    setAssetClass(newAssetClass);
  }

  useEffect(() => {
    setError(null);
    setLoading(true);

    getCommitments(investorId)
      .then((c) => {
        const assetSummaries = getAssetSummary(c);
        setAssetSummaries(assetSummaries);
        setCommitments(c);
      })
      .catch((error) => {
        setError(error.message);
      })
      .finally(() => setLoading(false));
  }, [investorId]);

  return (
    <>
      {loading && <p>Loading investor commitments...</p>}
      {error && <p>Error: {error}</p>}
      {!loading && !error && commitments?.length == 0 && (
        <p>No commitments found for the investor: {investorId}.</p>
      )}

      {!loading && !error && commitments?.length > 0 && (
        <div className="list-items">
          <h1 className="list-title">Commitments</h1>
          <div className="assets-container">
            {Object.keys(assetSummaries).map((key) => (
              <AssetSummaryCart
                key={parseInt(key)}
                assetClass={parseInt(key)}
                amount={assetSummaries[parseInt(key)]}
                isActive={(assetClass & parseInt(key)) > 0}
                onCallBack={updateFilteredAssets}
              />
            ))}
          </div>

          <table className="table table-striped">
            <thead>
              <tr>
                <th>Id</th>
                <th>Asset Class</th>
                <th>Currency</th>
                <th>Amount</th>
              </tr>
            </thead>
            <tbody>
              {commitments
                .filter((c) => (assetClass & c.assetClass) > 0)
                .map((c) => (
                  <tr key={c.id}>
                    <td>{c.id}</td>
                    <td>{AssetClassToString[c.assetClass]}</td>
                    <td>{c.currency}</td>
                    <td>{formatNumber(c.amount)}</td>
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
      )}
    </>
  );
}

function getAssetSummary(commitments: Commitment[]): Dictionary<number> {
  let assetSummaries: Dictionary<number> = [];
  for (const commitment of commitments) {
    const { assetClass, amount } = commitment;

    if (assetSummaries[assetClass]) {
      assetSummaries[assetClass] += amount;
    } else {
      assetSummaries[assetClass] = amount;
    }
  }
  return assetSummaries;
}

async function getCommitments(investorId: any) {
  const response = await fetch(
    `/api/investors/${Number(investorId)}/commitments`
  );
  return await response.json();
}

export default Commitments;
