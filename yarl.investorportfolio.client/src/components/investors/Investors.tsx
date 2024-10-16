import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import { InvestoryTypes, InvestoryTypeToString } from "../../types/enums.ts";
import { formatDate } from "../../utils/dateHelper.ts";

interface Investor {
  id: number;
  name: string;
  country: string;
  type: InvestoryTypes;
  createdOn: string;
  totalCommitmentAmount: number;
}

function Investors() {
  const [investors, setInvestors] = useState<Investor[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setError(null);
    setLoading(true);

    getInvestors()
      .then((i) => {
        setInvestors(i);
      })
      .catch((error) => {
        setError(error.message);
      })
      .finally(() => setLoading(false));
  }, []);

  return (
    <>
      {loading && <p>Loading investors...</p>}
      {error && <p>Error: {error}</p>}
      {!loading && !error && investors?.length == 0 && (
        <p>No Investors were found.</p>
      )}

      {!loading && !error && investors?.length > 0 && (
        <div className="list-items">
          <h1 className="list-title">Investors</h1>
          <table className="table table-striped">
            <thead>
              <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Type</th>
                <th>Date Added</th>
                <th>Country</th>
                <th>Total Commitment</th>
                <th>View Commitments</th>
              </tr>
            </thead>
            <tbody>
              {investors.map((investor) => (
                <tr key={investor.id}>
                  <td>{investor.id}</td>
                  <td>{investor.name}</td>
                  <td>{InvestoryTypeToString[investor.type]}</td>
                  <td>{formatDate(investor.createdOn)}</td>
                  <td>{investor.country}</td>
                  <td>{investor.totalCommitmentAmount}</td>
                  <td>
                    <NavLink to={`/investors/${investor.id}/commitments`}>
                      View Commitments
                    </NavLink>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </>
  );
}

async function getInvestors() {
  const response = await fetch("/api/investors");
  return await response.json();
}

export default Investors;
