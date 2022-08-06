using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteelUnderpants.BrowserRouter.Core
{
    public class RoutingConfiguration
    {
        private List<BrowserDefinition> _browserDefinitions;
        private List<UrlMap> _urlMaps;
        private BrowserDefinition _defultBrowser;

        public RoutingConfiguration()
            : this(new BrowserDefinitionLoader().LoadBrowserDefinitions(), new UrlMapLoader().LoadUrlMaps())
        {
        }

        public RoutingConfiguration(IEnumerable<BrowserDefinition> browserDefinitions, IEnumerable<UrlMap> urlMaps)
        {
            this._browserDefinitions = new List<BrowserDefinition>(browserDefinitions);
            this._urlMaps = new List<UrlMap>(urlMaps);

            Initialize();
        }

        protected void Initialize()
        {
            var browserNameMap = new Dictionary<string, BrowserDefinition>();

            foreach (var browserDef in this._browserDefinitions)
            {
                browserNameMap.Add(browserDef.InternalName, browserDef);

                if (browserDef.IsDefault)
                    this._defultBrowser = browserDef;
            }

            if (null == this._defultBrowser)
                this._defultBrowser = _browserDefinitions.First();

            foreach (var urlMap in this._urlMaps)
            {
                if (!String.IsNullOrEmpty(urlMap.BrowserInternalName)
                    && browserNameMap.ContainsKey(urlMap.BrowserInternalName))
                {
                    urlMap.Browser = browserNameMap[urlMap.BrowserInternalName];
                }
            }
        }

        public BrowserDefinition DefaultBrowser
        {
            get
            {
                return this._defultBrowser;
            }
        }

        public IEnumerable<BrowserDefinition> BrowserDefinitions
        {
            get
            {
                return this._browserDefinitions;
            }
        }

        public IEnumerable<UrlMap> UrlMaps
        {
            get
            {
                return _urlMaps;
            }
        }
    }
}
