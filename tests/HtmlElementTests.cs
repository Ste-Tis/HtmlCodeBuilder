using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
	public class HtmlElementTests
	{
		/// <summary>
		/// Test conversion to string
		/// </summary>
		[Fact]
		public void ToStringTest()
		{
			var obj = HtmlElement.Create();
			Assert.Equal("", obj.ToString());
			Assert.Equal("", obj.ToString(1));
		}

		/// <summary>
		/// Test static creation
		/// </summary>
		[Fact]
		public void CreateTest()
		{
			// All values must be set
			var obj = HtmlElement.Create();
			Assert.IsType<HtmlElement>(obj);
		}

		/// <summary>
		/// Check comparison of two instances
		/// </summary>
		[Fact]
		public void EqualsTest()
		{
			var orig = HtmlElement.Create();
			var copy = HtmlElement.Create();
			var str = "not same";
			Assert.True(orig.Equals(copy));
			Assert.False(orig.Equals(null));
			Assert.False(orig.Equals(str));
		}

		/// <summary>
		/// Test hash creation
		/// </summary>
		[Fact]
		public void GetHashCodeTest()
		{
			var orig = HtmlElement.Create();
			var copy = HtmlElement.Create();
			Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
		}
	}
}
