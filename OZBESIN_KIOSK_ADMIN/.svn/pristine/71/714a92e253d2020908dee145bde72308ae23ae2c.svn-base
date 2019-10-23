using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using OZBESIN_KAYIT.Models.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OZBESIN_KAYIT.Forms
{
    /// <summary>
    /// Interaction logic for Yemek.xaml
    /// </summary>
    public partial class Yemeks : MetroWindow
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlDataReader datareader;
        SqlCommand komut;
        ObservableCollection<Urunler> Urunlers;
        Urunler urun;
        ObservableCollection<YemekKategoriler> YemekKategoris;
        YemekKategoriler yk;
        ObservableCollection<Yemekler> Yemeklers;
        Yemekler yemek;

        public int SonKayitID = 0;

        public Yemeks()
        {
            InitializeComponent();
            datagrd.RowHeight = 40;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Listele();
            UrunGoster();
            YemekKategoriIDcmb.Items.Clear();
            YemekKategoriGoster();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(datagrd.ItemsSource);
            view.Filter = UserFilter;
            CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(listUrun.ItemsSource);
            view1.Filter = UrunUserFilter;
        }

        public void UrunGoster()
        {
            Urunlers = new ObservableCollection<Urunler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT u.UrunID,u.UrunAd,ISNULL(uy.YemekID,0) FROM Urun u LEFT JOIN UrunYemek uy ON u.UrunID=uy.UrunID AND uy.YemekID='" + YemekIDtxt.Text + "'";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                urun = new Urunler();
                urun.UrunID = (int)datareader[0];
                urun.UrunAd = datareader[1].ToString();
                urun.YemekIDs = (int)datareader[2];
                Urunlers.Add(urun);
                if (YemekIDtxt.Text == urun.YemekIDs.ToString())
                {
                    urun.Checked = true;
                }
                else
                {
                    urun.Checked = false;
                }
            }
            listUrun.ItemsSource = Urunlers;
            datareader.Close();
            komut.Dispose();
            con.Close();
        }

        public void YemekKategoriGoster()
        {
            YemekKategoris = new ObservableCollection<YemekKategoriler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT * FROM YemekKategori";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                yk = new YemekKategoriler();
                yk.YemekKategoriID = (int)datareader[0];
                yk.YemekKategoriAd = datareader[1].ToString();
                YemekKategoris.Add(yk);
                YemekKategoriIDcmb.Items.Add(yk.YemekKategoriAd);
            }
            datareader.Close();
            komut.Dispose();
            con.Close();
        }

        public void Listele()
        {
            Yemeklers = new ObservableCollection<Yemekler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT y.*,yk.YemekKategoriAd FROM Yemek y LEFT JOIN YemekKategori yk ON y.YemekKategoriID = yk.YemekKategoriID order by YemekID ASC";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                yemek = new Yemekler();
                yemek.YemekID = (int)datareader[0];
                yemek.YemekHazırlama = datareader[1].ToString();
                yemek.YemekAd = datareader[2].ToString();
                yemek.YemekMalzeme1 = datareader[3].ToString();
                yemek.YemekKategoriID = (int)datareader[4];
                yemek.YemekResim = datareader[5].ToString();
                yemek.Durum = datareader[6].ToString();
                yemek.YemekKategoriAd = datareader[7].ToString();
                Yemeklers.Add(yemek);
            }
            con.Close();
            datagrd.ItemsSource = Yemeklers;
        }

        private void Kaydetbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (YemekIDtxt.Text == null || YemekIDtxt.Text == "" || YemekIDtxt.Text == "0")
                {
                    if (YemekAdtxt.Text.Length > 0)
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("insert into Yemek(YemekHazırlama,YemekAd,YemekMalzeme1,YemekKategoriID,YemekResim,Durum) values (@p1,@p2,@p3,@p4,@p5,@p6) SET @YemekID = SCOPE_IDENTITY()", con);
                        komut.Parameters.AddWithValue("@p1", YemekHazirlamatxt.Text);
                        komut.Parameters.AddWithValue("@p2", YemekAdtxt.Text);
                        komut.Parameters.AddWithValue("@p3", YemekMalzemetxt.Text);
                        komut.Parameters.AddWithValue("@p4", YemekKategoriIDtxt.Text);
                        komut.Parameters.AddWithValue("@p5", YemekResimtxt.Text);
                        komut.Parameters.AddWithValue("@p6", Durumtxt.Text);
                        komut.Parameters.Add("@YemekID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        komut.ExecuteNonQuery();
                        SonKayitID = Convert.ToInt32(komut.Parameters["@YemekID"].Value);
                        komut.Dispose();
                        con.Close();
                        this.ShowMessageAsync("KAYDET", "Kayıt Eklendi");
                        YemekIDtxt.Text = SonKayitID.ToString();
                        listUrun.ItemsSource = null;
                        UrunGoster();
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
                    komut.CommandText = "UPDATE Yemek SET YemekHazırlama=@YemekHazırlama,YemekAd=@YemekAd,YemekMalzeme1=@YemekMalzeme1,YemekKategoriID=@YemekKategoriID,YemekResim=@YemekResim,Durum=@Durum WHERE YemekID=@YemekID";
                    komut.Parameters.AddWithValue("@YemekID", YemekIDtxt.Text);
                    komut.Parameters.AddWithValue("@YemekHazırlama", YemekHazirlamatxt.Text);
                    komut.Parameters.AddWithValue("@YemekAd", YemekAdtxt.Text);
                    komut.Parameters.AddWithValue("@YemekMalzeme1", YemekMalzemetxt.Text);
                    komut.Parameters.AddWithValue("@YemekKategoriID", YemekKategoriIDtxt.Text);
                    komut.Parameters.AddWithValue("@YemekResim", YemekResimtxt.Text);
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
                YemekIDtxt.Text = null;
            }
            finally
            {
                CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(listUrun.ItemsSource);
                view1.Filter = UrunUserFilter;
            }
        }

        private async void Silbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string secmeSorgusu = "SELECT * FROM Yemek";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
                secmeKomutu.Parameters.AddWithValue("@YemekID", YemekIDtxt.Text);
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
                        komut.CommandText = "DELETE FROM Yemek WHERE YemekID=@YemekID";
                        komut.Parameters.AddWithValue("@YemekID", YemekIDtxt.Text);
                        komut.ExecuteNonQuery();
                        if (YemekIDtxt.Text == "" || YemekIDtxt.Text == "0")
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
            Yemekler yemeks = new Yemekler();
            katgrid.DataContext = yemeks;
            Window_Loaded(this, null);
            YemekIDtxt.Text = null;
            YemekHazirlamatxt.Text = null;
            YemekAdtxt.Text = null;
            YemekMalzemetxt.Text = null;
            YemekKategoriIDtxt.Text = null;
            YemekResimtxt.Text = null;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(Aramatxt.Text))
                return true;
            else
                return ((item as Yemekler).YemekAd.IndexOf(Aramatxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Aramatxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(datagrd.ItemsSource).Refresh();
        }

        private void listKategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Yemekler secilen = new Yemekler();
                secilen = (Yemekler)datagrd.SelectedItem;
                katgrid.DataContext = secilen;
                YemekKategoriIDcmb.SelectedItem = null;
                listUrun.ItemsSource = null;
                UrunGoster();
                CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(listUrun.ItemsSource);
                view1.Filter = UrunUserFilter;
            }
            catch (Exception)
            {
            }
        }

        private void KategoriIDcmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            YemekKategoris = new ObservableCollection<YemekKategoriler>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT * FROM YemekKategori WHERE YemekKategoriAd = '" + YemekKategoriIDcmb.SelectedItem + "'";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                int YemekKategoriIDs = (int)datareader["YemekKategoriID"];
                YemekKategoriIDtxt.Text = YemekKategoriIDs.ToString();
            }
            datareader.Close();
            komut.Dispose();
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                YemekResimtxt.Text = openFileDialog.FileName;
            }
        }

        private bool UrunUserFilter(object item)
        {
            if (String.IsNullOrEmpty(UrunAramatxt.Text))
                return true;
            else
                return ((item as Urunler).UrunAd.IndexOf(UrunAramatxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void UrunAramatxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listUrun.ItemsSource).Refresh();
        }

        private void YemekIDtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (YemekIDtxt.Text.Length > 0 || YemekIDtxt.Text == "0")
            {
                gridurun.Visibility = Visibility.Visible;
            }
            else
            {
                gridurun.Visibility = Visibility.Hidden;
            }
        }

        private void checkbox1_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.IsChecked == true)
            {
                con.Open();
                SqlCommand komut1 = new SqlCommand("insert into UrunYemek(UrunID,YemekID) values (@p1,@p2)", con);
                komut1.Parameters.AddWithValue("@p1", checkBox.Tag);
                komut1.Parameters.AddWithValue("@p2", YemekIDtxt.Text);
                komut1.ExecuteNonQuery();
                komut1.Dispose();
                con.Close();
            }
        }

        private void checkbox1_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            con.Open();
            string secmeSorgusu = "SELECT YemekID,UrunID FROM UrunYemek";
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
            secmeKomutu.Parameters.AddWithValue("@YemekID", YemekIDtxt.Text);
            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                komut = new SqlCommand();
                komut.Connection = con;
                komut.CommandText = "DELETE FROM UrunYemek WHERE YemekID=@YemekID AND UrunID=@UrunID";
                komut.Parameters.AddWithValue("@YemekID", YemekIDtxt.Text);
                komut.Parameters.AddWithValue("@UrunID", checkBox.Tag);
                komut.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
