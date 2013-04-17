namespace BootStrapHtmlExtensions.Tests
{
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HelperButtonTests
    {
        [TestMethod]
        public void BootstrapButton_Default()
        {
            var expected = "<button class=\"btn\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text").ToString();
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void BoostrapButton_ButtonType_Primary()
        {
            var expected = "<button class=\"btn btn-primary\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.primary).ToString();
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Info()
        {
            var expected = "<button class=\"btn btn-info\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.info).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Success()
        {
            var expected = "<button class=\"btn btn-success\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.success).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Warning()
        {
            var expected = "<button class=\"btn btn-warning\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.warning).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Danger()
        {
            var expected = "<button class=\"btn btn-danger\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.danger).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonSize_Large()
        {
            var expected = "<button class=\"btn btn-large\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.@default, ButtonSize.large).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonSize_Small()
        {
            var expected = "<button class=\"btn btn-small\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.@default, ButtonSize.small).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonDisable_True()
        {
            var expected = "<button class=\"disabled btn\" disabled=\"disabled\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.@default, ButtonSize.@default,true).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapFormButtonContainer()
        {
            var expected = "<div class=\"form-actions\"></div>";
            var output = new StringBuilder();
            var htmlHelper = Util.GetHtmlHelper(output);

            using (htmlHelper.BootstrapFormButtonContainer())
            {
                
            }

            Assert.AreEqual(expected, output.ToString());
        }

        [TestMethod]
        public void BootstrapLinkButton_Default()
        {
            string expected = "<a class=\"btn\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#").ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_Primary()
        {
            string expected = "<a class=\"btn btn-primary\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.primary).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_Info()
        {
            string expected = "<a class=\"btn btn-info\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.info).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_Success()
        {
            string expected = "<a class=\"btn btn-success\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.success).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_Warning()
        {
            string expected = "<a class=\"btn btn-warning\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.warning).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_Danger()
        {
            string expected = "<a class=\"btn btn-danger\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.danger).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonSize_Large()
        {
            string expected = "<a class=\"btn btn-large\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.@default, ButtonSize.large).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonSize_Small()
        {
            string expected = "<a class=\"btn btn-small\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.@default, ButtonSize.small).ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
