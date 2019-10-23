using OZBESIN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Printing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OZBESIN.UserControls
{
    /// <summary>
    /// Interaction logic for UcYemekTarifi.xaml
    /// </summary>
    public partial class UcYemekTarifi : UserControl
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        private string kategoriSorgusu = "SELECT * From YemekKategori";
        private string yemekSorgusu = "SELECT DISTINCT YemekHazırlama,YemekAd,YemekMalzeme1,YemekKategoriID,YemekResim From Yemek WHERE Durum = 'Açık' ";
        public string mailstr;
        public UcYemekTarifi()
        {
            InitializeComponent();
            VerileriCek();
        }

        private void VerileriCek()
        {
            using (con)
            {
                SqlDataAdapter daKategori = new SqlDataAdapter(kategoriSorgusu, con);
                DataTable dtKategori = new DataTable();
                daKategori.Fill(dtKategori);

                SqlDataAdapter daYemek = new SqlDataAdapter(yemekSorgusu, con);
                DataTable dtYemek = new DataTable();
                daYemek.Fill(dtYemek);

                DataSet ds = new DataSet();
                ds.Tables.Add(dtYemek);
                ds.Tables.Add(dtKategori);

                DataRelation iliski = new DataRelation("YemekKategoriYemek", dtKategori.Columns["YemekKategoriID"], dtYemek.Columns["YemekKategoriID"]);
                ds.Relations.Add(iliski);

                DataContext = dtKategori;
            }
        }

        private void PrintImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int x = TabControl1.Items.Count;
            int y = -42;
            int toplam = x * y;
            var printDialog = new PrintDialog();
            printDialog.PrintQueue = System.Printing.LocalPrintServer.GetDefaultPrintQueue();
            PrintQueue pq = printDialog.PrintQueue;
            PrintTicket pt = pq.DefaultPrintTicket;
            TabControl1.Margin = new Thickness(0, toplam - 100, 0, 0);
            TabControl1.Width = 248;
            TabControl1.FontSize = 13;
            TabControl1.Items.Refresh();
            pt.PageMediaSize = new PageMediaSize(150, 800);
            printDialog.PrintTicket = pt;
            printDialog.PrintVisual(TabControl1, "OZBESIN");
            TabControl1.Margin = new Thickness(0);
            TabControl1.Width = 1130;
            TabControl1.FontSize = 20;
            TabControl1.Items.Refresh();
            UserControl_Loaded(this, null);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabControl1.Items.Count > 1)
            {
                TabControl1.SelectedItem = TabControl1.Items[0];
            }
        }

        private void mail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                mailstr = ((DataRowView)TabControl1.SelectedItem)["YemekAd"].ToString() + "\n\n" + ((DataRowView)TabControl1.SelectedItem)["YemekMalzeme1"].ToString() + "\n\n" + ((DataRowView)TabControl1.SelectedItem)["YemekHazırlama"].ToString() + "\n\n";
                MailForm mailForm = new MailForm()
                {
                    mailstr_ = mailstr,
                };
                this.Opacity = 0.3;
                this.Background = Brushes.Black;
                mailForm.ShowActivated = false;
                mailForm.Show();
                mailForm.Deactivated += delegate
                {
                    mailForm.Close();
                    this.Opacity = 1.0;
                    this.Background = Brushes.Transparent;
                };
            }
            catch (Exception)
            {  }
        }
    }
}
