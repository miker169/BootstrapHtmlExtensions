
namespace BootStrapHtmlExtensions
{
    using System.Web.Mvc;

    using BootStrapHtmlExtensions.Extensions;

    /// <summary>
    /// All html helper icon extension methods
    /// </summary>
    public static class HelperIcon
    {
        public static MvcHtmlString BootstrapIcon(this HtmlHelper htmlHelper, Icon icon, bool inverted = false)
        {
            if (icon == Icon.@default)
            {
                return string.Empty.ToMvcHtmlString();
            }

            var t = new TagBuilder("i");
            t.AddCssClass(GetCssClass(icon));
            if (inverted)
            {
                t.AddCssClass("icon-white");
            }
            // add a space after the li tag incase it is next to text or used in a button
            return string.Format("{0} ", t.ToString().Replace('_', '-')).ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the Css class
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>returns the class of the icon</returns>
        private static string GetCssClass(Icon icon)
        {
            return icon.ToString().Replace('_', '-');
        }
    }
}
