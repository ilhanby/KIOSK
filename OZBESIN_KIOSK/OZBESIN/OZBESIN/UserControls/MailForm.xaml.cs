using OZBESIN.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using System.Windows.Threading;

namespace OZBESIN.UserControls
{
    /// <summary>
    /// Interaction logic for MailForm.xaml
    /// </summary>
    public partial class MailForm : Window
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlCommand komut;
        SqlDataReader datareader;
        List<Parameters> Parameter;
        Parameters p;
        DispatcherTimer timer = new DispatcherTimer();
        public string mailstr_;

        public MailForm()
        {
            InitializeComponent();
            timer.IsEnabled = true;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            timer.Tick += Timer_Tick;
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

        private void klavyebtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process _p = null;
            _p = System.Diagnostics.Process.Start("osk.exe");
            mailtxt.Focus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            mailtxt.Focus();
            timer.Stop();
        }

        private void gonderbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(p.Adres, "ÖZBESİN");
                mail.Subject = "ÖZBESİN YEMEK TARİFİ";
                mail.To.Add(mailtxt.Text);
                mail.Body = mailstr_;
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential(p.Adres, p.Sifre);
                smtp.EnableSsl = true;
                smtp.Port = 25;
                smtp.Host = "smtp.gmail.com";
                smtp.Send(mail);
                mailtxtblck.Text = "E-MAIL GÖNDERİLDİ \nYemek Tarifi Mail Adresinize Gönderildi.";
            }
            catch (Exception)
            {
                mailtxtblck.Text = "E-MAIL ADRES HATASI \nMail Adresinizi Kontrol Ettikten Sonra Tekrar Deneyiniz.";
            }
        }
        
        private void Window_Activated(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
