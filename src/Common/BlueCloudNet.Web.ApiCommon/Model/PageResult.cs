using BlueCloudNet.Web.ApiCommon.Persistence.Condition;

namespace BlueCloudNet.Web.ApiCommon.Model;

public class PageResult<T> : OperationalResult<IEnumerable<T>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int SumCount { get; set; }

    /// <summary>
    /// 无数据返回
    /// </summary>
    /// <param name="data"></param>
    /// <param name="paging"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    public static PageResult<T> OK(Paging paging) => new()
    {
        PageIndex = paging.PageIndex,
        PageSize = paging.PageSize,
    };

    /// <summary>
    /// 有数据返回
    /// </summary>
    /// <param name="data"></param>
    /// <param name="paging"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    public static PageResult<T> OK(IEnumerable<T> data, Paging paging, int sum) => new()
    {
        PageIndex = paging.PageIndex,
        PageSize = paging.PageSize,

        SumCount = sum,

        Data = data
    };
}
