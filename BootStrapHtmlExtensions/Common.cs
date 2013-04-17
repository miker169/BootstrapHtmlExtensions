namespace BootStrapHtmlExtensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    using BootStrapHtmlExtensions.Extensions;

    /// <summary>
    /// Common items used by more than one helper class
    /// </summary>
    internal static class Common
    {

      

        /// <summary>
        /// Gets the CSS class
        /// </summary>
        /// <param name="inputSize">The size of the input</param>
        /// <returns>The css class of the input size</returns>
        internal static string GetCssClass(InputSize inputSize)
        {
            switch (inputSize)
            {
                case InputSize.small:
                    return "span2";
                case InputSize.medium:
                    return "span3";
                case InputSize.large:
                    return "span4";
                default:
                    return string.Empty;

            }
        }

        /// <summary>
        /// Gets the CSS.
        /// </summary>
        /// <param name="css">The CSS. </param>
        /// <returns>comma delimeted list of css classes</returns>
        internal static string GetCss(IEnumerable<string> css)
        {
            var sb = new StringBuilder();
            foreach (var c in css)
            {
                sb.Append(string.Format("{0}", c));
            }

            return sb.ToString();
        }
      
        /// <summary>
        /// Gets the Root container
        /// </summary>
        /// <returns>A Tag Builder</returns>
        internal static TagBuilder GetRootContainer()
        {
            var container = new TagBuilder("div");
            container.AddCssClass("control-group");
            return container;
        }

        /// <summary>
        /// Gets the input container.
        /// </summary>
        /// <returns>A TagBuilder</returns>
        internal static TagBuilder GetInputContainer()
        {
            var b = new TagBuilder("div");
            b.AddCssClass("controls");
            return b;
        }


    

        /// <summary>
        /// Determines whether [has validation error] [the specified HTML helper]
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="name">The name.</param>
        /// <returns>
        /// <c>true</c> if [has validation error] [the specified HTML helper]; otherwise <c>false</c>
        /// </returns>
        internal static bool HasValidationError(HtmlHelper htmlHelper, string name)
        {
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the validation message for you
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression</param>
        /// <returns>An MvcHtmlString</returns>
        internal static MvcHtmlString GetValidationMessageSpan(HtmlHelper htmlHelper, string expression)
        {
            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);

            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName))
            {
                return new MvcHtmlString(string.Empty);
            }

            var modelState = htmlHelper.ViewData.ModelState[modelName];
            var modelErrors = (modelState == null) ? null : modelState.Errors;
            var modelError = ((modelErrors == null) || (modelErrors.Count == 0))
                                        ? null
                                        : modelErrors.FirstOrDefault(m => !string.IsNullOrEmpty(m.ErrorMessage))
                                          ?? modelErrors[0];

            if (modelError == null)
            {
                return new MvcHtmlString(string.Empty);
            }

            var vtag = new TagBuilder("span");
            vtag.AddCssClass("help-inline");
            vtag.InnerHtml = modelError.ErrorMessage;

            return vtag.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the help span
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>An MvcHtmlString</returns>
        internal static MvcHtmlString GetHelpSpan(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return new MvcHtmlString(string.Empty);
            }

            var s = new TagBuilder("p");
            s.AddCssClass("help-block");
            s.InnerHtml = message;
            return s.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the label
        /// </summary>
        /// <param name="labelFor">The label for</param>
        /// <param name="value">The value.</param>
        /// <returns>An MvcHtmlString</returns>
        internal static MvcHtmlString GetLabel(string labelFor, string value)
        {
            var l = new TagBuilder("label");
            l.AddCssClass("control-label");
            l.Attributes.Add("for", labelFor);
            l.InnerHtml = value;
            return l.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the buttong container
        /// </summary>
        /// <returns>A TagBuilder</returns>
        internal static TagBuilder GetButtonContainer()
        {
            TagBuilder b = new TagBuilder("div");
            b.AddCssClass("form-actions");
            return b;
        }
    }
}
