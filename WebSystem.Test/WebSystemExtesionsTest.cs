
namespace WebSystem.Test
{
    [TestClass]
    public class WebSystemExtesionsTest
    {
        [TestMethod]
        public void ShouldGenarateToken()
        {
            var wso = new WebSystemObject
            {
                Name = "Kelvin",
                Email = "kelvin@gmail.com"
            };

             WebSystemToken.GenerateToken(wso,"5+IVE2SDIJCF12(@#$!W2@&%3saw123tp!", DateTime.UtcNow.AddHours(2));
        }

    }
}