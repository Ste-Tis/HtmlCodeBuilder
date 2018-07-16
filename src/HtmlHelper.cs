using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlCodeBuilder
{
    /// <summary>
    /// Special methods to help construct HTML code
    /// </summary>
    public static class HtmlHelper
    {
        /// <summary>
        /// Add a new value to the values list of the dictionary
        /// </summary>
        /// <param name="dict">Dictionary to expand</param>
        /// <param name="key">Key to add value to</param>
        /// <param name="value">New value</param>
        /// <param name="removeDuplicatedValue">Only add value, if it isn't already in the list</param>
        /// <returns>Expanded dictionary</returns>
        private static Dictionary<string, List<string>> AddValueToDict(Dictionary<string, List<string>> dict, string key, string value, bool removeDuplicatedValue = true)
        {
            // Add new value to existing key
            if (dict.ContainsKey(key))
            {
                List<string> l = dict.GetValueOrDefault(key, new List<string>());

                if (removeDuplicatedValue && !dict.GetValueOrDefault(key, new List<string>()).Contains(value))
                {
                    l.Add(value);
                }
                else if (!removeDuplicatedValue)
                {
                    l.Add(value);
                }

                dict[key] = l;
            }
            // Create new key
            else
            {
                dict.Add(key, new List<string>() { value });
            }

            return dict;
        }

        /// <summary>
        /// Group values to the same CSS option
        /// </summary>
        /// <param name="htmlStyles">Set HTML styles</param>
        /// <returns>Grouped list</returns>
        private static List<HtmlStyle> PrepareStyles(IEnumerable<HtmlStyle> htmlStyles)
        {
            var builder = new StringBuilder();
            var res = new List<HtmlStyle>();

            // Group styles with same CSS option
            var groupped = new Dictionary<string, List<string>>();
            foreach (HtmlStyle a in htmlStyles)
            {
                if (a != null && a.Name.Length > 0 && a.Value.Length > 0)
                {
                    groupped = AddValueToDict(groupped, a.Name, a.Value);
                }
            }

            // Construct single CSS options including values
            foreach (KeyValuePair<string, List<string>> entry in groupped.OrderBy(e => e.Key))
            {
                if (entry.Value.Count > 0)
                {
                    builder.Clear();

                    builder.Append($"{entry.Key}: ");
                    var sortedValues = entry.Value.OrderBy(e => e).ToList();
                    for (int i = 0; i < sortedValues.Count; i++)
                    {
                        if (i == 0)
                        {
                            builder.Append(sortedValues[i]);
                        }
                        else
                        {
                            builder.Append($" {sortedValues[i]}");
                        }
                    }
                    builder.Append(";");

                    res.Add(new HtmlStyle("style", builder.ToString()));
                }
            }

            return res;
        }

        /// <summary>
        /// Group all HtmlAttributes, which are not of type HtmlStyle and remove duplicates
        /// </summary>
        /// <param name="attributes">List with attributes</param>
        /// <param name="expand">Add values to the given dictionary. A new one is returned.</param>
        /// <returns>Grouped attributes</returns>
        private static Dictionary<string, List<string>> GroupHtmlAttributesAndRemoveDuplicates(List<HtmlAttribute> attributes, Dictionary<string, List<string>> expand=null)
        {
            Dictionary<string, List<string>> grouped = expand ?? new Dictionary<string, List<string>>();

            foreach (HtmlAttribute a in attributes)
            {
                if (a.Name.Length > 0 && a.Value.Length > 0 && a.GetType() != typeof(HtmlStyle))
                {
                    grouped = AddValueToDict(grouped, a.Name, a.Value);
                }
            }

            return grouped;
        }

        /// <summary>
        /// Group all HtmlStyles and remove duplicates
        /// </summary>
        /// <param name="attributes">List with attributes</param>
        /// <param name="expand">Add values to the given dictionary. A new one is returned.</param>
        /// <returns>Grouped styles</returns>
        private static Dictionary<string, List<string>> GroupHtmlStylesAndRemoveDuplicates(List<HtmlAttribute> attributes, Dictionary<string, List<string>> expand = null)
        {
            Dictionary<string, List<string>> grouped = expand ?? new Dictionary<string, List<string>>();

            foreach (HtmlStyle a in PrepareStyles(attributes.OfType<HtmlStyle>()))
            {
                if (a.Name.Length > 0 && a.Value.Length > 0)
                {
                    grouped = AddValueToDict(grouped, a.Name, a.Value);
                }
            }

            return grouped;
        }

        /// <summary>
        /// Converts a given list of attributes to a string. Attributes with the same name are grouped and duplicated entries removed.
        /// </summary>
        /// <param name="attributes">List with all attributes</param>
        /// <returns>All attributes ready to be embedded into HTML tag</returns>
        public static string ConvertAttributesToString(List<HtmlAttribute> attributes)
        {
            var builder = new StringBuilder();

            if (attributes != null)
            {
                // Group attributes with same name and remove duplicate values
                var grouped = new Dictionary<string, List<string>>();
                grouped = GroupHtmlAttributesAndRemoveDuplicates(attributes, grouped);
                grouped = GroupHtmlStylesAndRemoveDuplicates(attributes, grouped);

                // Create string from attributes
                foreach (KeyValuePair<string, List<string>> entry in grouped.OrderBy(e => e.Key))
                {
                    builder.Append($@" {entry.Key}=""");
                    var sortedValues = entry.Value.OrderBy(e => e).ToList();
                    for (int i = 0; i < sortedValues.Count; i++)
                    {
                        if (i == 0)
                        {
                            builder.Append(sortedValues[i]);
                        }
                        else
                        {
                            builder.Append($" {sortedValues[i]}");
                        }
                    }
                    builder.Append(@"""");
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Encode given string for usage in HTML
        /// </summary>
        /// <param name="value">String to encode</param>
        /// <returns>Encoded result</returns>
        public static string HtmlEncode(string value)
        {
            return System.Web.HttpUtility.HtmlEncode(value);
        }

        /// <summary>
        /// Decode given string for usage in HTML
        /// </summary>
        /// <param name="value">String to decode</param>
        /// <returns>Decoded result</returns>
        public static string HtmlDecode(string value)
        {
            return System.Web.HttpUtility.HtmlDecode(value);
        }
    }
}
