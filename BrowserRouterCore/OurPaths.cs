using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SteelUnderpants.BrowserRouter.Core
{
    class OurPaths
    {
        /// <summary>
        /// The folder in %APPDATA% this program uses to store files.
        /// </summary>
        public const string AppDataFolderName = "SteelUnderpants\\BrowserRouter\\1.0";

        /// <summary>
        /// The default file name for the url mapping file.
        /// </summary>
        public const string DefaultUrlMapFileName = "UrlMap.xml";

        /// <summary>
        /// The default file name for the browser definitions file.
        /// </summary>
        public const string DefaultBrowserDefinitionFileName = "BrowserDefinitions.xml";

        /// <summary>
        /// The full path to the browser definitions file.
        /// </summary>
        public static string BrowserDefinitionsPath
        {
            get
            {
                return GetPathToAppDataFile(DefaultBrowserDefinitionFileName);
            }
        }

        /// <summary>
        /// The full path to the url mapping file.
        /// </summary>
        public static string UrlMapPath
        {
            get
            {
                return GetPathToAppDataFile(DefaultUrlMapFileName);
            }
        }

        /// <summary>
        /// Retrieves the full path to a file located in this program's %APPDATA% folder.
        /// </summary>
        /// <param name="filename">the filename for the file in %APPDATA% folder.</param>
        /// <returns>the full path to the file</returns>
        public static string GetPathToAppDataFile(string filename)
        {
            return Path.Combine(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppDataFolderName), 
                filename);
        }
    }
}
