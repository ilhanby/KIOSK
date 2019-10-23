using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZBESIN_KAYIT.Models.Class
{
    public class Parameters
    {
        int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        string _Adres;
        public string Adres
        {
            get { return _Adres; }
            set { _Adres = value; }
        }

        string _Sifre;
        public string Sifre
        {
            get { return _Sifre; }
            set { _Sifre = value; }
        }
    }
}
