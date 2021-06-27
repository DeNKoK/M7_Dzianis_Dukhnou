using OpenQA.Selenium;

namespace M7_Dzianis_Dukhnou.WebObjects
{
    public class DraftPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//div[@title = 'Создать шаблон']");

        public DraftPage() : base(StartPageLocator, "Draft Page") { }

        private readonly BaseElement _selectAllCheckBox = new BaseElement(By.XPath("//span[@class = 'checkbox_view']"));
        private readonly BaseElement _deleteButton = new BaseElement(By.XPath("//div[contains(@title, 'Delete')]"));
        private readonly BaseElement _letter = new BaseElement(By.XPath("//span[contains(@class, 'js-message-snippet-left')]"));
        private BaseElement _subject;

        public bool FindLetterBySubject(string subject)
        {
            _subject = new BaseElement(By.XPath($"//span[@Title = '{subject}']"));

            return _subject.IsElementDisplayed();
        }

        public LetterPage OpenLetterByOrder(int number)
        {
            _letter.GetElements()[number - 1].Click();

            return new LetterPage();
        }

        public RightClickMenuPage RightClick(int number)
        {
            _letter.RightClick(_letter.GetElements()[number - 1]);

            return new RightClickMenuPage();
        }

        public int CountDraftLetters()
        {
            return _letter.GetElements().Count;
        }

        public void DeleteAll()
        {
            _selectAllCheckBox.Click();
            Delete();
        }

        public void Delete()
        {
            _deleteButton.Click();
        }
    }
}