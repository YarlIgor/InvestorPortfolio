import "./Pagination.css";

interface PaginationProps {
  totalRecords: number;
  pageSize: number;
  currentPage: number;
  onPageChange: (page: number) => void;
}

function Pagination(props: PaginationProps) {
  const totalPages = Math.ceil(props.totalRecords / props.pageSize);

  if (totalPages === 1) return null; // No need to show pagination if there's only one page

  const handlePageChange = (page: number) => {
    if (page < 1 || page > totalPages) return;
    props.onPageChange(page);
  };

  const renderPageNumbers = () => {
    const pages = [];
    for (let i = 1; i <= totalPages; i++) {
      pages.push(
        <button
          key={i}
          onClick={() => handlePageChange(i)}
          disabled={i === props.currentPage}
        >
          {i}
        </button>
      );
    }
    return pages;
  };

  return (
    <div className="pagination-container">
      <button
        onClick={() => handlePageChange(props.currentPage - 1)}
        disabled={props.currentPage === 1}
      >
        Previous
      </button>
      {renderPageNumbers()}
      <button
        onClick={() => handlePageChange(props.currentPage + 1)}
        disabled={props.currentPage === totalPages}
      >
        Next
      </button>
    </div>
  );
}

export default Pagination;
