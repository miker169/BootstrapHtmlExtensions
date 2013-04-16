
namespace BootStrapHtmlExtensions.Extensions
{
    using System.Web.Mvc;

    /// <summary>
    /// Sting extension methods
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts a string to an MVC Html String
        /// </summary>
        /// <param name="stringValue">The String Value</param>
        /// <returns>An MVCHtlString</returns>
        internal static MvcHtmlString ToMvcHtmlString(this string stringValue)
        {
            return new MvcHtmlString(stringValue);
        }


    }
}
