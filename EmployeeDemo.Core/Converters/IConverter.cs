namespace EmployeeDemo.Core.Converters
{
    public interface IConverter<TSource, TDestination> where TSource : class
                                                        where TDestination : class
    {
        TDestination Convert(TSource source);

        List<TDestination> Convert(List<TSource> source);

        TSource Convert(TDestination source);

        List<TSource> Convert(List<TDestination> source);
    }

}
