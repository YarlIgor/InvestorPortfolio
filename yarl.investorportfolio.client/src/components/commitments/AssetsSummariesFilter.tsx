import { useEffect, useState } from "react";
import AssetSummaryCart from "./AssetSummaryCart";
import { useParams } from "react-router-dom";
import { AssetSummary } from "../../types/interfaces";

interface AssetsSummariesFilterProps {
  onFilterChanged: (assetClass: number) => void;
  assetClass: number;
}

function AssetsSummariesFilter(props: AssetsSummariesFilterProps) {
  const [assetsSummaries, setAssetsSummaries] = useState<AssetSummary[]>([]);
  const { investorId } = useParams();
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setError(null);
    setLoading(true);

    getAssets(investorId)
      .then((a) => {
        setAssetsSummaries(a.assets);
      })
      .catch((error) => {
        setError(error.message);
      })
      .finally(() => setLoading(false));
  }, [investorId]);

  function assetSummaryCartClickHandler(assetClass: number) {
    props.onFilterChanged(assetClass);
  }

  return (
    <>
      {loading && <p>Loading investor assets...</p>}
      {error && <p>Error: {error}</p>}
      {!loading && !error && assetsSummaries?.length == 0 && (
        <p>No assetsSummaries found for the investor: {investorId}.</p>
      )}

      {!loading && !error && assetsSummaries?.length > 0 && (
        <div className="assets-container">
          {assetsSummaries.map((asset) => (
            <AssetSummaryCart
              key={asset.assetClass}
              assetClass={asset.assetClass}
              amount={asset.amount}
              isActive={(props.assetClass & asset.assetClass) > 0}
              onCallBack={assetSummaryCartClickHandler}
            />
          ))}
        </div>
      )}
    </>
  );
}

async function getAssets(investorId: any) {
  const response = await fetch(`/api/investors/${Number(investorId)}/assets`);
  return await response.json();
}

export default AssetsSummariesFilter;
