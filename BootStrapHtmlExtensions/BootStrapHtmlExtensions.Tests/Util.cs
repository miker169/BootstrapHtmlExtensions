﻿namespace BootStrapHtmlExtensions.Tests
{
    using System.IO;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class Util
    {
        public static HtmlHelper<TModel> GetHtmlHelper<TModel>(TModel model, bool clientValidationEnabled)
        {
            var m = new MockContext();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(m.ViewEngine.Object);

            m.ViewData.Setup(x => x.ViewData).Returns(new ViewDataDictionary<TModel>(model));

            var routeData = new RouteData();
            routeData.Values["controller"] = "home";
            routeData.Values["action"] = "index";

            var htmlHelper = new HtmlHelper<TModel>(m.ViewContext.Object, m.ViewData.Object);
            return htmlHelper;
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
