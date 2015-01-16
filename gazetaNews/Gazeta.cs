﻿namespace gazetaNews
{
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Gazeta : IGazetaNews
    {
        public NewsData PobierzWiadomosc()
        {
            var lista = new List<News>();

                HtmlWeb web = new HtmlWeb
                {
                    AutoDetectEncoding = false,
                    OverrideEncoding = Encoding.GetEncoding("iso-8859-2")
                };

                HtmlDocument doc = new HtmlDocument();

                try
                {
                    doc = web.Load("http://www.gazeta.pl/0,0.html");
                }
                catch
                {
                    return new EmptyNews();
                }

                var nagłowek = doc.DocumentNode.SelectSingleNode("//h2[@class=\"mt_pict_title \"]/a/span[@class=\"title\"]");
                
                if (nagłowek != null)
                {
                    var obrazek = doc.DocumentNode.SelectSingleNode("//div[@class=\"mt_pict_layer\"]/a[@id=\"LinkArea:MT\"]/img");

                    if (obrazek != null)
                    {
                        var opis = doc.DocumentNode.SelectSingleNode("//div[@class=\"mt_txt_layer\"]/p/a[@id=\"LinkArea:MT\"]");

                        if (opis != null)
                        {
                            var wiadomosc = new News();

                            wiadomosc.link = nagłowek.GetAttributeValue("href", "brak");

                            wiadomosc.naglowek = nagłowek.InnerText;

                            wiadomosc.obrazek_link = obrazek.GetAttributeValue("src", "");

                            wiadomosc.czasZapisania = System.DateTime.Now;

                            wiadomosc.opis = opis.InnerHtml;

                            wiadomosc.hash = CheckSum.Create(wiadomosc.link);

                            return wiadomosc;
                        }
                    }
                }
                return new EmptyNews();
            
        }
    }
}
