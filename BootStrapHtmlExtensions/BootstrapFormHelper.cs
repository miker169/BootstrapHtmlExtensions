using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootStrapHtmlExtensions
{
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using BootStrapHtmlExtensions.Extensions;

    /// <summary>
    /// Bootstrap form helper extension methods
    /// </summary>
    public static class BootstrapFormHelper
    {
        /// <summary>
        /// Button Types, determines the coloring/effects
        /// </summary>
        public enum ButtonType
        {
            /// <summary>
            /// default button type
            /// </summary>
            @default,

            /// <summary>
            /// primary button type
            /// </summary>
            primary,

            /// <summary>
            /// info button type
            /// </summary>
            info,

            /// <summary>
            /// success button type
            /// </summary>
            success,

            /// <summary>
            /// warning button type
            /// </summary>
            warning,

            /// <summary>
            /// danger button type
            /// </summary>
            danger



        }

        /// <summary>
        /// Button Sizes, determines the height, width and text size
        /// </summary>
        public enum ButtonSize
        {
            /// <summary>
            /// default button size
            /// </summary>
            @default,

            /// <summary>
            /// large button size
            /// </summary>
            large,

            /// <summary>
            /// small button size
            /// </summary>
            small

        }

        /// <summary>
        /// Input sizes, determines the width of the input
        /// </summary>
        public enum InputSize
        {
            /// <summary>
            /// small input size
            /// </summary>
            small,

            /// <summary>
            /// medium input size
            /// </summary>
            medium,

            /// <summary>
            /// large input size
            /// </summary>
            large

        }

        /// <summary>
        /// Bootstraps the text box for
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="expression">The expression</param>
        /// <param name="inputSize">Size of the input</param>
        /// <param name="disabled">is set to <c>true</c> [disabled].</param>
        /// <param name="helpText">The helptext</param>
        /// <returns></returns>
        public static MvcHtmlString BootstrapTextBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            InputSize inputSize = InputSize.medium,
            bool disabled = false,
            string helpText = "")
        {
            var container = GetRootContainer();
            var icontainer = GetInputContainer();
            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            bool error = HasValidationError(htmlHelper, ExpressionHelper.GetExpressionText(expression));

            if (error)
            {
                container.AddCssClass("error");

            }
            css.Add(GetCssClass(inputSize));

            if (disabled)
            {
                css.Add("disabled");
                htmlAttributes.Add("disabled", "disabled");
            }

            htmlAttributes.Add("class", GetCss(css));

            var label = GetLabel(metadata.PropertyName, metadata.DisplayName);
            var input = htmlHelper.TextBoxFor(expression, htmlAttributes);

            icontainer.InnerHtml = input.ToString()
                                   + GetValidationMessageSpan(
                                       htmlHelper, ExpressionHelper.GetExpressionText(expression))
                                   + GetHelpSpan(helpText);
            container.InnerHtml = label + icontainer.ToString();
            return container.ToMvcHtmlString();
        }

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
            var container = GetRootContainer();
            var icontainer = GetInputContainer();
            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            if (disabled)
            {
                css.Add("disabled");
                htmlAttributes.Add("disabled", "disabled");
            }

            htmlAttributes.Add("class", GetCss(css));

            var label = GetLabel(metadata.PropertyName, metadata.DisplayName);
            var input = htmlHelper.CheckBoxFor(expression, htmlAttributes);

            icontainer.InnerHtml = input.ToString();
            container.InnerHtml = label + icontainer.ToString();

            return container.ToMvcHtmlString();
        }

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
            var container = GetRootContainer();
            var icontainer = GetInputContainer();
            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var error = HasValidationError(htmlHelper, ExpressionHelper.GetExpressionText(expression));
            if (error)
            {
                container.AddCssClass("error");
            }

            css.Add(GetCssClass(inputSize));

            if (disabled)
            {
                css.Add("disabled");
                htmlAttributes.Add("disabled", "disabled");
            }

            htmlAttributes.Add("rows", "rows");
            htmlAttributes.Add("class", GetCssClass(css));

            var label = GetLabel(metadata.PropertyName, metadata.DisplayName);
            var input = htmlHelper.TextAreaFor(expression, htmlAttributes);

            icontainer.InnerHtml = input.ToString() + GetValidationMessageSpan(htmlHelper, ExpressionHelper.GetExpressionText(expression)) + GetHelpSpan(helpText);
            container.InnerHtml = label + icontainer.ToString();

            return container.ToMvcHtmlString();




        }

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
            var container = GetRootContainer();
            var icontainer = GetInputContainer();
            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var error = HasValidationError(htmlHelper, ExpressionHelper.GetExpressionText(expression));

            if (error)
            {
                container.AddCssClass("error");
            }

            css.Add(GetCssClass(inputSize));

            if (disabled)
            {
                css.Add("disabled");
                htmlAttributes.Add("disabled", "disabled");
            }
            htmlAttributes.Add("class", GetCss(css));

            MvcHtmlString label = GetLabel(metadata.PropertyName, metadata.DisplayName);
            MvcHtmlString input = htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);

            icontainer.InnerHtml = input.ToString()
                                   + GetValidationMessageSpan(
                                       htmlHelper,
                                       ExpressionHelper.GetExpressionText(expression) + GetHelpSpan(helpText));
            container.InnerHtml = label + icontainer.ToString();

            return container.ToMvcHtmlString();
        }

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
            var container = GetRootContainer();
            var icontainer = GetInputContainer();
            var disabledInput = new TagBuilder("span");

            var css = new List<string>();
            var htmlAttributes = new Dictionary<string, object>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            disabledInput.AddCssClass(GetCssClass(inputSize));
            disabledInput.AddCssClass("uneditable-input");
            disabledInput.InnerHtml = metadata.Model.ToString();
            var label = GetLabel(metadata.PropertyName, metadata.DisplayName);

            icontainer.InnerHtml = disabledInput.ToString();
            container.InnerHtml = label + icontainer.ToString();
            return container.ToMvcHtmlString();
        }

        /// <summary>
        /// Start of the bootstrap button container
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <returns>An MvcHTMLString</returns>
        public static MvcHtmlString BootstrapButtonsBegin(this HtmlHelper htmlHelper)
        {
            return GetButtonContainer().ToString(TagRenderMode.StartTag).ToMvcHtmlString();
        }

        /// <summary>
        /// End of the bootstrap button container
        /// </summary>
        /// <param name="htmlHelper">An HTML helper</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapButtonsEnd(this HtmlHelper htmlHelper)
        {
            return GetButtonContainer().ToString(TagRenderMode.EndTag).ToMvcHtmlString();
        }

        /// <summary>
        /// Bootstraps the link button
        /// </summary>
        /// <param name="htmlHelper">The Html helper.</param>
        /// <param name="id">The id.</param>
        /// <param name="text">The text.</param>
        /// <param name="navigateTo">The navigate to.</param>
        /// <param name="buttonType">Type of the button.</param>
        /// <param name="buttonSize">Size of the button.</param>
        /// <returns>An MvcHtmlstring</returns>
        public static MvcHtmlString BootstrapLinkButton(
            this HtmlHelper htmlHelper,
            string id,
            string text,
            string navigateTo,
            ButtonType buttonType = ButtonType.@default,
            ButtonSize buttonSize = ButtonSize.@default)
        {
            var a = new TagBuilder("a");
            a.AddCssClass(GetCssClass(buttonType));
            a.AddCssClass(GetCssClass(buttonSize));
            a.AddCssClass("btn");

            a.Attributes.Add("id", id);
            a.Attributes.Add("href", navigateTo);
            a.InnerHtml = text;

            return a.ToMvcHtmlString();
        }


        /// <summary>
        /// Gets the Root container
        /// </summary>
        /// <returns>A Tag Builder</returns>
        private static TagBuilder GetRootContainer()
        {
            var container = new TagBuilder("div");
            container.AddCssClass("control-group");
            return container;
        }


        /// <summary>
        /// Gets the Button Container
        /// </summary>
        /// <returns>A Tag Builder</returns>
        private static TagBuilder GetButtonContainer()
        {
            var b = new TagBuilder("div");
            b.AddCssClass("form-actions");
            return b;
        }

        /// <summary>
        /// Gets the input container.
        /// </summary>
        /// <returns>A TagBuilder</returns>
        private static TagBuilder GetInputContainer()
        {
            var b = new TagBuilder("div");
            b.AddCssClass("controls");
            return b;
        }


        /// <summary>
        /// Gets the CSS.
        /// </summary>
        /// <param name="css">The CSS. </param>
        /// <returns>comma delimeted list of css classes</returns>
        private static string GetCss(IEnumerable<string> css)
        {
            var sb = new StringBuilder();
            foreach (var c in css)
            {
                sb.Append(string.Format("{0}", c));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Determines whether [has validation error] [the specified HTML helper]
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="name">The name.</param>
        /// <returns>
        /// <c>true</c> if [has validation error] [the specified HTML helper]; otherwise <c>false</c>
        /// </returns>
        private static bool HasValidationError(HtmlHelper htmlHelper, string name)
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
        private static MvcHtmlString GetValidationMessageSpan(HtmlHelper htmlHelper, string expression)
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
        private static MvcHtmlString GetHelpSpan(string message)
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
        private static MvcHtmlString GetLabel(string labelFor, string value)
        {
            var l = new TagBuilder("label");
            l.AddCssClass("control-label");
            l.Attributes.Add("for", labelFor);
            l.InnerHtml = value;
            return l.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the CSS class
        /// </summary>
        /// <param name="buttonType">Type of the button</param>
        /// <returns>The css class of the button type</returns>
        private static string GetCssClass(ButtonType buttonType)
        {
            switch (buttonType)
            {
                case ButtonType.@default:
                    return string.Empty;
                case ButtonType.primary:
                    return "btn-primary";
                case ButtonType.info:
                    return "btn-info";
                case ButtonType.success:
                    return "btn-success";
                case ButtonType.warning:
                    return "btn-warning";
                case ButtonType.danger:
                    return "btn-danger";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the CSS class
        /// </summary>
        /// <param name="buttonSize">size of the button</param>
        /// <returns>The css class of the button size</returns>
        private static string GetCssClass(ButtonSize buttonSize)
        {
            switch (buttonSize)
            {
                case ButtonSize.@default:
                    return string.Empty;
                case ButtonSize.large:
                    return "btn-large";
                case ButtonSize.small:
                    return "btn-small";
                default:
                    return string.Empty;

            }
        }

        /// <summary>
        /// Gets the CSS class
        /// </summary>
        /// <param name="inputSize">The size of the input</param>
        /// <returns>The css class of the input size</returns>
        private static string GetCssClass(InputSize inputSize)
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


    }
}
