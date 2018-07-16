using System;
using System.Collections.Generic;

namespace HtmlCodeBuilder
{
    /// <summary>
    /// Representing text content inside an HTML tag
    /// </summary>
    public class HtmlText : HtmlElement
    {
        /// <summary>
        /// Text to put inside tags
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Create an empty instance
        /// </summary>
        public HtmlText() { }

        /// <summary>
        /// Create simple text
        /// </summary>
        /// <param name="content">Content of tag</param>
        /// <param name="encodeContent">Encode content</param>
        public HtmlText(string content, bool encodeContent = true)
        {
            Content = (encodeContent ? HtmlHelper.HtmlEncode(content) : content);
        }

        /// <summary>
        /// Create string with HTML code
        /// </summary>
        /// <returns>String with HTML code</returns>
        public override string ToString()
        {
            return ToString(0);
        }

        /// <summary>
        /// Create string with HTML code
        /// </summary>
        /// <param name="indentation">Indentation of the root element</param>
        /// <returns>String with HTML code</returns>
        public override string ToString(int indentation)
        {
            return $"{new String('\t', indentation)}{Content}\n";
        }

        /// <summary>
        /// Create a new text element
        /// </summary>
        /// <param name="content">Text</param>
        /// <param name="encodeContent">Encode content</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlText Create(string content, bool encodeContent = true)
        {
            return new HtmlText() { Content = (encodeContent ? HtmlHelper.HtmlEncode(content) : content) };
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            HtmlText txt = (HtmlText)obj;
            return (txt.Content == Content);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return 1997410482 + EqualityComparer<string>.Default.GetHashCode(Content);
        }
    }
}
