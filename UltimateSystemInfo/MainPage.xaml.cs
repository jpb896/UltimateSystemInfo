using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Win32;
using System;
using System.IO;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UltimateSystemInfo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DeviceName.Text = (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS").GetValue("SystemProductName");
            FirmwareType.Text = FirmwareInterface.GetFirmwareTypeAsString();
            Wallpaper.Source =  new BitmapImage(new Uri(GetWallpaperPath()));
        }

        private string GetWallpaperPath()
        {
            string desktopPath = "";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop");
            string wallpaper = key.GetValue("Wallpaper").ToString();

            if (wallpaper.StartsWith("~"))

            {

                desktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Web\Wallpaper\Windows", wallpaper.Substring(1));

            }

            else if (wallpaper.StartsWith("%"))

            {

                string[] slides = wallpaper.Substring(1).Split(',');

                desktopPath = slides[0].Trim();

            }

            else

            {

                desktopPath = wallpaper;

            }
            return desktopPath;
        }
    }
}
