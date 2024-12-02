using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace HTMLToQPDF.Components.Styling;

public static class ColourParser
{

    public static Color GetColour(string value)
    {
        return GetColour(value, Colors.Black);
    }

    public static Color GetColour(string value, Color failToParseColour)
    {

        if (string.IsNullOrWhiteSpace(value))
            return failToParseColour;

        value = value.Trim();
        try
        {
            if (value.StartsWith("#"))
                return Color.FromHex(value);

            if (CssColours.TryGetValue(value, out var colour))
            {
                return colour;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Parsing colour threw and exception for '{value}'. Returning default value. {ex.Message}");
        }

        Console.WriteLine($"Failed to parse colour '{value}'. Returning default value");
        return failToParseColour;
    }


    private static readonly Dictionary<string, Color> CssColours = new(StringComparer.OrdinalIgnoreCase)
    {
        { "aliceblue", Color.FromHex("#F0F8FF") },
        { "antiquewhite", Color.FromHex("#FAEBD7") },
        { "aqua", Color.FromHex("#00FFFF") },
        { "aquamarine", Color.FromHex("#7FFFD4") },
        { "azure", Color.FromHex("#F0FFFF") },
        { "beige", Color.FromHex("#F5F5DC") },
        { "bisque", Color.FromHex("#FFE4C4") },
        { "black", Color.FromHex("#000000") },
        { "blanchedalmond", Color.FromHex("#FFEBCD") },
        { "blue", Color.FromHex("#0000FF") },
        { "blueviolet", Color.FromHex("#8A2BE2") },
        { "brown", Color.FromHex("#A52A2A") },
        { "burlywood", Color.FromHex("#DEB887") },
        { "cadetblue", Color.FromHex("#5F9EA0") },
        { "chartreuse", Color.FromHex("#7FFF00") },
        { "chocolate", Color.FromHex("#D2691E") },
        { "coral", Color.FromHex("#FF7F50") },
        { "cornflowerblue", Color.FromHex("#6495ED") },
        { "cornsilk", Color.FromHex("#FFF8DC") },
        { "crimson", Color.FromHex("#DC143C") },
        { "cyan", Color.FromHex("#00FFFF") },
        { "darkblue", Color.FromHex("#00008B") },
        { "darkcyan", Color.FromHex("#008B8B") },
        { "darkgoldenrod", Color.FromHex("#B8860B") },
        { "darkgray", Color.FromHex("#A9A9A9") },
        { "darkgreen", Color.FromHex("#006400") },
        { "darkkhaki", Color.FromHex("#BDB76B") },
        { "darkmagenta", Color.FromHex("#8B008B") },
        { "darkolivegreen", Color.FromHex("#556B2F") },
        { "darkorange", Color.FromHex("#FF8C00") },
        { "darkorchid", Color.FromHex("#9932CC") },
        { "darkred", Color.FromHex("#8B0000") },
        { "darksalmon", Color.FromHex("#E9967A") },
        { "darkseagreen", Color.FromHex("#8FBC8F") },
        { "darkslateblue", Color.FromHex("#483D8B") },
        { "darkslategray", Color.FromHex("#2F4F4F") },
        { "darkturquoise", Color.FromHex("#00CED1") },
        { "darkviolet", Color.FromHex("#9400D3") },
        { "deeppink", Color.FromHex("#FF1493") },
        { "deepskyblue", Color.FromHex("#00BFFF") },
        { "dimgray", Color.FromHex("#696969") },
        { "dodgerblue", Color.FromHex("#1E90FF") },
        { "firebrick", Color.FromHex("#B22222") },
        { "floralwhite", Color.FromHex("#FFFAF0") },
        { "forestgreen", Color.FromHex("#228B22") },
        { "fuchsia", Color.FromHex("#FF00FF") },
        { "gainsboro", Color.FromHex("#DCDCDC") },
        { "ghostwhite", Color.FromHex("#F8F8FF") },
        { "gold", Color.FromHex("#FFD700") },
        { "goldenrod", Color.FromHex("#DAA520") },
        { "gray", Color.FromHex("#808080") },
        { "green", Color.FromHex("#008000") },
        { "greenyellow", Color.FromHex("#ADFF2F") },
        { "honeydew", Color.FromHex("#F0FFF0") },
        { "hotpink", Color.FromHex("#FF69B4") },
        { "indianred", Color.FromHex("#CD5C5C") },
        { "indigo", Color.FromHex("#4B0082") },
        { "ivory", Color.FromHex("#FFFFF0") },
        { "khaki", Color.FromHex("#F0E68C") },
        { "lavender", Color.FromHex("#E6E6FA") },
        { "lavenderblush", Color.FromHex("#FFF0F5") },
        { "lawngreen", Color.FromHex("#7CFC00") },
        { "lemonchiffon", Color.FromHex("#FFFACD") },
        { "lightblue", Color.FromHex("#ADD8E6") },
        { "lightcoral", Color.FromHex("#F08080") },
        { "lightcyan", Color.FromHex("#E0FFFF") },
        { "lightgoldenrodyellow", Color.FromHex("#FAFAD2") },
        { "lightgray", Color.FromHex("#D3D3D3") },
        { "lightgreen", Color.FromHex("#90EE90") },
        { "lightpink", Color.FromHex("#FFB6C1") },
        { "lightsalmon", Color.FromHex("#FFA07A") },
        { "lightseagreen", Color.FromHex("#20B2AA") },
        { "lightskyblue", Color.FromHex("#87CEFA") },
        { "lightslategray", Color.FromHex("#778899") },
        { "lightsteelblue", Color.FromHex("#B0C4DE") },
        { "lightyellow", Color.FromHex("#FFFFE0") },
        { "lime", Color.FromHex("#00FF00") },
        { "limegreen", Color.FromHex("#32CD32") },
        { "linen", Color.FromHex("#FAF0E6") },
        { "magenta", Color.FromHex("#FF00FF") },
        { "maroon", Color.FromHex("#800000") },
        { "mediumaquamarine", Color.FromHex("#66CDAA") },
        { "mediumblue", Color.FromHex("#0000CD") },
        { "mediumorchid", Color.FromHex("#BA55D3") },
        { "mediumpurple", Color.FromHex("#9370DB") },
        { "mediumseagreen", Color.FromHex("#3CB371") },
        { "mediumslateblue", Color.FromHex("#7B68EE") },
        { "mediumspringgreen", Color.FromHex("#00FA9A") },
        { "mediumturquoise", Color.FromHex("#48D1CC") },
        { "mediumvioletred", Color.FromHex("#C71585") },
        { "midnightblue", Color.FromHex("#191970") },
        { "mintcream", Color.FromHex("#F5FFFA") },
        { "mistyrose", Color.FromHex("#FFE4E1") },
        { "moccasin", Color.FromHex("#FFE4B5") },
        { "navajowhite", Color.FromHex("#FFDEAD") },
        { "navy", Color.FromHex("#000080") },
        { "oldlace", Color.FromHex("#FDF5E6") },
        { "olive", Color.FromHex("#808000") },
        { "olivedrab", Color.FromHex("#6B8E23") },
        { "orange", Color.FromHex("#FFA500") },
        { "orangered", Color.FromHex("#FF4500") },
        { "orchid", Color.FromHex("#DA70D6") },
        { "palegoldenrod", Color.FromHex("#EEE8AA") },
        { "palegreen", Color.FromHex("#98FB98") },
        { "paleturquoise", Color.FromHex("#AFEEEE") },
        { "palevioletred", Color.FromHex("#DB7093") },
        { "papayawhip", Color.FromHex("#FFEFD5") },
        { "peachpuff", Color.FromHex("#FFDAB9") },
        { "peru", Color.FromHex("#CD853F") },
        { "pink", Color.FromHex("#FFC0CB") },
        { "plum", Color.FromHex("#DDA0DD") },
        { "powderblue", Color.FromHex("#B0E0E6") },
        { "purple", Color.FromHex("#800080") },
        { "red", Color.FromHex("#FF0000") },
        { "rosybrown", Color.FromHex("#BC8F8F") },
        { "royalblue", Color.FromHex("#4169E1") },
        { "saddlebrown", Color.FromHex("#8B4513") },
        { "salmon", Color.FromHex("#FA8072") },
        { "sandybrown", Color.FromHex("#F4A460") },
        { "seagreen", Color.FromHex("#2E8B57") },
        { "seashell", Color.FromHex("#FFF5EE") },
        { "sienna", Color.FromHex("#A0522D") },
        { "silver", Color.FromHex("#C0C0C0") },
        { "skyblue", Color.FromHex("#87CEEB") },
        { "slateblue", Color.FromHex("#6A5ACD") },
        { "slategray", Color.FromHex("#708090") },
        { "snow", Color.FromHex("#FFFAFA") },
        { "springgreen", Color.FromHex("#00FF7F") },
        { "steelblue", Color.FromHex("#4682B4") },
        { "tan", Color.FromHex("#D2B48C") },
        { "teal", Color.FromHex("#008080") },
        { "thistle", Color.FromHex("#D8BFD8") },
        { "tomato", Color.FromHex("#FF6347") },
        { "turquoise", Color.FromHex("#40E0D0") },
        { "violet", Color.FromHex("#EE82EE") },
        { "wheat", Color.FromHex("#F5DEB3") },
        { "white", Color.FromHex("#FFFFFF") },
        { "whitesmoke", Color.FromHex("#F5F5F5") },
        { "yellow", Color.FromHex("#FFFF00") },
        { "yellowgreen", Color.FromHex("#9ACD32") },
    };
}