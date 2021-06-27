using NUnit.Framework;

namespace M7_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestCreatingNumberOfLetters : BaseTest
    {
        string emailTo;
        string subject;
        string message;

        [SetUp]
        public void TestCreatingNumberOfLetters_SetUp()
        {
            emailTo = "dzianis.dukhnou@thomsonreuters.com";
            subject = "TestEmail";
            message = "TestEmail";
        }

        [TearDown]
        public void TestCreatingNumberOfLetters_TearDown()
        {
            _draftPage.DeleteAll();
        }

        [TestCase(15)]
        public void CreatingNumberOfDraftLetters(int number)
        {
            _homePage.CreateNumberOfDraftLetters(number, emailTo, subject, message);

            _draftPage = _homePage.OpenDraftLetters();

            _rightClickMenuPage = _draftPage.RightClick(10);
            _draftPage = _rightClickMenuPage.Delete();

            Assert.AreEqual(number - 1, _draftPage.CountDraftLetters());
        }
    }
}