using OpenQA.Selenium;

namespace M7_Dzianis_Dukhnou.WebObjects
{
    public class RightClickMenuPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//div[@data-id = '8']");

        public RightClickMenuPage() : base(StartPageLocator, "RightClick Page") { }

        private readonly BaseElement _deleteButton = new BaseElement(By.XPath("//div[@data-id = '2']"));
        private readonly BaseElement _putInFolder = new BaseElement(By.XPath("//div[@data-id = '8']"));
        private readonly BaseElement _putInFolderInput = new BaseElement(By.XPath("//div[@title = 'Входящие']"));

        public void MoveToInputFolder ()
        {
            _putInFolder.Click();
            _putInFolderInput.Click();
        }

        public DraftPage Delete()
        {
            _deleteButton.Click();

            return new DraftPage();
        }
    }
}