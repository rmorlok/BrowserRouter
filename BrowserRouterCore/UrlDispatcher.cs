using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteelUnderpants.BrowserRouter.Core
{
    /// <summary>
    /// Class to translate URLs into runnable system commands.  E.g. figure
    /// out which browser to use, and how to format a command to launch that browser
    /// with the specified URL.
    /// </summary>
    public class UrlDispatcher
    {
        private RoutingConfiguration _configuration;

        public UrlDispatcher(RoutingConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public BrowserDefinition GetBrowserForUrl(string url)
        {
            UrlMap matchingMap = GetMatchMap(url);

            BrowserDefinition usedBrowser;

            if (null == matchingMap || null == matchingMap.Browser )
                usedBrowser = this._configuration.DefaultBrowser;
            else
                usedBrowser = matchingMap.Browser;

            return usedBrowser;
        }

        public UrlMap GetMatchMap(string url)
        {
            foreach (UrlMap map in _configuration.UrlMaps)
            {
                if (map.MatchesUrl(url))
                    return map;
            }

            return null;
        }
    }
}
