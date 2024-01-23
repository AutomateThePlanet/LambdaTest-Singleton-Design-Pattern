using SingletonDesignPatternTests.FourthVersion;
using SingletonDesignPatternTests.Models;

namespace SingletonDesignPattern.FourthVersion;

[TestFixture]
public class ProductPurchaseWebSiteSingletonTests
{
    [SetUp]
    public void TestInit()
    {
        DriverAdapter.Instance.Start(Browser.Chrome);
        DriverAdapter.Instance.GoToUrl("https://ecommerce-playground.lambdatest.io/");
    }

    [TearDown]
    public void TestCleanup()
    {
        DriverAdapter.Instance.Quit();
    }

    [Test]
    public void CorrectInformationDisplayedInCompareScreen_WhenOpenProductFromSearchResults_TwoProducts()
    {
        // Arrange
        var expectedProduct1 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            Price = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Weight = "5.00kg"
        };

        var expectedProduct2 = new ProductDetails
        {
            Name = "iPod Shuffle",
            Id = 34,
            Price = "$182.00",
            Model = "Product 7",
            Brand = "Apple",
            Weight = "5.00kg"
        };

        WebSite.Instance.HomePage.SearchProduct("ip");
        WebSite.Instance.ProductPage.SelectProductFromAutocomplete(expectedProduct1.Id);
        WebSite.Instance.ProductPage.CompareLastProduct();
        WebSite.Instance.HomePage.SearchProduct("ip");
        WebSite.Instance.ProductPage.SelectProductFromAutocomplete(expectedProduct2.Id);
        WebSite.Instance.ProductPage.CompareLastProduct();

        WebSite.Instance.ProductPage.GoToComparePage();

        WebSite.Instance.ProductPage.AssertCompareProductDetails(expectedProduct1, 1);
        WebSite.Instance.ProductPage.AssertCompareProductDetails(expectedProduct2, 2);
    }

    [Test]
    public void PurchaseTwoSameProduct()
    {
        var expectedProduct1 = new ProductDetails
        {
            Name = "iPod Touch",
            Id = 32,
            Price = "$194.00",
            Model = "Product 5",
            Brand = "Apple",
            Weight = "5.00kg",
            Quantity = "2"
        };

        var userDetails = new UserDetails
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            Telephone = "1234567890",
            Password = "password123",
            ConfirmPassword = "password123",
            AccountType = AccountOption.Register
        };

        var billingAddress = new BillingAddress
        {
            FirstName = "John",
            LastName = "Doe",
            Company = "Acme Corp",
            Address1 = "123 Main St",
            Address2 = "Apt 4",
            City = "Metropolis",
            PostCode = "12345",
            Country = "United States",
            Region = "Alabama"
        };

        WebSite.Instance.HomePage.SearchProduct("ip");
        WebSite.Instance.ProductPage.SelectProductFromAutocomplete(expectedProduct1.Id);
        WebSite.Instance.ProductPage.AddToCart(expectedProduct1.Quantity);
        WebSite.Instance.CartPage.ViewCart();
        WebSite.Instance.CartPage.AssertTotalPrice("$388.00");

        WebSite.Instance.CartPage.Checkout();
        WebSite.Instance.CheckoutPage.FillUserDetails(userDetails);
        WebSite.Instance.CheckoutPage.FillBillingAddress(billingAddress);
        WebSite.Instance.CheckoutPage.AssertTotalPrice("$396.00");

        WebSite.Instance.CheckoutPage.AgreeToTerms();
        WebSite.Instance.CheckoutPage.CompleteCheckout();
    }
}
