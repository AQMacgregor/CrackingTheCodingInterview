using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class XMLEncoding : ISolution
    {
        public string Encode(string xml, Dictionary<string, string> attributes)
        {
            //string encoded = xml;
            //foreach (var attibute in attributes)
            //{
            //    encoded = encoded.Replace(attibute.Key, attibute.Value.ToString());
            //}
            //foreach (var attibute in attributes)
            //{
            //    encoded = encoded.Replace($"</{attibute.Value.ToString()}>", " 0");
            //}
            //encoded = encoded.Replace("=\"", " ");
            //encoded = encoded.Replace("\">", " 0 ");
            //encoded = encoded.Replace("\"", " ");
            //encoded = encoded.Replace("<", "");
            //encoded = encoded.Replace(">", " ");
            //while(encoded.Contains("  "))
            //{
            //    encoded = encoded.Replace("  ", " ");
            //}
            //return encoded;
            string encoded = xml;

            foreach(var attribute in attributes)
            {
                var tag = attribute.Key;
                var value = attribute.Value;
                encoded = encoded.Replace($"<{tag}", value);
                encoded = encoded.Replace($"</{tag}>", " 0");
                encoded = encoded.Replace($"{tag}=\"", $"{value} ");
            }
            encoded = encoded.Replace("\">", " 0 ");
            encoded = encoded.Replace("\"", "");

            return encoded;
        }
        public void Test()
        {
            string xml = "<family lastName=\"McDowell\" state=\"CA\"><person firstName=\"Gayle\">Some Message</person></family>";
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"family", "1" },
                {"person", "2" },
                {"firstName", "3" },
                {"lastName", "4" },
                {"state", "5" },
            };
            Assert.That(Encode(xml, attributes) == "1 4 McDowell 5 CA 0 2 3 Gayle 0 Some Message 0 0");
        }
    }
}
