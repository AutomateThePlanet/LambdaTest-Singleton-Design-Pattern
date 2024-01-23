namespace SingletonDesignPatternTests.FourthVersion;
public class ThreadStaticSingleton<T> 
    where T : new()
{
    // In C#, we can simulate ThreadLocal behavior by using the [ThreadStatic] attribute. 
    [ThreadStatic]
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
