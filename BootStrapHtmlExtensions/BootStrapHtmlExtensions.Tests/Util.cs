namespace BootStrapHtmlExtensions.Tests
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class Util
    {
        public static HtmlHelper<TModel> GetHtmlHelper<TModel>(TModel model, bool clientValidationEnabled, bool doModelValidation=false)
        {
            var m = new MockContext();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(m.ViewEngine.Object);
            var viewDataDictionary = new ViewDataDictionary<TModel>(model);

            m.ViewData.Setup(x => x.ViewData).Returns(viewDataDictionary);
            m.ViewContext.Setup(x => x.ClientValidationEnabled).Returns(clientValidationEnabled);
            m.ViewContext.Setup(x => x.UnobtrusiveJavaScriptEnabled).Returns(clientValidationEnabled);

            var routeData = new RouteData();
            routeData.Values["controller"] = "home";
            routeData.Values["action"] = "index";

            var htmlHelper = new HtmlHelper<TModel>(m.ViewContext.Object, m.ViewData.Object);
            MimicModelValidation<TModel>(model, m, viewDataDictionary, doModelValidation);
            return htmlHelper;
        }

        private static void MimicModelValidation<TModel>(TModel model, MockContext m, ViewDataDictionary<TModel> viewDataDictionary, bool doModelValidation)
        {
            if (doModelValidation)
            {
                var validationContext = new ValidationContext(model, null, null);
                var validtionResults = new List<ValidationResult>();
                Validator.TryValidateObject(model, validationContext, validtionResults, true);

                foreach (var validationResult in validtionResults)
                {
                    viewDataDictionary.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
                }
            }
        }

        public static HtmlHelper GetHtmlHelper()
        {
            return GetHtmlHelper(null);
        }

        public static HtmlHelper GetHtmlHelper(StringBuilder writerOutput)
        {
            var m = new MockContext();
            if (writerOutput != null)
            {
                m.ViewContext.Setup(x => x.Writer).Returns(new StringWriter(writerOutput));
            }

            var htmlHelper = new HtmlHelper(m.ViewContext.Object, m.ViewData.Object);
            return htmlHelper;
        }


    }
}
