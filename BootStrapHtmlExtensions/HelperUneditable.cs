

namespace BootStrapHtmlExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using BootStrapHtmlExtensions.Extensions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class HelperUneditable
    {
        /// <summary>
        /// Boostraps the uneditable input.
        /// </summary>
        /// <typeparam name="TModel">the type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="expression">The expression</param>
        /// <param name="inputSize">The Size of the input</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapUneditableInput<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, InputSize inputSize = InputSize.medium)
        {
            var container = Common.GetRootContainer();
            var icontainer = Common.GetInputContainer();
            var disabledInput = new TagBuilder("span");

            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            disabledInput.AddCssClass(Common.GetCssClass(inputSize));
            disabledInput.AddCssClass("uneditable-input");
            disabledInput.InnerHtml = metadata.Model.ToString();
            var label = Common.GetLabel(metadata.PropertyName, metadata.DisplayName);

            icontainer.InnerHtml = disabledInput.ToString();
            container.InnerHtml = label + icontainer.ToString();
            return container.ToMvcHtmlString();
        }
    }
}
