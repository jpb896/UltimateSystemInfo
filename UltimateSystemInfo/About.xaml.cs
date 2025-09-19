using Microsoft.UI.Xaml.Controls;
using System.Reflection;
using System;

namespace UltimateSystemInfo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class About : Page
    {
        public About()
        {
            string buildTimeDesc = new Microsoft.Windows.ApplicationModel.Resources.ResourceLoader().GetString("BuildTime");
            this.InitializeComponent();
            Assembly assembly = typeof(App).Assembly;
            CompileDateText.Text = buildTimeDesc + " " + GetBuildDate(assembly) + " UTC";
        }

        private static DateTime GetBuildDate(Assembly assembly)
        {
            var attribute = assembly.GetCustomAttribute<BuildDateAttribute>();
            return attribute != null ? attribute.DateTime : default(DateTime);
        }
    }
}
