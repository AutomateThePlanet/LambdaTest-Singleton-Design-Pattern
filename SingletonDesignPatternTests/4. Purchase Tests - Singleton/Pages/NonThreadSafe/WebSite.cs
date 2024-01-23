namespace SingletonDesignPatternTests.FourthVersion.NonThreadSafe;
public class WebSite
{
    private readonly IDriver _driver;

    public WebSite(IDriver driver)
    {
        _driver = driver;

        // we can implement lazy loading here
        HomePage = HomePage.Instance;
        ProductPage = ProductPage.Instance;
        CartPage = CartPage.Instance;
        CheckoutPage = CheckoutPage.Instance;
    }

    public HomePage HomePage { get; private set; }
    public ProductPage ProductPage { get; private set; }
    public CartPage CartPage { get; private set; }
    public CheckoutPage CheckoutPage { get; private set; }
}
