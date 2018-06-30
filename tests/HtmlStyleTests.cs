using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
	public class HtmlStyleTests
	{
		private readonly string name = "font-family";
		private readonly string value = "Tahoma";

		/// <summary>
		/// Test constructor without args
		/// </summary>
		[Fact]
		public void EmptyConstructorTest()
		{
			var obj = new HtmlStyle();
			Assert.Null(obj.Name);
			Assert.Null(obj.Value);
		}

		/// <summary>
		/// Test constructor setting all values
		/// </summary>
		[Fact]
		public void SetValuesConstructorTest()
		{
			var obj = new HtmlStyle(name, value);
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
			var obj = HtmlStyle.Create(name, value);
			Assert.Equal(name, obj.Name);
			Assert.Equal(value, obj.Value);

			// Check return value
			Assert.IsType<HtmlStyle>(obj);
		}

		/// <summary>
		/// Check comparison of two instances
		/// </summary>
		[Fact]
		public void EqualsTest()
		{
			var orig = HtmlStyle.Create(name, value);
			var copy = HtmlStyle.Create(name, value);
			var other = HtmlStyle.Create("not", "same");
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
			var obj = HtmlStyle.Create(name, value);
			Assert.Equal($@"style=""{name}: {value}""", obj.ToString());
		}
	}
}
