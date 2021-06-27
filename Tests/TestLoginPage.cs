using NUnit.Framework;

namespace M7_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestLogin : BaseTest
    {
        [Test]
        public void Login()
        {
            Assert.IsTrue(_homePage.FindAccountIconByAccountName());
        }
    }
}