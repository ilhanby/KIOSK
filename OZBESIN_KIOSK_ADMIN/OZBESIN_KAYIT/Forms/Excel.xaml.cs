using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using OZBESIN_KAYIT.Models.Class;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Excel.xaml
    /// </summary>
    public partial class Excel : MetroWindow
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        SqlCommand comm;
        SqlDataReader datareader;
        ObservableCollection<Urunler> Urunlers;
        Urunler urun;

        public Excel()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagrd.IsEnabled = true;
            Exceltxt.IsEnabled = true;
            dialog.IsEnabled = true;
            lbl.Visibility = Visibility.Hidden;
            progress.Visibility = Visibility.Hidden;
            if (lbl.Visibility == Visibility.Hidden && progress.Visibility == Visibility.Hidden)
            {
                kaydet.Visibility = Visibility.Visible;
                goster.Visibility = Visibility.Visible;
            }
            else
            {
                kaydet.Visibility = Visibility.Hidden;
                goster.Visibility = Visibility.Hidden;
            }
        }

        private void Aktar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(@"" + Exceltxt.Text + "", ExcelVersion.Version2007);
                int sheetCount = workbook.Worksheets.Count;
                Random r = new Random();
                int index = r.Next(1);
                Worksheet sheet = workbook.Worksheets[index];
                DataTable dataTable = sheet.ExportDataTable();
                DataView view = new DataView(dataTable);
                this.datagrd.ItemsSource = view;
                this.ShowMessageAsync("UYARI","\nEXCEL dosyanızın sütun isimleri ve sıralaması önemlidir. \nLütfen kontrol ettikten sonra kayıt yapınız");
            }
            catch (Exception)
            {
                this.ShowMessageAsync("HATA", "\nEXCEL Dosyası Bulunamadı. \nDosya seçimi yapmadıysanız seçiniz ve dosya açık konumda ise lütfen kapatınız.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Exceltxt.Text = null;
            OpenFileDialog openf = new OpenFileDialog();
            openf.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openf.Title = "Excel Dosyası Seçiniz";
            if (openf.ShowDialog() == true)
            {
                Exceltxt.Text = openf.FileName;
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            if (datagrd.Items.Count >= 1)
            {
                lbl.Visibility = Visibility.Visible;
                progress.Visibility = Visibility.Visible;
                kaydet.Visibility = Visibility.Hidden;
                goster.Visibility = Visibility.Hidden;
                datagrd.IsEnabled = false;
                Exceltxt.IsEnabled = false;
                dialog.IsEnabled = false;

                worker.RunWorkerAsync();
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExcelKayit();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Window_Loaded(this, null);
        }

        public void ExcelKayit()
        {
            try
            {
                foreach (DataRowView row in datagrd.Items)
                {
                    double ID = 0;
                    Urunlers = new ObservableCollection<Urunler>();
                    comm = new SqlCommand();
                    comm.Connection = con;
                    comm.CommandText = "SELECT ISNULL(UrunID,0) FROM Urun WHERE Barkod ='" + row.Row.ItemArray[2].ToString() + "'";
                    con.Open();
                    datareader = comm.ExecuteReader();
                    while (datareader.Read())
                    {
                        urun = new Urunler();
                        urun.UrunID = (int)datareader[0];
                        Urunlers.Add(urun);
                        ID = urun.UrunID;
                    }
                    con.Close();

                    if (ID > 0)
                    {
                        con.Open();
                        comm = new SqlCommand();
                        comm.Connection = con;
                        comm.CommandText = "UPDATE Urun SET UrunFiyat=@UrunFiyat,StokKodu=@StokKodu,KDV=@KDV,OlcuBirim=@OlcuBirim WHERE UrunID=@UrunID";
                        comm.Parameters.AddWithValue("@UrunID", ID);
                        comm.Parameters.AddWithValue("@StokKodu", row.Row.ItemArray[0].ToString());
                        comm.Parameters.AddWithValue("@UrunFiyat", Convert.ToDecimal(row.Row.ItemArray[3]));
                        comm.Parameters.AddWithValue("@KDV", row.Row.ItemArray[4].ToString());
                        comm.Parameters.AddWithValue("@OlcuBirim", row.Row.ItemArray[5].ToString());
                        comm.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        con.Open();
                        comm = new SqlCommand("INSERT INTO Urun(StokKodu, UrunAd, UrunIcerik, Barkod, UrunFiyat, KDV, OlcuBirim, KategoriID, UrunEskiFiyat , Durum) Values(@p1, @p2, @p2, @p3, @p4, @p5, @p6, 28, 0 ,'Kapalı')", con);
                        comm.Parameters.AddWithValue("@p1", row.Row.ItemArray[0].ToString());
                        comm.Parameters.AddWithValue("@p2", row.Row.ItemArray[1].ToString());
                        comm.Parameters.AddWithValue("@p3", row.Row.ItemArray[2].ToString());
                        comm.Parameters.AddWithValue("@p4", Convert.ToDecimal(row.Row.ItemArray[3]));
                        comm.Parameters.AddWithValue("@p5", row.Row.ItemArray[4].ToString());
                        comm.Parameters.AddWithValue("@p6", row.Row.ItemArray[5].ToString());
                        comm.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception)
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.ShowMessageAsync("HATA", "\nKayıt Yapılamadı EXCEL Dosyanızın Sütun İsimlerini ve Sıralamasını Kontrol Ediniz");
                });
                con.Close();
            }
            finally
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.ShowMessageAsync("EXCEL", "\nKayıt Tamamlandı.");
                });
            }
        }
    }
}







