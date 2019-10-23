using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OZBESIN_KAYIT.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace OZBESIN_KAYIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
                con.Open();
                con.Close();
            }
            catch (Exception)
            {
                this.ShowMessageAsync("HATA", "SQL Server Bağlantınız Kapalı ya da Erişilemiyor Ayarları Kontrol Edip Tekrar Deneyiniz...");
                kat.IsEnabled = false;
                yemek.IsEnabled = false;
                urun.IsEnabled = false;
                yemekkat.IsEnabled = false;
                kullanici.IsEnabled = false;
            }
        }

        private void Kategori_Click(object sender, RoutedEventArgs e)
        {
            Kategoris kategori = new Kategoris();
            kategori.Show();
        }

        private void Urun_Click(object sender, RoutedEventArgs e)
        {
            Uruns urun = new Uruns();
            urun.Show();
        }

        private void YemekTarif_Click(object sender, RoutedEventArgs e)
        {
            Yemeks yemek = new Yemeks();
            yemek.Show();
        }

        private void YemekKategori_Click(object sender, RoutedEventArgs e)
        {
            YemekKategoris yemekKategori = new YemekKategoris();
            yemekKategori.Show();
        }

        private void kullanici_Click(object sender, RoutedEventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.Show();
        }
    }
}
