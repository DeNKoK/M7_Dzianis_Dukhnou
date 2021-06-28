using NUnit.Framework;

namespace M7_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestRightClick : BaseTest
    {
        string emailTo;
        string subject;
        string message;

        [SetUp]
        public void TestRightClick_SetUp()
        {
            emailTo = "dzianis.dukhnou@thomsonreuters.com";
            subject = "TestEmail";
            message = "TestEmail";
        }

        [Test]
        public void MoveLetterFromDraftToInput()
        {
            //Arrange
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);

            //Act
            _draftPage = _homePage.OpenDraftLetters();
            _rightClickMenuPage = _draftPage.RightClick(1);
            _rightClickMenuPage.MoveToInputFolder();

            //Assert
            Assert.IsFalse(_draftPage.FindLetterBySubject(subject), "The Letter is still in the draft folder");
        }
    }
}