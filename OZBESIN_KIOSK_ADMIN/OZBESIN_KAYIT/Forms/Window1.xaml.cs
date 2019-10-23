using MahApps.Metro.Controls;
using Microsoft.Win32;
using OZBESIN_KAYIT.Models.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using Spire.Xls;

namespace OZBESIN_KAYIT.Forms
{
    /// <summary>
    /// Interaction logic for Urun.xaml
    /// </summary>
    public partial class Window1 : MetroWindow
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlDataReader datareader;
        SqlCommand komut;
        ObservableCollection<TestUrunler> TUrunlers;
        TestUrunler turun;
        ObservableCollection<Kategoriler> Kategorilers;
        Kategoriler k;
        public Window1()
        {
            InitializeComponent();
            datagrd.RowHeight = 40;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                UrunResimtxt.Text = openFileDialog.FileName;
            }
        }

        public void Listele()
        {
            TUrunlers = new ObservableCollection<TestUrunler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT u.*,k.KategoriAd FROM TestUrun u INNER JOIN Kategori k ON u.KategoriID = k.KategoriID";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                turun = new TestUrunler();
                turun.UrunID = (int)datareader[0];
                turun.KategoriID = (int)datareader[1];
                turun.UrunBarkod = datareader[2].ToString();
                turun.UrunAd = datareader[3].ToString();
                turun.UrunFiyat = Convert.ToDecimal(datareader[4]);
                turun.UrunFiyat = Decimal.Round(turun.UrunFiyat, 2);
                turun.UrunFiyatKampanya = Convert.ToDecimal(datareader[5]);
                turun.UrunFiyatKampanya = Decimal.Round(turun.UrunFiyatKampanya, 2);
                turun.UrunResim = datareader[6].ToString();
                turun.UrunIcerik = datareader[7].ToString();
                turun.StokKodu = datareader[8].ToString();
                turun.KDV = datareader[9].ToString();
                turun.OlcuBirim = datareader[10].ToString();
                turun.KategoriAd = datareader[11].ToString();
                TUrunlers.Add(turun);
            }
            con.Close();
            datagrd.ItemsSource = TUrunlers;
        }

        private void Kaydetbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UrunAdtxt.Text.Length > 0)
                {
                    con.Open();
                    SqlCommand komut = new SqlCommand("insert into TestUrun(KategoriID,Barkod,UrunAd,UrunFiyat,UrunEskiFiyat,UrunResim,UrunIcerik,StokKodu,KDV,OlcuBirim) values (@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", con);
                    komut.Parameters.AddWithValue("@p2", KategoriIDtxt.Text);
                    komut.Parameters.AddWithValue("@p3", Barkodtxt.Text);
                    komut.Parameters.AddWithValue("@p4", UrunAdtxt.Text);
                    komut.Parameters.AddWithValue("@p5", UrunFiyattxt.Text);
                    komut.Parameters.AddWithValue("@p6", UrunIndirimsiztxt.Text);
                    komut.Parameters.AddWithValue("@p7", UrunResimtxt.Text);
                    komut.Parameters.AddWithValue("@p8", UrunIceriktxt.Text);
                    komut.Parameters.AddWithValue("@p9", Stoktxt.Text);
                    komut.Parameters.AddWithValue("@p10", KDVtxt.Text);
                    komut.Parameters.AddWithValue("@p11", Olcubrmtxt.Text);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    con.Close();
                    MessageBox.Show("Kayıt Eklendi");
                    Yenibtn_Click(this, null);
                }
            }
            catch (Exception)
            {
                MessageBoxResult durum = MessageBox.Show("Girdiğiniz Bilgilerde Eksiklik ya da Yanlışlık Var", "HATA",
                MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Cancel);
                con.Close();
            }
        }

        private void Silbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string secmeSorgusu = "SELECT * FROM TestUrun";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
                secmeKomutu.Parameters.AddWithValue("@UrunID", UrunIDtxt.Text);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MessageBoxResult durum = MessageBox.Show("Seçili Kaydı Silmek İstediğinizden Emin Misiniz?", "Silme Onayı",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
                    if (durum == MessageBoxResult.OK)
                    {
                        komut = new SqlCommand();
                        komut.Connection = con;
                        komut.CommandText = "DELETE FROM TestUrun WHERE UrunID=@UrunID";
                        komut.Parameters.AddWithValue("@UrunID", UrunIDtxt.Text);
                        komut.ExecuteNonQuery();
                        if (UrunIDtxt.Text == "" || UrunIDtxt.Text == "0")
                        {
                            MessageBoxResult durum1 = MessageBox.Show("Müşteri Bulunamadı", "HATA",
                            MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Cancel);
                        }
                        else
                        {
                            MessageBox.Show("Seçilen Kayıt Silindi...");
                        }
                    }
                }
                con.Close();
                Yenibtn_Click(this, null);
            }
            catch (Exception)
            {
                MessageBoxResult durum1 = MessageBox.Show("Müşteri Bulunamadı", "HATA",
                MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Cancel);
            }
        }

        private void Yenibtn_Click(object sender, RoutedEventArgs e)
        {
            Urunler uruns = new Urunler();
            katgrid.DataContext = uruns;
            Window_Loaded(this, null);
            UrunIDtxt.Text = null;
            KategoriIDtxt.Text = null;
            Barkodtxt.Text = null;
            UrunAdtxt.Text = null;
            UrunFiyattxt.Text = null;
            UrunIndirimsiztxt.Text = null;
            UrunResimtxt.Text = null;
            UrunIceriktxt.Text = null;
        }

        private void Guncelbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                komut = new SqlCommand();
                komut.Connection = con;
                komut.CommandText = "UPDATE TestUrun SET KategoriID=@KategoriID,Barkod=@Barkod,UrunAd=@UrunAd,UrunFiyat=@UrunFiyat,UrunEskiFiyat=@UrunEskiFiyat,UrunResim=@UrunResim,UrunIcerik=@UrunIcerik,StokKodu=@StokKodu,KDV=@KDV,OlcuBirim=@OlcuBirim WHERE UrunID=@UrunID";
                komut.Parameters.AddWithValue("@UrunID", UrunIDtxt.Text);
                komut.Parameters.AddWithValue("@KategoriID", KategoriIDtxt.Text);
                komut.Parameters.AddWithValue("@Barkod", Barkodtxt.Text);
                komut.Parameters.AddWithValue("@UrunAd", UrunAdtxt.Text);
                komut.Parameters.AddWithValue("@UrunFiyat", UrunFiyattxt.Text);
                komut.Parameters.AddWithValue("@UrunEskiFiyat", UrunIndirimsiztxt.Text);
                komut.Parameters.AddWithValue("@UrunResim", UrunResimtxt.Text);
                komut.Parameters.AddWithValue("@UrunIcerik", UrunIceriktxt.Text);
                komut.Parameters.AddWithValue("@StokKodu", Stoktxt.Text);
                komut.Parameters.AddWithValue("@KDV", KDVtxt.Text);
                komut.Parameters.AddWithValue("@OlcuBirim", Olcubrmtxt.Text);
                con.Open();
                komut.ExecuteNonQuery();
                con.Close();
                Yenibtn_Click(this, null);
            }
            catch (Exception)
            {
                MessageBoxResult durum = MessageBox.Show("Bilgiler Güncellenemedi. Eksik ya da Yanlış Var", "HATA",
                MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Cancel);
                con.Close();
            }

        }

        private void listKategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                KategoriIDcmb.Text = null;
                TestUrunler secilen = new TestUrunler();
                secilen = (TestUrunler)datagrd.SelectedItem;
                katgrid.DataContext = secilen;
            }
            catch (Exception)
            {

            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(Aramatxt.Text))
                return true;
            else
                return ((item as TestUrunler).UrunAd.IndexOf(Aramatxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Aramatxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(datagrd.ItemsSource).Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Listele();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(datagrd.ItemsSource);
            view.Filter = UserFilter;

            KategoriIDcmb.Items.Clear();
            Kategorilers = new ObservableCollection<Kategoriler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT * FROM Kategori";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                k = new Kategoriler();
                k.KategoriID = (int)datareader[0];
                k.KategoriAd = datareader[1].ToString();
                Kategorilers.Add(k);
                KategoriIDcmb.Items.Add(k.KategoriAd);
            }
            datareader.Close();
            komut.Dispose();
            con.Close();
        }

        private void KategoriIDcmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kategorilers = new ObservableCollection<Kategoriler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT KategoriID,KategoriAd FROM Kategori WHERE KategoriAd = '" + KategoriIDcmb.SelectedItem + "'";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                int KategoriIDs = (int)datareader["KategoriID"];
                KategoriIDtxt.Text = KategoriIDs.ToString();
            }
            datareader.Close();
            komut.Dispose();
            con.Close();
        }

        private void UrunFiyattxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9^,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UrunIndirimsiztxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9^,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Excel_Aktar_Click(object sender, RoutedEventArgs e)
        {
            Excel excel = new Excel();
            excel.Show();
        }
    }
}
