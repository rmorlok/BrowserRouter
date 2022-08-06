using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SteelUnderpants.BrowserRouter.Core
{
    [DebuggerDisplay("{UrlWildcardPattern} --> {Browser.DisplayName}")]
    public class UrlMap
    {
        public string UrlWildcardPattern
        {
            get;
            set;
        }

        public string BrowserInternalName
        {
            get;
            set;
        }

        public BrowserDefinition Browser
        {
            get;
            set;
        }

        public bool MatchesUrl(string url)
        {
            return new Wildcard(UrlWildcardPattern, RegexOptions.IgnoreCase).IsMatch(url);
        }
    }
}
