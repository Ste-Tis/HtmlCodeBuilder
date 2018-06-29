namespace HtmlCodeBuilder
{
	/// <summary>
	/// Store a class declaration for an HTML tag
	/// </summary>
	class HtmlClass : HtmlAttribute
	{
		/// <summary>
		/// Name of the attribute is always 'class'
		/// </summary>
		public new string Name { get; } = "class";

		/// <summary>
		/// Create empty instance
		/// </summary>
		public HtmlClass() { }

		/// <summary>
		/// Create fully functional instance
		/// </summary>
		/// <param name="value">Name of the class</param>
		public HtmlClass(string value) : base("class", value) { }

		/// <summary>
		/// Create class without using new keyword
		/// </summary>
		/// <param name="value">Value of the class</param>
		/// <returns>Fully functional instance</returns>
		public static HtmlClass Create(string value)
		{
			return new HtmlClass(value);
		}
	}
}
