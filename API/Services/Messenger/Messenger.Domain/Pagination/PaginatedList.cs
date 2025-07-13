namespace Messenger.Domain.Pagination;

public class PaginatedList<T>(int pageIndex, int pageSize, int totalCount, IReadOnlyList<T> data) where T : class
{
    public int PageIndex { get; set; } = pageIndex;
    public int PageSize { get; set; } = pageSize;
    public int TotalCount { get; set; } = totalCount;
    public IReadOnlyList<T> Data { get; set; } = data;
    public bool HasNextPage => PageIndex * PageSize < TotalCount;
    public bool HasPreviousPage => PageIndex > 1;
}
