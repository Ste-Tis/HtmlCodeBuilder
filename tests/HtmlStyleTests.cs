using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
    public class HtmlStyleTests
    {
        private readonly string name = "font-family";
        private readonly string value = "Tahoma";

        [Fact]
        public void Constrcutor_Empty()
        {
            // Act
            var obj = new HtmlStyle();

            // Assert
            Assert.Null(obj.Name);
            Assert.Null(obj.Value);
        }

        [Fact]
        public void Constructor_SetValues()
        {
            // Act
            var obj = new HtmlStyle(name, value);

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Equal(value, obj.Value);
        }

        [Fact]
        public void Create_ReturnNewInstance()
        {
            // Act
            var obj = HtmlStyle.Create(name, value);

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Equal(value, obj.Value);
            Assert.IsType<HtmlStyle>(obj);
        }

        [Fact]
        public void Equals_IsEqual()
        {
            // Arrange
            var orig = HtmlStyle.Create(name, value);
            var copy = HtmlStyle.Create(name, value);
            
            // Assert
            Assert.True(orig.Equals(copy));
        }

        [Fact]
        public void Equals_IsNotEqual()
        {
            // Arrange
            var orig = HtmlStyle.Create(name, value);
            var other = HtmlStyle.Create("not", "same");
            
            // Assert
            Assert.False(orig.Equals(other));
        }

        [Fact]
        public void Equals_OtherObject()
        {
            // Arrange
            var orig = HtmlStyle.Create(name, value);
            var str = $@"{name}=""{value}""";

            // Assert
            Assert.False(orig.Equals(str));
        }

        [Fact]
        public void Equals_Null()
        {
            // Arrange
            var orig = HtmlStyle.Create(name, value);
            
            // Assert
            Assert.False(orig.Equals(null));
        }

        [Fact]
        public void ToString_ReturnString()
        {
            // Arrange
            var obj = HtmlStyle.Create(name, value);

            // Assert
            Assert.Equal($@"style=""{name}: {value}""", obj.ToString());
        }
    }
}
