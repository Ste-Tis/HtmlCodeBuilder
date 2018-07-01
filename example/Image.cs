using System;

namespace HtmlCodeBuilder.Examples
{
    public static class Image
    {
		public static void HtmlImage()
		{
			var html = HtmlTag.Create("p", new HtmlElement[] {
				HtmlText.Create("Lorem ipsum dolor sit amet, consetetur sadipscing elitr."),
				HtmlTag.Create("figure", new[] {
					HtmlTag.Create("img").AddAttribute("src", "https://upload.wikimedia.org/wikipedia/fr/c/c8/Assystem_Logo.jpg").AddStyles(
						new[] { new[] {"width", "8cm"}, new[] {"height", "auto"} }
					),
					HtmlTag.Create("figcaption", "Assystem Logo")
				}),
				HtmlText.Create("Lorem ipsum dolor sit amet, consetetur sadipscing elitr.")
			});

			Console.WriteLine(html);
		}
    }
}
