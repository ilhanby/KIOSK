﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZBESIN_KAYIT.Models.Class
{
    public class Kategoriler
    {
        int _KategoriID;
        public int KategoriID
        {
            get { return _KategoriID; }
            set { _KategoriID = value; }
        }

        string _KategoriAd;
        public string KategoriAd
        {
            get { return _KategoriAd; }
            set { _KategoriAd = value; }
        }

        string _KategoriResim;
        public string KategoriResim
        {
            get { return _KategoriResim; }
            set { _KategoriResim = value; }
        }

        string _Durum;
        public string Durum
        {
            get { return _Durum; }
            set { _Durum = value; }
        }
    }
}
