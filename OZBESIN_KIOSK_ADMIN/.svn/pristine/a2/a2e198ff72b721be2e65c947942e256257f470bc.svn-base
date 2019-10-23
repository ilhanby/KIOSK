using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OZBESIN_KAYIT.Models.Class;
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
using System.Windows.Shapes;

namespace OZBESIN_KAYIT.Forms
{
    /// <summary>
    /// Interaction logic for Kullanici.xaml
    /// </summary>
    public partial class Kullanici : MetroWindow
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlCommand komut;
        SqlDataReader datareader;
        List<Parameters> Parameter;
        Parameters p;

        public Kullanici()
        {
            InitializeComponent();
            VeriCek();
        }

        public void VeriCek()
        {
            Parameter = new List<Parameters>();
            komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "SELECT * FROM Parameter";
            con.Open();
            datareader = komut.ExecuteReader();
            while (datareader.Read())
            {
                p = new Parameters();
                p.ID = (int)datareader[0];
                p.Adres = datareader[1].ToString();
                p.Sifre = datareader[2].ToString();
                Parameter.Add(p);
            }
            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            girisgrid.Visibility = Visibility.Visible;
            mailgrid.Visibility = Visibility.Hidden;
            mailgrid.DataContext = p;
            girispassword.Focus();
        }

        private async void girisbtn_Click(object sender, RoutedEventArgs e)
        {
            if (giristxt.Text == "özbesinet" || girispassword.Password == "özbesinet")
            {
                girisgrid.Visibility = Visibility.Hidden;
                mailgrid.Visibility = Visibility.Visible;
                password.Focus();
            }
            else
                await this.ShowMessageAsync("HATA", "\nŞİFRE DOĞRULANAMADI");
        }

        private async void kaydetbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (adrestxt.Text.Length > 8)
                {
                    komut = new SqlCommand();
                    komut.Connection = con;
                    komut.CommandText = "UPDATE Parameter SET Adres=@Adres,Sifre=@Sifre WHERE ID=@ID";
                    komut.Parameters.AddWithValue("@ID", IDtxt.Text);
                    komut.Parameters.AddWithValue("@Adres", adrestxt.Text);
                    if (password.Visibility == Visibility.Visible)
                        komut.Parameters.AddWithValue("@Sifre", password.Password);
                    else
                        komut.Parameters.AddWithValue("@Sifre", sifretxt.Text);
                    con.Open();
                    komut.ExecuteNonQuery();
                    con.Close();
                    await this.ShowMessageAsync("HATA", "\nŞİFRE DEĞİŞTİRİLDİ");
                }
                else
                    await this.ShowMessageAsync("HATA", "\nŞİFRE DOĞRULANAMADI");
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("HATA", "\nSQL Bağlantınızı ve Girilen Bilgileri Kontrol Edip Tekrar Deneyiniz");
            }
        }

        private void passchck_Checked(object sender, RoutedEventArgs e)
        {
            sifretxt.Text = password.Password;

            password.Visibility = System.Windows.Visibility.Hidden;
            sifretxt.Visibility = System.Windows.Visibility.Visible;

            sifretxt.Focus();
        }

        private void passchck_Unchecked(object sender, RoutedEventArgs e)
        {
            password.Password = sifretxt.Text;

            password.Visibility = System.Windows.Visibility.Visible;
            sifretxt.Visibility = System.Windows.Visibility.Hidden;

            password.Focus();
        }

        private void girischeck_Checked(object sender, RoutedEventArgs e)
        {
            giristxt.Text = girispassword.Password;

            girispassword.Visibility = System.Windows.Visibility.Hidden;
            giristxt.Visibility = System.Windows.Visibility.Visible;

            giristxt.Focus();
        }

        private void girischeck_Unchecked(object sender, RoutedEventArgs e)
        {
            girispassword.Password = giristxt.Text;

            girispassword.Visibility = System.Windows.Visibility.Visible;
            giristxt.Visibility = System.Windows.Visibility.Hidden;

            girispassword.Focus();
        }
    }
}
