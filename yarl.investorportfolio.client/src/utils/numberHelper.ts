export function formatNumber(num: number) {
  if (num >= 1_000_000_000) {
    return formatDecimal(num / 1_000_000_000) + "B";
  } else if (num >= 1_000_000) {
    return formatDecimal(num / 1_000_000) + "M";
  } else if (num >= 1_000) {
    return formatDecimal(num / 1_000) + "K";
  }
  return num.toString();
}

export function formatDecimal(num: number) {
  return num % 1 === 0 ? num.toFixed(0) : num.toFixed(1);
}
