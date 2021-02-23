using System.Globalization;

namespace Primer.IconGenerator
{
    /// <summary>
    /// String utilities
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// Converts a string to Pascal case
        /// </summary>
        /// <param name="str">The input string</param>
        /// <returns>The string in Pascal case</returns>
        public static string ToPascalCase(this string str)
        {
            var info = CultureInfo.CurrentCulture.TextInfo;
            return info.ToTitleCase(str).Replace("-", "");
        }
    }
}
