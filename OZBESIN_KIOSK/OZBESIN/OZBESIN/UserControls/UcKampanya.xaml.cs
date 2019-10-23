using OZBESIN.Models;
using OZBESIN.Properties;
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
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Configuration;

namespace OZBESIN.UserControls
{
    public partial class UcKampanya : UserControl
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlDataReader datareader;
        SqlCommand komut;
        ObservableCollection<Kategoriler> Kategorilers;
        Kategoriler k;
        public object kategori_id;
        public  UcKampanya()
        {
            InitializeComponent();
            KategoriGoster();
        }

        public void KategoriGoster()
        {
            Kategorilers = new ObservableCollection<Kategoriler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT * FROM Kategori WHERE Durum = 'Açık'";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                k = new Kategoriler();
                k.KategoriID = (int)datareader[0];
                k.KategoriAd = datareader[1].ToString();
                k.KategoriResim = datareader[2].ToString();

                Kategorilers.Add(k);
            }
            items.ItemsSource = Kategorilers;
            datareader.Close();
            komut.Dispose();
            con.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            KategoriGoster();
        }

        public void Text_MouseDown(object sender, MouseButtonEventArgs e)
        {
            items.ItemsSource = null;
            kategori_id = ((TextBlock)sender).Text;
            UcUrunler UcUrun1 = new UcUrunler()
            {
                kategori_id_id = kategori_id,
            };
            GridKampanya.Children.Clear();
            GridKampanya.Children.Add(UcUrun1);
        }
    }
}