using NUnit.Framework;
using M7_Dzianis_Dukhnou.WebObjects;
using M7_Dzianis_Dukhnou.WebDriver;

namespace M7_Dzianis_Dukhnou
{
    public class BaseTest
    {
        protected Browser Browser;

        protected StartPage _startPage;
        protected LoginPage _loginPage;
        protected HomePage _homePage;
        protected LetterPage _letterPage;
        protected DraftPage _draftPage;
        protected SentPage _sentPage;
        protected UserMenuPage _userMenuPage;
        protected RightClickMenuPage _rightClickMenuPage;

        [SetUp]
        public void SetUp()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo();
            _startPage = new StartPage();
            _loginPage = _startPage.ClickLogin();
            _homePage = _loginPage.Login();
        }

        [TearDown]
        public void TearDown()
        {
            _userMenuPage = _homePage.OpenUserMenu();
            _userMenuPage.Logoff();
            Browser.Quit();
        }
    }
}