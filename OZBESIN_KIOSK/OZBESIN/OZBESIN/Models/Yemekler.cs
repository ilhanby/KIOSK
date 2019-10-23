using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZBESIN.Models
{
    public class Yemekler
    {
        int _YemekID;
        public int YemekID
        {
            get { return _YemekID; }
            set { _YemekID = value; }
        }

        string _YemekAd;
        public string YemekAd
        {
            get { return _YemekAd; }
            set { _YemekAd = value; }
        }

        string _YemekHazırlama;
        public string YemekHazırlama
        {
            get { return _YemekHazırlama; }
            set { _YemekHazırlama = value; }
        }

        int _UrunID;
        public int UrunID
        {
            get { return _UrunID; }
            set { _UrunID = value; }
        }

        string _UrunAd;
        public string UrunAd
        {
            get { return _UrunAd; }
            set { _UrunAd = value; }
        }

        string _YemekMalzeme1;
        public string YemekMalzeme1
        {
            get { return _YemekMalzeme1; }
            set { _YemekMalzeme1 = value; }
        }

        int _YemekKategoriID;
        public int YemekKategoriID
        {
            get { return _YemekKategoriID; }
            set { _YemekKategoriID = value; }
        }

        string _YemekResim;
        public string YemekResim
        {
            get { return _YemekResim; }
            set { _YemekResim = value; }
        }
    }
}
