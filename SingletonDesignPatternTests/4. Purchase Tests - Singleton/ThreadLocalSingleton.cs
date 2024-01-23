namespace SingletonDesignPatternTests.FourthVersion;
using System.Threading;

public class ThreadLocalSingleton<T> where T : new()
{
    private static ThreadLocal<T> instance = new ThreadLocal<T>(() => new T());

    public static T Instance => instance.Value;
}
