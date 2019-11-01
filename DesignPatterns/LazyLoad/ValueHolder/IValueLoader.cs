namespace DesignPatterns.LazyLoad.ValueHolder
{
    public interface IValueLoader<T>
    {
        T Load();
    }
}