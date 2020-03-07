namespace LearningApi.Data
{
    public class PostParameter
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize == 0 ? maxPageSize : _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; }
        }

    }
}