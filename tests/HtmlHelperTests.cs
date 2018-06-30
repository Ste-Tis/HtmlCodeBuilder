using Xunit;
using HtmlCodeBuilder;
using System.Collections.Generic;
using System;

namespace HtmlCodeBuilderTests
{
	public class HtmlHelperTests
	{
		/// <summary>
		/// Test empty attribute list.
		/// </summary>
		[Fact]
		public void ConvertEmptyTest()
		{
			List<HtmlAttribute> attributes = new List<HtmlAttribute>();

			var res = "";
			Assert.Equal(res, HtmlHelper.ConvertAttributesToString(attributes));
		}

		/// <summary>
		/// Test only HtmlAttributes in list.
		/// 
		/// Attributes with same name are grouped and values are separated by space. Values should be sorted by name.
		/// </summary>
		[Fact]
		public void ConvertOnlyHtmlAttributeTest()
		{
			List<HtmlAttribute> attributes = new List<HtmlAttribute>()
			{
				HtmlAttribute.Create("att-1", "1"),
				HtmlAttribute.Create("att-1", "2"),
				HtmlAttribute.Create("att-1", "2"),
				HtmlAttribute.Create("att-2", "1"),
				HtmlAttribute.Create("att-3", "3"),
			};

			var res = @" att-1=""1 2"" att-2=""1"" att-3=""3""";
			Assert.Equal(res, HtmlHelper.ConvertAttributesToString(attributes));
		}

		/// <summary>
		/// Test only HtmlClass in list.
		/// 
		/// Only one attribute should be created which contains all classes separated by space. Values should be sorted by name.
		/// </summary>
		[Fact]
		public void ConvertOnlyHtmlClassTest()
		{
			List<HtmlAttribute> attributes = new List<HtmlAttribute>()
			{
				HtmlClass.Create("no-border"),
				HtmlClass.Create("bold"),
				HtmlClass.Create("no-border")
			};

			// Attributes with same name are grouped and values are separated by space
			var res = @" class=""bold no-border""";
			Assert.Equal(res, HtmlHelper.ConvertAttributesToString(attributes));
		}

		/// <summary>
		/// Test only HtmlStyle in list.
		/// 
		/// Only one attribute should be created which contains all styles conform to CSS rules. Values should be sorted by name.
		/// </summary>
		[Fact]
		public void ConvertOnlyHtmlStyleTest()
		{
			List<HtmlAttribute> attributes = new List<HtmlAttribute>()
			{
				HtmlStyle.Create("font-family", "Tahoma"),
				HtmlStyle.Create("color", "#555"),
				HtmlStyle.Create("font-family", "Arial"),
				HtmlStyle.Create("display", "table"),
				HtmlStyle.Create("border", "1px solid #999"),
				HtmlStyle.Create("font-family", "Arial")
			};

			// Attributes with same name are grouped and values are separated by space
			var res = @" style=""border: 1px solid #999; color: #555; display: table; font-family: Arial Tahoma;""";
			Assert.Equal(res, HtmlHelper.ConvertAttributesToString(attributes));
		}

		/// <summary>
		/// Test combination of all attribute classes.
		/// 
		/// Attributes and values should be separated by space. Values should be sorted.
		/// </summary>
		[Fact]
		public void ConvertMixedTest()
		{
			List<HtmlAttribute> attributes = new List<HtmlAttribute>()
			{
				HtmlClass.Create("no-border"),
				HtmlAttribute.Create("att-1", "1"),
				HtmlAttribute.Create("att-1", "2"),
				HtmlStyle.Create("display", "table"),
				HtmlStyle.Create("border", "1px solid #999"),
				HtmlAttribute.Create("att-1", "2"),
				HtmlStyle.Create("font-family", "Tahoma"),
				HtmlStyle.Create("color", "#555"),
				HtmlStyle.Create("font-family", "Arial"),
				HtmlAttribute.Create("att-2", "1"),
				HtmlAttribute.Create("att-3", "3"),
				HtmlClass.Create("no-border"),
				HtmlClass.Create("bold"),
				HtmlStyle.Create("font-family", "Arial")
			};

			// Attributes with same name are grouped and values are separated by space
			var res = @" att-1=""1 2"" att-2=""1"" att-3=""3"" class=""bold no-border"" style=""border: 1px solid #999; color: #555; display: table; font-family: Arial Tahoma;""";
			Assert.Equal(res, HtmlHelper.ConvertAttributesToString(attributes));
		}

		/// <summary>
		/// Test simple encoding of some chars
		/// </summary>
		[Fact]
		public void EncodeTest()
		{
			Assert.Equal("This &lt;b&gt;is&lt;/b&gt; a test &amp; nothing more ...", HtmlHelper.HtmlEncode("This <b>is</b> a test & nothing more ..."));
		}

		/// <summary>
		/// Test simple decoding of some chars
		/// </summary>
		[Fact]
		public void DecodeTest()
		{
			Assert.Equal("This <b>is</b> a test & nothing more ...", HtmlHelper.HtmlDecode("This &lt;b&gt;is&lt;/b&gt; a test &amp; nothing more ..."));
		}
	}
}
