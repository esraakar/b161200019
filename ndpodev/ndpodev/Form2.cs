using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ndpodev
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void VerileriYukle()
        {
            //sınıfımızdan nesne türetip datagridview1 e nesnemizin özelliklerindeki değerleri datagridviewe bastık
            Musteri mp = new Musteri();
            dataGridView1.DataSource = mp.MusteriGetir();
            //dataGridView1.Columns[0].Visible = false;

        }
        //Form Yüklendiğinde VerileriYükle Metodu çalışarak Datagridview'e veriler yükleniyor
        private void Form2_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }
        //Ekle butonuna basıldığında gerekli kontrollerden geçerek veri ekleme işlemi gerçekleştiriliyor.
        private void button1_Click(object sender, EventArgs e)
        {
            //Müşteri eklerken textboxların boş olup olmadığını kontrol ediyoruz.
            if(textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox15.Text == "" || textBox13.Text == ""|| comboBox1.Text == ""|| dateTimePicker2.Text == ""|| dateTimePicker3.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Eğer textboxlar doluysa içindeki değerleri sınıfımıza ait propertylere ilgili değerler yükleniyor.
                Musteri musteri = new Musteri();
               
                musteri.Ad = textBox1.Text;
                musteri.Soyad = textBox2.Text;
                musteri.Sira = textBox3.Text;
                musteri.Adres = textBox13.Text;
                musteri.Kefil = textBox11.Text;
                musteri.Kefiltel = textBox12.Text;
                musteri.Telefon = textBox4.Text;
                musteri.Borc = textBox5.Text;
                musteri.Taksit = textBox6.Text;
                musteri.Btarih = dateTimePicker2.Text;
                musteri.Otarih = dateTimePicker3.Text;
                musteri.Uruntur = textBox15.Text;
                musteri.Odemesekli = comboBox1.Text;
                if (musteri.MusteriEkle())
                {
                    MessageBox.Show("Yeni Müşteri Eklendi");
                    //Yeni veriler tekrar datagridview e yükleniyor
                    VerileriYukle();
                }
              
            }
               
           
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
            textBox15.Text = "";
            textBox13.Text = "";
            comboBox1.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
           //datagridview in ilk sütunundaki müşteri id değerini alıp silme işlemini müşteri id ye göre yapılıyor.
            musteri.Musteriid =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if (musteri.MusteriSil())
            {
                MessageBox.Show("Müşteri Silindi.");
                //Silindikten sonra yeni veriler yükleniyor.
                VerileriYukle();
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            Musteri musteri = new Musteri();
            //TextBox8 in içerisindeki soyisim değerine göre arama yapmak için sınıfımıza ait soyisim propertysine atama yapılıyor.
            musteri.Soyad = textBox8.Text;
            dataGridView2.DataSource = musteri.SoyIsimAra();
            dataGridView2.Columns[0].Visible = false;

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            //TextBox9 in içerisindeki sira değerine göre arama yapmak için sınıfımıza ait sira propertysine atama yapılıyor.
            musteri.Sira = textBox9.Text;
            dataGridView2.DataSource = musteri.SiraAra();
            dataGridView2.Columns[0].Visible = false;
        }
        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

            Musteri musteri = new Musteri();
            //TextBox7 in içerisindeki İsim değerine göre arama yapmak için sınıfımıza ait isim propertysine atama yapılıyor.
            musteri.Ad = textBox7.Text;
            dataGridView2.DataSource = musteri.IsimAra();
            dataGridView2.Columns[0].Visible = false;
        }
        //Güncelle butonuna basıldığında çalışıcak olan kodlar
        private void button3_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            //Müşteri id sine göre borc ve taksit bilgisini gerekli kontroller yapıldıktan sonra güncelliyoruz.
            musteri.Musteriid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            musteri.Borc = textBox10.Text;


                int taksitsayi = Convert.ToInt32(dataGridView2.CurrentRow.Cells[9].Value);
                int borcmiktari = Convert.ToInt32(dataGridView2.CurrentRow.Cells[8].Value);
                int dusurecek=Convert.ToInt32(textBox10.Text);
                
                if (taksitsayi<=0 || borcmiktari<=0 || dusurecek>borcmiktari)
                {
                    MessageBox.Show("Taksitini tamamlamış müşterinin borcunu düşüremezsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (musteri.BorcGuncelle())
                    {
                        MessageBox.Show("Borç bilgisi Güncellendi.");
                        musteri.Ad = textBox7.Text;
                        dataGridView2.DataSource = musteri.IsimAra();
                        dataGridView2.Columns[0].Visible = false;
                }
               
                }

                
                textBox10.Text = "";



                
            

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            //datetimepicker1 in içerisindeki tarih değerine göre arama yapmak için sınıfımıza ait tarih propertysine atama yapılıyor.
            musteri.Otarih = dateTimePicker1.Text;
            dataGridView3.DataSource = musteri.TarihAra();
            dataGridView3.Columns[0].Visible = false;
        }
    }
}
