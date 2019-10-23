using OZBESIN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OZBESIN.UserControls
{
    public partial class UcUrunler : UserControl
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlDataReader datareader;
        SqlCommand komut;
        ObservableCollection<Urun> Urunlers;
        Urun urun;
        public object kategori_id_id;
        public object urun_id;
        public UcUrunler()
        {
            InitializeComponent();
        }

        public void UrunGoster()
        {
            Urunlers = new ObservableCollection<Urun>();
            con.Open();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT KategoriID,UrunAd,UrunFiyat,UrunEskiFiyat,UrunResim,UrunID FROM Urun WHERE KategoriID ='" + kategori_id_id.ToString() + "' AND Durum = 'Açık' order by UrunAd asc";
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                urun = new Urun();
                urun.KategoriID = (int)datareader[0];
                urun.UrunAd = datareader[1].ToString();
                urun.UrunFiyat = (decimal)datareader[2];
                urun.UrunFiyat = Decimal.Round(urun.UrunFiyat, 2);
                urun.UrunFiyatKampanya = (decimal)datareader[3];
                urun.UrunFiyatKampanya = Decimal.Round(urun.UrunFiyatKampanya, 2);
                urun.UrunResim = datareader[4].ToString();
                urun.UrunID = (int)datareader[5];
                Urunlers.Add(urun);
                if( urun.UrunFiyatKampanya > 0 )
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

        private void TextUrun_MouseDown(object sender, MouseButtonEventArgs e)
        {
            urun_id = ((TextBlock)sender).Text;
            UcUrun UcUrun1 = new UcUrun()
            {
                urun_id_id = urun_id,
            };
            GridUrunler.Children.Clear();
            GridUrunler.Children.Add(UcUrun1);
        }

        private void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            UrunGoster();
        }
    }
}
