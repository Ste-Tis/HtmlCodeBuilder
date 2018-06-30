using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
	public class HtmlAttributeTests
	{
		private readonly string name = "Name";
		private readonly string value = "Egon Olsen";

		/// <summary>
		/// Test constructor without args
		/// </summary>
		[Fact]
		public void EmptyConstructorTest()
		{
			var obj = new HtmlAttribute();
			Assert.Null(obj.Name);
			Assert.Null(obj.Value);
		}

		/// <summary>
		/// Test constructor setting all values
		/// </summary>
		[Fact]
		public void SetValuesConstructorTest()
		{
			var obj = new HtmlAttribute(name, value);
			Assert.Equal(name, obj.Name);
			Assert.Equal(value, obj.Value);
		}

		/// <summary>
		/// Test static creation
		/// </summary>
		[Fact]
		public void CreateTest()
		{
			// All values must be set
			var obj = HtmlAttribute.Create(name, value);
			Assert.Equal(name, obj.Name);
			Assert.Equal(value, obj.Value);

			// Check return value
			Assert.IsType<HtmlAttribute>(obj);
		}

		/// <summary>
		/// Check comparison of two instances
		/// </summary>
		[Fact]
		public void EqualsTest()
		{
			var orig = HtmlAttribute.Create(name, value);
			var copy = HtmlAttribute.Create(name, value);
			var other = HtmlAttribute.Create("not", "same");
			var str = $@"{name}=""{value}""";
			Assert.True(orig.Equals(copy));
			Assert.False(orig.Equals(other));
			Assert.False(orig.Equals(null));
			Assert.False(orig.Equals(str));
		}

		/// <summary>
		/// Test conversion to string
		/// </summary>
		[Fact]
		public void ToStringTest()
		{
			var obj = HtmlAttribute.Create(name, value);
			Assert.Equal($@"{name}=""{value}""", obj.ToString());
		}
	}
}
