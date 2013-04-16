
namespace BootStrapHtmlExtensions.Extensions
{
    using System.Web.Mvc;

    /// <summary>
    /// Sting extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to an MVC Html String
        /// </summary>
        /// <param name="stringValue">The String Value</param>
        /// <returns>An MVCHtlString</returns>
        public static MvcHtmlString ToMvcHtmlString(this string stringValue)
        {
            return new MvcHtmlString(stringValue);
        }


    }
}
