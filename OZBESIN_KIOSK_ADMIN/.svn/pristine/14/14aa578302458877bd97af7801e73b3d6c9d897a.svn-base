using MahApps.Metro.Controls;
using Microsoft.Win32;
using OZBESIN_KAYIT.Models.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
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
using MahApps.Metro.Controls.Dialogs;

namespace OZBESIN_KAYIT.Forms
{
    /// <summary>
    /// Interaction logic for Urun.xaml
    /// </summary>
    public partial class Uruns : MetroWindow
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlDataReader datareader;
        SqlCommand komut;
        ObservableCollection<Urunler> Urunlers;
        Urunler urun;
        ObservableCollection<Kategoriler> Kategorilers;
        Kategoriler k;
        public Uruns()
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
            Urunlers = new ObservableCollection<Urunler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT u.*,k.KategoriAd FROM Urun u INNER JOIN Kategori k ON u.KategoriID = k.KategoriID";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                urun = new Urunler();
                urun.UrunID = (int)datareader[0];
                urun.KategoriID = (int)datareader[1];
                urun.UrunBarkod = datareader[2].ToString();
                urun.UrunAd = datareader[3].ToString();
                urun.UrunFiyat = (decimal)datareader[4];
                urun.UrunFiyat = Decimal.Round(urun.UrunFiyat, 2);
                urun.UrunFiyatKampanya = (decimal)datareader[5];
                urun.UrunFiyatKampanya = Decimal.Round(urun.UrunFiyatKampanya, 2);
                urun.UrunResim = datareader[6].ToString();
                urun.UrunIcerik = datareader[7].ToString();
                urun.StokKodu = datareader[8].ToString();
                urun.KDV = datareader[9].ToString();
                urun.OlcuBirim = datareader[10].ToString();
                urun.Durum = datareader[11].ToString();
                urun.KategoriAd = datareader[12].ToString();
                Urunlers.Add(urun);
            }
            con.Close();
            datagrd.ItemsSource = Urunlers;
        }

        private void Kaydetbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UrunIDtxt.Text == null || UrunIDtxt.Text == "" || UrunIDtxt.Text == "0")
                {
                    if (UrunAdtxt.Text.Length > 0)
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("insert into Urun(KategoriID,Barkod,UrunAd,UrunFiyat,UrunEskiFiyat,UrunResim,UrunIcerik,StokKodu,KDV,OlcuBirim,Durum) values (@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", con);
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
                        komut.Parameters.AddWithValue("@p12", Durumtxt.Text);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        con.Close();
                        this.ShowMessageAsync("KAYDET", "Kayıt Eklendi");
                        Yenibtn_Click(this, null);
                    }
                    else
                    {
                        this.ShowMessageAsync("HATA", "Girdiğiniz Bilgilerde Eksik ya da Yanlışlık Var Kayıt Yapılamıyor");
                        con.Close();
                    }
                }
                else
                {
                    komut = new SqlCommand();
                    komut.Connection = con;
                    komut.CommandText = "UPDATE Urun SET KategoriID=@KategoriID,Barkod=@Barkod,UrunAd=@UrunAd,UrunFiyat=@UrunFiyat,UrunEskiFiyat=@UrunEskiFiyat,UrunResim=@UrunResim,UrunIcerik=@UrunIcerik,StokKodu=@StokKodu,KDV=@KDV,OlcuBirim=@OlcuBirim,Durum=@Durum WHERE UrunID=@UrunID";
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
                    komut.Parameters.AddWithValue("@Durum", Durumtxt.Text);
                    con.Open();
                    komut.ExecuteNonQuery();
                    con.Close();
                    Yenibtn_Click(this, null);
                }
            }
            catch (Exception)
            {
                this.ShowMessageAsync("HATA", "Girdiğiniz Bilgilerde Eksik ya da Yanlışlık Var");
                con.Close();
            }
        }

        private async void Silbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string secmeSorgusu = "SELECT * FROM Urun";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
                secmeKomutu.Parameters.AddWithValue("@UrunID", UrunIDtxt.Text);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MessageDialogResult durum = await this.ShowMessageAsync("UYARI", "Seçili Kaydı Silmek İstediğinizden Emin Misiniz?", MessageDialogStyle.AffirmativeAndNegative);
                    if (durum == MessageDialogResult.Affirmative)
                    {
                        komut = new SqlCommand();
                        komut.Connection = con;
                        komut.CommandText = "DELETE FROM Urun WHERE UrunID=@UrunID";
                        komut.Parameters.AddWithValue("@UrunID", UrunIDtxt.Text);
                        komut.ExecuteNonQuery();
                        if (UrunIDtxt.Text == "" || UrunIDtxt.Text == "0")
                        {
                            await this.ShowMessageAsync("HATA", "Müşteri Bulunamadı");
                        }
                        else
                        {
                            await this.ShowMessageAsync("SİL", "Seçilen Kayıt Silindi...");
                        }
                    }
                }
                con.Close();
                Yenibtn_Click(this, null);
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("HATA", "Müşteri Bulunamadı");
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

        private void listKategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                KategoriIDcmb.Text = null;
                Urunler secilen = new Urunler();
                secilen = (Urunler)datagrd.SelectedItem;
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
                return ((item as Urunler).UrunAd.IndexOf(Aramatxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
            Regex regex = new Regex("[^0-9^.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UrunIndirimsiztxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9^.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Excel_Aktar_Click(object sender, RoutedEventArgs e)
        {
            Excel excel = new Excel();
            excel.Show();
        }
    }
}
