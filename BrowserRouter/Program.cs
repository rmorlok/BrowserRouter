using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

using SteelUnderpants.BrowserRouter.Core;

namespace SteelUnderpants.BrowserRouter.BrowserRouter
{
    public class Program
    {
        /// <summary>
        /// Flag indicating this program should route the opening of the specified URL.
        /// </summary>
        const string OpenUrlFlag = "-url";

        /// <summary>
        /// Flag indicating this program should register itself as the default browser for the system.
        /// </summary>
        const string RegisterSelfAsDefaultBrowserFlag = "-registerAsDefaultBrowser";

        /// <summary>
        /// Flag to print the help string.
        /// </summary>
        const string HelpFlag = "-help";

        static void Main(string[] args)
        {
            if (args.Length < 1)
                LaunchDefaultBrowser();
            else if (String.Compare(args[0], HelpFlag, true) == 0)
                PrintUsage();
            else if (String.Compare(args[0], OpenUrlFlag, true) == 0)
                OpenUrl(args[1]);
            else if (String.Compare(args[0], RegisterSelfAsDefaultBrowserFlag, true) == 0)
                RegisterSelfAsDefaultBrowser();
            else if (args[0].ToLower().Contains("http"))
                OpenUrl(args[0]);
        }

        static void PrintUsage()
        {
            Console.WriteLine("Usage: browserrouter");
            Console.WriteLine("         " + HelpFlag);
            Console.WriteLine("            Print this help message.");
            Console.WriteLine("");
            Console.WriteLine("         " + RegisterSelfAsDefaultBrowserFlag);
            Console.WriteLine("            Registers browserrouter as the default web browser with the Windows.");
            Console.WriteLine("");
            Console.WriteLine("         " + OpenUrlFlag + " <URL>");
            Console.WriteLine("            Opens the specified URL with web browser defined by the URL mappnig rules.");
        }

        static void RegisterSelfAsDefaultBrowser()
        {
            string myFileName = Path.Combine(Environment.CurrentDirectory, Process.GetCurrentProcess().ProcessName + ".exe");
            myFileName = String.Concat("\"", myFileName, "\"");

            RegistryManager.RegisterDefaultBrowserLaunchString(myFileName, OpenUrlFlag + " \"%1\"");
        }

        static void OpenUrl(string url)
        {
            BrowserDefinition toRun = (new UrlDispatcher(new RoutingConfiguration())).GetBrowserForUrl(url);

            if (null != toRun)
                Process.Start(toRun.ExePath, toRun.GetLaunchCommandArguments(url));
        }

        static void LaunchDefaultBrowser()
        {
            BrowserDefinition toRun = (new RoutingConfiguration()).DefaultBrowser;

            if (null != toRun)
                Process.Start(toRun.ExePath);
        }
    }
}
