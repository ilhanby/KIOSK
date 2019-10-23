using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZBESIN.Models
{
    public class Urun
    {
        int _UrunID;
        public int UrunID
        {
            get { return _UrunID; }
            set { _UrunID = value; }
        }

        int _KategoriID;
        public int KategoriID
        {
            get { return _KategoriID; }
            set { _KategoriID = value; }
        }

        string _Barkod;
        public string Barkod
        {
            get { return _Barkod; }
            set { _Barkod = value; }
        }

        string _UrunAd;
        public string UrunAd
        {
            get { return _UrunAd; }
            set { _UrunAd = value; }
        }
        decimal _UrunFiyat;
        public decimal UrunFiyat
        {
            get { return _UrunFiyat; }
            set { _UrunFiyat = value; }
        }
        decimal _UrunFiyatKampanya;
        public decimal UrunFiyatKampanya
        {
            get { return _UrunFiyatKampanya; }
            set { _UrunFiyatKampanya = value; }
        }
        string _UrunIcerik;
        public string UrunIcerik
        {
            get { return _UrunIcerik; }
            set { _UrunIcerik = value; }
        }
        string _UrunResim;
        public string UrunResim
        {
            get { return _UrunResim; }
            set { _UrunResim = value; }
        }

        bool _GridVisibility;
        public bool GridVisibility
        {
            get { return _GridVisibility; }
            set { _GridVisibility = value; }
        }
    }
}
