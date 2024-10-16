import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import "./Commitments.css";
import { AssetClasses, AssetClassToString } from "../../types/enums.ts";
import { formatNumber } from "../../utils/numberHelper.ts";
import AssetsSummariesFilter from "./AssetsSummariesFilter.tsx";
import Pagination from "../UI/Pagination.tsx";

interface Commitment {
  id: number;
  investorId: number;
  amount: number;
  assetClass: AssetClasses;
  currency: string;
}

const PAGE_SIZE: number = 20;

function Commitments() {
  const [commitments, setCommitments] = useState<Commitment[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [commitmentsCount, setCommitmentsCount] = useState(0);

  const { investorId } = useParams();
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [assetClass, setAssetClass] = useState<number>(AssetClasses.All);

  function updateFilteredAssets(toggleAssetClass: AssetClasses) {
    let newAssetClass = assetClass ^ toggleAssetClass;
    setAssetClass(newAssetClass);
  }

  function onPageChange(pageNumber: number) {
    setPageNumber(pageNumber);
  }

  useEffect(() => {
    setError(null);
    setLoading(true);

    getCommitments(investorId, assetClass, pageNumber, PAGE_SIZE)
      .then((c) => {
        setCommitments(c.commitments);
        setCommitmentsCount(c.commitmentsCount);
      })
      .catch((error) => {
        setError(error.message);
      })
      .finally(() => setLoading(false));
  }, [investorId, assetClass, pageNumber]);

  return (
    <>
      <div className="list-items">
        <h1 className="list-title">Commitments</h1>
        <AssetsSummariesFilter
          onFilterChanged={updateFilteredAssets}
          assetClass={assetClass}
        />
        {loading && <p>Loading investor commitments...</p>}
        {error && <p>Error: {error}</p>}
        {!loading && !error && commitments?.length == 0 && (
          <p>No commitments found for the investor with specified filters.</p>
        )}

        {!loading && !error && commitments?.length > 0 && (
          <>
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
                {commitments.map((c) => (
                  <tr key={c.id}>
                    <td>{c.id}</td>
                    <td>{AssetClassToString[c.assetClass]}</td>
                    <td>{c.currency}</td>
                    <td>{formatNumber(c.amount)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
            <Pagination
              currentPage={pageNumber}
              pageSize={PAGE_SIZE}
              totalRecords={commitmentsCount}
              onPageChange={onPageChange}
            />
          </>
        )}
      </div>
    </>
  );
}

async function getCommitments(
  investorId: any,
  assetClass: number,
  pageNumber: number,
  pageSize: number
) {
  const response = await fetch(
    `/api/investors/${Number(
      investorId
    )}/commitments?assetClass=${assetClass}&pageNumber=${pageNumber}&pageSize=${pageSize}`
  );
  return await response.json();
}

export default Commitments;
