using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soru_1
{
    public partial class Form1 : Form
    {
        bool optDurum = false;          //Operatörlere(+,-,*,/) tıklanma durumunu incelediğimiz için boolean türünde.
        double sonuc = 0;               //İşlemlerin sırasıyla aktarıldığı, tutulduğu değişken.
        string opt = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void RakamEventı(object sender, EventArgs e)
        {
            if (textBoxSonuc.Text == "0" || optDurum)       //Başlangıça sabitlediğimiz 0 değerinin, yeni rakamlar girildiğinde veya
                textBoxSonuc.Clear();                      // bir operatöre tıklandığında temizlenmesi işlemi.

            optDurum = false;                             //optDurum değişkenini başlangıç durumuna getirir.
            Button btn = (Button)sender;
            textBoxSonuc.Text += btn.Text;                //Tıklanan butonun yazısını alarak textboxSonuc'un textine ekler.
        }

        private void optHesap(object sender, EventArgs e)
        {
            optDurum = true;                //Burada operatöre tıklanmış olacağı için opt durumunu true yaptık.
            Button btn = (Button)sender;
            string yeniOpt = btn.Text;      //Bir önceki operatör işlemini tutmak için yeni bir değişken oluşturduk.
            labelsonuc.Text = labelsonuc.Text + " " + textBoxSonuc.Text + " " + yeniOpt;

            switch (opt)
            {
                case "+":
                    textBoxSonuc.Text = (sonuc + double.Parse(textBoxSonuc.Text)).ToString();            //Parse ile dönüşüm işlemi yapıldı.
                    break;

                case "-":
                    textBoxSonuc.Text = (sonuc - double.Parse(textBoxSonuc.Text)).ToString();           
                    break;

                case "x":
                    textBoxSonuc.Text = (sonuc * double.Parse(textBoxSonuc.Text)).ToString();
                    break;

                case "÷":
                    textBoxSonuc.Text = (sonuc / double.Parse(textBoxSonuc.Text)).ToString();
                    break;
            }

            sonuc = Double.Parse(textBoxSonuc.Text);
            textBoxSonuc.Text = sonuc.ToString();
            opt = yeniOpt;                  //Eski operatör bilgisini yeni opt bilgisiyle değiştiriyoruz.
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBoxSonuc.Text = "0";        //CE ile sadece textbox'daki veriyi temizliyoruz.
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBoxSonuc.Text = "0";            //C ile tüm işlemleri temizliyoruz.
            labelsonuc.Text = " ";
            opt = " ";
            sonuc = 0;
            optDurum = false; 

        }

        private void buttonSil_Click(object sender, EventArgs e)
        {

            int uzunluk = textBoxSonuc.Text.Length;
            if (uzunluk > 0)
            {
                textBoxSonuc.Text = textBoxSonuc.Text.Substring(0, uzunluk - 1);
            }
            textBoxSonuc.Focus();
            textBoxSonuc.SelectionStart = textBoxSonuc.Text.Length;
            textBoxSonuc.SelectionLength = 0;
        }

        private void buttonEsittir_Click(object sender, EventArgs e)
        {
            labelsonuc.Text = "";
            optDurum = true;

            switch (opt)
            {
                case "+":
                    textBoxSonuc.Text = (sonuc + double.Parse(textBoxSonuc.Text)).ToString();            
                    break;

                case "-":
                    textBoxSonuc.Text = (sonuc - double.Parse(textBoxSonuc.Text)).ToString();
                    break;

                case "x":
                    textBoxSonuc.Text = (sonuc * double.Parse(textBoxSonuc.Text)).ToString();
                    break;

                case "÷":
                    textBoxSonuc.Text = (sonuc / double.Parse(textBoxSonuc.Text)).ToString();
                    break;
            }


            sonuc = Double.Parse(textBoxSonuc.Text);
            textBoxSonuc.Text = sonuc.ToString();
            opt = "";
        }

        private void buttonVirgül_Click(object sender, EventArgs e)
        {
            if (!textBoxSonuc.Text.Contains(","))
            {
                textBoxSonuc.Text += ",";
            }
            optDurum = false;
        }

        private void buttonSigned_Click(object sender, EventArgs e)
        {
            if (textBoxSonuc.Text != "0")
            {
                if (textBoxSonuc.Text.StartsWith("-"))
                    textBoxSonuc.Text = textBoxSonuc.Text.Replace("-", "");
                else 
                    textBoxSonuc.Text = "-" + textBoxSonuc.Text;
            }
        }

        private void buttonYüzde_Click(object sender, EventArgs e)
        {
            double sayi, sonuc;
            sayi = Convert.ToDouble(textBoxSonuc.Text);
            sonuc = sayi / 100;                 //Yüzde hesabında 250*10%= şeklinde işlem yapıldığı düşünülmüştür.
            textBoxSonuc.Text = sonuc.ToString();
        }

        private void buttonKarekök_Click(object sender, EventArgs e)
        {
            double sayi, sonuc;
            sayi = Convert.ToDouble(textBoxSonuc.Text);
            sonuc = Math.Sqrt(sayi);
            textBoxSonuc.Text = sonuc.ToString(); 
        }

        private void buttonBirBölüX_Click(object sender, EventArgs e)
        {
            double sayi, sonuc;
            sayi = Convert.ToDouble(textBoxSonuc.Text);
            sonuc = 1 / sayi;
            textBoxSonuc.Text = sonuc.ToString();
        }

        private void buttonKareAlma_Click(object sender, EventArgs e)
        {
            double sayi, sonuc;
            sayi = Convert.ToDouble(textBoxSonuc.Text);
            sonuc = sayi * sayi;
            textBoxSonuc.Text = sonuc.ToString();
        }
    }
}
