using Microsoft.Win32;
using OZBESIN_KAYIT.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using OZBESIN_KAYIT.Models.Class;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace OZBESIN_KAYIT.Forms
{
    /// <summary>
    /// Interaction logic for Kategori.xaml
    /// </summary>
    public partial class Kategoris : MetroWindow
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlDataReader datareader;
        SqlCommand komut;
        ObservableCollection<Kategoriler> Kategoriss;
        Kategoriler k;
        public Kategoris()
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
                KategoriResimtxt.Text = openFileDialog.FileName;
            }
        }

        public void Listele()
        {
            Kategoriss = new ObservableCollection<Kategoriler>();
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
                k.KategoriResim = datareader[2].ToString();
                k.Durum = datareader[3].ToString();
                Kategoriss.Add(k);
            }
            con.Close();
            datagrd.ItemsSource = Kategoriss;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Listele();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(datagrd.ItemsSource);
            view.Filter = UserFilter;
        }

        private void Kaydetbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KategoriIDtxt.Text == "0" || KategoriIDtxt.Text == null || KategoriIDtxt.Text == "")
                {
                    if (KategoriAdtxt.Text.Length > 0)
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("insert into Kategori(KategoriAd,KategoriResim,Durum) values (@p2,@p3,@p4)", con);
                        komut.Parameters.AddWithValue("@p2", KategoriAdtxt.Text);
                        komut.Parameters.AddWithValue("@p3", KategoriResimtxt.Text);
                        komut.Parameters.AddWithValue("@p4", Durumtxt.Text);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        con.Close();
                        this.ShowMessageAsync("KAYDET", "Kayıt Eklendi");
                        Window_Loaded(this, null);
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
                    komut.CommandText = "UPDATE Kategori SET KategoriAd=@KategoriAd,KategoriResim=@KategoriResim,Durum=@Durum WHERE KategoriID=@KategoriID";
                    komut.Parameters.AddWithValue("@KategoriID", KategoriIDtxt.Text);
                    komut.Parameters.AddWithValue("@KategoriAd", KategoriAdtxt.Text);
                    komut.Parameters.AddWithValue("@KategoriResim", KategoriResimtxt.Text);
                    komut.Parameters.AddWithValue("@Durum", Durumtxt.Text);
                    con.Open();
                    komut.ExecuteNonQuery();
                    con.Close();
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
                string secmeSorgusu = "SELECT * from Kategori";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
                secmeKomutu.Parameters.AddWithValue("@KategoriID", KategoriIDtxt.Text);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MessageDialogResult durum = await this.ShowMessageAsync("UYARI", "Seçili Kaydı Silmek İstediğinizden Emin Misiniz?",MessageDialogStyle.AffirmativeAndNegative);
                    if (durum == MessageDialogResult.Affirmative)
                    {
                        komut = new SqlCommand();
                        komut.Connection = con;
                        komut.CommandText = "DELETE FROM Kategori WHERE KategoriID=@KategoriID";
                        komut.Parameters.AddWithValue("@KategoriID", KategoriIDtxt.Text);
                        komut.ExecuteNonQuery();
                        if (KategoriIDtxt.Text == "" || KategoriIDtxt.Text == "0")
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
                Window_Loaded(this, null);
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("HATA", "Müşteri Bulunamadı");
            }
        }

        private void Yenibtn_Click(object sender, RoutedEventArgs e)
        {
            Kategoriler kat = new Kategoriler();
            katgrid.DataContext = kat;
            Window_Loaded(this, null);
            KategoriIDtxt.Text = null;
            KategoriAdtxt.Text = null;
            KategoriResimtxt.Text = null;
        }

        private void listKategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Kategoriler secilen = new Kategoriler();
                secilen = (Kategoriler)datagrd.SelectedItem;
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
                return ((item as Kategoriler).KategoriAd.IndexOf(Aramatxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Aramatxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(datagrd.ItemsSource).Refresh();
        }
    }
}
