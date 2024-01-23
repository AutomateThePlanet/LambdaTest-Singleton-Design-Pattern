namespace SingletonDesignPatternTests.FourthVersion;
public class WebPage<TPage> : ThreadSafeLazyBaseSingleton<TPage>
     where TPage : new()
{
    protected readonly IDriver Driver;

    public WebPage()
    {
        Driver = DriverAdapter.Instance;
    }
}
