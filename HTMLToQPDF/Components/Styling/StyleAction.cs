using HtmlAgilityPack;
using QuestPDF.Fluent;

namespace HTMLToQPDF.Components.Styling;

public class StyleAction
{
    public string CssProperty { get; private set; }
    
    public Action<HtmlNode, TextSpanDescriptor, string> Style { get; set; }

    public static StyleAction Create(string property, Action<HtmlNode, TextSpanDescriptor, string> descriptor)
    {
        var ret = new StyleAction()
        {
            CssProperty = property,
            Style = descriptor,
        };
       
   
        return ret;
    }
}