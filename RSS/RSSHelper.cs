using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Xml;
using System.Data;
using System.Xml.Linq;
using Terradue.ServiceModel.Syndication;

namespace SınavProjesi.RSS
{
    public class RSSHelper
    {
        public static List<Item> read()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


            //string url = "https://www.wired.com/feed/rss";
            //XmlReader reader = XmlReader.Create(url);
            //SyndicationFeed feed = SyndicationFeed.Load(reader);

            List<Item> listItems = new List<Item>();
            //reader.Close();
            //foreach (SyndicationItem item in feed.Items)
            //{
            //    //String subject = item.Title.Text;
            //    //String summary = item..Text;

            //}


            string RssFeedUrl = "https://www.wired.com/feed/rss";
            try
            {
                XDocument xDoc = new XDocument();

                xDoc = XDocument.Load(RssFeedUrl);

                var items = (from x in xDoc.Descendants("item").Take(5)
                             select new
                             {
                                 title = x.Element("title").Value,
                                 description = x.Element("description").Value
                             });
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        Item item = new Item()
                        {
                            Title = i.title,
                            Description = i.description
                        };

                        listItems.Add(item);

                    }
                }
            }
            catch (Exception)
            {

                listItems = null;
            }
            return listItems;

        }
    }
} 