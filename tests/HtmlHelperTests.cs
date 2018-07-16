using Xunit;
using HtmlCodeBuilder;
using System.Collections.Generic;
using System;

namespace HtmlCodeBuilderTests
{
    public class HtmlHelperTests
    {
        [Fact]
        public void ConvertAttributesToString_EmptyAttribute_ReturnEmptyString()
        {
            // Arrange
            List<HtmlAttribute> attributes = new List<HtmlAttribute>();
            var output = "";

            // Act
            var result = HtmlHelper.ConvertAttributesToString(attributes);

            // Assert
            Assert.Equal(output, result);
        }

        [Fact]
        public void ConvertAttributesToString_MultipleAttributes_ReturnAttributesSeparated()
        {
            // Arrange
            List<HtmlAttribute> attributes = new List<HtmlAttribute>()
            {
                HtmlAttribute.Create("att-1", "1"),
                HtmlAttribute.Create("att-1", "2"),
                HtmlAttribute.Create("att-1", "2"),
                HtmlAttribute.Create("att-2", "1"),
                HtmlAttribute.Create("att-3", "3"),
            };
            var output = @" att-1=""1 2"" att-2=""1"" att-3=""3""";

            // Act
            var result = HtmlHelper.ConvertAttributesToString(attributes);

            // Assert
            Assert.Equal(output, result);
        }

        [Fact]
        public void ConvertAttributesToString_MultipleClasses_ReturnClassCombined()
        {
            // Arrange
            List<HtmlAttribute> attributes = new List<HtmlAttribute>()
            {
                HtmlClass.Create("no-border"),
                HtmlClass.Create("bold"),
                HtmlClass.Create("no-border")
            };
            var output = @" class=""bold no-border""";

            // Act
            var result = HtmlHelper.ConvertAttributesToString(attributes);

            Assert.Equal(output, result);
        }

        [Fact]
        public void ConvertAttributesToString_MultipleStyles_ReturnStyleCombined()
        {
            // Arrange
            List<HtmlAttribute> attributes = new List<HtmlAttribute>()
            {
                HtmlStyle.Create("font-family", "Tahoma"),
                HtmlStyle.Create("color", "#555"),
                HtmlStyle.Create("font-family", "Arial"),
                HtmlStyle.Create("display", "table"),
                HtmlStyle.Create("border", "1px solid #999"),
                HtmlStyle.Create("font-family", "Arial")
            };
            var output = @" style=""border: 1px solid #999; color: #555; display: table; font-family: Arial Tahoma;""";

            // act
            var result = HtmlHelper.ConvertAttributesToString(attributes);

            // Assert
            Assert.Equal(output, result);
        }

        [Fact]
        public void ConvertAttributesToString_MultipleMixed_ReturnSeparated()
        {
            // Arrange
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
            var output = @" att-1=""1 2"" att-2=""1"" att-3=""3"" class=""bold no-border"" style=""border: 1px solid #999; color: #555; display: table; font-family: Arial Tahoma;""";

            // Act
            var result = HtmlHelper.ConvertAttributesToString(attributes);

            // Assert
            Assert.Equal(output, result);
        }

        [Fact]
        public void Encode_ReturnEncodedString()
        {
            // Arrange
            var input = "This <b>is</b> a test & nothing more ...";
            var output = "This &lt;b&gt;is&lt;/b&gt; a test &amp; nothing more ...";

            // Act
            var result = HtmlHelper.HtmlEncode(input);

            // Assert
            Assert.Equal(output, result);
        }

        [Fact]
        public void Decode_ReturnDecodedString()
        {

            // Arrange
            var input = "This &lt;b&gt;is&lt;/b&gt; a test &amp; nothing more ...";
            var output = "This <b>is</b> a test & nothing more ...";

            // Act
            var result = HtmlHelper.HtmlDecode(input);

            // Assert
            Assert.Equal(output, result);
        }
    }
}
