using System;
using MonoMac.AppKit;
using System.Threading.Tasks;
using MonoMac.Foundation;

namespace CocoaExtensions
{
    public static class CocoaExtensions
    {
        public static bool IsRetina
        {
            get
            {
                return NSScreen.MainScreen.BackingScaleFactor == 2.0f;
            }
        }

        async public static Task<NSImage> DownloadImage(string url)
        {
            var webclient = new System.Net.WebClient();
            var imageBytes = await webclient.DownloadDataTaskAsync(new Uri(url));
            NSImage image = null;
            try 
            {
                image = new NSImage(NSData.FromArray(imageBytes));
                imageBytes = null;
            } 
            catch (Exception ) 
            {
                return null;
            }
            return image;
        }

        public static string AppVersion
        {
            get
            {
                return NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString(); 
            }
        }

        public static string OSVersion
        {
            get
            {
                var info = new NSProcessInfo();
                return info.OperatingSystemVersionString;
            }
        }

        public static string OSName
        {
            get
            {
                var info = new NSProcessInfo();
                return info.OperatingSystemName;
            }
        }

        public static bool IsInstalledToApplications
        {
            get
            {
                var path = NSBundle.MainBundle.BundlePath;
                Console.WriteLine(path);
                return path.Contains("Applications");
            }

        }
    }
}

