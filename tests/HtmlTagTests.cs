using Xunit;
using HtmlCodeBuilder;
using System.Collections.Generic;
using System;

namespace HtmlCodeBuilderTests
{
	public class HtmlTagTests
	{
		private readonly string type = "div";
		private readonly string content = "Lorem ipsum <b>dolor</b> sit amet";
		private readonly string contentEncoded = "Lorem ipsum &lt;b&gt;dolor&lt;/b&gt; sit amet";
		private readonly string attName1 = "att_1";
		private readonly string attName2 = "att_2";
		private readonly string attValue1 = "some value";
		private readonly string attValue2 = "some other value";
		private readonly string classValue1 = "no-border";
		private readonly string classValue2 = "bold";
		private readonly string styleName1 = "font-family";
		private readonly string styleName2 = "color";
		private readonly string styleValue1 = "Tahoma";
		private readonly string styleValue2 = "#999";
		private readonly string tagName1 = "p";
		private readonly string tagName2 = "p";
		private readonly string tagName3 = "div";
		private readonly string tagValue1 = "1";
		private readonly string tagValue2 = "2";
		private readonly string tagValue3 = "3";

		/// <summary>
		/// Test constructor without args
		/// </summary>
		[Fact]
		public void EmptyConstructorTest()
		{
			var obj = new HtmlTag();
			Assert.Null(obj.Type);
			Assert.Null(obj.Content);
			Assert.Null(obj.Attributes);
			Assert.Null(obj.Children);
		}

		/// <summary>
		/// Test constructor setting all values
		/// </summary>
		[Fact]
		public void SetValuesConstructorTest()
		{
			// Encode content
			var obj = new HtmlTag(type, content);
			Assert.Equal(type, obj.Type);
			Assert.Equal(contentEncoded, obj.Content);
			Assert.Null(obj.Attributes);
			Assert.Null(obj.Children);

			// Raw content
			obj = new HtmlTag(type, content, false);
			Assert.Equal(type, obj.Type);
			Assert.Equal(content, obj.Content);
			Assert.Null(obj.Attributes);
			Assert.Null(obj.Children);
		}

		/// <summary>
		/// Test adding new attributes
		/// </summary>
		[Fact]
		public void AddAttributeTest()
		{
			var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
			var htmlAtt2 = new HtmlAttribute(attName2, attValue2);

			// Add objects directly
			var obj = new HtmlTag(type, content, false);
			Assert.IsType<HtmlTag>(obj.AddAttribute(htmlAtt1));
			Assert.IsType<HtmlTag>(obj.AddAttribute(htmlAtt2));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlAtt1, obj.Attributes);
			Assert.Contains(htmlAtt2, obj.Attributes);
			Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
			Assert.IsType<HtmlAttribute>(obj.Attributes[1]);

			// Use strings
			obj = new HtmlTag(type, content, false);
			Assert.IsType<HtmlTag>(obj.AddAttribute(attName1, attValue1));
			Assert.IsType<HtmlTag>(obj.AddAttribute(attName2, attValue2));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlAtt1, obj.Attributes);
			Assert.Contains(htmlAtt2, obj.Attributes);
			Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
			Assert.IsType<HtmlAttribute>(obj.Attributes[1]);
		}

		/// <summary>
		/// Test adding multiple new attributes
		/// </summary>
		[Fact]
		public void AddAttributesTest()
		{
			var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
			var htmlAtt2 = new HtmlAttribute(attName2, attValue2);

			// Add objects directly
			var obj = new HtmlTag(type, content, false);
			var attList = new[] { htmlAtt1, htmlAtt2 };
			Assert.IsType<HtmlTag>(obj.AddAttributes(attList));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlAtt1, obj.Attributes);
			Assert.Contains(htmlAtt2, obj.Attributes);
			Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
			Assert.IsType<HtmlAttribute>(obj.Attributes[1]);

			// Use strings
			obj = new HtmlTag(type, content, false);
			var strList = new string[][] {
				new string[] { attName1, attValue1 },
				new string[] { attName2, attValue2 }

			};
			Assert.IsType<HtmlTag>(obj.AddAttributes(strList));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlAtt1, obj.Attributes);
			Assert.Contains(htmlAtt2, obj.Attributes);
			Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
			Assert.IsType<HtmlAttribute>(obj.Attributes[1]);
		}

		/// <summary>
		/// Test removal of all attributes at once
		/// </summary>
		[Fact]
		public void RemoveAllAttributesTest()
		{
			var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
			var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
			var htmlStyle = new HtmlStyle(styleName2, styleValue2);
			var htmlClass = new HtmlClass(classValue1);

			var obj = new HtmlTag(type, content, false);
			obj.AddAttribute(htmlAtt1);
			obj.AddAttribute(htmlAtt2);
			obj.AddStyle(htmlStyle);
			obj.AddClass(htmlClass);

			Assert.IsType<HtmlTag>(obj.RemoveAllAttributes());
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlStyle, obj.Attributes);
			Assert.Contains(htmlClass, obj.Attributes);
			Assert.DoesNotContain(htmlAtt1, obj.Attributes);
			Assert.DoesNotContain(htmlAtt2, obj.Attributes);

			// Empty list to null
			obj = new HtmlTag(type, content, false);
			obj.AddAttribute(htmlAtt1);
			obj.AddAttribute(htmlAtt2);
			Assert.IsType<HtmlTag>(obj.RemoveAllAttributes());
			Assert.Null(obj.Attributes);
		}

		/// <summary>
		/// Test removal of a specific attribute
		/// </summary>
		[Fact]
		public void RemoveAttributeTest()
		{
			var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
			var htmlAtt2 = new HtmlAttribute(attName2, attValue2);

			var obj = new HtmlTag(type, content, false);
			obj.AddAttribute(htmlAtt1);
			obj.AddAttribute(htmlAtt2);
			Assert.IsType<HtmlTag>(obj.RemoveAttribute(attName2));
			Assert.Single(obj.Attributes);
			Assert.Contains(htmlAtt1, obj.Attributes);
			Assert.DoesNotContain(htmlAtt2, obj.Attributes);

			// Empty list to null
			Assert.IsType<HtmlTag>(obj.RemoveAttribute(attName1));
			Assert.Null(obj.Attributes);
		}

		/// <summary>
		/// Test adding new class
		/// </summary>
		[Fact]
		public void AddClassTest()
		{
			var htmlClass1 = new HtmlClass(classValue1);
			var htmlClass2 = new HtmlClass(classValue2);

			// Add objects directly
			var obj = new HtmlTag(type, content, false);
			Assert.IsType<HtmlTag>(obj.AddClass(htmlClass1));
			Assert.IsType<HtmlTag>(obj.AddClass(htmlClass2));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlClass1, obj.Attributes);
			Assert.Contains(htmlClass2, obj.Attributes);
			Assert.IsType<HtmlClass>(obj.Attributes[0]);
			Assert.IsType<HtmlClass>(obj.Attributes[1]);

			// Use strings
			obj = new HtmlTag(type, content, false);
			Assert.IsType<HtmlTag>(obj.AddClass(classValue1));
			Assert.IsType<HtmlTag>(obj.AddClass(classValue2));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlClass1, obj.Attributes);
			Assert.Contains(htmlClass2, obj.Attributes);
			Assert.IsType<HtmlClass>(obj.Attributes[0]);
			Assert.IsType<HtmlClass>(obj.Attributes[1]);
		}

		/// <summary>
		/// Test adding multiple new classes
		/// </summary>
		[Fact]
		public void AddAClassesTest()
		{
			var htmlClass1 = new HtmlClass(classValue1);
			var htmlClass2 = new HtmlClass(classValue2);

			// Add objects directly
			var obj = new HtmlTag(type, content, false);
			var attList = new[] { htmlClass1, htmlClass2 };
			Assert.IsType<HtmlTag>(obj.AddClasses(attList));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlClass1, obj.Attributes);
			Assert.Contains(htmlClass2, obj.Attributes);
			Assert.IsType<HtmlClass>(obj.Attributes[0]);
			Assert.IsType<HtmlClass>(obj.Attributes[1]);

			// Use strings
			obj = new HtmlTag(type, content, false);
			var strList = new string[] { classValue1, classValue2 };
			Assert.IsType<HtmlTag>(obj.AddClasses(strList));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlClass1, obj.Attributes);
			Assert.Contains(htmlClass2, obj.Attributes);
			Assert.IsType<HtmlClass>(obj.Attributes[0]);
			Assert.IsType<HtmlClass>(obj.Attributes[1]);
		}

		/// <summary>
		/// Test removal of all classes at once
		/// </summary>
		[Fact]
		public void RemoveAllClassesTest()
		{
			var htmlAtt = new HtmlAttribute(attName1, attValue1);
			var htmlStyle = new HtmlStyle(styleName1, styleValue1);
			var htmlClass1 = new HtmlClass(classValue1);
			var htmlClass2 = new HtmlClass(classValue2);

			var obj = new HtmlTag(type, content, false);
			obj.AddAttribute(htmlAtt);
			obj.AddStyle(htmlStyle);
			obj.AddClass(htmlClass1);
			obj.AddClass(htmlClass2);

			Assert.IsType<HtmlTag>(obj.RemoveAllClasses());
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlAtt, obj.Attributes);
			Assert.Contains(htmlStyle, obj.Attributes);
			Assert.DoesNotContain(htmlClass1, obj.Attributes);
			Assert.DoesNotContain(htmlClass2, obj.Attributes);

			// Empty list to null
			obj = new HtmlTag(type, content, false);
			obj.AddClass(htmlClass1);
			obj.AddClass(htmlClass2);
			Assert.IsType<HtmlTag>(obj.RemoveAllClasses());
			Assert.Null(obj.Attributes);
		}

		/// <summary>
		/// Test removal of a specific class
		/// </summary>
		[Fact]
		public void RemoveClassTest()
		{
			var htmlClass1 = new HtmlClass(classValue1);
			var htmlClass2 = new HtmlClass(classValue2);

			var obj = new HtmlTag(type, content, false);
			obj.AddClass(htmlClass1);
			obj.AddClass(htmlClass2);
			obj.AddClass(htmlClass1);
			Assert.IsType<HtmlTag>(obj.RemoveClass(classValue1));
			Assert.Single(obj.Attributes);
			Assert.Contains(htmlClass2, obj.Attributes);
			Assert.DoesNotContain(htmlClass1, obj.Attributes);

			// Empty list to null
			Assert.IsType<HtmlTag>(obj.RemoveClass(classValue2));
			Assert.Null(obj.Attributes);
		}

		/// <summary>
		/// Test adding new style
		/// </summary>
		[Fact]
		public void AddStyleTest()
		{
			var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
			var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);

			// Add objects directly
			var obj = new HtmlTag(type, content, false);
			Assert.IsType<HtmlTag>(obj.AddStyle(htmlStyle1));
			Assert.IsType<HtmlTag>(obj.AddStyle(htmlStyle2));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlStyle1, obj.Attributes);
			Assert.Contains(htmlStyle2, obj.Attributes);
			Assert.IsType<HtmlStyle>(obj.Attributes[0]);
			Assert.IsType<HtmlStyle>(obj.Attributes[1]);

			// Use strings
			obj = new HtmlTag(type, content, false);
			Assert.IsType<HtmlTag>(obj.AddStyle(styleName1, styleValue1));
			Assert.IsType<HtmlTag>(obj.AddStyle(styleName2, styleValue2));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlStyle1, obj.Attributes);
			Assert.Contains(htmlStyle2, obj.Attributes);
			Assert.IsType<HtmlStyle>(obj.Attributes[0]);
			Assert.IsType<HtmlStyle>(obj.Attributes[1]);
		}

		/// <summary>
		/// Test adding multiple new styles
		/// </summary>
		[Fact]
		public void AddStylesTest()
		{
			var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
			var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);

			// Add objects directly
			var obj = new HtmlTag(type, content, false);
			var attList = new[] { htmlStyle1, htmlStyle2 };
			Assert.IsType<HtmlTag>(obj.AddStyles(attList));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlStyle1, obj.Attributes);
			Assert.Contains(htmlStyle2, obj.Attributes);
			Assert.IsType<HtmlStyle>(obj.Attributes[0]);
			Assert.IsType<HtmlStyle>(obj.Attributes[1]);

			// Use strings
			obj = new HtmlTag(type, content, false);
			var strList = new string[][] {
				new string[] { styleName1, styleValue1 },
				new string[] { styleName2, styleValue2 }

			};
			Assert.IsType<HtmlTag>(obj.AddStyles(strList));
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlStyle1, obj.Attributes);
			Assert.Contains(htmlStyle2, obj.Attributes);
			Assert.IsType<HtmlStyle>(obj.Attributes[0]);
			Assert.IsType<HtmlStyle>(obj.Attributes[1]);
		}

		/// <summary>
		/// Test removal of all styles at once
		/// </summary>
		[Fact]
		public void RemoveAllStylesTest()
		{
			var htmlAtt = new HtmlAttribute(attName1, attValue1);
			var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
			var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
			var htmlClass = new HtmlClass(classValue1);

			var obj = new HtmlTag(type, content, false);
			obj.AddAttribute(htmlAtt);
			obj.AddStyle(htmlStyle1);
			obj.AddStyle(htmlStyle2);
			obj.AddClass(htmlClass);

			Assert.IsType<HtmlTag>(obj.RemoveAllStyles());
			Assert.Equal(2, obj.Attributes.Count);
			Assert.Contains(htmlAtt, obj.Attributes);
			Assert.Contains(htmlClass, obj.Attributes);
			Assert.DoesNotContain(htmlStyle1, obj.Attributes);
			Assert.DoesNotContain(htmlStyle2, obj.Attributes);

			// Empty list to null
			obj = new HtmlTag(type, content, false);
			obj.AddStyle(htmlStyle1);
			obj.AddStyle(htmlStyle2);
			Assert.IsType<HtmlTag>(obj.RemoveAllStyles());
			Assert.Null(obj.Attributes);
		}

		/// <summary>
		/// Test removal of a specific style
		/// </summary>
		[Fact]
		public void RemoveStyleTest()
		{
			var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
			var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);

			var obj = new HtmlTag(type, content, false);
			obj.AddStyle(htmlStyle1);
			obj.AddStyle(htmlStyle2);
			Assert.IsType<HtmlTag>(obj.RemoveStyle(styleName2));
			Assert.Single(obj.Attributes);
			Assert.Contains(htmlStyle1, obj.Attributes);
			Assert.DoesNotContain(htmlStyle2, obj.Attributes);

			// Empty list to null
			obj.RemoveStyle(styleName1);
			Assert.Null(obj.Attributes);
		}

		/// <summary>
		/// Test adding a new tag as child
		/// </summary>
		[Fact]
		public void AddChildTest()
		{
			var htmlTag1 = new HtmlTag(tagName1, tagValue1);
			var htmlTag2 = new HtmlTag(tagName3, tagValue3);

			var obj = new HtmlTag(type, content, false);
			Assert.IsType<HtmlTag>(obj.AddChild(htmlTag1));
			Assert.IsType<HtmlTag>(obj.AddChild(htmlTag2));
			Assert.Equal(2, obj.Children.Count);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag2, obj.Children);
			Assert.IsType<HtmlTag>(obj.Children[0]);
			Assert.IsType<HtmlTag>(obj.Children[1]);
		}

		/// <summary>
		/// Test adding multiple tags as children
		/// </summary>
		[Fact]
		public void AddChildrenTest()
		{
			var htmlTag1 = new HtmlTag(tagName1, tagValue1);
			var htmlTag2 = new HtmlTag(tagName3, tagValue3);

			var obj = new HtmlTag(type, content, false);
			var chList = new[] { htmlTag1, htmlTag2 };
			Assert.IsType<HtmlTag>(obj.AddChildren(chList));
			Assert.Equal(2, obj.Children.Count);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag2, obj.Children);
			Assert.IsType<HtmlTag>(obj.Children[0]);
			Assert.IsType<HtmlTag>(obj.Children[1]);
		}

		/// <summary>
		/// Test removal of all children at once
		/// </summary>
		[Fact]
		public void RemoveAllChildrenTest()
		{
			var htmlTag1 = new HtmlTag(tagName1, tagValue1);
			var htmlTag2 = new HtmlTag(tagName2, tagValue2);
			var htmlTag3 = new HtmlTag(tagName3, tagValue3);

			var obj = new HtmlTag(type, content, false);
			var chList = new[] { htmlTag1, htmlTag2, htmlTag3 };
			obj.AddChildren(chList);

			// Remove all children with same tag
			Assert.IsType<HtmlTag>(obj.RemoveAllChildren());
			Assert.Null(obj.Children);
		}

		/// <summary>
		/// Test removal of all children of an specific tag type
		/// </summary>
		[Fact]
		public void RemoveChildrenTest()
		{
			var htmlTag1 = new HtmlTag(tagName1, tagValue1);
			var htmlTag2 = new HtmlTag(tagName2, tagValue2);
			var htmlTag3 = new HtmlTag(tagName3, tagValue3);

			var obj = new HtmlTag(type, content, false);
			var chList = new[] { htmlTag1, htmlTag2, htmlTag3 };
			obj.AddChildren(chList);

			// Remove all children with same tag
			Assert.IsType<HtmlTag>(obj.RemoveChildren(tagName1));
			Assert.Single(obj.Children);
			Assert.Contains(htmlTag3, obj.Children);
			Assert.DoesNotContain(htmlTag1, obj.Children);
			Assert.DoesNotContain(htmlTag2, obj.Children);

			// Empty list to null
			Assert.IsType<HtmlTag>(obj.RemoveChildren(tagName3));
			Assert.Null(obj.Children);
		}

		/// <summary>
		/// Remove a specific child
		/// </summary>
		[Fact]
		public void RemoveChildTest()
		{
			var htmlTag1 = new HtmlTag(tagName1, tagValue1);
			var htmlTag2 = new HtmlTag(tagName2, tagValue2);
			var htmlTag3 = new HtmlTag(tagName3, tagValue3);

			var obj = new HtmlTag(type, content, false);
			var chList = new[] { htmlTag1, htmlTag2, htmlTag3 };
			obj.AddChildren(chList);

			// Only remove the second tag of the given type
			Assert.IsType<HtmlTag>(obj.RemoveChild(tagName1, 1));
			Assert.Equal(2, obj.Children.Count);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag3, obj.Children);
			Assert.DoesNotContain(htmlTag2, obj.Children);
		}

		/// <summary>
		/// Test transformation to string
		/// </summary>
		[Fact]
		public void ToStringTest()
		{
			var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
			var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
			var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
			var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
			var htmlClass1 = new HtmlClass(classValue1);
			var htmlClass2 = new HtmlClass(classValue2);
			var htmlTag1 = new HtmlTag(tagName1, tagValue1);
			var htmlTag2 = new HtmlTag(tagName2, tagValue2);
			var htmlTag3 = new HtmlTag(tagName3, tagValue3);

			// Test correct indentation
			var resExp = $"<{type}>\n\t<{tagName1}>\n\t\t{tagValue1}\n\t</{tagName1}>\n\t<{tagName2}>\n\t\t{tagValue2}\n\t</{tagName2}>\n</{type}>\n";
			var obj = HtmlTag.Create(type);
			obj.AddChild(htmlTag1);
			obj.AddChild(htmlTag2);
			var resAct = obj.ToString();
			Assert.IsType<string>(resAct);
			Assert.Equal(resExp, resAct);

			resExp = $"<{type}>\n\t<{tagName3}>\n\t\t{tagValue3}\n\t\t<{tagName1}>\n\t\t\t{tagValue1}\n\t\t</{tagName1}>\n\t</{tagName3}>\n</{type}>\n";
			obj = HtmlTag.Create(type);
			htmlTag3.AddChild(htmlTag1);
			obj.AddChild(htmlTag3);
			resAct = obj.ToString();
			Assert.IsType<string>(resAct);
			Assert.Equal(resExp, resAct);
			htmlTag3.RemoveAllChildren();

			// Test correct creation of attributes, classes and styles - Remove duplicated values
			resExp = $@"<{type} {attName1}=""{attValue1}"" {attName2}=""{attValue2}"" class=""{classValue2} {classValue1}"" style=""{styleName2}: {styleValue2}; {styleName1}: {styleValue1};"" />" + "\n";
			obj = HtmlTag.Create(type);
			obj.AddClass(htmlClass1);
			obj.AddClass(htmlClass2);
			obj.AddClass(htmlClass2);
			obj.AddAttribute(htmlAtt1);
			obj.AddAttribute(htmlAtt2);
			obj.AddAttribute(htmlAtt2);
			obj.AddStyle(htmlStyle1);
			obj.AddStyle(htmlStyle2);
			obj.AddStyle(htmlStyle2);
			resAct = obj.ToString();
			Assert.IsType<string>(resAct);
			Assert.Equal(resExp, resAct);
		}

		/// <summary>
		/// Test the different static ways to create a tag
		/// </summary>
		[Fact]
		public void CreateTest()
		{
			var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
			var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
			var attArray = new[] { htmlAtt1, htmlAtt2 };
			var attList = new List<HtmlAttribute>() { htmlAtt1, htmlAtt2 };
			var htmlTag1 = new HtmlTag(tagName1, tagValue1);
			var htmlTag2 = new HtmlTag(tagName2, tagValue2);
			var tagArray = new[] { htmlTag1, htmlTag2 };
			var tagList = new List<HtmlTag>() { htmlTag1, htmlTag2 };

			// Only type
			var obj = HtmlTag.Create(type);
			Assert.Equal(type, obj.Type);
			Assert.Null(obj.Content);
			Assert.Null(obj.Children);
			Assert.Null(obj.Attributes);

			// Type, encoded content
			obj = HtmlTag.Create(type, content);
			Assert.Equal(type, obj.Type);
			Assert.Equal(contentEncoded, obj.Content);
			Assert.Null(obj.Children);
			Assert.Null(obj.Attributes);

			// Type, raw content
			obj = HtmlTag.Create(type, content, false);
			Assert.Equal(type, obj.Type);
			Assert.Equal(content, obj.Content);
			Assert.Null(obj.Children);
			Assert.Null(obj.Attributes);

			// Type, encoded content, one child
			obj = HtmlTag.Create(type, content, htmlTag1);
			Assert.Equal(type, obj.Type);
			Assert.Equal(contentEncoded, obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Single(obj.Children);

			// Type, raw content, one child
			obj = HtmlTag.Create(type, content, htmlTag1, false);
			Assert.Equal(type, obj.Type);
			Assert.Equal(content, obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Single(obj.Children);

			// Type, encoded content, multiple child (list)
			obj = HtmlTag.Create(type, content, tagList);
			Assert.Equal(type, obj.Type);
			Assert.Equal(contentEncoded, obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag2, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Equal(2, obj.Children.Count);

			// Type, raw content, multiple child (list)
			obj = HtmlTag.Create(type, content, tagList, false);
			Assert.Equal(type, obj.Type);
			Assert.Equal(content, obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag2, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Equal(2, obj.Children.Count);

			// Type, encoded content, multiple child (array)
			obj = HtmlTag.Create(type, content, tagArray);
			Assert.Equal(type, obj.Type);
			Assert.Equal(contentEncoded, obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag2, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Equal(2, obj.Children.Count);

			// Type, raw content, multiple child (array)
			obj = HtmlTag.Create(type, content, tagArray, false);
			Assert.Equal(type, obj.Type);
			Assert.Equal(content, obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag2, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Equal(2, obj.Children.Count);

			// Type, one child
			obj = HtmlTag.Create(type, htmlTag1);
			Assert.Equal(type, obj.Type);
			Assert.Null(obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Single(obj.Children);

			// Type, multiple child (list)
			obj = HtmlTag.Create(type, tagList);
			Assert.Equal(type, obj.Type);
			Assert.Null(obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag2, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Equal(2, obj.Children.Count);

			// Type, multiple child (array)
			obj = HtmlTag.Create(type, tagArray);
			Assert.Equal(type, obj.Type);
			Assert.Null(obj.Content);
			Assert.Contains(htmlTag1, obj.Children);
			Assert.Contains(htmlTag2, obj.Children);
			Assert.Null(obj.Attributes);
			Assert.Equal(2, obj.Children.Count);
		}
	}
}