using System;
using HtmlCodeBuilder;

namespace HtmlCodeBuilderExmaple
{
	/// <summary>
	/// Todo:
	/// - Add class for ID
	/// - Position of tag content not fixed
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			var html = HtmlTag.Create("body", new[] {
				HtmlTag.Create("h1", "HtmlCodeBuilder Example"),
				HtmlTag.Create("p", @"Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod 
									tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At 
									vero eos et accusam et justo duo dolores et ea rebum. <b>Stet clita kasd gubergren</b>, 
									no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit 
									amet, <i>consetetur sadipscing elitr</i>, sed diam nonumy eirmod tempor invidunt ut 
									labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam 
									et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
									sanctus est Lorem ipsum dolor sit amet.", false).AddStyle("Font-Family", "Courier New"),
				HtmlTag.Create("h2", "Example for tables"),
				HtmlTag.Create("table", new[] {
					HtmlTag.Create("tr", new[] {
						HtmlTag.Create("th", "Name"),
						HtmlTag.Create("th", "Color"),
						HtmlTag.Create("th", "Price")
					}),
					HtmlTag.Create("tr", new[] {
						HtmlTag.Create("td", HtmlTag.Create("span", "Apple").AddClass("margin-rl")),
						HtmlTag.Create("td", HtmlTag.Create("span", "Green").AddClass("margin-rl")),
						HtmlTag.Create("td", HtmlTag.Create("span", "0.69€").AddClass("margin-rl"))
					}),
					HtmlTag.Create("tr", new[] {
						HtmlTag.Create("td", HtmlTag.Create("span", "Pear").AddClass("margin-rl")),
						HtmlTag.Create("td", HtmlTag.Create("span", "Yellow").AddClass("margin-rl")),
						HtmlTag.Create("td", HtmlTag.Create("span", "0.59€").AddClass("margin-rl"))
					}),
					HtmlTag.Create("tr", new[] {
						HtmlTag.Create("td", HtmlTag.Create("span", "Strawberry").AddClass("margin-rl")),
						HtmlTag.Create("td", HtmlTag.Create("span", "Red").AddClass("margin-rl")),
						HtmlTag.Create("td", HtmlTag.Create("span", "0.09€").AddClass("margin-rl"))
					}),
				}),
				HtmlTag.Create("h2", "Example for lists"),
				HtmlTag.Create("ul", new[] {
					HtmlTag.Create("li", "Option 1", false).AddStyle("font-weight", "bold"),
					HtmlTag.Create("li", "Option 2", false).AddStyle("font-style", "italic"),
					HtmlTag.Create("li", "Option 3", false)
				}),
				HtmlTag.Create("h2", "Example for images"),
				HtmlTag.Create("p", new[] {
					HtmlTag.Create("figure", new[] {
						HtmlTag.Create("img").AddAttribute("src", "https://upload.wikimedia.org/wikipedia/fr/c/c8/Assystem_Logo.jpg").AddStyles(new[] { new[] {"width", "8cm"}, new[] {"height", "auto"} }),
						HtmlTag.Create("figcaption", "Assystem Logo")
					})
				})
			});

			Console.WriteLine(html);
		}
	}
}
