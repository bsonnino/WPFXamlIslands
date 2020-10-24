using System;
using System.Windows;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using WPFXamlIslands.Converters;
using WPFXamlIslands.ViewModel;

namespace WPFXamlIslands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void XamlHost_ChildChanged(object sender, EventArgs e)
        {
            WindowsXamlHost windowsXamlHost = (WindowsXamlHost)sender;

            Windows.UI.Xaml.Controls.FlipView flipView =
                (Windows.UI.Xaml.Controls.FlipView)windowsXamlHost.Child;
            if (flipView == null)
                return;
            var dataTemplate = (Windows.UI.Xaml.DataTemplate)XamlReader.Load(@"
<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
  <Grid Margin=""5"">
      <Grid.RowDefinitions>
         <RowDefinition Height=""*"" />
         <RowDefinition Height=""40"" />
      </Grid.RowDefinitions>
      <Image Source=""{Binding PhotoUrl}"" Grid.Row=""0"" Margin=""5""
            Stretch=""Uniform"" />
      <TextBlock Text=""{Binding UserName}"" HorizontalAlignment=""Center""
            VerticalAlignment=""Center"" Grid.Row=""1""/>
  </Grid>
</DataTemplate>");
            
            flipView.ItemTemplate = dataTemplate;
            flipView.ItemsSource = ((MainViewModel)DataContext).Photos;
        }
    }
}
