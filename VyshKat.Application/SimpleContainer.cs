namespace VyshKat.Application;

public class SimpleContainer
{
    private readonly Dictionary<Type, Func<object>> _services = new();

    public void Register<TInterface>(Func<TInterface> func)
    {
        _services[typeof(TInterface)] = () => func();
    }

    public T Resolve<T>()
    {
        if (_services.TryGetValue(typeof(T), out var service))
        {
            return (T)service();
        }

        throw new ArgumentException("Invalid type");
    }
}
