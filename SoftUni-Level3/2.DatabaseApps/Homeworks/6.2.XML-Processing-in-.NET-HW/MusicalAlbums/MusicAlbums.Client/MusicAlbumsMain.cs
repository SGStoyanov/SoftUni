namespace MusicAlbums.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class MusicAlbumsMain
    {
        public static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../music.xml");
            
            if (doc.DocumentElement != null)
            {
                var rootNode = doc.DocumentElement.ChildNodes;
                // Problem 2.	DOM Parser: Extract Album Names
                //ExtractAlbumNames(rootNode);

                // Problem 3.	DOM Parser: Extract All Artists Alphabetically
                //ExtractArtistsNames(rootNode);

                // Problem 4.	DOM Parser: Extract Artists and Number of Albums
                //ExtractArtistsAndNumberOfAlbums(rootNode);

                // Problem 5.	XPath: Extract Artists and Number of Albums
                //ExtractArtistsAndNumberOfAlbumsByXPath(doc);
            }

            var alternativeDoc = new XmlDocument();
            alternativeDoc.Load("../../music-alternative.xml");

            // Problem 6.	DOM Parser: Delete Albums
            //DeleteAlbums(alternativeDoc); 

            // Problem 7.	DOM Parser and XPath: Old Albums
            //ExtractOldAlbums(alternativeDoc);

            // Problem 8.	LINQ to XML: Old Albums
            var xdoc = XDocument.Load("../../music-alternative.xml");
            //GetOldAlbumsbyLinq(xdoc);
        }

        // Problem 8.	LINQ to XML: Old Albums
        private static void GetOldAlbumsbyLinq(XDocument xdoc)
        {
            var oldAlbums = (from album in xdoc.Descendants("album")
                             where decimal.Parse(album.Element("year").Value) <= (DateTime.Now.Year - 5)
                             select new { Name = album.Element("name").Value, Price = album.Element("price").Value }).ToList();

            foreach (var oldAlbum in oldAlbums)
            {
                Console.WriteLine("Album: {0}, Price: {1}", oldAlbum.Name, oldAlbum.Price);
            }
        }

        // Problem 7.	DOM Parser and XPath: Old Albums
        private static void ExtractOldAlbums(XmlDocument alternativeDoc)
        {
            int year5YearsAgo = DateTime.Now.Year - 5;
            string albumsQuery = "/catalog/album[year <= " + year5YearsAgo + "]";

            XmlNodeList oldAlbumsList = alternativeDoc.SelectNodes(albumsQuery);

            if (oldAlbumsList != null)
            {
                foreach (XmlNode oldAlbum in oldAlbumsList)
                {
                    var oldAlbumName = oldAlbum["name"].InnerText;
                    var oldAlbumPrice = oldAlbum["price"].InnerText;
                    Console.WriteLine("Album: {0}, Price: {1}", oldAlbumName, oldAlbumPrice);
                }
            }
        }

        // Problem 6.	DOM Parser: Delete Albums
        private static void DeleteAlbums(XmlDocument alternativeDoc)
        {
            XmlDocument doc;
            if (alternativeDoc.DocumentElement != null)
            {
                XmlNode rootNode = alternativeDoc.DocumentElement;
                foreach (XmlNode albumNode in rootNode.ChildNodes)
                {
                    var price = albumNode["price"];
                    if (price != null && decimal.Parse(price.InnerText) < 20)
                    {
                        if (albumNode.ParentNode != null)
                        {
                            albumNode.ParentNode.RemoveChild(albumNode);
                        }
                    }
                }

                Console.WriteLine("Document has been modified.");
                alternativeDoc.Save("../../cheap-albums-catalog.xml");
                Console.WriteLine("Document has been saved as cheap-albums-catalog.xml.");
            }
        }

        // Problem 5.	XPath: Extract Artists and Number of Albums
        private static void ExtractArtistsAndNumberOfAlbumsByXPath(XmlDocument doc)
        {
            var artistsAlbums = new Dictionary<string, int>();
            var artists = doc.SelectNodes("/music/artist");
            if (artists != null)
            {
                foreach (XmlNode artist in artists)
                {
                    if (artist.Attributes != null)
                    {
                        string artistName = artist.Attributes["name"].Value;
                        artistsAlbums.Add(artistName, 0);

                        foreach (XmlNode album in artist.ChildNodes)
                        {
                            artistsAlbums[artistName] += 1;
                        }
                    }
                }
            }

            foreach (var artistsAlbum in artistsAlbums)
            {
                Console.WriteLine("Artist: {0}, Albums Count: {1}", artistsAlbum.Key, artistsAlbum.Value);
            }
        }

        // Problem 2.	DOM Parser: Extract Album Names
        private static void ExtractAlbumNames(XmlNodeList rootNode)
        {
            foreach (XmlNode artistNode in rootNode)
            {
                foreach (XmlNode albumNode in artistNode.ChildNodes)
                {
                    if (albumNode.Attributes != null)
                    {
                        XmlAttribute albumTitle = albumNode.Attributes["title"];
                        Console.WriteLine(albumTitle.Value ?? string.Empty);
                    }
                }
            }
        }

        // Problem 3.	DOM Parser: Extract All Artists Alphabetically
        private static void ExtractArtistsNames(XmlNodeList rootNode)
        {
            var sortedArtistsNames = new SortedSet<string>();
            foreach (XmlNode artistNode in rootNode)
            {
                if (artistNode.Attributes != null)
                {
                    XmlAttribute artistName = artistNode.Attributes["name"];
                    if (artistName != null)
                    {
                        //Console.WriteLine(artistName.Value);
                        sortedArtistsNames.Add(artistName.Value);
                    }
                }
            }

            foreach (var name in sortedArtistsNames)
            {
                Console.WriteLine(name);
            }
        }

        // Problem 4.	DOM Parser: Extract Artists and Number of Albums
        private static void ExtractArtistsAndNumberOfAlbums(XmlNodeList rootNode)
        {
            var artistsAlbums = new Dictionary<string, int>();
            foreach (XmlNode artistNode in rootNode)
            {
                if (artistNode.Attributes != null)
                {
                    string artistName = artistNode.Attributes["name"].Value;
                    artistsAlbums.Add(artistName, 0);
                    foreach (XmlNode albumNode in artistNode.ChildNodes)
                    {
                        artistsAlbums[artistName] += 1;
                    }
                }
            }

            foreach (var artistsAlbum in artistsAlbums)
            {
                Console.WriteLine("Artist: {0}, Albums Count: {1}", artistsAlbum.Key, artistsAlbum.Value);
            }
        }
    }
}