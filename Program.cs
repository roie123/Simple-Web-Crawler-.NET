using System.Reflection.Metadata;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;


namespace SimpleWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var web = new HtmlWeb();
            var links = new List<String>();
            var baseUri =
                "https://www.linkedin.com/feed/?nis=true&=";
            var doc = web.Load(baseUri);
            var productHtmlElement = doc.DocumentNode.SelectNodes("//a[@href]");
            foreach (var productHTMLElement in productHtmlElement)
            {
                // scraping the interesting data from the current HTML element 
                // var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("a").InnerText); 
                var name = productHTMLElement.GetAttributeValue("href", "No href attribute");
                Console.WriteLine(name);

                if (String.Equals(name, "No href attribute") || links.Contains(name))
                {
                    continue;
                }
                else
                {

                    if (name.StartsWith("mailto:",StringComparison.OrdinalIgnoreCase))
                    {
                        links.Add(baseUri+name);
                        
                    }
                    
                }
            }

            foreach (var VARIABLE in links)
            {
                Console.WriteLine(VARIABLE);
                
            }
            // scraping logic... 
        }
    }
}