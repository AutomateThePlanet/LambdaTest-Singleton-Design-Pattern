using SingletonDesignPatternTests.FourthVersion;
using SingletonDesignPatternTests.Models;

namespace SingletonDesignPattern.FourthVersion;

[TestFixture]
public class ProductPurchasePagesSingletonTests
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

        HomePage.Instance.SearchProduct("ip");
        ProductPage.Instance.SelectProductFromAutocomplete(expectedProduct1.Id);
        ProductPage.Instance.CompareLastProduct();
        HomePage.Instance.SearchProduct("ip");
        ProductPage.Instance.SelectProductFromAutocomplete(expectedProduct2.Id);
        ProductPage.Instance.CompareLastProduct();

        ProductPage.Instance.GoToComparePage();

        ProductPage.Instance.AssertCompareProductDetails(expectedProduct1, 1);
        ProductPage.Instance.AssertCompareProductDetails(expectedProduct2, 2);
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

        HomePage.Instance.SearchProduct("ip");
        ProductPage.Instance.SelectProductFromAutocomplete(expectedProduct1.Id);
        ProductPage.Instance.AddToCart(expectedProduct1.Quantity);
        CartPage.Instance.ViewCart();
        CartPage.Instance.AssertTotalPrice("$388.00");

        CartPage.Instance.Checkout();
        CheckoutPage.Instance.FillUserDetails(userDetails);
        CheckoutPage.Instance.FillBillingAddress(billingAddress);
        CheckoutPage.Instance.AssertTotalPrice("$396.00");

        CheckoutPage.Instance.AgreeToTerms();
        CheckoutPage.Instance.CompleteCheckout();
    }
}
