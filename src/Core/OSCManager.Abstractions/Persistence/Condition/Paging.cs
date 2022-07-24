namespace OSCManager.Abstractions.Persistence.Condition;

public class Paging
{
    public static Paging Page(int page, int pageSize) => new(page * pageSize, pageSize);

    public Paging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }

    public int Skip { get; }
    public int Take { get; }
}
