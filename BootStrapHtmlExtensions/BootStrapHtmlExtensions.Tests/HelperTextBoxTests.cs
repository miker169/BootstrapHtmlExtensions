
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
                "<div class=\"control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-medium\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"Mike\" /></div></div>";
            var model = new Contact() { Id = 1, FirstName = "Mike" };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, false);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void BootstrapTextBoxFor_Model_Valid_With_Client_Validation()
        {
            var expected =
                "<div class=\"control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-medium\" data-val=\"true\" data-val-required=\"The First Name field is required.\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"Mike\" /></div></div>";
            var model = new Contact { Id = 1, FirstName = "Mike" };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, true);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void BootstrapTextBoxFor_Model_Invalid_No_Client_Validation()
        {
            var expected =
                "<div class=\"error control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-validation-error input-medium\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"\" /><span class=\"help-inline\">The First Name field is required.</span></div></div>";
            var model = new Contact() { Id = 1, FirstName = string.Empty };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, false, true);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapTextBoxFor_Model_Invalid_With_Client_Validation()
        {
            var expected =
                "<div class=\"error control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-validation-error input-medium\" data-val=\"true\" data-val-required=\"The First Name field is required.\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"\" /><span class=\"help-inline\">The First Name field is required.</span></div></div>";
            var model = new Contact() { Id = 1, FirstName = string.Empty };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, true, true);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapTextBoxFor_Model_Valid_No_Clinent_Validation_Disabled()
        {
            var expected = "<div class=\"control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-medium disabled\" disabled=\"disabled\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"Test\" /></div></div>";
            var model = new Contact() { Id = 1, FirstName = "Test" };

            var htmlHelper = Util.GetHtmlHelper<Contact>(model, false, false);
            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName, disabled: true).ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
