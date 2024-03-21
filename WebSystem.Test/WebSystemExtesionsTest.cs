
namespace WebSystem.Test
{
    [TestClass]
    public class WebSystemExtesionsTest
    {
        [TestMethod]
        public void ShouldGenarateToken()
        {
            WebSystemToken.GenerateToken("5+IVE2SDIJCF12(@#$!W2@&%3saw123tp!", DateTime.UtcNow.AddHours(3));
        }

    }
}