using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
    public class HtmlElementTests
    {
        [Fact]
        public void ToString_ReturnString()
        {
            // Arrange
            var obj = HtmlElement.Create();

            // Assert
            Assert.Equal("", obj.ToString());
            Assert.Equal("", obj.ToString(1));
        }

        [Fact]
        public void Create_ReturnNewInstance()
        {
            // Act
            var obj = HtmlElement.Create();

            // Assert
            Assert.IsType<HtmlElement>(obj);
        }

        [Fact]
        public void Equals_IsEqual()
        {
            // Arrange
            var orig = HtmlElement.Create();
            var copy = HtmlElement.Create();
            
            // Assert
            Assert.True(orig.Equals(copy));
        }

        [Fact]
        public void Equals_OtherObject()
        {
            // Arrange
            var orig = HtmlElement.Create();
            var str = "not same";

            // Assert
            Assert.False(orig.Equals(str));
        }

        [Fact]
        public void Equals_Null()
        {
            // Arrange
            var orig = HtmlElement.Create();

            // Assert
            Assert.False(orig.Equals(null));
        }

        [Fact]
        public void GetHashCode_IsEqual()
        {
            // Arrange
            var orig = HtmlElement.Create();
            var copy = HtmlElement.Create();

            // Assert
            Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
        }
    }
}
