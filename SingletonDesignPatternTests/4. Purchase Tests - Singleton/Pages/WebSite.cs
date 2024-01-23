namespace SingletonDesignPatternTests.FourthVersion;
public class WebSite : ThreadSafeLazyBaseSingleton<WebSite>
{
    //private readonly IDriver _driver;

    //public WebSite(IDriver driver)
    //{
    //    _driver = driver;
    //}

    public HomePage HomePage => HomePage.Instance;
    public ProductPage ProductPage => ProductPage.Instance;
    public CartPage CartPage => CartPage.Instance;
    public CheckoutPage CheckoutPage => CheckoutPage.Instance;
}
