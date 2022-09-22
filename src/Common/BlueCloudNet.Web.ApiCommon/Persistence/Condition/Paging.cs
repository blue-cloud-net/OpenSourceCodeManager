namespace BlueCloudNet.Web.ApiCommon.Persistence.Condition;

public class Paging
{
    public static Paging Page(int? pageIndex, int? pageSize)
    {
        if (!pageIndex.HasValue || pageIndex.Value <= 0)
        {
            pageIndex = 0;
        }

        if (!pageSize.HasValue || pageSize.Value <= 0)
        {
            pageSize = 15;
        }

        return new(pageIndex.Value, pageSize.Value);
    }

    public Paging(int pageIndex, int pageSize)
    {
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;

        this.Skip = pageIndex * pageSize;
        this.Take = pageSize;
    }

    public int PageIndex { get; }
    public int PageSize { get; }

    public int Skip { get; }
    public int Take { get; }
}
