namespace BootStrapHtmlExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using BootStrapHtmlExtensions.Extensions;

    /// <summary>
    /// All html helper select input extension methods
    /// </summary>
    public static class HelperSelect
    {
        /// <summary>
        /// Bootstraps the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="expression">The expression</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="inputSize">Size of the input</param>
        /// <param name="disabled">if set to <c>true</c> [disabled]</param>
        /// <param name="helpText">The help text</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectList,
            InputSize inputSize = InputSize.medium,
            bool disabled = false,
            string helpText = "")
        {
            var container = Common.GetRootContainer();
            var icontainer = Common.GetInputContainer();
            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var error =Common. HasValidationError(htmlHelper, ExpressionHelper.GetExpressionText(expression));

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
            htmlAttributes.Add("class", Common.GetCss(css));

            MvcHtmlString label = Common.GetLabel(metadata.PropertyName, metadata.DisplayName);
            MvcHtmlString input = htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);

            icontainer.InnerHtml = input.ToString()
                                   + Common.GetValidationMessageSpan(
                                       htmlHelper,
                                       ExpressionHelper.GetExpressionText(expression) + Common.GetHelpSpan(helpText));
            container.InnerHtml = label + icontainer.ToString();

            return container.ToMvcHtmlString();
        }
    }
}
