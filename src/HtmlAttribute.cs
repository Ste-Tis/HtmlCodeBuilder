using System.Collections.Generic;

namespace HtmlCodeBuilder
{
    /// <summary>
    /// Store a simple attribute for an HTML tag
    /// </summary>
    public class HtmlAttribute
    {
        /// <summary>
        /// Name of the attribute
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value for the attribute
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Create empty instance
        /// </summary>
        public HtmlAttribute() { }

        /// <summary>
        /// Create fully functional instance
        /// </summary>
        /// <param name="name">Name of the attribute</param>
        /// <param name="value">Value of the attribute</param>
        public HtmlAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Create attribute without using new keyword
        /// </summary>
        /// <param name="name">Name of the attribute</param>
        /// <param name="value">Value of the attribute</param>
        /// <returns>Fully functional instance</returns>
        public static HtmlAttribute Create(string name, string value)
        {
            return new HtmlAttribute(name, value);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            HtmlAttribute att = (HtmlAttribute)obj;
            return (att.Name == Name && att.Value == Value);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = -244751520;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $@"{Name}=""{Value}""";
        }
    }
}
