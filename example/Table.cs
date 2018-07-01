using System;

namespace HtmlCodeBuilder.Examples
{
	public static class Table
	{
		public static void HtmlTable()
		{
			var html = HtmlTag.Create("table", new[] {
				HtmlTag.Create("tr", new[] {
					HtmlTag.Create("th", "Name"),
					HtmlTag.Create("th", "Color"),
					HtmlTag.Create("th", "Size")
				}),
				HtmlTag.Create("tr", new[] {
					HtmlTag.Create("td", HtmlTag.Create("span", "Apple")),
					HtmlTag.Create("td", HtmlTag.Create("span", "Green").AddStyle("color", "green")),
					HtmlTag.Create("td", HtmlTag.Create("span", "Big"))
				}),
				HtmlTag.Create("tr", new[] {
					HtmlTag.Create("td", HtmlTag.Create("span", "Pear")),
					HtmlTag.Create("td", HtmlTag.Create("span", "Yellow").AddStyle("color", "yellow")),
					HtmlTag.Create("td", HtmlTag.Create("span", "Big"))
				}),
				HtmlTag.Create("tr", new[] {
					HtmlTag.Create("td", HtmlTag.Create("span", "Strawberry")),
					HtmlTag.Create("td", HtmlTag.Create("span", "Red").AddStyle("color", "red")),
					HtmlTag.Create("td", HtmlTag.Create("span", "Small"))
				}),
			}).AddId("fruit-table");

			Console.WriteLine(html);
		}
	}
}
