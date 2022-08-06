using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SteelUnderpants.BrowserRouter.Core
{
    /// <summary>
    /// Object that represents stored information about a browser.
    /// </summary>
    [DebuggerDisplay("{DisplayName}")]
    public class BrowserDefinition
    {
        public string InternalName
        {
            get;
            set;
        }

        public string DisplayName
        {
            get;
            set;
        }

        public string ExePath
        {
            get;
            set;
        }

        public string LaunchUrlArgFormat
        {
            get;
            set;
        }

        public bool IsDefault
        {
            get;
            set;
        }

        public string GetLaunchCommandArguments(string url)
        {
            return String.Format(LaunchUrlArgFormat, url);
        }
    }
}
