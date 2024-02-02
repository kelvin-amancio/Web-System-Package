namespace WebSystem.Test
{
    [TestClass]
    public class WebSystemExtesionsTest
    {
        [TestMethod]
        public void ShouldClearCharacters()
        {
            var value = "Testing-@-";
            var ca = WebSystemStringHelper.ClearCharacters(value,'-', '@');
        }

    }
}