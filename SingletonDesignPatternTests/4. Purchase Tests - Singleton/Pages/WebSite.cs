using SingletonDesignPatternTests.FourthVersion;

namespace DecoratorDesignPatternTests.FourthVersion;
public class WebSite : ThreadSafeLazyBaseSingleton<WebSite>
{
    //private readonly IDriver _driver;

    //public WebSite(IDriver driver)
    //{
    //    _driver = driver;
    //}

    public HomePage HomePage => new HomePage(DriverAdapter.Instance);
    public ProductPage ProductPage => new ProductPage(DriverAdapter.Instance);
    public CartPage CartPage => new CartPage(DriverAdapter.Instance);
    public CheckoutPage CheckoutPage => new CheckoutPage(DriverAdapter.Instance);
}
