

namespace BootStrapHtmlExtensions
{
    using System.Web.Mvc;

    using BootStrapHtmlExtensions.Extensions;

    /// <summary>
    /// All html helper button input extension methods.
    /// </summary>
    public static class HelperButton
    {
        /// <summary>
        /// A container for the form buttons
        /// </summary>
        /// <returns>An MvcHtmlString</returns>
        public static BootstrapButtonContainer BootstrapFormButtonContainer(this HtmlHelper htmlHelper)
        {
            htmlHelper.ViewContext.Writer.Write(Common.GetButtonContainer().ToString(TagRenderMode.StartTag));
            var buttonContainer = new BootstrapButtonContainer(htmlHelper.ViewContext);
            return buttonContainer;

        }

        /// <summary>
        /// Bootstraps the button
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="id">The id.</param>
        /// <param name="text">The text.</param>
        /// <param name="buttonType">Type of the button</param>
        /// <param name="buttonSize">Size of the button</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapButton(
            this HtmlHelper htmlHelper,
            string id,
            string text,
            ButtonType buttonType = ButtonType.@default,
            ButtonSize buttonSize = ButtonSize.@default,
            bool disabled = false)
        {
            var b = new TagBuilder("button");
            var typeCss = Common.GetCssClass(buttonType);
            var sizeCss = Common.GetCssClass(buttonSize);
            
            if (! string.IsNullOrEmpty(typeCss))
            {
                b.AddCssClass(typeCss);
            }

            if (! string.IsNullOrEmpty(sizeCss))
            {
                b.AddCssClass(sizeCss);
            }

           
            b.AddCssClass("btn");

            if (disabled)
            {
                b.Attributes.Add("disabled", "disabled");
                b.AddCssClass("disabled");
            }

            b.Attributes.Add("id", id);
            b.InnerHtml = text;

            return b.ToMvcHtmlString();


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
            var typeCss = Common.GetCssClass(buttonType);
            var sizeCss = Common.GetCssClass(buttonSize);

            if (! string.IsNullOrEmpty(typeCss))
            {
                a.AddCssClass(typeCss);
            }

            if (! string.IsNullOrEmpty(sizeCss))
            {
                a.AddCssClass(sizeCss);
            }
           
            a.AddCssClass("btn");

            a.Attributes.Add("id", id);
            a.Attributes.Add("href", navigateTo);
            a.InnerHtml = text;

            return a.ToMvcHtmlString();
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
    }
}
