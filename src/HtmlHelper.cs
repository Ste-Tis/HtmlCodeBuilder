using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HtmlCodeBuilder
{
	/// <summary>
	/// Special methods to help construct html code
	/// </summary>
	static class HtmlHelper
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
		/// Group values to the same css option
		/// </summary>
		/// <param name="htmlStyles">Set html styles</param>
		/// <returns>Groupped list</returns>
		private static List<HtmlStyle> PrepareStyles(IEnumerable<HtmlStyle> htmlStyles)
		{
			var builder = new StringBuilder();
			var res = new List<HtmlStyle>();

			// Group styles with same css option
			var groupped = new Dictionary<string, List<string>>();
			foreach (HtmlStyle a in htmlStyles)
			{
				if (a != null && a.Name.Length > 0 && a.Value.Length > 0)
				{
					groupped = AddValueToDict(groupped, a.Name, a.Value);
				}
			}

			// Construct single css options including values
			foreach (KeyValuePair<string, List<string>> entry in groupped.OrderBy(e => e.Key))
			{
				if (entry.Value.Count > 0)
				{
					builder.Clear();

					builder.Append($"{entry.Key}: ");
					for (int i = 0; i < entry.Value.Count; i++)
					{
						if (i == 0)
						{
							builder.Append(entry.Value[i]);
						}
						else
						{
							builder.Append($" {entry.Value[i]}");
						}
					}
					builder.Append(";");

					res.Add(new HtmlStyle("style", builder.ToString()));
				}
			}

			return res;
		}

		/// <summary>
		/// Group attributes with the same name and remove double entries
		/// </summary>
		/// <param name="attributes">List with all attributes</param>
		/// <returns>All attributes ready to be embedded into HTML tag</returns>
		public static string ConvertAttributesToString(List<HtmlAttribute> attributes)
		{
			var builder = new StringBuilder();

			if (attributes != null)
			{
				// Group attributes with same name and remove duplicate values
				var groupped = new Dictionary<string, List<string>>();
				foreach (HtmlAttribute a in attributes)
				{
					if (a.Name.Length > 0 && a.Value.Length > 0 && a.GetType() != typeof(HtmlStyle))
					{
						if (a.GetType() != typeof(HtmlStyle))
						{
							groupped = AddValueToDict(groupped, a.Name, a.Value);
						}
					}
				}

				foreach (HtmlStyle a in PrepareStyles(attributes.OfType<HtmlStyle>()))
				{
					if (a.Name.Length > 0 && a.Value.Length > 0)
					{
						groupped = AddValueToDict(groupped, a.Name, a.Value);
					}
				}

				// Create string from attributes
				foreach (KeyValuePair<string, List<string>> entry in groupped.OrderBy(e => e.Key))
				{
					builder.Append($@" {entry.Key}=""");
					for (int i = 0; i < entry.Value.Count; i++)
					{
						if (i == 0)
						{
							builder.Append(entry.Value[i]);
						}
						else
						{
							builder.Append($" {entry.Value[i]}");
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
