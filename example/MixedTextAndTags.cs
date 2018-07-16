using System;

namespace HtmlCodeBuilder.Examples
{
    public static class MixedTextAndTags
    {
        public static void HtmlTextAndTag()
        {
            var html = HtmlTag.Create("div", new HtmlElement[] {
                HtmlTag.Create("h1", "First headline"),
                HtmlText.Create("Lorem ipsum dolor sit amet, consetetur sadipscing elitr."),
                HtmlTag.Create("h1", "Second headline"),
                HtmlText.Create("Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet."),
                HtmlTag.Create("h1", "Third headline"),
                HtmlText.Create("Lorem ipsum dolor sit amet, consetetur sadipscing elitr."),
            });

            Console.WriteLine(html);
        }
    }
}
