using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HtmlCodeBuilder
{
    /// <summary>
    /// Represents a HTML tag
    /// </summary>
    public class HtmlTag : HtmlElement
    {
        /// <summary>
        /// Defines which tag to represent
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Special attributes of the tag
        /// </summary>
        public List<HtmlAttribute> Attributes { get; set; }

        /// <summary>
        /// Child tags and text
        /// </summary>
        public List<HtmlElement> Children { get; set; }

        /// <summary>
        /// Create an empty instance
        /// </summary>
        public HtmlTag() { }

        /// <summary>
        /// Create simple tag
        /// </summary>
        /// <param name="type">Tag type</param>
        public HtmlTag(string type)
        {
            Type = type;
        }

        /// <summary>
        /// Create simple tag
        /// </summary>
        /// <param name="type">Tag type</param>
        /// <param name="content">Content of tag</param>
        /// <param name="encodeContent">Encode content</param>
        public HtmlTag(string type, string content, bool encodeContent = true)
        {
            Type = type;
            AddText(content, encodeContent);
        }

        /// <summary>
        /// Checks if the given tag is of the same type as this instance
        /// </summary>
        /// <param name="tag">Tag to compare to</param>
        /// <returns>Returns TRUE if tags are of the same type, otherwise FALSE</returns>
        private bool EqualsType(HtmlTag tag)
        {
            if (tag.Type != Type)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the given tag has the same attributes than this instance
        /// </summary>
        /// <param name="tag">Tag to compare to</param>
        /// <returns>Returns TRUE if tags have the same attributes, otherwise FALSE</returns>
        private bool EqualsAttributes(HtmlTag tag)
        {
            if (tag.Attributes != null && Attributes != null)
            {
                if (tag.Attributes.Count != Attributes.Count)
                {
                    return false;
                }

                for (int i = 0; i < tag.Attributes.Count; i++)
                {
                    if (!tag.Attributes[i].Equals(Attributes[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the given tag has the same children than this instance
        /// </summary>
        /// <param name="tag">Tag to compare to</param>
        /// <returns>Returns TRUE if tags have the same children, otherwise FALSE</returns>
        private bool EqualsChildren(HtmlTag tag)
        {
            if (tag.Children != null && Children != null)
            {
                if (tag.Children.Count != Children.Count)
                {
                    return false;
                }

                for (int i = 0; i < tag.Children.Count; i++)
                {
                    if (!tag.Children[i].Equals(Children[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Add a new attribute to the tag
        /// </summary>
        /// <param name="htmlAttribute">Attribute</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddAttribute(HtmlAttribute htmlAttribute)
        {
            if (Attributes == null)
            {
                Attributes = new List<HtmlAttribute> { htmlAttribute };
            }
            else
            {
                Attributes.Add(htmlAttribute);
            }
            return this;
        }

        /// <summary>
        /// Add a new attribute to the tag
        /// </summary>
        /// <param name="name">Name of the attribute</param>
        /// <param name="value">Value of the attribute</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddAttribute(string name, string value)
        {
            return AddAttribute(new HtmlAttribute(name, value));
        }

        /// <summary>
        /// Add multiple attributes to the tag
        /// </summary>
        /// <param name="htmlAttributes">Attributes</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddAttributes(HtmlAttribute[] htmlAttributes)
        {
            foreach (HtmlAttribute value in htmlAttributes)
            {
                AddAttribute(value);
            }
            return this;
        }

        /// <summary>
        /// Add multiple attributes to the tag
        /// </summary>
        /// <param name="htmlAttributes">Attributes</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddAttributes(string[][] htmlAttributes)
        {
            foreach (string[] attribute in htmlAttributes)
            {
                if (attribute.Length >= 2)
                {
                    AddAttribute(new HtmlAttribute(attribute[0], attribute[1]));
                }
            }
            return this;
        }

        /// <summary>
        /// Add multiple attributes to the tag
        /// </summary>
        /// <param name="htmlAttributes">Attributes</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddAttributes(string[] htmlAttributes)
        {
            for (int i = 0; i < htmlAttributes.Length; i += 2)
            {
                if (i + 1 < htmlAttributes.Length)
                {
                    AddAttribute(new HtmlAttribute(htmlAttributes[i], htmlAttributes[i + 1]));
                }
            }
            return this;
        }

        /// <summary>
        /// Remove all attributes at once
        /// </summary>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveAllAttributes()
        {
            Attributes.RemoveAll(e => e.GetType() == typeof(HtmlAttribute));
            if (Attributes.Count == 0)
            {
                Attributes = null;
            }
            return this;
        }

        /// <summary>
        /// Remove attribute with given name from tag
        /// </summary>
        /// <param name="name">Name of attribute</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveAttribute(string name)
        {
            Attributes.RemoveAll(e => e.Name == name);
            if (Attributes.Count == 0)
            {
                Attributes = null;
            }
            return this;
        }

        /// <summary>
        /// Add a new class to the tag
        /// </summary>
        /// <param name="htmlClass">Class</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddClass(HtmlClass htmlClass)
        {
            if (Attributes == null)
            {
                Attributes = new List<HtmlAttribute> { htmlClass };
            }
            else
            {
                if (!Attributes.Any(e => e.Name == htmlClass.Name && e.Value == htmlClass.Value))
                {
                    Attributes.Add(htmlClass);
                }
            }

            return this;
        }

        /// <summary>
        /// Add a new class to the tag
        /// </summary>
        /// <param name="value">Name of the class</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddClass(string value)
        {
            return AddClass(new HtmlClass(value));
        }

        /// <summary>
        /// Add multiple classes to the tag
        /// </summary>
        /// <param name="htmlClasses">Classes</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddClasses(HtmlClass[] htmlClasses)
        {
            foreach (HtmlClass value in htmlClasses)
            {
                AddClass(value);
            }
            return this;
        }

        /// <summary>
        /// Add multiple classes to the tag
        /// </summary>
        /// <param name="values">Name of the class</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddClasses(string[] values)
        {
            foreach (string value in values)
            {
                AddClass(new HtmlClass(value));
            }
            return this;
        }

        /// <summary>
        /// Remove all classes at once
        /// </summary>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveAllClasses()
        {
            Attributes.RemoveAll(e => e.GetType() == typeof(HtmlClass));
            if (Attributes.Count == 0)
            {
                Attributes = null;
            }
            return this;
        }

        /// <summary>
        /// Remove class from the tag
        /// </summary>
        /// <param name="value">Name of the class</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveClass(string value)
        {
            Attributes.RemoveAll(e => e.Value == value && e.GetType() == typeof(HtmlClass));
            if (Attributes.Count == 0)
            {
                Attributes = null;
            }
            return this;
        }

        /// <summary>
        /// Add a new style to the tag
        /// </summary>
        /// <param name="htmlStyle">Style</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddStyle(HtmlStyle htmlStyle)
        {
            if (Attributes == null)
            {
                Attributes = new List<HtmlAttribute> { htmlStyle };
            }
            else
            {
                if (!Attributes.Any(e => e.Name == htmlStyle.Name && e.Value == htmlStyle.Value))
                {
                    Attributes.Add(htmlStyle);
                }
            }
            return this;
        }

        /// <summary>
        /// Add a new style to the tag
        /// </summary>
        /// <param name="cssOption">Name of the CSS option</param>
        /// <param name="value">Value of the CSS option</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddStyle(string cssOption, string value)
        {
            return AddStyle(new HtmlStyle(cssOption, value));
        }

        /// <summary>
        /// Add multiple styles to the tag
        /// </summary>
        /// <param name="htmlStyles">Styles</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddStyles(HtmlStyle[] htmlStyles)
        {
            foreach (HtmlStyle value in htmlStyles)
            {
                AddStyle(value);
            }
            return this;
        }

        /// <summary>
        /// Add multiple styles to the tag
        /// </summary>
        /// <param name="htmlStyles">Styles</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddStyles(string[][] htmlStyles)
        {
            foreach (string[] style in htmlStyles)
            {
                if (style.Length >= 2)
                {
                    AddStyle(new HtmlStyle(style[0], style[1]));
                }
            }
            return this;
        }

        /// <summary>
        /// Add multiple styles to the tag
        /// </summary>
        /// <param name="htmlStyles">Styles</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddStyles(string[] htmlStyles)
        {
            for(int i = 0; i < htmlStyles.Length; i += 2)
            {
                if(i+1 < htmlStyles.Length)
                {
                    AddStyle(new HtmlStyle(htmlStyles[i], htmlStyles[i + 1]));
                }
            }
            return this;
        }

        /// <summary>
        /// Remove all CSS options at once
        /// </summary>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveAllStyles()
        {
            Attributes.RemoveAll(e => e.GetType() == typeof(HtmlStyle));
            if (Attributes.Count == 0)
            {
                Attributes = null;
            }
            return this;
        }

        /// <summary>
        /// Remove CSS option from the tag
        /// </summary>
        /// <param name="cssOption">Name of the CSS option</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveStyle(string cssOption)
        {
            return RemoveAttribute(cssOption);
        }

        /// <summary>
        /// Add a new id to the tag
        /// </summary>
        /// <param name="htmlId">Id</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddId(HtmlId htmlId)
        {
            if (Attributes == null)
            {
                Attributes = new List<HtmlAttribute> { htmlId };
            }
            else
            {
                if (!Attributes.Any(e => e.Name == htmlId.Name && e.Value == htmlId.Value))
                {
                    Attributes.Add(htmlId);
                }
            }

            return this;
        }

        /// <summary>
        /// Add a new id to the tag
        /// </summary>
        /// <param name="value">Name of the id</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddId(string value)
        {
            return AddId(new HtmlId(value));
        }

        /// <summary>
        /// Add multiple ids to the tag
        /// </summary>
        /// <param name="htmlIds">Ids</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddIds(HtmlId[] htmlIds)
        {
            foreach (HtmlId value in htmlIds)
            {
                AddId(value);
            }
            return this;
        }

        /// <summary>
        /// Add multiple ids to the tag
        /// </summary>
        /// <param name="values">Name of the ids</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddIds(string[] values)
        {
            foreach (string value in values)
            {
                AddId(new HtmlId(value));
            }
            return this;
        }

        /// <summary>
        /// Remove all ids at once
        /// </summary>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveAllIds()
        {
            Attributes.RemoveAll(e => e.GetType() == typeof(HtmlId));
            if (Attributes.Count == 0)
            {
                Attributes = null;
            }
            return this;
        }

        /// <summary>
        /// Remove id from the tag
        /// </summary>
        /// <param name="value">Name of the id</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveId(string value)
        {
            Attributes.RemoveAll(e => e.Value == value && e.GetType() == typeof(HtmlId));
            if (Attributes.Count == 0)
            {
                Attributes = null;
            }
            return this;
        }

        /// <summary>
        /// Add child to the tag
        /// </summary>
        /// <param name="child">Child tag</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddChild(HtmlTag child)
        {
            if (Children == null)
            {
                Children = new List<HtmlElement> { child };
            }
            else
            {
                Children.Add(child);
            }

            return this;
        }

        /// <summary>
        /// Add multiple child's to the tag
        /// </summary>
        /// <param name="children">Tags of new children</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddChildren(HtmlTag[] children)
        {
            foreach(HtmlTag child in children)
            {
                AddChild(child);
            }
            return this;
        }

        /// <summary>
        /// Remove all children tags
        /// </summary>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveAllChildren()
        {
            Children = null;
            return this;
        }

        /// <summary>
        /// Remove all children tags of a given type from the tag
        /// </summary>
        /// <param name="type">Type of the children to remove</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveChildren(string type)
        {
            Children.RemoveAll(e => e.GetType() == typeof(HtmlTag) && ((HtmlTag)e).Type == type);
            if (Children.Count == 0)
            {
                Children = null;
            }
            return this;
        }

        /// <summary>
        /// Remove a specific child from the tag. First child of type is numbered with Zero.
        /// </summary>
        /// <remarks>
        /// Call:
        ///     RemoveChild("td", 1);
        /// 
        /// Before:
        ///     <tr>
        ///         <td>Pos 1</td>
        ///         <td>Pos 2</td>
        ///         <td>Pos 3</td>
        ///     </tr>
        /// 
        /// After:
        ///     <tr>
        ///         <td>Pos 1</td>
        ///         <td>Pos 3</td>
        ///     </tr>
        /// </remarks>
        /// <param name="type">Type of the child to remove</param>
        /// <param name="pos">Position of the child</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveChild(string type, int pos)
        {
            for(int i = 0; i < Children.Count; i++)
            {
                if (Children[i].GetType() == typeof(HtmlTag) && ((HtmlTag)Children[i]).Type == type)
                {
                    pos--;
                }

                // Counting starts from 0
                if (pos == -1)
                {
                    Children.RemoveAt(i);
                    break;
                }
            }

            if (Children.Count == 0)
            {
                Children = null;
            }

            return this;
        }

        /// <summary>
        /// Add a new text to the tag
        /// </summary>
        /// <param name="content">Text content of the tag</param>
        /// <param name="encodeContent">Encode content</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag AddText(string content, bool encodeContent = true)
        {
            if (Children == null)
            {
                Children = new List<HtmlElement> { new HtmlText(content, encodeContent) };
            }
            else
            {
                Children.Add(new HtmlText(content, encodeContent));
            }

            return this;
        }

        /// <summary>
        /// Remove a specific text from the tag. The numbering start with Zero.
        /// </summary>
        /// <remarks>
        /// Call:
        ///     RemoveText(1);
        /// 
        /// Before:
        ///     <div>
        ///         Text 0
        ///         <span>Pos 1</span>
        ///         Text 1
        ///         <span>Pos 2</span>
        ///         Text 2
        ///     </div>
        /// 
        /// After:
        ///     <div>
        ///         Text 0
        ///         <span>Pos 1</span>
        ///         <span>Pos 2</span>
        ///         Text 2
        ///     </div>
        /// </remarks>
        /// <param name="pos">Position of the text</param>
        /// <returns>Updated instance of tag</returns>
        public HtmlTag RemoveText(int pos)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i].GetType() == typeof(HtmlText))
                {
                    pos--;
                }

                // Counting starts from 0
                if (pos == -1)
                {
                    Children.RemoveAt(i);
                    break;
                }
            }

            if (Children.Count == 0)
            {
                Children = null;
            }

            return this;
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
            var builderHtmlTag = new StringBuilder();
            var builderContent = new StringBuilder();

            builderHtmlTag.Append($"{new String('\t', indentation)}<{Type}");
            builderHtmlTag.Append(HtmlHelper.ConvertAttributesToString(Attributes));

            if (Children != null)
            {
                foreach (HtmlElement c in Children)
                {
                    if (c != null)
                    {
                        builderContent.Append(c.ToString(indentation + 1));
                    }
                }
            }

            if (builderContent.Length > 0)
            {
                builderHtmlTag.Append(">\n");
                builderHtmlTag.Append(builderContent.ToString());
                builderHtmlTag.Append($"{new String('\t', indentation)}</{Type}>\n");
            }
            else
            {
                builderHtmlTag.Append(" />\n");
            }

            return builderHtmlTag.ToString();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            
            HtmlTag tag = (HtmlTag)obj;
            return (EqualsType(tag) && EqualsAttributes(tag) && EqualsChildren(tag));
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = -25211342;
            hashCode += Type.GetHashCode(StringComparison.CurrentCulture);
            if(Children != null)
            {
                foreach (HtmlElement c in Children)
                {
                    hashCode += c.GetHashCode();
                }
            }
            if(Attributes != null)
            {
                foreach (HtmlAttribute a in Attributes)
                {
                    hashCode += a.GetHashCode();
                }
            }
            return hashCode;
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="type">Type of the tag</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlTag Create(string type)
        {
            return new HtmlTag() { Type = type };
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="type">Type of the tag</param>
        /// <param name="content">Text content of the tag</param>
        /// <param name="encodeContent">Encode content</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlTag Create(string type, string content, bool encodeContent = true)
        {
            return new HtmlTag() { Type = type, Children = new List<HtmlElement>() { new HtmlText(content, encodeContent) } };
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="type">Type of the tag</param>
        /// <param name="content">Text content of the tag</param>
        /// <param name="child">Child of the tag</param>
        /// <param name="encodeContent">Encode content</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlTag Create(string type, string content, HtmlElement child, bool encodeContent = true)
        {
            return new HtmlTag() { Type = type, Children = new List<HtmlElement>() { new HtmlText(content, encodeContent), child } };
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="type">Type of the tag</param>
        /// <param name="content">Text content of the tag</param>
        /// <param name="children">Children of the tag</param>
        /// <param name="encodeContent">Encode content</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlTag Create(string type, string content, List<HtmlElement> children, bool encodeContent = true)
        {
            var c = new List<HtmlElement>() { new HtmlText(content, encodeContent) };
            c.AddRange(children);
            return new HtmlTag() { Type = type, Children = c };
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="type">Type of the tag</param>
        /// <param name="content">Text content of the tag</param>
        /// <param name="children">Children of the tag</param>
        /// <param name="encodeContent">Encode content</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlTag Create(string type, string content, HtmlElement[] children, bool encodeContent = true)
        {
            var c = new List<HtmlElement>() { new HtmlText(content, encodeContent) };
            c.AddRange(children.ToList());
            return new HtmlTag() { Type = type, Children = c };
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="type">Type of the tag</param>
        /// <param name="child">Child of the tag</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlTag Create(string type, HtmlElement child)
        {
            return new HtmlTag() { Type = type, Children = new List<HtmlElement> { child } };
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="type">Type of the tag</param>
        /// <param name="children">Children of the tag</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlTag Create(string type, List<HtmlElement> children)
        {
            return new HtmlTag() { Type = type, Children = children };
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="type">Type of the tag</param>
        /// <param name="children">Children of the tag</param>
        /// <returns>New initialized instance of tag</returns>
        public static HtmlTag Create(string type, HtmlElement[] children)
        {
            return new HtmlTag() { Type = type, Children = children.ToList() };
        }
    }
}
