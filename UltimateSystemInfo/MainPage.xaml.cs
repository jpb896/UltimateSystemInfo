using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Win32;
using System;
using System.IO;
using System.Management;

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
            var manufacturer = (string)Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS").GetValue("SystemManufacturer");
            var model = (string)Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS").GetValue("SystemProductName");
            DeviceName.Text = model;
            FirmwareType.Text = FirmwareInterface.GetFirmwareTypeAsString();
            Wallpaper.Source =  new BitmapImage(new Uri(GetWallpaperPath()));
            ManagementObjectSearcher ProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");
            var RamType = MemoryInterface.RamType;
            foreach (ManagementObject obj in ProcessorObject.Get())
            {
                var CPUModel = (string)obj["Name"];
                CPUModel =
                CPUModel
               .Replace("(TM)", "™")
               .Replace("(tm)", "™")
               .Replace("(R)", "®")
               .Replace("(r)", "®")
               .Replace("(C)", "©")
               .Replace("(c)", "©")
               .Replace("    ", " ")
               .Replace("  ", " ");
                CPUName.Text = CPUModel;
                CPUModelText.Text = CPUModel;
            }
            RAMSize.Text = MemoryInterface.GetRAMAmount();
            RAMAmountText.Text = MemoryInterface.GetRAMAmount();
            RAMTypeText.Text = RamType;
            DeviceText.Text = model;
            OEMText.Text = manufacturer;
            FirmwareText.Text = FirmwareInterface.GetFirmwareTypeAsString();
            ManagementObjectSearcher OperatingSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject obj in OperatingSystemObject.Get())
            {
                WinDesc.Text = (string)obj["Caption"];
                WinVer.Text = (string)obj["Version"];
            }
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
