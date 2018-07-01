using Xunit;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderTests
{
	public class HtmlTextTests
	{
		private readonly string contentRaw = "some <b>content</b>";
		private readonly string contentEncoded = "some &lt;b&gt;content&lt;/b&gt;";

		/// <summary>
		/// Test constructor without args
		/// </summary>
		[Fact]
		public void EmptyConstructorTest()
		{
			var obj = new HtmlText();
			Assert.Null(obj.Content);
		}

		/// <summary>
		/// Test constructor setting all values
		/// </summary>
		[Fact]
		public void SetValuesConstructorTest()
		{
			var obj = new HtmlText(contentRaw);
			Assert.Equal(contentEncoded, obj.Content);

			obj = new HtmlText(contentRaw, false);
			Assert.Equal(contentRaw, obj.Content);
		}


		/// <summary>
		/// Test conversion to string
		/// </summary>
		[Fact]
		public void ToStringTest()
		{
			var obj = HtmlText.Create(contentRaw);
			Assert.Equal($"{contentEncoded}\n", obj.ToString());
			Assert.Equal($"\t{contentEncoded}\n", obj.ToString(1));
		}

		/// <summary>
		/// Test static creation
		/// </summary>
		[Fact]
		public void CreateTest()
		{
			var obj = HtmlText.Create(contentRaw);
			Assert.Equal(contentEncoded, obj.Content);
			Assert.IsType<HtmlText>(obj);

			obj = HtmlText.Create(contentRaw, false);
			Assert.Equal(contentRaw, obj.Content);
			Assert.IsType<HtmlText>(obj);
		}

		/// <summary>
		/// Check comparison of two instances
		/// </summary>
		[Fact]
		public void EqualsTest()
		{
			var orig = HtmlText.Create(contentRaw, false);
			var copy = HtmlText.Create(contentRaw, false);
			var other = HtmlText.Create(contentEncoded, false);
			var str = "not same";
			Assert.True(orig.Equals(copy));
			Assert.False(orig.Equals(other));
			Assert.False(orig.Equals(null));
			Assert.False(orig.Equals(str));
		}

		/// <summary>
		/// Test hash creation
		/// </summary>
		[Fact]
		public void GetHashCodeTest()
		{
			var orig = HtmlText.Create(contentRaw, false);
			var copy = HtmlText.Create(contentRaw, false);
			var other = HtmlText.Create(contentEncoded, false);
			Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
			Assert.NotEqual(orig.GetHashCode(), other.GetHashCode());
		}
	}
}
