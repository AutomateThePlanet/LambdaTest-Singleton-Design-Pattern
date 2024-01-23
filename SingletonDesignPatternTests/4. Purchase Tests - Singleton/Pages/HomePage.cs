namespace SingletonDesignPatternTests.FourthVersion;
public class HomePage : WebPage<HomePage>
{
    public IComponent SearchInput => Driver.FindComponent(By.XPath("//input[@name='search']"));

    public void SearchProduct(string searchText)
    {
        //SearchInput.Clear();
        SearchInput.TypeText(searchText);
        //SearchInput.SendKeys(Keys.Enter);
    }
}
