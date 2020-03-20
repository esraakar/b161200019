using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpodev
{
    class Musteri
    {

        MySqlConnection baglanti;
        MySqlCommand cmd;

        public Musteri() //Kurucu metotta bağlantı yolumuzu belirledik.
        {
            string bag;
            MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder();
            build.UserID = "root";
            build.Password = "kedicik123";
            build.Database = "asanmobilya";
            build.Server = "localhost";
            build.SslMode = MySqlSslMode.None;
            bag = build.ToString();
            baglanti = new MySqlConnection(bag); ;
        }

        int _musteriid;
        string _ad;
        string _soyad;
        string _sira;
        string _telefon;
        string _adres;
        string _kefil;
        string _kefiltel;
        string _borc;
        string _taksit;
        string _btarih;
        string _otarih;
        string _uruntur;
        string _odemesekli;
        //Propertylerimizi Oluşturduk
        #region
        public int Musteriid { get => _musteriid; set => _musteriid = value; }
        public string Ad { get => _ad; set => _ad = value; }
        public string Soyad { get => _soyad; set => _soyad = value; }
        public string Sira { get => _sira; set => _sira = value; }
        public string Telefon { get => _telefon; set => _telefon = value; }
        public string Adres { get => _adres; set => _adres = value; }
        public string Kefil { get => _kefil; set => _kefil = value; }
        public string Kefiltel { get => _kefiltel; set => _kefiltel = value; }
        public string Borc { get => _borc; set => _borc = value; }
        public string Taksit { get => _taksit; set => _taksit = value; }
        public string Btarih { get => _btarih; set => _btarih = value; }
        public string Otarih { get => _otarih; set => _otarih = value; }
        public string Uruntur { get => _uruntur; set => _uruntur = value; }
        public string Odemesekli { get => _odemesekli; set => _odemesekli = value; }
       
        #endregion
        //Musteri Ekle Metodu
        public bool MusteriEkle()
        {
            
            bool check = false;

            baglanti.Open();


            MySqlCommand komut = new MySqlCommand("INSERT INTO Musteri(musteriad, musterisoyad, musterisira,musteritelefon, musteriadres, musterikefil,kefiltel,musteriborc, musteritaksit, borctarihi, odemetarihi,uruntipi,odemesekli) VALUES(@musteriad,@musterisoyad,@musterisira,@musteritelefon,@musteriadress,@musterikefil,@kefiltel,@musteriborc,@musteritaksit,@borctarihi,@odemetarihi,@uruntipi,@odemesekli)", baglanti);
            komut.Parameters.AddWithValue("@musteriad",Ad);
            komut.Parameters.AddWithValue("@musterisoyad", Soyad);
            komut.Parameters.AddWithValue("@musterisira", Sira);
            komut.Parameters.AddWithValue("@musteritelefon", Telefon);
            komut.Parameters.AddWithValue("@musteriadress", Adres);
            komut.Parameters.AddWithValue("@musterikefil", Kefil);
            komut.Parameters.AddWithValue("@kefiltel", Kefiltel);
            komut.Parameters.AddWithValue("@musteriborc", Borc);
            komut.Parameters.AddWithValue("@musteritaksit", Taksit);
            komut.Parameters.AddWithValue("@borctarihi", Btarih);
            komut.Parameters.AddWithValue("@odemetarihi", Otarih);
            komut.Parameters.AddWithValue("@uruntipi", Uruntur);
            komut.Parameters.AddWithValue("@odemesekli", Odemesekli);

            if (komut.ExecuteNonQuery() > 0)
            {
                check = true;
            }


            //command.ExecuteNonQuery();
            baglanti.Close();
            return check;

        }
        //Musteri Getir Metodu
        public List<Musteri> MusteriGetir()
        {
            List<Musteri> MusteriListesi = new List<Musteri>();
            string sql = "SELECT * FROM musteri";
            baglanti.Open();
            cmd = new MySqlCommand(sql, baglanti);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Musteri mstr = new Musteri();

                mstr.Musteriid = Convert.ToInt32(dr[0]);
                mstr.Ad = dr[1].ToString();
                mstr.Soyad = dr[2].ToString();
                mstr.Sira = dr[3].ToString();
                mstr.Telefon = dr[4].ToString();
                mstr.Adres = dr[5].ToString();
                mstr.Kefil = dr[6].ToString();
                mstr.Kefiltel = dr[7].ToString();
                mstr.Borc = dr[8].ToString();
                mstr.Taksit = dr[9].ToString();
                mstr.Btarih = dr[10].ToString();
                mstr.Otarih = dr[11].ToString();
                mstr.Uruntur = dr[12].ToString();
                mstr.Odemesekli = dr[13].ToString();
                MusteriListesi.Add(mstr);

            }
            baglanti.Close();
            return MusteriListesi;
        }
        //Musteri Sil Metodu
        public bool MusteriSil()
        {
            bool check = false;
            
            baglanti.Open();
            string sql = "Delete from musteri where musteriid='" + Musteriid + "'";
            MySqlCommand command = new MySqlCommand(sql, baglanti);

            if (command.ExecuteNonQuery()>0)
            {
                check = true;
            }
            
            baglanti.Close();
            return check;

        }
        //İsime göre arama yapıp listeleyen metod.
        public List<Musteri> IsimAra()
        {
            List<Musteri> MusteriListesi = new List<Musteri>();
            string sql = "SELECT * from musteri where musteriad Like   '" + Ad + "%'";
            baglanti.Open();
            cmd = new MySqlCommand(sql, baglanti);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Musteri mstr = new Musteri();

                mstr.Musteriid = Convert.ToInt32(dr[0]);
                mstr.Ad = dr[1].ToString();
                mstr.Soyad = dr[2].ToString();
                mstr.Sira = dr[3].ToString();
                mstr.Telefon = dr[4].ToString();
                mstr.Adres = dr[5].ToString();
                mstr.Kefil = dr[6].ToString();
                mstr.Kefiltel = dr[7].ToString();
                mstr.Borc = dr[8].ToString();
                mstr.Taksit = dr[9].ToString();
                mstr.Btarih = dr[10].ToString();
                mstr.Otarih = dr[11].ToString();
                mstr.Uruntur = dr[12].ToString();
                mstr.Odemesekli = dr[13].ToString();
                MusteriListesi.Add(mstr);

            }
            baglanti.Close();
            return MusteriListesi;
        }
        //Soyisime göre arama yapıp listeleyen metod.
        public List<Musteri> SoyIsimAra()
        {
            List<Musteri> MusteriListesi = new List<Musteri>();
            string sql = "SELECT * from musteri where musterisoyad Like   '" + Soyad + "%' and musteriad Like'"+Ad+"%'";
            baglanti.Open();
            cmd = new MySqlCommand(sql, baglanti);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Musteri mstr = new Musteri();

                mstr.Musteriid = Convert.ToInt32(dr[0]);
                mstr.Ad = dr[1].ToString();
                mstr.Soyad = dr[2].ToString();
                mstr.Sira = dr[3].ToString();
                mstr.Telefon = dr[4].ToString();
                mstr.Adres = dr[5].ToString();
                mstr.Kefil = dr[6].ToString();
                mstr.Kefiltel = dr[7].ToString();
                mstr.Borc = dr[8].ToString();
                mstr.Taksit = dr[9].ToString();
                mstr.Btarih = dr[10].ToString();
                mstr.Otarih = dr[11].ToString();
                mstr.Uruntur = dr[12].ToString();
                mstr.Odemesekli = dr[13].ToString();
                MusteriListesi.Add(mstr);

            }
            baglanti.Close();
            return MusteriListesi;
        }
        //Müşteri sırasına göre arama yapıp listeleyen metod.
        public List<Musteri> SiraAra()
        {
            List<Musteri> MusteriListesi = new List<Musteri>();
            string sql = "SELECT * from musteri where musterisoyad Like   '" + Soyad + "%' and musteriad Like'" + Ad + "%' and musterisira ='"+Sira+"'";
            baglanti.Open();
            cmd = new MySqlCommand(sql, baglanti);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Musteri mstr = new Musteri();

                mstr.Musteriid = Convert.ToInt32(dr[0]);
                mstr.Ad = dr[1].ToString();
                mstr.Soyad = dr[2].ToString();
                mstr.Sira = dr[3].ToString();
                mstr.Telefon = dr[4].ToString();
                mstr.Adres = dr[5].ToString();
                mstr.Kefil = dr[6].ToString();
                mstr.Kefiltel = dr[7].ToString();
                mstr.Borc = dr[8].ToString();
                mstr.Taksit = dr[9].ToString();
                mstr.Btarih = dr[10].ToString();
                mstr.Otarih = dr[11].ToString();
                mstr.Uruntur = dr[12].ToString();
                mstr.Odemesekli = dr[13].ToString();
                MusteriListesi.Add(mstr);

            }
            baglanti.Close();
            return MusteriListesi;
        }
        //Borç güncelleme metodu
        public bool BorcGuncelle()
        {
            bool check = false;
            MySqlCommand cmd = new MySqlCommand();
            cmd = baglanti.CreateCommand();

           
            cmd.Parameters.AddWithValue("@borcmiktar", Borc);
           
            cmd.Parameters.AddWithValue("@id", Musteriid);
            cmd.CommandText = "UPDATE musteri SET musteriborc=(musteriborc-@borcmiktar),musteritaksit=(musteritaksit-1) WHERE musteriid=@id";
            baglanti.Open();
            if (cmd.ExecuteNonQuery()>0)
            {
                check = true;
            }
           
            baglanti.Close();

            return check;


        }
        //Tarihe göre arama yapıp listeleyen metod.
        public List<Musteri> TarihAra()
        {
            List<Musteri> MusteriListesi = new List<Musteri>();
            string sql = "SELECT * from musteri where odemetarihi='" + Otarih + "'";
            baglanti.Open();
            cmd = new MySqlCommand(sql, baglanti);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Musteri mstr = new Musteri();

                mstr.Musteriid = Convert.ToInt32(dr[0]);
                mstr.Ad = dr[1].ToString();
                mstr.Soyad = dr[2].ToString();
                mstr.Sira = dr[3].ToString();
                mstr.Telefon = dr[4].ToString();
                mstr.Adres = dr[5].ToString();
                mstr.Kefil = dr[6].ToString();
                mstr.Kefiltel = dr[7].ToString();
                mstr.Borc = dr[8].ToString();
                mstr.Taksit = dr[9].ToString();
                mstr.Btarih = dr[10].ToString();
                mstr.Otarih = dr[11].ToString();
                mstr.Uruntur = dr[12].ToString();
                mstr.Odemesekli = dr[13].ToString();
                MusteriListesi.Add(mstr);

            }
            baglanti.Close();
            return MusteriListesi;
        }
    }
}
