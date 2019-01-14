using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Find_Box_Enter(object sender, EventArgs e)
        {



        }



        private void Netice_Click(object sender, EventArgs e)
        {





            User user = new User()
            {
                Ad = Ad_Box.Text,
                Soyad = Soyad_Box.Text,
                AtaAdi = Ata_Box.Text,
                Olke = Olke_Box.Text,
                Seher = Seher_Box.Text,
                Telefon = Telefon_BOx.Text,
                
               
            
            
        };


            string json = JsonConvert.SerializeObject(user);
            System.IO.File.WriteAllText($"{Ad_Box.Text}.json", json);

            Ad_Box.Text = string.Empty;
            Soyad_Box.Text = string.Empty;
            Ata_Box.Text = string.Empty;
            Olke_Box.Text = string.Empty;
            Seher_Box.Text = string.Empty;
            Telefon_BOx.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
            Kisi.Checked = false;
            Qadin.Checked = false;












        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Ok_Click(object sender, EventArgs e)
        {

            Find_Box.Text = string.Empty;
            if (File.Exists($"{Find_Box.Text}.json"))
            {
            string str = File.ReadAllText($"{Find_Box.Text}.json");

                var obj = JsonConvert.DeserializeObject<User>(str);
             
                Ad_Box.Text = obj.Ad;
                Soyad_Box.Text = obj.Soyad;
                Ata_Box.Text = obj.AtaAdi;
                Olke_Box.Text = obj.Olke;
                Seher_Box.Text = obj.Seher;
                Telefon_BOx.Text = obj.Telefon;
                Cinsi.Text = obj.Cins;

            }

         




           
        }

        private void asd(object sender, EventArgs e)
        {

        }

        private void Kisi_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    public class User
    {

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AtaAdi { get; set; }
        public string Olke { get; set; }
        public string Seher { get; set; }
        public string Telefon { get; set; }
        //private string Time;   { get; set; }
        public string Cins { get; set; }



    }
}
