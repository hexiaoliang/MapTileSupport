using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Media.Animation;
using System.Windows.Threading;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;


namespace MapTileSupport
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isMenuOpenFlag;

        SolidColorBrush normalBrush = new SolidColorBrush();
        SolidColorBrush currentBrush = new SolidColorBrush();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            isMenuOpenFlag = false;

            normalBrush.Color = Color.FromRgb(51, 51, 51);
            currentBrush.Color = Color.FromRgb(85, 85, 85);

            mapWrapper.Navigate(new Uri("Views/MainMapView.xaml", UriKind.Relative));
        }

        private void btn_Menu_Click(object sender, RoutedEventArgs e)
        {
            asideWrapper.Width = 0;

            txb_Navigate.Text = String.Empty;

            Button btn_Current = sender as Button;

            SolidColorBrush currentBrush = new SolidColorBrush();
            currentBrush.Color = Color.FromRgb(0, 66, 117);

            if (isMenuOpenFlag)
            {
                btn_Current.Background = normalBrush;

                asideMenu.SetValue(Grid.ColumnSpanProperty, 1);

                line_split.X2 = 50;

                isMenuOpenFlag = false;
            }
            else
            {
                btn_Current.Background = currentBrush;

                asideMenu.SetValue(Grid.ColumnSpanProperty, 2);

                line_split.X2 = 320;

                isMenuOpenFlag = true;
            }
        }

        private void btn_Ribbon_Click(object sender, RoutedEventArgs e)
        {
            line_split.X2 = 50;

            btn_Menu.Background = normalBrush;

            asideMenu.SetValue(Grid.ColumnSpanProperty, 1);
            isMenuOpenFlag = false;

            Button btn_Current = sender as Button;

            if (btn_Current.Background == currentBrush)
            {
                btn_Current.Background = normalBrush;
                asideWrapper.Width = 0;
                return;
            }

            btn_Searching.Background = normalBrush;
            btn_MapProvider.Background = normalBrush;
            btn_TileDownloader.Background = normalBrush;
            btn_TileMerger.Background = normalBrush;
            btn_Drawing.Background = normalBrush;
            btn_Region.Background = normalBrush;
            btn_Setting.Background = normalBrush;
            btn_Account.Background = normalBrush;

            asideWrapper.Width = 270;

            if (btn_Current.Name == "btn_Searching")
            {
                btn_Current.Background = currentBrush;
                txb_Navigate.Text = "搜索";
                asideWrapper.Navigate(new Uri("Views/SearchingView.xaml", UriKind.Relative));
            }

            else if (btn_Current.Name == "btn_MapProvider")
            {
                btn_Current.Background = currentBrush;
                txb_Navigate.Text = "地图提供商";
                asideWrapper.Navigate(new Uri("Views/MapProviderView.xaml", UriKind.Relative));
            }

            else if (btn_Current.Name == "btn_TileDownloader")
            {
                btn_Current.Background = currentBrush;
                txb_Navigate.Text = "切片下载";
                asideWrapper.Navigate(new Uri("Views/TileDownloaderView.xaml", UriKind.Relative));
            }

            else if (btn_Current.Name == "btn_TileMerger")
            {
                btn_Current.Background = currentBrush;
                txb_Navigate.Text = "拼接切片";
                asideWrapper.Navigate(new Uri("Views/TileMergerView.xaml", UriKind.Relative));
            }

            else if (btn_Current.Name == "btn_Drawing")
            {
                btn_Current.Background = currentBrush;
                txb_Navigate.Text = "范围框选";
                asideWrapper.Navigate(new Uri("Views/DrawingView.xaml", UriKind.Relative));
            }

            else if (btn_Current.Name == "btn_Region")
            {
                btn_Current.Background = currentBrush;
                txb_Navigate.Text = "政区边界";
                asideWrapper.Navigate(new Uri("Views/RegionView.xaml", UriKind.Relative));
            }

            else if (btn_Current.Name == "btn_Setting")
            {
                btn_Current.Background = currentBrush;
                txb_Navigate.Text = "设置";
                asideWrapper.Navigate(new Uri("Views/SettingView.xaml", UriKind.Relative));
            }

            else if (btn_Current.Name == "btn_Account")
            {
                btn_Current.Background = currentBrush;
                txb_Navigate.Text = "账户";
                asideWrapper.Navigate(new Uri("Views/AccountView.xaml", UriKind.Relative));
            }
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_Maximize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}