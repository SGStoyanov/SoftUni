namespace SoftUniRssFeed
{
    using System.IO;

    public static class Utility
    {
        public const string XmlPath = @"..\..\output\news.xml";
        public const string HtmlPath = @"..\..\output\news.html";
        public const string OutputPath = @"..\..\output";
        public const string Url = "https://softuni.bg/Feed/News";

        public static void CreateOutputFolder()
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }
        }
    }
}