using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
    public class HtmlIdTests
    {
        private readonly string name = "id";
        private readonly string value = "main";

        [Fact]
        public void Constructor_Empty()
        {
            // Act
            var obj = new HtmlId();

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Null(obj.Value);
        }

        [Fact]
        public void Constructor_SetValues()
        {
            // Act
            var obj = new HtmlId(value);

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Equal(value, obj.Value);
        }

        [Fact]
        public void Create_ReturnNewInstance()
        {
            // Act
            var obj = HtmlId.Create(value);

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Equal(value, obj.Value);
            Assert.IsType<HtmlId>(obj);
        }

        [Fact]
        public void Equals_IsEqual()
        {
            // Arrange
            var orig = HtmlId.Create(value);
            var copy = HtmlId.Create(value);

            // Assert
            Assert.True(orig.Equals(copy));
        }

        [Fact]
        public void Equals_IsNotEqual()
        {
            // Arrange
            var orig = HtmlId.Create(value);
            var other = HtmlId.Create("not same");

            // Assert
            Assert.False(orig.Equals(other));
        }

        [Fact]
        public void Equals_OtherObject()
        {
            // Arrange
            var orig = HtmlId.Create(value);
            var str = $@"{name}=""{value}""";

            // Assert
            Assert.False(orig.Equals(str));
        }

        [Fact]
        public void Equals_Null()
        {
            // Arrange
            var orig = HtmlId.Create(value);

            // Assert
            Assert.False(orig.Equals(null));
        }

        [Fact]
        public void ToString_ReturnString()
        {
            // Act
            var obj = HtmlId.Create(value);

            // Assert
            Assert.Equal($@"{name}=""{value}""", obj.ToString());
        }
    }
}
