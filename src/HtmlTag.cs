using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HtmlCodeBuilder
{
	/// <summary>
	/// Represents a HTML tag
	/// </summary>
	class HtmlTag
	{
		/// <summary>
		/// Defines which tag to represent
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Text content of the tag
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Special attributes of the tag
		/// </summary>
		public List<HtmlAttribute> Attributes { get; set; }

		/// <summary>
		/// Child tags
		/// </summary>
		public List<HtmlTag> Children { get; set; }

		/// <summary>
		/// Create an empty instance
		/// </summary>
		public HtmlTag() { }

		/// <summary>
		/// Add a new attribute to the tag
		/// </summary>
		/// <param name="htmlAttribute">Attribute</param>
		/// <returns>Updates instance of tag</returns>
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
		/// <returns>Updates instance of tag</returns>
		public HtmlTag AddAttribute(string name, string value)
		{
			return AddAttribute(new HtmlAttribute(name, value));
		}

		/// <summary>
		/// Remove attribute with given name from tag
		/// </summary>
		/// <param name="name">Name of attribute</param>
		/// <returns>Updates instance of tag</returns>
		public HtmlTag RemoveAttribute(string name)
		{
			Attributes.RemoveAll(e => e.Name == name);
			return this;
		}

		/// <summary>
		/// Add a new class to the tag
		/// </summary>
		/// <param name="htmlClass">Class</param>
		/// <returns>Updates instance of tag</returns>
		public HtmlTag AddClass(HtmlClass htmlClass)
		{
			if (Attributes == null)
			{
				Attributes = new List<HtmlAttribute> { htmlClass };
			}
			else
			{
				if (Attributes.Where(e => e.Name == htmlClass.Name && e.Value == htmlClass.Value).Count() == 0)
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
		/// <returns>Updates instance of tag</returns>
		public HtmlTag AddClass(string value)
		{
			return AddClass(new HtmlClass(value));
		}

		/// <summary>
		/// Add multiple classes to the tag
		/// </summary>
		/// <param name="htmlClasses">Classes</param>
		/// <returns>Updates instance of tag</returns>
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
		/// <returns>Updates instance of tag</returns>
		public HtmlTag AddClasses(string[] values)
		{
			foreach (string value in values)
			{
				AddClass(new HtmlClass(value));
			}
			return this;
		}

		/// <summary>
		/// Remove class from the tag
		/// </summary>
		/// <param name="value">Name of the class</param>
		/// <returns>Updates instance of tag</returns>
		public HtmlTag RemoveClass(string value)
		{
			Attributes.RemoveAll(e => e.Value == value);
			return this;
		}

		/// <summary>
		/// Add a new style to the tag
		/// </summary>
		/// <param name="htmlStyle">Style</param>
		/// <returns>Updates instance of tag</returns>
		public HtmlTag AddStyle(HtmlStyle htmlStyle)
		{
			if (Attributes == null)
			{
				Attributes = new List<HtmlAttribute> { htmlStyle };
			}
			else
			{
				if (Attributes.Where(e => e.Name == htmlStyle.Name && e.Value == htmlStyle.Value).Count() == 0)
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
		/// <returns>Updates instance of tag</returns>
		public HtmlTag AddStyle(string cssOption, string value)
		{
			return AddStyle(new HtmlStyle(cssOption, value));
		}

		/// <summary>
		/// Add multiple styles to the tag
		/// </summary>
		/// <param name="htmlStyles">Styles</param>
		/// <returns>Updates instance of tag</returns>
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
		/// <returns>Updates instance of tag</returns>
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
		/// Remove CSS option from the tag
		/// </summary>
		/// <param name="cssOption">Name of the CSS option</param>
		/// <returns>Updates instance of tag</returns>
		public HtmlTag RemoveStyle(string cssOption)
		{
			Attributes.RemoveAll(e => e.Name == cssOption);
			return this;
		}

		/// <summary>
		/// Add child to the tag
		/// </summary>
		/// <param name="child">Child tag</param>
		/// <returns>Updates instance of tag</returns>
		public HtmlTag AddChild(HtmlTag child)
		{
			if (Children == null)
			{
				Children = new List<HtmlTag> { child };
			}
			else
			{
				Children.Add(child);
			}

			return this;
		}

		/// <summary>
		/// Remove all children of a given type from the tag
		/// </summary>
		/// <param name="type">Type of the children to remove</param>
		/// <returns>Updates instance of tag</returns>
		public HtmlTag RemoveChildren(string type)
		{
			Children.Where(e => e.Type != type).ToArray();
			return this;
		}

		/// <summary>
		/// Remove a specific child from the tag
		/// </summary>
		/// <remarks>
		/// Call:
		///	 RemoveChild("td", 2);
		/// 
		/// Before:
		///	 <tr>
		///		 <td>Pos 1</td>
		///		 <td>Pos 2</td>
		///		 <td>Pos 3</td>
		///	 </tr>
		/// 
		/// After:
		///	 <tr>
		///		 <td>Pos 1</td>
		///		 <td>Pos 3</td>
		///	 </tr>
		/// </remarks>
		/// <param name="type">Type of the child to remove</param>
		/// <param name="pos">Position of the child</param>
		/// <returns>Updates instance of tag</returns>
		public HtmlTag RemoveChild(string type, int pos)
		{
			foreach (HtmlTag c in Children)
			{
				if (c.Type == type)
				{
					pos--;
				}

				if (pos == 0)
				{
					Children.Remove(c);
					break;
				}
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
		public string ToString(int indentation)
		{
			var builderHtmlTag = new StringBuilder();
			var builderContent = new StringBuilder();

			builderHtmlTag.Append($"{new String('\t', indentation)}<{Type}");
			builderHtmlTag.Append(HtmlHelper.ConvertAttributesToString(Attributes));

			if (Content != null && Content.Length > 0)
			{
				builderContent.Append($"{new String('\t', indentation + 1)}{Content}\n");
			}

			if (Children != null)
			{
				foreach (HtmlTag c in Children)
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

		/// <summary>
		/// Create a new tag
		/// </summary>
		/// <param name="type">Type of the tag</param>
		/// <returns>Updates instance of tag</returns>
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
		/// <returns>Updates instance of tag</returns>
		public static HtmlTag Create(string type, string content, bool encodeContent = true)
		{
			return new HtmlTag() { Type = type, Content = (encodeContent ? HtmlHelper.HtmlEncode(content) : content) };
		}

		/// <summary>
		/// Create a new tag
		/// </summary>
		/// <param name="type">Type of the tag</param>
		/// <param name="content">Text content of the tag</param>
		/// <param name="child">Child of the tag</param>
		/// <param name="encodeContent">Encode content</param>
		/// <returns>Updates instance of tag</returns>
		public static HtmlTag Create(string type, string content, HtmlTag child, bool encodeContent = true)
		{
			return new HtmlTag() { Type = type, Content = (encodeContent ? HtmlHelper.HtmlEncode(content) : content), Children = new List<HtmlTag> { child } };
		}

		/// <summary>
		/// Create a new tag
		/// </summary>
		/// <param name="type">Type of the tag</param>
		/// <param name="content">Text content of the tag</param>
		/// <param name="children">Children of the tag</param>
		/// <param name="encodeContent">Encode content</param>
		/// <returns>Updates instance of tag</returns>
		public static HtmlTag Create(string type, string content, List<HtmlTag> children, bool encodeContent = true)
		{
			return new HtmlTag() { Type = type, Content = (encodeContent ? HtmlHelper.HtmlEncode(content) : content), Children = children };
		}

		/// <summary>
		/// Create a new tag
		/// </summary>
		/// <param name="type">Type of the tag</param>
		/// <param name="content">Text content of the tag</param>
		/// <param name="children">Children of the tag</param>
		/// <param name="encodeContent">Encode content</param>
		/// <returns>Updates instance of tag</returns>
		public static HtmlTag Create(string type, string content, HtmlTag[] children, bool encodeContent = true)
		{
			return new HtmlTag() { Type = type, Content = (encodeContent ? HtmlHelper.HtmlEncode(content) : content), Children = children.ToList() };
		}

		/// <summary>
		/// Create a new tag
		/// </summary>
		/// <param name="type">Type of the tag</param>
		/// <param name="child">Child of the tag</param>
		/// <returns>Updates instance of tag</returns>
		public static HtmlTag Create(string type, HtmlTag child)
		{
			return new HtmlTag() { Type = type, Children = new List<HtmlTag> { child } };
		}

		/// <summary>
		/// Create a new tag
		/// </summary>
		/// <param name="type">Type of the tag</param>
		/// <param name="children">Children of the tag</param>
		/// <returns>Updates instance of tag</returns>
		public static HtmlTag Create(string type, List<HtmlTag> children)
		{
			return new HtmlTag() { Type = type, Children = children };
		}

		/// <summary>
		/// Create a new tag
		/// </summary>
		/// <param name="type">Type of the tag</param>
		/// <param name="children">Children of the tag</param>
		/// <returns>Updates instance of tag</returns>
		public static HtmlTag Create(string type, HtmlTag[] children)
		{
			return new HtmlTag() { Type = type, Children = children.ToList() };
		}
	}
}
