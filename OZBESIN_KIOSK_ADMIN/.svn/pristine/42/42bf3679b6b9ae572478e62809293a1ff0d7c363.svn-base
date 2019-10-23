using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OZBESIN_KAYIT.Models.Class;
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
using System.Windows.Shapes;

namespace OZBESIN_KAYIT.Forms
{
    /// <summary>
    /// Interaction logic for YemekKategori.xaml
    /// </summary>
    public partial class YemekKategoris : MetroWindow
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlDataReader datareader;
        SqlCommand komut;
        ObservableCollection<YemekKategoriler> YemekKategoriss;
        YemekKategoriler yk;
        public YemekKategoris()
        {
            InitializeComponent();
            datagrd.RowHeight = 40;
        }

        public void Listele()
        {
            YemekKategoriss = new ObservableCollection<YemekKategoriler>();
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
                YemekKategoriss.Add(yk);
            }
            con.Close();
            datagrd.ItemsSource = YemekKategoriss;
        }

        private void Kaydetbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (YemekKategoriIDtxt.Text == null || YemekKategoriIDtxt.Text == "" || YemekKategoriIDtxt.Text == "0")
                {
                    if (YemekKategoriAdtxt.Text.Length > 0)
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("insert into YemekKategori(YemekKategoriAd) values (@p2)", con);
                        komut.Parameters.AddWithValue("@p2", YemekKategoriAdtxt.Text);
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
                    komut.CommandText = "UPDATE YemekKategori SET YemekKategoriAd=@YemekKategoriAd WHERE YemekKategoriID=@YemekKategoriID";
                    komut.Parameters.AddWithValue("@YemekKategoriID", YemekKategoriIDtxt.Text);
                    komut.Parameters.AddWithValue("@YemekKategoriAd", YemekKategoriAdtxt.Text);
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
                string secmeSorgusu = "SELECT * from YemekKategori";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
                secmeKomutu.Parameters.AddWithValue("@YemekKategoriID", YemekKategoriIDtxt.Text);
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
                        komut.CommandText = "DELETE FROM YemekKategori WHERE YemekKategoriID=@YemekKategoriID";
                        komut.Parameters.AddWithValue("@YemekKategoriID", YemekKategoriIDtxt.Text);
                        komut.ExecuteNonQuery();
                        if (YemekKategoriIDtxt.Text == "" || YemekKategoriIDtxt.Text == "0")
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
            YemekKategoriler kat = new YemekKategoriler();
            katgrid.DataContext = kat;
            Window_Loaded(this, null);
            YemekKategoriIDtxt.Text = null;
            YemekKategoriAdtxt.Text = null;
        }

        private void listKategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                YemekKategoriler secilen = new YemekKategoriler();
                secilen = (YemekKategoriler)datagrd.SelectedItem;
                katgrid.DataContext = secilen;
            }
            catch (Exception)
            {

            }
        }

        private void Aramatxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(datagrd.ItemsSource).Refresh();
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(Aramatxt.Text))
                return true;
            else
                return ((item as YemekKategoriler).YemekKategoriAd.IndexOf(Aramatxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Listele();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(datagrd.ItemsSource);
            view.Filter = UserFilter;
        }
    }
}
