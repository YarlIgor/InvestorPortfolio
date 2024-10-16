import "./AssetSummaryCart.css";
import { AssetClasses, AssetClassToString } from "../../types/enums.ts";
import { AssetSummary } from "../../types/interfaces.ts";
import { formatNumber } from "../../utils/numberHelper.ts";

interface AssetSummaryProps extends AssetSummary {
  assetClass: AssetClasses;
  isActive: boolean;
  onCallBack: (assetClass: number) => void;
}

const AssetSummaryCart = (props: AssetSummaryProps) => {
  function toggleState() {
    props.onCallBack(props.assetClass);
  }

  return (
    <div
      onClick={toggleState}
      className={`main-container ${props.isActive ? "active" : "inactive"}`}
    >
      <div>{AssetClassToString[props.assetClass]}</div>
      <div>£{formatNumber(props.amount)}</div>
    </div>
  );
};

export default AssetSummaryCart;
