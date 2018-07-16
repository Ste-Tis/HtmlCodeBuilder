using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
    public class HtmlAttributeTests
    {
        private readonly string name = "Name";
        private readonly string value = "Egon Olsen";

        [Fact]
        public void Constructor_Empty()
        {
            // Act
            var obj = new HtmlAttribute();

            // Assert
            Assert.Null(obj.Name);
            Assert.Null(obj.Value);
        }

        [Fact]
        public void Constructor_SetValues()
        {
            // Act
            var obj = new HtmlAttribute(name, value);

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Equal(value, obj.Value);
        }

        [Fact]
        public void Create_ReturnNewInstance()
        {
            // Act
            var obj = HtmlAttribute.Create(name, value);

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Equal(value, obj.Value);
            Assert.IsType<HtmlAttribute>(obj);
        }

        [Fact]
        public void Equals_IsEqual()
        {
            // Arrange
            var orig = HtmlAttribute.Create(name, value);
            var copy = HtmlAttribute.Create(name, value);

            // Assert
            Assert.True(orig.Equals(copy));
        }

        [Fact]
        public void Equals_IsNotEqual()
        {
            // Arrange
            var orig = HtmlAttribute.Create(name, value);
            var other = HtmlAttribute.Create("not", "same");
            
            // Assert
            Assert.False(orig.Equals(other));
        }

        [Fact]
        public void Equals_OtherObject()
        {
            // Arrange
            var orig = HtmlAttribute.Create(name, value);
            var str = $@"{name}=""{value}""";

            // Assert
            Assert.False(orig.Equals(str));
        }

        [Fact]
        public void Equals_Null()
        {
            // Arrange
            var orig = HtmlAttribute.Create(name, value);

            // Assert
            Assert.False(orig.Equals(null));
        }

        [Fact]
        public void GetHashCode_IsEqual()
        {
            // Arrange
            var orig = HtmlAttribute.Create(name, value);
            var copy = HtmlAttribute.Create(name, value);

            // Assert
            Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
        }

        [Fact]
        public void GetHashCode_IsNotEqual()
        {
            // Arrange
            var orig = HtmlAttribute.Create(name, value);
            var other = HtmlAttribute.Create("not", "same");
            
            // Assert
            Assert.NotEqual(orig.GetHashCode(), other.GetHashCode());
        }

        [Fact]
        public void ToString_ReturnString()
        {
            // Arrange
            var obj = HtmlAttribute.Create(name, value);

            // Assert
            Assert.Equal($@"{name}=""{value}""", obj.ToString());
        }
    }
}
