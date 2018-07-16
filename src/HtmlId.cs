namespace HtmlCodeBuilder
{
    /// <summary>
    /// Store a id declaration for an HTML tag
    /// </summary>
    public class HtmlId : HtmlAttribute
    {
        /// <summary>
        /// Name of the attribute is always 'id'
        /// </summary>
        public new string Name { get; } = "id";

        /// <summary>
        /// Create empty instance
        /// </summary>
        public HtmlId() { }

        /// <summary>
        /// Create fully functional instance
        /// </summary>
        /// <param name="value">Name of the id</param>
        public HtmlId(string value) : base("id", value) { }

        /// <summary>
        /// Create id without using new keyword
        /// </summary>
        /// <param name="value">Value of the id</param>
        /// <returns>Fully functional instance</returns>
        public static HtmlId Create(string value)
        {
            return new HtmlId(value);
        }
    }
}
