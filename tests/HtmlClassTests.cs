using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
    public class HtmlClassTests
    {
        private readonly string name = "class";
        private readonly string value = "no-border";

        [Fact]
        public void Constructor_Empty()
        {
            // Act
            var obj = new HtmlClass();

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Null(obj.Value);
        }

        [Fact]
        public void Constructor_SetValues()
        {
            // Act
            var obj = new HtmlClass(value);

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Equal(value, obj.Value);
        }

        [Fact]
        public void Create_ReturnNewInstance()
        {
            // Act
            var obj = HtmlClass.Create(value);

            // Assert
            Assert.Equal(name, obj.Name);
            Assert.Equal(value, obj.Value);
            Assert.IsType<HtmlClass>(obj);
        }

        [Fact]
        public void Equals_IsEqual()
        {
            // Arrange
            var orig = HtmlClass.Create(value);
            var copy = HtmlClass.Create(value);
            
            // Assert
            Assert.True(orig.Equals(copy));
        }

        [Fact]
        public void Equals_IsNotEqual()
        {
            // Arrange
            var orig = HtmlClass.Create(value);
            var other = HtmlClass.Create("not same");
            
            // Assert
            Assert.False(orig.Equals(other));
        }

        [Fact]
        public void Equals_OtherObject()
        {
            // Arrange
            var orig = HtmlClass.Create(value);
            var str = $@"{name}=""{value}""";

            // Assert
            Assert.False(orig.Equals(str));
        }

        [Fact]
        public void Equals_Null()
        {
            // Arrange
            var orig = HtmlClass.Create(value);

            // Assert
            Assert.False(orig.Equals(null));
        }

        [Fact]
        public void ToString_ReturnString()
        {
            // Act
            var obj = HtmlClass.Create(value);

            // Assert
            Assert.Equal($@"{name}=""{value}""", obj.ToString());
        }
    }
}
