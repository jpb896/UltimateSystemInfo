using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UltimateSystemInfo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            NavigationFrame.Navigate(typeof(MainPage));
            var backdrop = new MicaBackdrop();
            backdrop.Kind = Microsoft.UI.Composition.SystemBackdrops.MicaKind.Base;
            SystemBackdrop = backdrop;
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(TitleBar);
        }

        private async void Info(object sender, RoutedEventArgs e)
        {
            About about = new About();
            ContentDialog aboutdialog = new ContentDialog();
            aboutdialog.DefaultButton = ContentDialogButton.Primary;
            aboutdialog.PrimaryButtonText = "OK";
            aboutdialog.XamlRoot = rootGrid.XamlRoot;
            aboutdialog.Content = about;
            await aboutdialog.ShowAsync();
        }

        private async void ChangelogButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Changelog changelog = new Changelog();
            ContentDialog changelogDialog = new ContentDialog();
            changelogDialog.Title = "What's New?";
            changelogDialog.DefaultButton = ContentDialogButton.Primary;
            changelogDialog.PrimaryButtonText = "OK";
            changelogDialog.XamlRoot = rootGrid.XamlRoot;
            changelogDialog.Content = changelog;
            await changelogDialog.ShowAsync();
        }
    }
}
