using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
	public class HtmlIdTests
	{
		private readonly string name = "id";
		private readonly string value = "main";

		/// <summary>
		/// Test constructor without args
		/// </summary>
		[Fact]
		public void EmptyConstructorTest()
		{
			var obj = new HtmlId();
			Assert.Equal(name, obj.Name);
			Assert.Null(obj.Value);
		}

		/// <summary>
		/// Test constructor setting all values
		/// </summary>
		[Fact]
		public void SetValuesConstructorTest()
		{
			var obj = new HtmlId(value);
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
			var obj = HtmlId.Create(value);
			Assert.Equal(name, obj.Name);
			Assert.Equal(value, obj.Value);

			// Check return value
			Assert.IsType<HtmlId>(obj);
		}

		/// <summary>
		/// Check comparison of two instances
		/// </summary>
		[Fact]
		public void EqualsTest()
		{
			var orig = HtmlId.Create(value);
			var copy = HtmlId.Create(value);
			var other = HtmlId.Create("not same");
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
			var obj = HtmlId.Create(value);
			Assert.Equal($@"{name}=""{value}""", obj.ToString());
		}
	}
}
