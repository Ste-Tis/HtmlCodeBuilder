using Xunit;
using HtmlCodeBuilder;
using System.Collections.Generic;
using System;

namespace HtmlCodeBuilderTests
{
    public class HtmlTagTests
    {
        private readonly string type = "div";
        private readonly string content = "Lorem ipsum <b>dolor</b> sit amet";
        private readonly string contentEncoded = "Lorem ipsum &lt;b&gt;dolor&lt;/b&gt; sit amet";
        private readonly string attName1 = "att_1";
        private readonly string attName2 = "att_2";
        private readonly string attName3 = "onclick";
        private readonly string attValue1 = "some value";
        private readonly string attValue2 = "some other value";
        private readonly string attValue3 = "myFunction('pos1')";
        private readonly string classValue1 = "no-border";
        private readonly string classValue2 = "bold";
        private readonly string styleName1 = "font-family";
        private readonly string styleName2 = "color";
        private readonly string styleValue1 = "Tahoma";
        private readonly string styleValue2 = "#999";
        private readonly string idValue1 = "main";
        private readonly string idValue2 = "footer";
        private readonly string tagName1 = "p";
        private readonly string tagName2 = "p";
        private readonly string tagName3 = "div";
        private readonly string tagValue1 = "1";
        private readonly string tagValue2 = "2";
        private readonly string tagValue3 = "3";

        [Fact]
        public void Constructor_Empty()
        {
            // Act
            var obj = new HtmlTag();

            // Assert
            Assert.Null(obj.Type);
            Assert.Null(obj.Attributes);
            Assert.Null(obj.Children);
        }

        [Fact]
        public void Constructor_SetValues_NoContent()
        {
            // Act
            var obj = new HtmlTag(type);

            // Assert
            Assert.Equal(type, obj.Type);
            Assert.Null(obj.Attributes);
            Assert.Null(obj.Children);
        }

        [Fact]
        public void Constructor_SetValues_ContentEncoded()
        {
            // Act
            var obj = new HtmlTag(type, content);

            // Assert
            Assert.Equal(type, obj.Type);
            Assert.Null(obj.Attributes);
            Assert.Single(obj.Children);
            Assert.IsType<HtmlText>(obj.Children[0]);
            Assert.Equal(contentEncoded, ((HtmlText)obj.Children[0]).Content);
        }

        [Fact]
        public void Constructor_SetValues_ContentRaw()
        {
            // Act
            var obj = new HtmlTag(type, content, false);

            // Assert
            Assert.Equal(type, obj.Type);
            Assert.Null(obj.Attributes);
            Assert.Single(obj.Children);
            Assert.IsType<HtmlText>(obj.Children[0]);
            Assert.Equal(content, ((HtmlText)obj.Children[0]).Content);
        }

        [Fact]
        public void AddAttribute_AsObject()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result1 = obj.AddAttribute(htmlAtt1);
            var result2 = obj.AddAttribute(htmlAtt2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlAtt1, obj.Attributes);
            Assert.Contains(htmlAtt2, obj.Attributes);
            Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
            Assert.IsType<HtmlAttribute>(obj.Attributes[1]);
        }


        [Fact]
        public void AddAttribute_AsString()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result1 = obj.AddAttribute(attName1, attValue1);
            var result2 = obj.AddAttribute(attName2, attValue2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlAtt1, obj.Attributes);
            Assert.Contains(htmlAtt2, obj.Attributes);
            Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
            Assert.IsType<HtmlAttribute>(obj.Attributes[1]);
        }

        [Fact]
        public void AddAttribute_AsJavaScriptString()
        {
            // Arrange
            var htmlAtt = new HtmlAttribute(attName3, attValue3);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result = obj.AddAttribute(attName3, attValue3);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Contains(htmlAtt, obj.Attributes);
            Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
        }

        [Fact]
        public void AddAttributes_AsListOfObjects()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var obj = new HtmlTag(type, content, false);
            var attList = new[] { htmlAtt1, htmlAtt2 };

            // Act
            var result = obj.AddAttributes(attList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlAtt1, obj.Attributes);
            Assert.Contains(htmlAtt2, obj.Attributes);
            Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
            Assert.IsType<HtmlAttribute>(obj.Attributes[1]);
        }

        [Fact]
        public void AddAttributes_AsListOfLists()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var obj = new HtmlTag(type, content, false);
            var strList = new string[][] {
                new string[] { attName1, attValue1 },
                new string[] { attName2, attValue2 }

            };

            // Act
            var result = obj.AddAttributes(strList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlAtt1, obj.Attributes);
            Assert.Contains(htmlAtt2, obj.Attributes);
            Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
            Assert.IsType<HtmlAttribute>(obj.Attributes[1]);
        }

        [Fact]
        public void AddAttributes_AsListOfStrings()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var obj = new HtmlTag(type, content, false);
            var strList2 = new string[] {
                attName1, attValue1, attName2, attValue2
            };

            // Act
            var result = obj.AddAttributes(strList2);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlAtt1, obj.Attributes);
            Assert.Contains(htmlAtt2, obj.Attributes);
            Assert.IsType<HtmlAttribute>(obj.Attributes[0]);
            Assert.IsType<HtmlAttribute>(obj.Attributes[1]);
        }

        [Fact]
        public void RemoveAllAttributes_OnlyRemoveAttributes()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var htmlStyle = new HtmlStyle(styleName2, styleValue2);
            var htmlClass = new HtmlClass(classValue1);
            var htmlId = new HtmlId(idValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddAttribute(htmlAtt1);
            obj.AddAttribute(htmlAtt2);
            obj.AddStyle(htmlStyle);
            obj.AddClass(htmlClass);
            obj.AddId(htmlId);

            // Act
            var result = obj.RemoveAllAttributes();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(3, obj.Attributes.Count);
            Assert.Contains(htmlStyle, obj.Attributes);
            Assert.Contains(htmlClass, obj.Attributes);
            Assert.Contains(htmlId, obj.Attributes);
            Assert.DoesNotContain(htmlAtt1, obj.Attributes);
            Assert.DoesNotContain(htmlAtt2, obj.Attributes);
        }

        [Fact]
        public void RemoveAllAttributes_EmptyListToNull()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var obj = new HtmlTag(type, content, false);
            obj.AddAttribute(htmlAtt1);
            obj.AddAttribute(htmlAtt2);

            // Act
            var result = obj.RemoveAllAttributes();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Attributes);
        }

        [Fact]
        public void RemoveAttribute_OnlyRemoveSpecificAttribute()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var obj = new HtmlTag(type, content, false);
            obj.AddAttribute(htmlAtt1);
            obj.AddAttribute(htmlAtt2);

            // Act
            var result = obj.RemoveAttribute(attName2);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Attributes);
            Assert.Contains(htmlAtt1, obj.Attributes);
            Assert.DoesNotContain(htmlAtt2, obj.Attributes);
        }

        [Fact]
        public void RemoveAttribute_EmptyListToNull()
        {
            // Arrange
            var htmlAtt = new HtmlAttribute(attName1, attValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddAttribute(htmlAtt);

            // Act
            var result = obj.RemoveAttribute(attName1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Attributes);
        }

        [Fact]
        public void AddClass_AsObject()
        {
            // Arrange
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result1 = obj.AddClass(htmlClass1);
            var result2 = obj.AddClass(htmlClass2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlClass1, obj.Attributes);
            Assert.Contains(htmlClass2, obj.Attributes);
            Assert.IsType<HtmlClass>(obj.Attributes[0]);
            Assert.IsType<HtmlClass>(obj.Attributes[1]);
        }

        [Fact]
        public void AddClass_AsString()
        {
            // Arrange
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result1 = obj.AddClass(classValue1);
            var result2 = obj.AddClass(classValue2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlClass1, obj.Attributes);
            Assert.Contains(htmlClass2, obj.Attributes);
            Assert.IsType<HtmlClass>(obj.Attributes[0]);
            Assert.IsType<HtmlClass>(obj.Attributes[1]);
        }

        [Fact]
        public void AddClasses_AsListOfObjects()
        {
            // Arrange
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var obj = new HtmlTag(type, content, false);
            var attList = new[] { htmlClass1, htmlClass2 };

            // Act
            var result = obj.AddClasses(attList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlClass1, obj.Attributes);
            Assert.Contains(htmlClass2, obj.Attributes);
            Assert.IsType<HtmlClass>(obj.Attributes[0]);
            Assert.IsType<HtmlClass>(obj.Attributes[1]);
        }

        [Fact]
        public void AddClasses_AsListOfStrings()
        {
            // Arrange
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var obj = new HtmlTag(type, content, false);
            var strList = new string[] { classValue1, classValue2 };

            // Act
            var result = obj.AddClasses(strList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlClass1, obj.Attributes);
            Assert.Contains(htmlClass2, obj.Attributes);
            Assert.IsType<HtmlClass>(obj.Attributes[0]);
            Assert.IsType<HtmlClass>(obj.Attributes[1]);
        }

        [Fact]
        public void RemoveAllClasses_OnlyRemoveClasses()
        {
            // Arrange
            var htmlAtt = new HtmlAttribute(attName1, attValue1);
            var htmlStyle = new HtmlStyle(styleName1, styleValue1);
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var htmlId = new HtmlId(idValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddAttribute(htmlAtt);
            obj.AddStyle(htmlStyle);
            obj.AddClass(htmlClass1);
            obj.AddClass(htmlClass2);
            obj.AddId(htmlId);

            // Act
            var result = obj.RemoveAllClasses();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(3, obj.Attributes.Count);
            Assert.Contains(htmlAtt, obj.Attributes);
            Assert.Contains(htmlStyle, obj.Attributes);
            Assert.Contains(htmlId, obj.Attributes);
            Assert.DoesNotContain(htmlClass1, obj.Attributes);
            Assert.DoesNotContain(htmlClass2, obj.Attributes);
        }

        [Fact]
        public void RemoveAllClasses_EmptyListToNull()
        {
            // Arrange
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var obj = new HtmlTag(type, content, false);
            obj.AddClass(htmlClass1);
            obj.AddClass(htmlClass2);

            // Act
            var result = obj.RemoveAllClasses();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Attributes);
        }

        [Fact]
        public void RemoveClass_OnlyRemoveSpecificClass()
        {
            // Arrange
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var htmlId = new HtmlId(classValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddClass(htmlClass1);
            obj.AddClass(htmlClass2);
            obj.AddClass(htmlClass1);

            // Act
            var result = obj.RemoveClass(classValue1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Attributes);
            Assert.Contains(htmlClass2, obj.Attributes);
            Assert.DoesNotContain(htmlClass1, obj.Attributes);
        }

        [Fact]
        public void RemoveClass_EmptyListToNull()
        {
            // Arrange
            var htmlClass = new HtmlClass(classValue2);
            var htmlId = new HtmlId(classValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddClass(htmlClass);

            // Act
            var result = obj.RemoveClass(classValue2);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Attributes);
        }

        [Fact]
        public void RemoveClass_ClassAndIdWithSameName_OnlyRemoveClass()
        {
            // Arrange
            var htmlClass = new HtmlClass(classValue1);
            var htmlId = new HtmlId(classValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddClass(htmlClass);
            obj.AddId(htmlId);

            // Act
            var result = obj.RemoveClass(classValue1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Attributes);
            Assert.Contains(htmlId, obj.Attributes);
            Assert.DoesNotContain(htmlClass, obj.Attributes);
        }

        [Fact]
        public void AddStyle_AsObject()
        {
            // Arrange
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result1 = obj.AddStyle(htmlStyle1);
            var result2 = obj.AddStyle(htmlStyle2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlStyle1, obj.Attributes);
            Assert.Contains(htmlStyle2, obj.Attributes);
            Assert.IsType<HtmlStyle>(obj.Attributes[0]);
            Assert.IsType<HtmlStyle>(obj.Attributes[1]);
        }

        [Fact]
        public void AddStyle_AsString()
        {
            // Arrange
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result1 = obj.AddStyle(styleName1, styleValue1);
            var result2 = obj.AddStyle(styleName2, styleValue2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlStyle1, obj.Attributes);
            Assert.Contains(htmlStyle2, obj.Attributes);
            Assert.IsType<HtmlStyle>(obj.Attributes[0]);
            Assert.IsType<HtmlStyle>(obj.Attributes[1]);
        }

        [Fact]
        public void AddStyles_AsListOfObjects()
        {
            // Arrange
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var obj = new HtmlTag(type, content, false);
            var attList = new[] { htmlStyle1, htmlStyle2 };

            // Act
            var result = obj.AddStyles(attList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlStyle1, obj.Attributes);
            Assert.Contains(htmlStyle2, obj.Attributes);
            Assert.IsType<HtmlStyle>(obj.Attributes[0]);
            Assert.IsType<HtmlStyle>(obj.Attributes[1]);
        }

        [Fact]
        public void AddStyles_AsListOfLists()
        {
            // Arrange
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var obj = new HtmlTag(type, content, false);
            var strList = new string[][] {
                new string[] { styleName1, styleValue1 },
                new string[] { styleName2, styleValue2 }

            };

            // Act
            var result = obj.AddStyles(strList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlStyle1, obj.Attributes);
            Assert.Contains(htmlStyle2, obj.Attributes);
            Assert.IsType<HtmlStyle>(obj.Attributes[0]);
            Assert.IsType<HtmlStyle>(obj.Attributes[1]);
        }

        [Fact]
        public void AddStyles_AsListOfStrings()
        {
            // Arrange
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var obj = new HtmlTag(type, content, false);
            var strList2 = new string[] {
                styleName1, styleValue1, styleName2, styleValue2
            };

            // Act
            var result = obj.AddStyles(strList2);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlStyle1, obj.Attributes);
            Assert.Contains(htmlStyle2, obj.Attributes);
            Assert.IsType<HtmlStyle>(obj.Attributes[0]);
            Assert.IsType<HtmlStyle>(obj.Attributes[1]);
        }

        [Fact]
        public void RemoveAllStyles_OnlyRemoveStyles()
        {
            // Arrange
            var htmlAtt = new HtmlAttribute(attName1, attValue1);
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var htmlClass = new HtmlClass(classValue1);
            var htmlId = new HtmlId(idValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddAttribute(htmlAtt);
            obj.AddStyle(htmlStyle1);
            obj.AddStyle(htmlStyle2);
            obj.AddClass(htmlClass);
            obj.AddId(htmlId);

            // Act
            var result = obj.RemoveAllStyles();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(3, obj.Attributes.Count);
            Assert.Contains(htmlAtt, obj.Attributes);
            Assert.Contains(htmlClass, obj.Attributes);
            Assert.Contains(htmlId, obj.Attributes);
            Assert.DoesNotContain(htmlStyle1, obj.Attributes);
            Assert.DoesNotContain(htmlStyle2, obj.Attributes);
        }

        [Fact]
        public void RemoveAllStyles_EmptyListToNull()
        {
            // Arrange
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var obj = new HtmlTag(type, content, false);
            obj.AddStyle(htmlStyle1);
            obj.AddStyle(htmlStyle2);

            // Act
            var result = obj.RemoveAllStyles();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Attributes);
        }

        [Fact]
        public void RemoveStyle_OnlyRemoveSpecificStyle()
        {
            // Arrange
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var obj = new HtmlTag(type, content, false);
            obj.AddStyle(htmlStyle1);
            obj.AddStyle(htmlStyle2);

            // Act
            var result = obj.RemoveStyle(styleName2);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Attributes);
            Assert.Contains(htmlStyle1, obj.Attributes);
            Assert.DoesNotContain(htmlStyle2, obj.Attributes);
        }

        [Fact]
        public void RemoveStyle_EmptyListToNull()
        {
            // Arrange
            var htmlStyle = new HtmlStyle(styleName1, styleValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddStyle(htmlStyle);

            // Act
            var result = obj.RemoveStyle(styleName1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Attributes);
        }

        [Fact]
        public void AddId_AsObject()
        {
            // Arrange
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result1 = obj.AddId(htmlId1);
            var result2 = obj.AddId(htmlId2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlId1, obj.Attributes);
            Assert.Contains(htmlId2, obj.Attributes);
            Assert.IsType<HtmlId>(obj.Attributes[0]);
            Assert.IsType<HtmlId>(obj.Attributes[1]);
        }

        [Fact]
        public void AddId_AsString()
        {
            // Arrange
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var obj = new HtmlTag(type, content, false);

            // Act
            var result1 = obj.AddId(idValue1);
            var result2 = obj.AddId(idValue2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlId1, obj.Attributes);
            Assert.Contains(htmlId2, obj.Attributes);
            Assert.IsType<HtmlId>(obj.Attributes[0]);
            Assert.IsType<HtmlId>(obj.Attributes[1]);
        }

        [Fact]
        public void AddIds_AsListOfObjects()
        {
            // Arrange
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var obj = new HtmlTag(type, content, false);
            var attList = new[] { htmlId1, htmlId2 };

            // Act
            var result = obj.AddIds(attList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlId1, obj.Attributes);
            Assert.Contains(htmlId2, obj.Attributes);
            Assert.IsType<HtmlId>(obj.Attributes[0]);
            Assert.IsType<HtmlId>(obj.Attributes[1]);
        }

        [Fact]
        public void AddIds_AsListOfStrings()
        {
            // Arrange
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var obj = new HtmlTag(type, content, false);
            var strList = new string[] { idValue1, idValue2 };

            // Act
            var result = obj.AddIds(strList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Attributes.Count);
            Assert.Contains(htmlId1, obj.Attributes);
            Assert.Contains(htmlId2, obj.Attributes);
            Assert.IsType<HtmlId>(obj.Attributes[0]);
            Assert.IsType<HtmlId>(obj.Attributes[1]);
        }

        [Fact]
        public void RemoveAllIds_OnlyRemoveIds()
        {
            // Arrange
            var htmlAtt = new HtmlAttribute(attName1, attValue1);
            var htmlStyle = new HtmlStyle(styleName1, styleValue1);
            var htmlClass = new HtmlClass(classValue1);
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var obj = new HtmlTag(type, content, false);
            obj.AddAttribute(htmlAtt);
            obj.AddStyle(htmlStyle);
            obj.AddClass(htmlClass);
            obj.AddId(htmlId1);
            obj.AddId(htmlId2);

            // Act
            var result = obj.RemoveAllIds();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(3, obj.Attributes.Count);
            Assert.Contains(htmlAtt, obj.Attributes);
            Assert.Contains(htmlStyle, obj.Attributes);
            Assert.Contains(htmlClass, obj.Attributes);
            Assert.DoesNotContain(htmlId1, obj.Attributes);
            Assert.DoesNotContain(htmlId2, obj.Attributes);
        }

        [Fact]
        public void RemoveAllIds_EmptyListToNull()
        {
            // Arrange
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var obj = new HtmlTag(type, content, false);
            obj.AddId(htmlId1);
            obj.AddId(htmlId2);

            // Act
            var result = obj.RemoveAllIds();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Attributes);
        }

        [Fact]
        public void RemoveId_RemoveSpecificId()
        {
            // Arrange
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var htmlClass = new HtmlClass(idValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddId(htmlId1);
            obj.AddId(htmlId2);
            obj.AddId(htmlId1);

            // Act
            var result = obj.RemoveId(idValue1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Attributes);
            Assert.Contains(htmlId2, obj.Attributes);
            Assert.DoesNotContain(htmlId1, obj.Attributes);
        }

        [Fact]
        public void RemoveId_EmptyListToNull()
        {
            // Arrange
            var htmlId = new HtmlId(idValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddId(htmlId);

            // Act
            var result = obj.RemoveId(idValue1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Attributes);
        }

        [Fact]
        public void RemoveId_ClassAndIdWithSameName_OnlyRemoveId()
        {
            // Arrange
            var htmlId = new HtmlId(idValue1);
            var htmlClass = new HtmlClass(idValue1);
            var obj = new HtmlTag(type, content, false);
            obj.AddId(htmlId);
            obj.AddClass(htmlClass);

            // Act
            var result = obj.RemoveId(idValue1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Attributes);
            Assert.Contains(htmlClass, obj.Attributes);
            Assert.DoesNotContain(htmlId, obj.Attributes);
        }

        [Fact]
        public void AddChild_AppendChildrenList()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName3, tagValue3);
            var obj = new HtmlTag(type);

            // Act
            var result1 = obj.AddChild(htmlTag1);
            var result2 = obj.AddChild(htmlTag2);

            // Assert
            Assert.IsType<HtmlTag>(result1);
            Assert.IsType<HtmlTag>(result2);
            Assert.Equal(2, obj.Children.Count);
            Assert.Contains(htmlTag1, obj.Children);
            Assert.Contains(htmlTag2, obj.Children);
            Assert.IsType<HtmlTag>(obj.Children[0]);
            Assert.IsType<HtmlTag>(obj.Children[1]);
        }

        [Fact]
        public void AddChildren_AppendChildrenList()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName3, tagValue3);
            var obj = new HtmlTag(type);
            var chList = new[] { htmlTag1, htmlTag2 };

            // Act
            var result = obj.AddChildren(chList);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Children.Count);
            Assert.Contains(htmlTag1, obj.Children);
            Assert.Contains(htmlTag2, obj.Children);
            Assert.IsType<HtmlTag>(obj.Children[0]);
            Assert.IsType<HtmlTag>(obj.Children[1]);
        }

        [Fact]
        public void RemoveAllChildren_EmptyListToNull()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var htmlTag3 = new HtmlTag(tagName3, tagValue3);
            var obj = new HtmlTag(type);
            var chList = new[] { htmlTag1, htmlTag2, htmlTag3 };
            obj.AddChildren(chList);

            // Act
            var result = obj.RemoveAllChildren();

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Children);
        }

        [Fact]
        public void RemoveChildren_OnlyRemoveChildrenWithSpecificTag()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var htmlTag3 = new HtmlTag(tagName3, tagValue3);
            var obj = new HtmlTag(type);
            var chList = new[] { htmlTag1, htmlTag2, htmlTag3 };
            obj.AddChildren(chList);

            // Act
            var result = obj.RemoveChildren(tagName1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Children);
            Assert.Contains(htmlTag3, obj.Children);
            Assert.DoesNotContain(htmlTag1, obj.Children);
            Assert.DoesNotContain(htmlTag2, obj.Children);
        }

        [Fact]
        public void RemoveChildren_EmptyListToNull()
        {
            // Arrange
            var htmlTag = new HtmlTag(tagName3, tagValue3);
            var obj = new HtmlTag(type);
            var chList = new[] { htmlTag };
            obj.AddChildren(chList);

            // Act
            var result = obj.RemoveChildren(tagName3);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Children);
        }

        [Fact]
        public void RemoveChild_OnlyRemoveSpecificChild()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var htmlTag3 = new HtmlTag(tagName3, tagValue3);
            var obj = new HtmlTag(type);
            var chList = new[] { htmlTag1, htmlTag2, htmlTag3 };
            obj.AddChildren(chList);

            // Act
            var result = obj.RemoveChild(tagName1, 1);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Equal(2, obj.Children.Count);
            Assert.Contains(htmlTag1, obj.Children);
            Assert.Contains(htmlTag3, obj.Children);
            Assert.DoesNotContain(htmlTag2, obj.Children);
        }

        [Fact]
        public void RemoveChild_EmptyListToNull()
        {
            // Arrange
            var htmlTag = new HtmlTag(tagName3, tagValue3);
            var obj = new HtmlTag(type);
            var chList = new[] { htmlTag };
            obj.AddChildren(chList);

            // Act
            var result = obj.RemoveChild(tagName3, 0);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Children);
        }

        [Fact]
        public void AddText_EncodeString()
        {
            // Arrange
            var obj = new HtmlTag(type);

            // Act
            var result = obj.AddText(content);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Children);
            Assert.IsType<HtmlText>(obj.Children[0]);
            Assert.Equal(contentEncoded, ((HtmlText)obj.Children[0]).Content);
        }

        [Fact]
        public void AddText_RawString()
        {
            // Arrange
            var obj = new HtmlTag(type);

            // Act
            var result = obj.AddText(content, false);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Children);
            Assert.IsType<HtmlText>(obj.Children[0]);
            Assert.Equal(content, ((HtmlText)obj.Children[0]).Content);
        }

        [Fact]
        public void RemoveText_OnlyRemoveSpecificText()
        {
            // Arrange
            var obj = new HtmlTag(type);
            obj.AddText(content, false);
            obj.AddText(contentEncoded, false);

            // Act
            var result = obj.RemoveText(0);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Single(obj.Children);
            Assert.Equal(contentEncoded, ((HtmlText)obj.Children[0]).Content);
        }

        [Fact]
        public void RemoveText_EmptyListToNull()
        {
            // Arrange
            var obj = new HtmlTag(type);
            obj.AddText(content, false);

            // Act
            var result = obj.RemoveText(0);

            // Assert
            Assert.IsType<HtmlTag>(result);
            Assert.Null(obj.Children);
        }

        [Fact]
        public void ToString_DefaultIndentation()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var htmlTag3 = new HtmlTag(tagName3, tagValue3);
            var resExp = $"<{type}>\n\t<{tagName1}>\n\t\t{tagValue1}\n\t</{tagName1}>\n\t<{tagName2}>\n\t\t{tagValue2}\n\t</{tagName2}>\n</{type}>\n";
            var obj = HtmlTag.Create(type);
            obj.AddChild(htmlTag1);
            obj.AddChild(htmlTag2);

            // Act
            var result = obj.ToString();

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal(resExp, result);
        }

        [Fact]
        public void ToString_CustomIndentation()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var htmlTag3 = new HtmlTag(tagName3, tagValue3);
            var resExp = $"<{type}>\n\t<{tagName3}>\n\t\t{tagValue3}\n\t\t<{tagName1}>\n\t\t\t{tagValue1}\n\t\t</{tagName1}>\n\t</{tagName3}>\n</{type}>\n";
            var obj = HtmlTag.Create(type);
            htmlTag3.AddChild(htmlTag1);
            obj.AddChild(htmlTag3);

            // Act
            var result = obj.ToString();

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal(resExp, result);
        }

        [Fact]
        public void ToString_TagAttributes()
        {
            // Arrange
            var htmlAtt1 = new HtmlAttribute(attName1, attValue1);
            var htmlAtt2 = new HtmlAttribute(attName2, attValue2);
            var htmlStyle1 = new HtmlStyle(styleName1, styleValue1);
            var htmlStyle2 = new HtmlStyle(styleName2, styleValue2);
            var htmlClass1 = new HtmlClass(classValue1);
            var htmlClass2 = new HtmlClass(classValue2);
            var htmlId1 = new HtmlId(idValue1);
            var htmlId2 = new HtmlId(idValue2);
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var htmlTag3 = new HtmlTag(tagName3, tagValue3);
            var resExp = $"<{type} {attName1}=\"{attValue1}\" {attName2}=\"{attValue2}\" class=\"{classValue2} {classValue1}\" id=\"{idValue2} {idValue1}\" " +
                     $"style=\"{styleName2}: {styleValue2}; {styleName1}: {styleValue1};\" />\n";
            var obj = HtmlTag.Create(type);
            obj.AddClass(htmlClass1);
            obj.AddClass(htmlClass2);
            obj.AddClass(htmlClass2);
            obj.AddAttribute(htmlAtt1);
            obj.AddAttribute(htmlAtt2);
            obj.AddAttribute(htmlAtt2);
            obj.AddId(htmlId1);
            obj.AddId(htmlId2);
            obj.AddStyle(htmlStyle1);
            obj.AddStyle(htmlStyle2);
            obj.AddStyle(htmlStyle2);

            // Act
            var result = obj.ToString();

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal(resExp, result);
        }

        [Fact]
        public void Equals_SimpleTag_IsEqual()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var copy = HtmlTag.Create(tagName1, content);

            // Act
            var result = orig.Equals(copy);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_SimpleTag_IsNotEqual()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var other = HtmlTag.Create(tagName1, content, false);

            // Act
            var result = orig.Equals(other);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_SimpleTag_OtherObject()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var str = "not same";

            // Act
            var result = orig.Equals(str);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_SimpleTag_Null()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);

            // Act
            var result = orig.Equals(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_IncludingChildren_IsEqual()
        {
            // Arrange
            var htmlTag1 = HtmlTag.Create(tagName1);
            var orig = HtmlTag.Create(tagName1, content);
            var copy = HtmlTag.Create(tagName1, content);
            orig.AddChild(htmlTag1);
            copy.AddChild(htmlTag1);

            // Act
            var result = orig.Equals(copy);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_IncludingChildren_IsNotEqual_SingleChild()
        {
            // Arrange
            var htmlTag1 = HtmlTag.Create(tagName1);
            var htmlTag2 = HtmlTag.Create(tagName3);
            var orig = HtmlTag.Create(tagName1, content);
            var other = HtmlTag.Create(tagName1, content);
            orig.AddChild(htmlTag1);
            other.AddChild(htmlTag2);

            // Act
            var result = orig.Equals(other);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_IncludingChildren_IsNotEqual_MultipleChildren()
        {
            // Arrange
            var htmlTag1 = HtmlTag.Create(tagName1);
            var htmlTag2 = HtmlTag.Create(tagName3);
            var orig = HtmlTag.Create(tagName1, content);
            var ext = HtmlTag.Create(tagName1, content);
            orig.AddChild(htmlTag1);
            ext.AddChild(htmlTag1);
            ext.AddChild(htmlTag2);

            // Act
            var result = orig.Equals(ext);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_IncludingChildren_Null()
        {
            // Arrange
            var htmlTag1 = HtmlTag.Create(tagName1);
            var orig = HtmlTag.Create(tagName1, content);
            orig.AddChild(htmlTag1);

            // Act
            var result = orig.Equals(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_IncludingAttributes_IsEqual()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var copy = HtmlTag.Create(tagName1, content);
            var htmlClass1 = HtmlClass.Create(classValue1);
            orig = HtmlTag.Create(tagName1, content);
            copy = HtmlTag.Create(tagName1, content);
            orig.AddClass(htmlClass1);
            copy.AddClass(htmlClass1);

            // Act
            var result = orig.Equals(copy);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_IncludingAttributes_IsNotEqual_SingleChild()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var other = HtmlTag.Create(tagName1, content);
            var htmlClass1 = HtmlClass.Create(classValue1);
            var htmlClass2 = HtmlClass.Create(classValue2);
            orig = HtmlTag.Create(tagName1, content);
            other = HtmlTag.Create(tagName1, content);
            orig.AddClass(htmlClass1);
            other.AddClass(htmlClass2);

            // Act
            var result = orig.Equals(other);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_IncludingAttributes_IsNotEqual_MultipleChildren()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var ext = HtmlTag.Create(tagName1, content);
            var htmlClass1 = HtmlClass.Create(classValue1);
            var htmlClass2 = HtmlClass.Create(classValue2);
            orig = HtmlTag.Create(tagName1, content);
            ext = HtmlTag.Create(tagName1, content);
            orig.AddClass(htmlClass1);
            ext.AddClass(htmlClass1);
            ext.AddClass(htmlClass2);

            // Act
            var result = orig.Equals(ext);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_IncludingAttributes_Null()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var htmlClass1 = HtmlClass.Create(classValue1);
            orig = HtmlTag.Create(tagName1, content);
            orig.AddClass(htmlClass1);

            // Act
            var result = orig.Equals(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetHashCode_SimpleTag_IsEqual()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var copy = HtmlTag.Create(tagName1, content);

            // Assert
            Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
        }

        [Fact]
        public void GetHashCode_SimpleTag_IsNotEqual()
        {
            // Arrange
            var orig = HtmlTag.Create(tagName1, content);
            var other = HtmlTag.Create(tagName1, content, false);
            
            // Assert
            Assert.NotEqual(orig.GetHashCode(), other.GetHashCode());
        }

        [Fact]
        public void GetHashCode_IncludingChildren_IsEqual()
        {
            // Arrange
            var htmlTag1 = HtmlTag.Create(tagName1);
            var orig = HtmlTag.Create(tagName1, content);
            var copy = HtmlTag.Create(tagName1, content);
            orig.AddChild(htmlTag1);
            copy.AddChild(htmlTag1);

            Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
        }

        [Fact]
        public void GetHashCode_IncludingChildren_IsNotEqual()
        {
            // Arrange
            var htmlTag1 = HtmlTag.Create(tagName1);
            var htmlTag2 = HtmlTag.Create(tagName3);
            var orig = HtmlTag.Create(tagName1, content);
            var other = HtmlTag.Create(tagName1, content);
            orig.AddChild(htmlTag1);
            other.AddChild(htmlTag2);
            
            // Assert
            Assert.NotEqual(orig.GetHashCode(), other.GetHashCode());
        }

        [Fact]
        public void GetHashCode_IncludingAttributes_IsEqual()
        {
            // Arrange
            var htmlClass1 = HtmlClass.Create(classValue1);
            var orig = HtmlTag.Create(tagName1, content);
            var copy = HtmlTag.Create(tagName1, content);
            orig.AddClass(htmlClass1);
            copy.AddClass(htmlClass1);

            // Assert
            Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
        }

        [Fact]
        public void GetHashCode_IncludingAttributes_IsNotEqual()
        {
            // Arrange
            var htmlClass1 = HtmlClass.Create(classValue1);
            var htmlClass2 = HtmlClass.Create(classValue2);
            var orig = HtmlTag.Create(tagName1, content);
            var other = HtmlTag.Create(tagName1, content);
            orig.AddClass(htmlClass1);
            other.AddClass(htmlClass2);

            // Assert
            Assert.NotEqual(orig.GetHashCode(), other.GetHashCode());
        }

        [Fact]
        public void Create_EmptyTag()
        {
            // Act
            var result = HtmlTag.Create(type);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Null(result.Children);
            Assert.Null(result.Attributes);
        }

        [Fact]
        public void Create_OnlyContent_Encoded()
        {
            // Act
            var result = HtmlTag.Create(type, content);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Null(result.Attributes);
            Assert.Single(result.Children);
            Assert.IsType<HtmlText>(result.Children[0]);
            Assert.Equal(contentEncoded, ((HtmlText)result.Children[0]).Content);
        }

        [Fact]
        public void Create_OnlyContent_Raw()
        {
            // Act
            var result = HtmlTag.Create(type, content, false);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Null(result.Attributes);
            Assert.Single(result.Children);
            Assert.IsType<HtmlText>(result.Children[0]);
            Assert.Equal(content, ((HtmlText)result.Children[0]).Content);
        }

        [Fact]
        public void Create_ContentAndChild_Encoded()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var contentElementEnc = new HtmlText(content);

            // Act
            var result = HtmlTag.Create(type, content, htmlTag1);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Equal(2, result.Children.Count);
            Assert.Contains(contentElementEnc, result.Children);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Equal(contentElementEnc, result.Children[0]);
            Assert.Null(result.Attributes);
        }

        [Fact]
        public void Create_ContentAndChild_Raw()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var contentElementRaw = new HtmlText(content, false);

            // Act
            var result = HtmlTag.Create(type, content, htmlTag1, false);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Equal(2, result.Children.Count);
            Assert.Contains(contentElementRaw, result.Children);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Equal(contentElementRaw, result.Children[0]);
            Assert.Null(result.Attributes);
        }

        [Fact]
        public void Create_ContentAndListOfChildren_Encoded()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var tagList = new List<HtmlElement>() { htmlTag1, htmlTag2 };
            var contentElementEnc = new HtmlText(content);

            // Act
            var result = HtmlTag.Create(type, content, tagList);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Equal(3, result.Children.Count);
            Assert.Contains(contentElementEnc, result.Children);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Contains(htmlTag2, result.Children);
            Assert.Equal(contentElementEnc, result.Children[0]);
            Assert.Null(result.Attributes);
        }

        [Fact]
        public void Create_ContentAndListOfChildren_Raw()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var tagList = new List<HtmlElement>() { htmlTag1, htmlTag2 };
            var contentElementRaw = new HtmlText(content, false);

            // Act
            var result = HtmlTag.Create(type, content, tagList, false);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Equal(3, result.Children.Count);
            Assert.Contains(contentElementRaw, result.Children);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Contains(htmlTag2, result.Children);
            Assert.Equal(contentElementRaw, result.Children[0]);
            Assert.Null(result.Attributes);
        }

        [Fact]
        public void Create_ContentAndArrayOfChildren_Encoded()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var tagArray = new[] { htmlTag1, htmlTag2 };
            var contentElementEnc = new HtmlText(content);

            // Act
            var result = HtmlTag.Create(type, content, tagArray);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Equal(3, result.Children.Count);
            Assert.Contains(contentElementEnc, result.Children);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Contains(htmlTag2, result.Children);
            Assert.Equal(contentElementEnc, result.Children[0]);
            Assert.Null(result.Attributes);
        }

        [Fact]
        public void Create_ContentAndArrayOfChildren_Raw()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var tagArray = new[] { htmlTag1, htmlTag2 };
            var contentElementRaw = new HtmlText(content, false);

            // Act
            var result = HtmlTag.Create(type, content, tagArray, false);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Equal(3, result.Children.Count);
            Assert.Contains(contentElementRaw, result.Children);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Contains(htmlTag2, result.Children);
            Assert.Equal(contentElementRaw, result.Children[0]);
            Assert.Null(result.Attributes);
        }

        [Fact]
        public void Create_NoContentAndChild()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);

            // Act
            var result = HtmlTag.Create(type, htmlTag1);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Null(result.Attributes);
            Assert.Single(result.Children);
        }

        [Fact]
        public void Create_NoContentAndListOfChildren()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var tagList = new List<HtmlElement>() { htmlTag1, htmlTag2 };

            // Act
            var result = HtmlTag.Create(type, tagList);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Contains(htmlTag2, result.Children);
            Assert.Null(result.Attributes);
            Assert.Equal(2, result.Children.Count);
        }

        [Fact]
        public void Create_NoContentAndArrayOfChildren()
        {
            // Arrange
            var htmlTag1 = new HtmlTag(tagName1, tagValue1);
            var htmlTag2 = new HtmlTag(tagName2, tagValue2);
            var tagArray = new[] { htmlTag1, htmlTag2 };

            // Act
            var result = HtmlTag.Create(type, tagArray);

            // Assert
            Assert.Equal(type, result.Type);
            Assert.Contains(htmlTag1, result.Children);
            Assert.Contains(htmlTag2, result.Children);
            Assert.Null(result.Attributes);
            Assert.Equal(2, result.Children.Count);
        }
    }
}
