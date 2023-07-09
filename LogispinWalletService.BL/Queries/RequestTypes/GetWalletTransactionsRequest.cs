using LogispinWalletService.Common.Enums;

namespace LogispinWalletService.BL.Queries.RequestTypes
{
    public class GetWalletTransactionsRequest
    {
        public string Email { get; set; }
        public TransactionQueryStatus TransactionStatus { get; set; }
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
