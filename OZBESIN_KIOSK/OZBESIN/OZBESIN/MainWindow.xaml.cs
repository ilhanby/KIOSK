using OZBESIN.Models;
using OZBESIN.UserControls;
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
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Configuration;

namespace OZBESIN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        ObservableCollection<Urun> Urunlers;
        Urun urun;
        SqlDataReader datareader;
        SqlCommand komut;
        public string barkod_id;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtbarkod.Clear();
            txtbarkod.Focus();
            gridmain.Children.Clear();
            UserControlAdd.Uc_Add(gridmainbutton, new UcMain());
            kampanya.Background = Brushes.Transparent;
            kampanya.Foreground = Brushes.DarkRed;
            hosgeldiniz.Background = Brushes.Transparent;
            hosgeldiniz.Foreground = Brushes.DarkRed;
            yemektarifi.Background = Brushes.Transparent;
            yemektarifi.Foreground = Brushes.DarkRed;
            if (WindowState == System.Windows.WindowState.Maximized)
            {
                WindowGrid.Margin = new Thickness(0);
            }
        }

        private void Button_Yemek(object sender, RoutedEventArgs e)
        {
            UserControlAdd.Uc_Add(gridmain, new UcYemekTarifi());
            gridmainbutton.Children.Clear();
            yemektarifi.Background = Brushes.Indigo;
            yemektarifi.Foreground = Brushes.Wheat;
            kampanya.Background = Brushes.DarkRed;
            kampanya.Foreground = Brushes.Wheat;
            hosgeldiniz.Background = Brushes.DarkRed;
            hosgeldiniz.Foreground = Brushes.Wheat;

            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0.5, 0);
            gradientBrush.EndPoint = new Point(0.5, 1);
            GradientStop Transparents = new GradientStop();
            Transparents.Color = Colors.White;
            Transparents.Offset = 0.8;
            gradientBrush.GradientStops.Add(Transparents);
            GradientStop Indigos = new GradientStop();
            Indigos.Color = Colors.Indigo;
            Indigos.Offset = 1;
            gradientBrush.GradientStops.Add(Indigos);
            gridyemek.Background = gradientBrush;

            LinearGradientBrush gradientBrushes = new LinearGradientBrush();
            gradientBrushes.StartPoint = new Point(0.5, 0);
            gradientBrushes.EndPoint = new Point(0.5, 1);
            GradientStop Transparentss = new GradientStop();
            Transparentss.Color = Colors.White;
            Transparentss.Offset = 0.8;
            gradientBrushes.GradientStops.Add(Transparents);
            GradientStop Darkred = new GradientStop();
            Darkred.Color = Colors.DarkRed;
            Darkred.Offset = 1;
            gradientBrushes.GradientStops.Add(Darkred);
            gridkampanya.Background = gradientBrushes;
        }

        private void Button_Kampanya(object sender, RoutedEventArgs e)
        {
            UserControlAdd.Uc_Add(gridmain, new UcKampanya());
            gridmainbutton.Children.Clear();
            kampanya.Background = Brushes.Indigo;
            kampanya.Foreground = Brushes.Wheat;
            hosgeldiniz.Background = Brushes.DarkRed;
            hosgeldiniz.Foreground = Brushes.Wheat;
            yemektarifi.Background = Brushes.DarkRed;
            yemektarifi.Foreground = Brushes.Wheat;

            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0.5, 0);
            gradientBrush.EndPoint = new Point(0.5, 1);
            GradientStop Transparents = new GradientStop();
            Transparents.Color = Colors.White;
            Transparents.Offset = 0.8;
            gradientBrush.GradientStops.Add(Transparents);
            GradientStop Indigos = new GradientStop();
            Indigos.Color = Colors.Indigo;
            Indigos.Offset = 1;
            gradientBrush.GradientStops.Add(Indigos);
            gridkampanya.Background = gradientBrush;

            LinearGradientBrush gradientBrushes = new LinearGradientBrush();
            gradientBrushes.StartPoint = new Point(0.5, 0);
            gradientBrushes.EndPoint = new Point(0.5, 1);
            GradientStop Transparentss = new GradientStop();
            Transparentss.Color = Colors.White;
            Transparentss.Offset = 0.8;
            gradientBrushes.GradientStops.Add(Transparents);
            GradientStop Darkred = new GradientStop();
            Darkred.Color = Colors.DarkRed;
            Darkred.Offset = 1;
            gradientBrushes.GradientStops.Add(Darkred);
            gridyemek.Background = gradientBrushes;
        }

        private void Button_Hosgeldiniz(object sender, RoutedEventArgs e)
        {
            UserControlAdd.Uc_Add(gridmainbutton, new UcMain());
            gridmain.Children.Clear();
            kampanya.Background = Brushes.Transparent;
            kampanya.Foreground = Brushes.DarkRed;
            hosgeldiniz.Background = Brushes.Transparent;
            hosgeldiniz.Foreground = Brushes.DarkRed;
            yemektarifi.Background = Brushes.Transparent;
            yemektarifi.Foreground = Brushes.DarkRed;

            LinearGradientBrush gradientBrushes = new LinearGradientBrush();
            gradientBrushes.StartPoint = new Point(0.5, 0);
            gradientBrushes.EndPoint = new Point(0.5, 1);
            GradientStop Transparentss = new GradientStop();
            Transparentss.Color = Colors.White;
            Transparentss.Offset = 0.8;
            gradientBrushes.GradientStops.Add(Transparentss);
            GradientStop Darkred = new GradientStop();
            Darkred.Color = Colors.DarkRed;
            Darkred.Offset = 1;
            gradientBrushes.GradientStops.Add(Darkred);
            gridyemek.Background = gradientBrushes;
            gridkampanya.Background = gradientBrushes;
        }

        private void scrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scroll = (ScrollViewer)sender;
            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Window_Close(object sender, MouseButtonEventArgs e)
        {
            Popup.IsOpen = true;
            PopupText.Text = string.Empty;
        }

        public bool active = true;

        private void Popup_Click(object sender, RoutedEventArgs e)
        {
            if (PopupText.Text.Length == 0 || PopupText.Text != "özbesinet")
            {
                Popup.IsOpen = false;
                active = true;
            }
            else if (PopupText.Text == "özbesinet")
            {
                Close();
            }
        }

        public void MyWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (Popup.IsOpen == true)
            {
                active = false;
                PopupText.Focus();
            }
            if (active == true)
            {
                txtbarkod.Focus();
            }    
        }

        private System.Diagnostics.Process _p = null;

        private void PopupText_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _p = System.Diagnostics.Process.Start("osk.exe");
            active = false;
            PopupText.Focus();
        }

        private void MyWindow_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (active == true)
                {
                    if (e.Key == Key.Enter)
                    {
                        barkod_id = txtbarkod.Text.ToString();
                        txtbarkod.Clear();
                        con.Open();
                        Urunlers = new ObservableCollection<Urun>();
                        urun = new Urun();
                        komut = new SqlCommand("SELECT UrunID FROM Urun WHERE Barkod = '" + barkod_id + "'", con);
                        datareader = komut.ExecuteReader();
                        while (datareader.Read())
                        {
                            urun = new Urun();
                            urun.UrunID = (int)datareader[0];
                        }
                        datareader.Close();
                        komut.Dispose();
                        con.Close();
                        if (urun == null || urun.UrunID == 0)
                        {
                            string terazibarkod;
                            if (barkod_id.Length >= 7)
                            {
                                terazibarkod = barkod_id.Substring(0, 7);
                                con.Open();
                                Urunlers = new ObservableCollection<Urun>();
                                urun = new Urun();
                                komut = new SqlCommand("SELECT UrunID FROM Urun WHERE Barkod = '" + terazibarkod + "'", con);
                                datareader = komut.ExecuteReader();
                                while (datareader.Read())
                                {
                                    urun = new Urun();
                                    urun.UrunID = (int)datareader[0];
                                }
                                datareader.Close();
                                komut.Dispose();
                                con.Close();
                                if (urun == null || urun.UrunID == 0)
                                {
                                    terazibarkod = barkod_id.Substring(0, 3);
                                    con.Open();
                                    Urunlers = new ObservableCollection<Urun>();
                                    urun = new Urun();
                                    komut = new SqlCommand("SELECT UrunID FROM Urun WHERE Barkod = '" + terazibarkod + "'", con);
                                    datareader = komut.ExecuteReader();
                                    while (datareader.Read())
                                    {
                                        urun = new Urun();
                                        urun.UrunID = (int)datareader[0];
                                    }
                                    datareader.Close();
                                    komut.Dispose();
                                    con.Close();

                                    if (urun == null || urun.UrunID == 0)
                                    {
                                    }
                                    else
                                    {
                                        UcBarkod UcBarkod1 = new UcBarkod()
                                        {
                                            barkod_id_id = terazibarkod,
                                        };
                                        gridmain.Children.Clear();
                                        gridmainbutton.Children.Clear();
                                        gridmain.Children.Add(UcBarkod1);
                                        txtbarkod.Focus();
                                    }
                                }
                                else
                                {
                                    UcBarkod UcBarkod1 = new UcBarkod()
                                    {
                                        barkod_id_id = terazibarkod,
                                    };
                                    gridmain.Children.Clear();
                                    gridmainbutton.Children.Clear();
                                    gridmain.Children.Add(UcBarkod1);
                                    txtbarkod.Focus();
                                }
                            }
                            if (urun == null || urun.UrunID == 0)
                            {
                                MessageBox.Show("BARKOD BULUNAMADI GÖREVLİYE BİLDİRİNİZ");
                                Window_Loaded(this, null);
                                txtbarkod.Focus();
                            }
                        }
                        else
                        {
                            UcBarkod UcBarkod1 = new UcBarkod()
                            {
                                barkod_id_id = barkod_id,
                            };
                            gridmain.Children.Clear();
                            gridmainbutton.Children.Clear();
                            gridmain.Children.Add(UcBarkod1);
                            txtbarkod.Focus();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("BARKOD BULUNAMADI GÖREVLİYE BİLDİRİNİZ");
            }
        }
    }
}