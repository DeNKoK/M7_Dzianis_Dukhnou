using M7_Dzianis_Dukhnou.WebObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace M7_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestDraftEmail : BaseTest
    {
        string emailTo;
        string subject;
        string message;

        [SetUp]
        public void TestDraftEmail_SetUp()
        {
            emailTo = "dzianis.dukhnou@thomsonreuters.com";
            subject = "TestEmail";
            message = "TestEmail";
        }

        [TearDown]
        public void TestDraftEmail_TearDown()
        {
            _draftPage = _homePage.OpenDraftLetters();
            _draftPage.DeleteAll();
        }

        [Test]
        public void CreatingDraftEmail_VerifyDarftFolder()
        {
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);

            _draftPage = _homePage.OpenDraftLetters();

            Assert.IsTrue(_draftPage.FindLetterBySubject(subject));
        }

        [Test]
        public void CreatingDraftEmail_VerifyContent()
        {
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);

            _draftPage = _homePage.OpenDraftLetters();
            _letterPage = _draftPage.OpenLetterByOrder(1);

            Assert.AreEqual(emailTo, _letterPage.GetToField());
            Assert.AreEqual(subject, _letterPage.GetSubjectField());
            Assert.AreEqual(message, _letterPage.GetMessageField());
        }
    }
}