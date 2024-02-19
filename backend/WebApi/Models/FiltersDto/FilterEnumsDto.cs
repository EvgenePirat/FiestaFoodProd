namespace WebApi.Models.FiltersDto
{
    public enum GridSortDirection
    {
        asc,
        desc
    }
    public enum GridFilterOperator
    {
        eq,
        neq,
        contains,
        isnull,
        isnotnull,
        doesnotcontain,
        startswith,
        endswith,
        gt,
        gte,
        lt,
        lte
    }

    public enum GridFilterLogic
    {
        and,
        or
    }
}
