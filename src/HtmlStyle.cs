namespace HtmlCodeBuilder
{
    /// <summary>
    /// Store a style declaration for an HTML tag
    /// </summary>
    /// <remarks>
    /// Uses the implementation of HtmlAttribute to store the CSS options name in the field 'name' and the value in the field 'value'.
    /// The type of the class is used to distinguish between an normal attribute and an style one.
    /// </remarks>
    public class HtmlStyle : HtmlAttribute {
        /// <summary>
        /// Create empty instance
        /// </summary>
        public HtmlStyle() { }

        /// <summary>
        /// Create fully functional instance
        /// </summary>
        /// <param name="cssOption">Name of the CSS option</param>
        /// <param name="value">Name of the CSS option</param>
        public HtmlStyle(string cssOption, string value) : base(cssOption, value) { }

        /// <summary>
        /// Create style without using new keyword
        /// </summary>
        /// <param name="name">Name of the CSS option</param>
        /// <param name="value">Value of the option</param>
        /// <returns>Fully functional instance</returns>s
        public new static HtmlStyle Create(string cssOption, string value)
        {
            return new HtmlStyle(cssOption, value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $@"style=""{Name}: {Value}""";
        }
    }
}
