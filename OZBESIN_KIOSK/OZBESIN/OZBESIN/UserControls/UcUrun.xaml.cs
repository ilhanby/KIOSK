using OZBESIN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Drawing.Printing;
using System.Printing;
using System.Printing.IndexedProperties;
using System.Globalization;
using Newtonsoft.Json;
using System.Windows.Xps.Packaging;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace OZBESIN.UserControls
{
    /// <summary>
    /// Interaction logic for UcUrunxaml.xaml
    /// </summary>
    public partial class UcUrun : UserControl
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlDataReader datareader;
        SqlCommand komut;
        ObservableCollection<Urun> Urunlers;
        Urun urun;
        ObservableCollection<Yemekler> Yemeklers;
        Yemekler yemek;
        public object urun_id_id;
        public object kategori_id_id_id;
        public string mailstr;
        public UcUrun()
        {
            InitializeComponent();
        }

        public void UrunGoster()
        {
            Urunlers = new ObservableCollection<Urun>();
            con.Open();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT * FROM Urun WHERE UrunID='" + urun_id_id.ToString() + "'";
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                urun = new Urun();
                urun.UrunID = (int)datareader[0];
                urun.KategoriID = (int)datareader[1];
                urun.Barkod = datareader[2].ToString();
                urun.UrunAd = datareader[3].ToString();
                urun.UrunFiyat = (decimal)datareader[4];
                urun.UrunFiyat = Decimal.Round(urun.UrunFiyat, 2);
                urun.UrunFiyatKampanya = (decimal)datareader[5];
                urun.UrunFiyatKampanya = Decimal.Round(urun.UrunFiyatKampanya, 2);
                urun.UrunResim = datareader[6].ToString();
                urun.UrunIcerik = datareader[7].ToString();
                Urunlers.Add(urun);
                if (urun.UrunFiyatKampanya > 0)
                {
                    urun.GridVisibility = true;
                }
                else
                {
                    urun.GridVisibility = false;
                }
            }
            itemsurun.ItemsSource = Urunlers;
            datareader.Close();
            komut.Dispose();
            con.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PrintImage.Visibility = Visibility.Hidden;
            Imgmail.Visibility = Visibility.Hidden;
            UrunGoster();
            TabControl1.ItemsSource = null;
            Yemeklers = new ObservableCollection<Yemekler>();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "SELECT y.*,uy.* FROM Yemek y INNER JOIN UrunYemek uy ON y.YemekID = uy.YemekID AND uy.UrunID=" + urun_id_id.ToString() + " WHERE y.Durum = 'Açık' ";
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                yemek = new Yemekler();
                yemek.YemekID = (int)datareader[0];
                yemek.YemekHazırlama = datareader[1].ToString();
                yemek.YemekAd = datareader[2].ToString();
                yemek.YemekMalzeme1 = datareader[3].ToString();
                yemek.YemekResim = datareader[5].ToString();
                yemek.UrunID = (int)datareader[7];
                yemek.UrunAd = datareader[8].ToString();
                Yemeklers.Add(yemek);
            }
            datareader.Close();
            komut.Dispose();
            con.Close();
            if (yemek == null)
            {
                yemekbttn.Visibility = Visibility.Hidden;
            }
        }

        private void YemekTarifleri_Click(object sender, RoutedEventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(1, 0);
            gradientBrush.EndPoint = new Point(1, 1);
            GradientStop Indigos = new GradientStop();
            Indigos.Color = Colors.Indigo;
            Indigos.Offset = 0.0;
            gradientBrush.GradientStops.Add(Indigos);
            GradientStop Transparents = new GradientStop();
            Transparents.Color = Colors.Transparent;
            Transparents.Offset = 0.80;
            gradientBrush.GradientStops.Add(Transparents);
            bordergrid.BorderBrush = gradientBrush;
            PrintImage.Visibility = Visibility.Visible;
            Imgmail.Visibility = Visibility.Visible;
            itemsurun.ItemsSource = null;
            Urunlers = new ObservableCollection<Urun>();
            con.Open();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT * FROM Urun WHERE Urun.UrunID=" + urun_id_id.ToString();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                urun = new Urun();
                urun.UrunID = (int)datareader[0];
                urun.KategoriID = (int)datareader[1];
                urun.Barkod = datareader[2].ToString();
                urun.UrunAd = datareader[3].ToString();
                urun.UrunFiyat = (decimal)datareader[4];
                urun.UrunFiyat = Decimal.Round(urun.UrunFiyat, 2);
                urun.UrunFiyatKampanya = (decimal)datareader[5];
                urun.UrunFiyatKampanya = Decimal.Round(urun.UrunFiyatKampanya, 2);
                urun.UrunResim = datareader[6].ToString();
                Urunlers.Add(urun);
                if (urun.UrunFiyatKampanya > 0)
                {
                    urun.GridVisibility = true;
                }
                else
                {
                    urun.GridVisibility = false;
                }
            }
            itemsurun.ItemsSource = Urunlers;
            datareader.Close();
            komut.Dispose();
            con.Close();

            Yemeklers = new ObservableCollection<Yemekler>();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "SELECT y.*,uy.* FROM Yemek y INNER JOIN UrunYemek uy ON y.YemekID = uy.YemekID AND uy.UrunID=" + urun_id_id.ToString() + "WHERE y.Durum = 'Açık' ";
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                yemek = new Yemekler();
                yemek.YemekID = (int)datareader[0];
                yemek.YemekHazırlama = datareader[1].ToString();
                yemek.YemekAd = datareader[2].ToString();
                yemek.YemekMalzeme1 = datareader[3].ToString();
                yemek.YemekResim = datareader[5].ToString();
                yemek.UrunID = (int)datareader[7];
                yemek.UrunAd = datareader[8].ToString();
                Yemeklers.Add(yemek);
            }
            TabControl1.ItemsSource = Yemeklers;
            TabControl1.SelectedItem = TabControl1.Items[0];
            datareader.Close();
            komut.Dispose();
            con.Close();
        }

        private void Tanım_Click(object sender, RoutedEventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(1, 0);
            gradientBrush.EndPoint = new Point(1, 1);
            GradientStop Indigos = new GradientStop();
            Indigos.Color = Colors.DarkRed;
            Indigos.Offset = 0.0;
            gradientBrush.GradientStops.Add(Indigos);
            GradientStop Transparents = new GradientStop();
            Transparents.Color = Colors.Transparent;
            Transparents.Offset = 0.80;
            gradientBrush.GradientStops.Add(Transparents);
            bordergrid.BorderBrush = gradientBrush;
            UserControl_Loaded(this, null);
            TabControl1.ItemsSource = null;
        }

        private void Backbutton_Mousedown(object sender, MouseButtonEventArgs e)
        {
            kategori_id_id_id = urun.KategoriID;
            UcUrunler UcUrunler1 = new UcUrunler()
            {
                kategori_id_id = kategori_id_id_id,
            };
            gridContent.Children.Clear();
            gridContent.Children.Add(UcUrunler1);
        }

        private void PrintImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int x = TabControl1.Items.Count;
            int y = -42;
            int toplam = x * y;
            var printDialog = new PrintDialog();
            printDialog.PrintQueue = System.Printing.LocalPrintServer.GetDefaultPrintQueue();
            PrintQueue pq = printDialog.PrintQueue;
            PrintTicket pt = pq.DefaultPrintTicket;
            TabControl1.Margin = new Thickness(0, toplam - 100, 0, 0);
            TabControl1.Width = 248;
            TabControl1.FontSize = 13;
            TabControl1.Items.Refresh();
            pt.PageMediaSize = new PageMediaSize(150, 800);
            printDialog.PrintTicket = pt;
            printDialog.PrintVisual(TabControl1, "OZBESIN");
            TabControl1.Margin = new Thickness(0);
            TabControl1.Width = 1130;
            TabControl1.FontSize = 20;
            TabControl1.Items.Refresh();
        }

        private void mail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                mailstr = ((Yemekler)TabControl1.SelectedItem).YemekAd + "\n\n" + ((Yemekler)TabControl1.SelectedItem).YemekMalzeme1 + "\n\n" + ((Yemekler)TabControl1.SelectedItem).YemekHazırlama + "\n";
                MailForm mailForm = new MailForm()
                {
                    mailstr_ = mailstr,
                };
                this.Opacity = 0.3;
                this.Background = Brushes.Black;
                mailForm.ShowActivated = false;
                mailForm.Show();
                mailForm.Deactivated += delegate
                {
                    mailForm.Close();
                    this.Opacity = 1.0;
                    this.Background = Brushes.Transparent;
                };
            }
            catch (Exception)
            {   }
        }
    }
}
