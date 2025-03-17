using System.Runtime.InteropServices;

namespace UltimateSystemInfo {
    public class FirmwareInterface
    {
        [DllImport("kernel32.dll")]
        static extern bool GetFirmwareType(
            ref uint FirmwareType);
        public static uint GetFirmwareType()
        {
            uint firmwaretype = 0;
            if (GetFirmwareType(ref firmwaretype))
                return firmwaretype;
            else
                return 0;
        }

        public static string GetFirmwareTypeAsString()
        {
            if (GetFirmwareType() == 1) { return "BIOS"; }
            else if (GetFirmwareType() == 2) { return "UEFI"; }
            else { return "Unknown"; }
        }
    }
}