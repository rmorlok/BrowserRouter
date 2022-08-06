using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace SteelUnderpants.BrowserRouter.Core
{
    public class UrlMapLoader
    {
        public IEnumerable<UrlMap> LoadUrlMaps()
        {
            return LoadUrlMaps(OurPaths.UrlMapPath);
        }

        public IEnumerable<UrlMap> LoadUrlMaps(string filename)
        {
            XDocument urlMaps = XDocument.Load(filename);

            return from map in urlMaps.Descendants("UrlMap")
                   select new UrlMap
                   {
                       BrowserInternalName = map.Attribute("InternalBrowserName").Value,
                       UrlWildcardPattern = map.Value
                   };
        }
    }
}
