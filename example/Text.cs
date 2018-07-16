using System;

namespace HtmlCodeBuilder.Examples
{
    public static class Text
    {
        public static void HtmlText()
        {
            var html = HtmlTag.Create("body", new[] {
                HtmlTag.Create("h1", "Chapter 1"),
                HtmlTag.Create("p", @"Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod 
                                    tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At 
                                    vero eos et accusam et justo duo dolores et ea rebum. <b>Stet clita kasd gubergren</b>, 
                                    no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit 
                                    amet, <i>consetetur sadipscing elitr</i>, sed diam nonumy eirmod tempor invidunt ut 
                                    labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam 
                                    et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
                                    sanctus est Lorem ipsum dolor sit amet.", false),
                HtmlTag.Create("h2", "Chapter 1.1."),
                HtmlTag.Create("p", @"Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod 
                                    tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua."),
                HtmlTag.Create("h2", "Chapter 1.2."),
                HtmlTag.Create("p", @"Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod 
                                    tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.")
            });

            Console.WriteLine(html);
        }
    }
}
