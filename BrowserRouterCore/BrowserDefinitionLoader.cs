using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace SteelUnderpants.BrowserRouter.Core
{
    public class BrowserDefinitionLoader
    {
        public IEnumerable<BrowserDefinition> LoadBrowserDefinitions()
        {
            return LoadBrowserDefinitions(OurPaths.BrowserDefinitionsPath);
        }

        public IEnumerable<BrowserDefinition> LoadBrowserDefinitions(string filename)
        {
            XDocument browserDefinitions = XDocument.Load(filename);

            return (from browser in browserDefinitions.Descendants("Browser")
                   select new BrowserDefinition
                   {
                       InternalName = browser.Attribute("InternalName").Value,
                       DisplayName = browser.Attribute("DisplayName").Value,
                       IsDefault = Boolean.Parse(browser.Attribute("IsDefault").Value),
                       ExePath = browser.Element("ExePath").Value,
                       LaunchUrlArgFormat = browser.Element("LaunchUrlArgFormat").Value
                   }).Where((x) => true);
        }
    }
}
