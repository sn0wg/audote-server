namespace Audote.Server.Domain.Entities
{
    public class Paged<T>
    {
        public T Data { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public PageInfo(int total, int pageSize, int page) {
            Page = page;
            PageSize = pageSize;
            TotalItems = total;
            LastPage = (int)(total / (double)pageSize) - 1;
            PreviousPage = page == 0 ? null : page - 1;
            NextPage = page >= LastPage ? null : page + 1;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? PreviousPage { get; set; }
        public int? NextPage { get; set; }
        public int LastPage { get; set; }
        public int TotalItems { get; set; }
    }
}
