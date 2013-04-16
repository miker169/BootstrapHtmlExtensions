

namespace BootStrapHtmlExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using BootStrapHtmlExtensions.Extensions;

    /// <summary>
    /// All html helper checkbox input methods
    /// </summary>
    public static class HelperCheckBox
    {
        /// <summary>
        /// Bootstraps the checkbox for
        /// </summary>
        /// <typeparam name="TModel">The type of theModel</typeparam>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="expression">The expression</param>
        /// <param name="disabled"></param>
        /// <returns></returns>
        public static MvcHtmlString BootstrapCheckBoxFor<TModel>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, bool disabled = false)
        {
            var container = Common.GetRootContainer();
            var icontainer = Common.GetInputContainer();
            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            if (disabled)
            {
                css.Add("disabled");
                htmlAttributes.Add("disabled", "disabled");
            }

            htmlAttributes.Add("class", Common.GetCss(css));

            var label = Common.GetLabel(metadata.PropertyName, metadata.DisplayName);
            var input = htmlHelper.CheckBoxFor(expression, htmlAttributes);

            icontainer.InnerHtml = input.ToString();
            container.InnerHtml = label + icontainer.ToString();

            return container.ToMvcHtmlString();
        }
    }
}
