﻿namespace HtmlCodeBuilder
{
	/// <summary>
	/// Store a style declaration for an html tag
	/// </summary>
	/// <remarks>
	/// Uses the implementation of HtmlAttribute to store the css options name in the field 'name' and the value in the field 'value'.
	/// The type of the class is used to distinguish between an normal attribute and an style one.
	/// </remarks>
	class HtmlStyle : HtmlAttribute {
		/// <summary>
		/// Create empty instance
		/// </summary>
		public HtmlStyle() { }

		/// <summary>
		/// Create fully functional instance
		/// </summary>
		/// <param name="cssOption">Name of the css option</param>
		/// <param name="value">Name of the css option</param>
		public HtmlStyle(string cssOption, string value) : base(cssOption, value) { }
	}
}