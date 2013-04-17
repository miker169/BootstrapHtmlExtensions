

namespace BootStrapHtmlExtensions.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HelperIconTests
    {
        [TestMethod]
        public void BootstrapIcon_DefaultIcon_returns_empty_string()
        {
            string expected = string.Empty;
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapIcon(Icon.@default).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapIcon_Default_Is_Inverted_returns_empty_string()
        {
            var expected = string.Empty;
            var htmlHelper = Util.GetHtmlHelper();
            var result = htmlHelper.BootstrapIcon(Icon.@default, true).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapIcon_Glass_Not_Inverted()
        {
            var expected = "<i class=\"icon-glass\"></i> ";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapIcon(Icon.icon_glass).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapIcon_Glass_Is_Inverted()
        {
            var expected = "<i class=\"icon-white icon-glass\"></i> ";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapIcon(Icon.icon_glass, true).ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
