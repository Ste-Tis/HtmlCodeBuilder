using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlCodeBuilder
{
	/// <summary>
	/// Base class for tags and text
	/// </summary>
    public class HtmlElement
    {
		/// <summary>
		/// Create an empty instance
		/// </summary>
		public HtmlElement() { }

		/// <summary>
		/// Create string with HTML code
		/// </summary>
		/// <returns>String with HTML code</returns>
		public override string ToString() => "";

		/// <summary>
		/// Create string with HTML code
		/// </summary>
		/// <param name="indentation">Indentation of the root element</param>
		/// <returns>String with HTML code</returns>
		public virtual string ToString(int indentation) => "";

		/// <summary>
		/// Create a new element
		/// </summary>
		/// <returns>New initialized instance of tag</returns>
		public static HtmlElement Create() => new HtmlElement();

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (obj != null && obj.GetType() == this.GetType())
			{
				return true;
			}
			return false;
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return 0;
		}
	}
}
