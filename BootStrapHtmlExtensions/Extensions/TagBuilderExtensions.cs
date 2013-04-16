using System.Web.Mvc;

namespace BootStrapHtmlExtensions.Extensions
{
    /// <summary>
    /// Tag Builder Extension methods
    /// </summary>
   internal static class TagBuilderExtensions
    {
        /// <summary>
        /// Convert tagbuilder to an MVC HTML string.
        /// </summary>
        /// <param name="tagBuilder"> The tag builder.</param>
        /// <returns>An MvcHtmlString</returns>
        internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder)
        {
            return tagBuilder.ToString().ToMvcHtmlString();
        }

        /// <summary>
        /// Convert a tagbuilder to an MVC Html string.
        /// </summary>
        /// <param name="tagBuilder">The tage builder.</param>
        /// <param name="tagRenderMode">The tag render mode</param>
        /// <returns>An Mvc Html String</returns>
        internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode tagRenderMode)
        {
            return tagBuilder.ToString(tagRenderMode).ToMvcHtmlString();
        }
    }
}
