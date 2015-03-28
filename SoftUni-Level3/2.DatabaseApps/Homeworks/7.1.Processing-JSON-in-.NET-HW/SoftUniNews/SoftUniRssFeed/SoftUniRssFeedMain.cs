namespace SoftUniRssFeed
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class SoftUniRssFeedMain
    {
        public static void Main()
        {
            Utility.CreateOutputFolder();
            // Problem 1
            //DownloadRssFeed(Utility.Url, Utility.XmlPath);

            // Problem 2.	Parse the XML from the feed to JSON
            var json = ParseXmlToJson(Utility.XmlPath);

            // Problem 3.	Using LINQ-to-JSON select all the question titles and print them to the console
            var newsTitles = GetTitles(json);

            // Problem 4.	Parse the JSON string to POCO
            var pocos = newsTitles.Select(item => JsonConvert.DeserializeObject<JsonToPoco>(item.ToString())).ToList();

            // Problem 5.	Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question’s page
            MakeHtml(pocos);

            Process.Start(Utility.HtmlPath);
        }

        // Problem 5
        public static void MakeHtml(List<JsonToPoco> pocos)
        {
            var result = new StringBuilder();
            result.Append("<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body>");
            foreach (var jsonToPoco in pocos)
            {
                result.Append(jsonToPoco);
            }

            result.Append("</body></html>");
            File.WriteAllText(Utility.HtmlPath, result.ToString());
        }

        // Problem 3
        private static IEnumerable<JToken> GetTitles(string json)
        {
            var jsonObj = JObject.Parse(json);
            var titles = jsonObj["rss"]["channel"]["item"].ToList();
            foreach (var title in titles.Select(n => n["title"]))
            {
                Console.WriteLine(title);
            }

            return titles;
        }

        // Problem 2
        private static string ParseXmlToJson(string xmlPath)
        {
            var doc = XDocument.Load(xmlPath);
            var jsonConverted = JsonConvert.SerializeXNode(doc, Formatting.Indented);
            return jsonConverted;
        }

        // Problem 1
        private static void DownloadRssFeed(string sourceLocation, string destination)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(sourceLocation, destination);
                Console.WriteLine("Feed downloaded");
            }
        }
    }
}