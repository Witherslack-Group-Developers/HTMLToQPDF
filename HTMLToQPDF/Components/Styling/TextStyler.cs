using HtmlAgilityPack;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace HTMLToQPDF.Components.Styling;

public class TextStyler
{

    public static Dictionary<string, StyleAction> Actions = new (StringComparer.OrdinalIgnoreCase)
    {
        {
            "background-color", StyleAction.Create("background-color", (prop, textSpanDescriptor, value) =>
            {
                var colour = ColourParser.GetColour(value);
                textSpanDescriptor.BackgroundColor(colour);
            })
        },
        {
            "color", StyleAction.Create("color", (prop, textSpanDescriptor, value) =>
            {
                var colour = ColourParser.GetColour(value);
                textSpanDescriptor.FontColor(colour);
            })
        },
    };

    public static TextSpanDescriptor Style(TextSpanDescriptor span, HtmlNode mainNode)
    {


        HtmlNode? current = mainNode;
        List<HtmlNode> hierarchy = new();

        while (current != null)
        {
            hierarchy.Add(current);
            current = current.ParentNode;
        }

        //traverse down the hierarchy to apply style in order
        hierarchy.Reverse();

        foreach (var node in hierarchy)
        {
            var style = node.Attributes.FirstOrDefault(d => d.Name.Equals("style", StringComparison.OrdinalIgnoreCase));

            if (style == null)
                continue;

            var items = (style.Value ?? "").Split(";");

            foreach (var cssStyle in items)
            {

                if (string.IsNullOrWhiteSpace(cssStyle))
                    continue;

                var keyValue = cssStyle.Split(":");

                if (keyValue.Length != 2)
                    continue;

                var key = (keyValue[0] ?? "").Trim();
                var value = (keyValue[1] ?? "").Trim();

                TextStyler.Style(node, span, key, value);
            }
        }

        return span;
    }

    public static TextSpanDescriptor Style(HtmlNode node, TextSpanDescriptor span, string key, string value)
    {

        if (Actions.TryGetValue(key, out var action))
        {
            action.Style(node, span, value);
        }

        return span;
    }

}