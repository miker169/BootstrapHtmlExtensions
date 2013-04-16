

namespace BootStrapHtmlExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using BootStrapHtmlExtensions.Extensions;

    /// <summary>
    /// All html helper text area input extension methods
    /// </summary>
    public static class HelperTextArea
    {
        /// <summary>
        /// Bootstraps the text area for
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression</param>
        /// <param name="rows">The rows.</param>
        /// <param name="inputSize">Size of the input.</param>
        /// <param name="disabled">if set to <c>true</c> [disabled]</param>
        /// <param name="helpText">The helptext</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapTextAreaFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            int rows = 2,
            InputSize inputSize = InputSize.medium,
            bool disabled = false,
            string helpText = "")
        {
            var container = Common.GetRootContainer();
            var icontainer = Common.GetInputContainer();
            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var error = Common.HasValidationError(htmlHelper, ExpressionHelper.GetExpressionText(expression));
            if (error)
            {
                container.AddCssClass("error");
            }

            css.Add(Common.GetCssClass(inputSize));

            if (disabled)
            {
                css.Add("disabled");
                htmlAttributes.Add("disabled", "disabled");
            }

            htmlAttributes.Add("rows", "rows");
            htmlAttributes.Add("class", Common.GetCss(css));

            var label = Common.GetLabel(metadata.PropertyName, metadata.DisplayName);
            var input = htmlHelper.TextAreaFor(expression, htmlAttributes);

            icontainer.InnerHtml = input.ToString() +Common.GetValidationMessageSpan(htmlHelper, ExpressionHelper.GetExpressionText(expression)) + Common.GetHelpSpan(helpText);
            container.InnerHtml = label + icontainer.ToString();

            return container.ToMvcHtmlString();




        }
    }
}
