using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace SteelUnderpants.BrowserRouter.Core
{
    public class RegistryManager
    {
        const string BrowserRouterUrl = "BrowserRouterURL";

        const string BrowserRouterStartMenuInternetName = "BrowserRouter.exe";

        private static bool IsVistaOrNewer()
        {
            return Environment.OSVersion.Version.Major >= 6;
        }

        public static void RegisterDefaultBrowserLaunchString(string exePath, string launchStringArgs)
        {
            string launchString = exePath + " " + launchStringArgs;

            /* Handled in installer - requires elevation
             * 
            // Register URL class
            Registry.ClassesRoot.CreateSubKey(@"BrowserRouterURL\shell\open\command");
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"BrowserRouterURL\shell\open\command", true))
            {
                key.SetValue(String.Empty, launchString);
            }

            Registry.ClassesRoot.CreateSubKey(@"BrowserRouterURL\DefaultIcon");
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"BrowserRouterURL\DefaultIcon", true))
            {
                key.SetValue(String.Empty, exePath+",0");
            }
            */

            // These settings are for Windows Vista/Windows 7
            if (IsVistaOrNewer())
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice", true))
                {
                    if (null != key)
                        key.SetValue("Progid", BrowserRouterUrl);
                }

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\https\UserChoice", true))
                {
                    if (null != key)
                        key.SetValue("Progid", BrowserRouterUrl);
                }
            }

            // These settings are for earlier versions of Windows (e.g. Windows XP)
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command", true))
            {
                key.SetValue(String.Empty, launchString);
            }

            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"https\shell\open\command", true))
            {
                key.SetValue(String.Empty, launchString);
            }

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Clients\StartMenuInternet", true))
            {
                if (null != key)
                    key.SetValue(String.Empty, BrowserRouterStartMenuInternetName);
            }
        }
    }
}
