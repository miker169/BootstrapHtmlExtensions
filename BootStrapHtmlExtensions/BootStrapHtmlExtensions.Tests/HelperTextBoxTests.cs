
namespace BootStrapHtmlExtensions.Tests
{
    using BootStrapHtmlExtensions.Tests.TestModels;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HelperTextBoxTests
    {
        [TestMethod]
        public void BootstrapTextBoxFor_Model_No_Client_Validation()
        {
            var expected =
                "<div class=\"control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"span3\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"Mike\" /></div></div>";
            var model = new Contact() { Id = 1, FirstName = "Mike" };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, false);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void BootstrapTextBoxFor_Model_Valid_With_Client_Validation()
        {
            var expected =
                "<div class=\"control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"span3\" data-val=\"true\" data-val-required=\"The First Name field is required.\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"Mike\" /></div></div>";
            var model = new Contact { Id = 1, FirstName = "Mike" };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, true);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
