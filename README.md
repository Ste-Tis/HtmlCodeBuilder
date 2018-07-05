# HtmlCodeBuilder
Fluent way to create HTML code in C# .NET Core.

```
var html = HtmlTag.Create("p", new HtmlElement[] {
    HtmlText.Create("Lorem ipsum dolor sit amet, consetetur sadipscing elitr."),
    HtmlTag.Create("figure", new[] {
        HtmlTag.Create("img").AddAttribute("src", "https://www.mysite.com/mylogo.png").AddStyles(
            new[] { new[] {"width", "8cm"}, new[] {"height", "auto"} }
        ),
        HtmlTag.Create("figcaption", "My Logo")
    }),
    HtmlText.Create("Lorem ipsum dolor sit amet, consetetur sadipscing elitr.")
});
```

# Installation

**Download the Source**

Download the source and include it directly into your project. It's not that much.

**Install NuGet-Package**

Get the package at [nuget.org](https://www.nuget.org/packages/HtmlCodeBuilder/1.0.2)

Visual Studio:
```
PM> Install-Package HtmlCodeBuilder
```

Cmd:
```
dotnet add package HtmlCodeBuilder
```

# Usage

The examples give an good overview about the usage. It's not that complicated.

**Create a single tag**

A single tag can be created with one line of code.
```
Input:
var html = HtmlTag.Create("p");

Output:
<p />
```

**Add content**

Add a bit of text to the tag.
```
Input:
var html = HtmlTag.Create("p", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr.");

Output:
<p>
    Lorem ipsum dolor sit amet, consetetur sadipscing elitr.
</p>
```

**Style the text**

Bring color to the screen.
```
Input:
var html = HtmlTag.Create("p", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr.").AddStyle("color", "#932");

Output:
<p style="color: #932;">
    Lorem ipsum dolor sit amet, consetetur sadipscing elitr.
</p>
```

**Put the style away and use a class**

Style in the tag is ugly, use a class instead.
```
Input:
var html = HtmlTag.Create("p", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr.").AddClass("color-red");

Output:
<p class="color-red">
    Lorem ipsum dolor sit amet, consetetur sadipscing elitr.
</p>
```

Ids can be used by replacing *AddClass()* with *AddId()*.

**Add a JS action**

Add JavaScript interaction to the tag.
```
Input:
var html = HtmlTag.Create("p", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr.").AddAttribute("onclick", "myfunction('p')");

Output:
<p onlick="myfunction('p')">
    Lorem ipsum dolor sit amet, consetetur sadipscing elitr.
</p>
```

**Highlight some parts of the text**

Make the important words bold.
```
Input:
var html = HtmlTag.Create("p", "Lorem ipsum dolor sit amet, <b>consetetur</b> sadipscing elitr.", false);

Output:
<p>
    Lorem ipsum dolor sit amet, <b>consetetur</b> sadipscing elitr.
</p>
```

Without setting the third parameter to FALSE the included HTML tags would be encoded.
```
Input:
var html = HtmlTag.Create("p", "Lorem ipsum dolor sit amet, <b>consetetur</b> sadipscing elitr.", true);

Output:
<p>
    Lorem ipsum dolor sit amet, &lt;b&gt;consetetur&lt;/b&gt; sadipscing elitr.
</p>
```

**Tags in tags? Of course!**

Put other tags inside an tag.
```
Input:
var html = HtmlTag.Create("div", new[] {
    HtmlTag.Create("h1", "Nice Headline"),
    HtmlTag.Create("p", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr.");
});

Output:
<div>
    <h1>
        Nice Headline
    </h1>
    <p>
        Lorem ipsum dolor sit amet, consetetur sadipscing elitr.
    </p>
</div>
```

**Mix text and tags inside a tag**

You can also put normal text between the nestd tag.
```
Input:
var html = HtmlTag.Create("div", new HtmlElement[] {
    HtmlTag.Create("h1", "First headline"),
    HtmlText.Create("Lorem ipsum dolor sit amet, consetetur sadipscing elitr."),
    HtmlTag.Create("h1", "Second headline"),
    HtmlText.Create("Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.")
});

Output:
<div>
    <h1>
        First headline
    </h1>
    Lorem ipsum dolor sit amet, consetetur sadipscing elitr.
    <h1>
        Second headline
    </h1>
    Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
</div>
```

# Important

HtmlCodeBuilder doesn't check if the HTML you create is valid. It simply creates a HTML code string from your input.

# License

This project is licensed under the MIT license. See the [LICENSE](https://github.com/Ste-Tis/HtmlCodeBuilder/blob/master/LICENSE) file for more info.