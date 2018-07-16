using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
    public class HtmlTextTests
    {
        private readonly string contentRaw = "some <b>content</b>";
        private readonly string contentEncoded = "some &lt;b&gt;content&lt;/b&gt;";

        [Fact]
        public void Constrcutor_Empty()
        {
            // Act
            var obj = new HtmlText();

            // Assert
            Assert.Null(obj.Content);
        }

        [Fact]
        public void Constrcutor_SetValues_Encode()
        {
            // Act
            var obj = new HtmlText(contentRaw);

            // Assert
            Assert.Equal(contentEncoded, obj.Content);
        }

        [Fact]
        public void Constrcutor_SetValues_Raw()
        {
            // Act
            var obj = new HtmlText(contentRaw, false);

            // Assert
            Assert.Equal(contentRaw, obj.Content);
        }

        [Fact]
        public void ToString_ReturnString_NoIndent()
        {
            // Arrange
            var obj = HtmlText.Create(contentRaw);

            // Assert
            Assert.Equal($"{contentEncoded}\n", obj.ToString());
        }

        [Fact]
        public void ToString_ReturnString_Indent()
        {
            // Arrange
            var obj = HtmlText.Create(contentRaw);

            // Assert
            Assert.Equal($"\t{contentEncoded}\n", obj.ToString(1));
        }

        [Fact]
        public void Create_ReturnNewInstance_Encode()
        {
            // Act
            var obj = HtmlText.Create(contentRaw);

            // Assert
            Assert.Equal(contentEncoded, obj.Content);
            Assert.IsType<HtmlText>(obj);
        }

        [Fact]
        public void Create_ReturnNewInstance_Raw()
        {
            // Act
            var obj = HtmlText.Create(contentRaw, false);

            // Assert
            Assert.Equal(contentRaw, obj.Content);
            Assert.IsType<HtmlText>(obj);
        }

        [Fact]
        public void Equals_IsEqual()
        {
            // Arrange
            var orig = HtmlText.Create(contentRaw, false);
            var copy = HtmlText.Create(contentRaw, false);

            // Assert
            Assert.True(orig.Equals(copy));
        }

        [Fact]
        public void Equals_IsNotEqual()
        {
            // Arrange
            var orig = HtmlText.Create(contentRaw, false);
            var other = HtmlText.Create(contentEncoded, false);

            // Assert
            Assert.False(orig.Equals(other));
        }

        [Fact]
        public void Equals_OtherObject()
        {
            // Arrange
            var orig = HtmlText.Create(contentRaw, false);
            var str = "not same";

            // Assert
            Assert.False(orig.Equals(str));
        }

        [Fact]
        public void Equals_Null()
        {
            // Arrange
            var orig = HtmlText.Create(contentRaw, false);

            // Assert
            Assert.False(orig.Equals(null));
        }

        [Fact]
        public void GetHashCode_IsEqual()
        {
            // Arrange
            var orig = HtmlText.Create(contentRaw, false);
            var copy = HtmlText.Create(contentRaw, false);

            // Assert
            Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
        }

        [Fact]
        public void GetHashCode_IsNotEqual()
        {
            // Arrange
            var orig = HtmlText.Create(contentRaw, false);
            var other = HtmlText.Create(contentEncoded, false);

            // Assert
            Assert.NotEqual(orig.GetHashCode(), other.GetHashCode());
        }
    }
}
