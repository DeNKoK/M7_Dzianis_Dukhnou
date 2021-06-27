using NUnit.Framework;

namespace M7_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestSendEmail : BaseTest
    {
        string emailTo;
        string subject;
        string message;

        [SetUp]
        public void TestSendEmail_SetUp()
        {
            emailTo = "dzianis.dukhnou@thomsonreuters.com";
            subject = "TestEmail";
            message = "TestEmail";
        }

        [TearDown]
        public void TestSendEmail_TearDown()
        {
            _sentPage = _homePage.OpenSentLetters();
            _sentPage.DeleteAll();
        }

        [Test]
        public void SendingDraftEmail_CheckDraftFolder()
        {
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);

            _draftPage = _homePage.OpenDraftLetters();
            _letterPage = _draftPage.OpenLetterByOrder(1);
            _homePage = _letterPage.ClickSend();

            _draftPage = _homePage.OpenDraftLetters();

            Assert.IsFalse(_draftPage.FindLetterBySubject(subject));
        }

        [Test]
        public void SendingDraftEmail_CheckSentFolder()
        {
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);

            _draftPage = _homePage.OpenDraftLetters();
            _letterPage = _draftPage.OpenLetterByOrder(1);
            _homePage = _letterPage.ClickSend();

            _sentPage = _homePage.OpenSentLetters();

            Assert.IsTrue(_draftPage.FindLetterBySubject(subject));
        }
    }
}