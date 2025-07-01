namespace AutoMarket.BLL.Helpers
{
    public abstract class QueryStringParameters
    {
        // --- ПАГІНАЦІЯ ---
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        // --- СОРТУВАННЯ ---
        public string? OrderBy { get; set; }
    }
}