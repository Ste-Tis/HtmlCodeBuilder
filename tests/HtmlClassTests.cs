using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
	public class HtmlClassTests
	{
		private readonly string name = "class";
		private readonly string value = "no-border";

		/// <summary>
		/// Test constructor without args
		/// </summary>
		[Fact]
		public void EmptyConstructorTest()
		{
			var obj = new HtmlClass();
			Assert.Equal(name, obj.Name);
			Assert.Null(obj.Value);
		}

		/// <summary>
		/// Test constructor setting all values
		/// </summary>
		[Fact]
		public void SetValuesConstructorTest()
		{
			var obj = new HtmlClass(value);
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
			var obj = HtmlClass.Create(value);
			Assert.Equal(name, obj.Name);
			Assert.Equal(value, obj.Value);

			// Check return value
			Assert.IsType<HtmlClass>(obj);
		}

		/// <summary>
		/// Check comparison of two instances
		/// </summary>
		[Fact]
		public void EqualsTest()
		{
			var orig = HtmlClass.Create(value);
			var copy = HtmlClass.Create(value);
			var other = HtmlClass.Create("not same");
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
			var obj = HtmlClass.Create(value);
			Assert.Equal($@"{name}=""{value}""", obj.ToString());
		}
	}
}
