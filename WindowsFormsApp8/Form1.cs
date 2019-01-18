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
            Ad_Box.ForeColor = Color.Gray;
            Soyad_Box.ForeColor = Color.Gray;
           Ata_Box.ForeColor = Color.Gray;
            Olke_Box.ForeColor = Color.Gray;
            Seher_Box.ForeColor = Color.Gray;
            Telefon_BOx.ForeColor = Color.Gray;
            Find_Box.ForeColor = Color.Gray;
            Ad_Box.Text = "Name";
            Soyad_Box.Text = "Soyad";
            Ata_Box.Text = "AtaAdi";
            Olke_Box.Text = "Olke";
            Seher_Box.Text = "Seher";
            Telefon_BOx.Text = "Telefon";
            Find_Box.Text = "Find";
        }
        private void Netice_Click(object sender, EventArgs e)
        {           
             DateTimePicker dateTimePicker = new DateTimePicker();
            int number;
            bool a = Int32.TryParse(Telefon_BOx.Text,out  number);
            if (Ad_Box.Text != "Name" & Soyad_Box.Text != "Soyad" & Ata_Box.Text != "AtaAdi" & Olke_Box.Text != "Olke" & Seher_Box.Text != "Seher" & a & dateTimePicker.Value.ToShortDateString()!=dateTimePicker1.Value.ToShortDateString() )
            {
                if (Kisi.Checked || Qadin.Checked)
                {
                    User user = new User()
                    {
                        Ad = Ad_Box.Text,
                        Soyad = Soyad_Box.Text,
                        AtaAdi = Ata_Box.Text,
                        Olke = Olke_Box.Text,
                        Seher = Seher_Box.Text,
                        Telefon = Telefon_BOx.Text,
                        Time = dateTimePicker1.Value,
                    };                 
                    if (Kisi.Checked)
                    {
                        user.Cins = Kisi.Text;
                    }
                    else
                    {
                        user.Cins = Qadin.Text;
                    }
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
                    Ad_Box.BackColor = Color.White;
                    Soyad_Box.BackColor = Color.White;
                    Ata_Box.BackColor = Color.White;
                    Olke_Box.BackColor = Color.White;
                    Seher_Box.BackColor = Color.White;
                    Telefon_BOx.BackColor = Color.White;
                    Kisi.BackColor = Color.White;
                    Qadin.BackColor = Color.White;
                }
            }
            else
            {
             if (!a)
                {
                Telefon_Box.Text=string.Empty;
                    Telefon_BOx.BackColor = Color.Red;
                }
                else
                {
                    Telefon_BOx.BackColor = Color.White;

                }
                if (Ad_Box.ForeColor == Color.Gray)
                {
                    Ad_Box.BackColor = Color.Red;
                }
                else {
                    Ad_Box.BackColor = Color.White;
                }
                if (Soyad_Box.ForeColor == Color.Gray)
                {
                    Soyad_Box.BackColor = Color.Red;
                }
                else
                {
                    Soyad_Box.BackColor = Color.White;
                }
                if (Ata_Box.ForeColor == Color.Gray)
                {
                    Ata_Box.BackColor = Color.Red;
                }
                else
                {
                    Ata_Box.BackColor = Color.White;
                }
                if (Olke_Box.ForeColor == Color.Gray)
                {
                    Olke_Box.BackColor = Color.Red;
                }
                else
                {
                    Olke_Box.BackColor = Color.White;

                }
                if (Seher_Box.ForeColor == Color.Gray)
                {
                    Seher_Box.BackColor = Color.Red;
                }
                else
                {
                    Seher_Box.BackColor = Color.White;

                }
               
                if (!Kisi.Checked & !Qadin.Checked)
                {
                    Kisi.BackColor = Color.Red;
                    Qadin.BackColor = Color.Red;
                }
                else
                {
                    Kisi.BackColor = Color.White;
                    Qadin.BackColor = Color.White;
                }
                if(dateTimePicker.Value.ToShortDateString()==dateTimePicker1.Value.ToShortDateString())
                {
                    MessageBox.Show("Dogum tarixini daxil edin");
                    
                }
            } 
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            if (Find_Box.Text != "Find")
            {
                if (File.Exists($"{Find_Box.Text}.json"))
                {
                    string str = File.ReadAllText($"{Find_Box.Text}.json");
                    Find_Box.Text = string.Empty;
                    var obj = JsonConvert.DeserializeObject<User>(str);
                    Ad_Box.ForeColor = Color.Black;
                    Soyad_Box.ForeColor = Color.Black;
                    Ata_Box.ForeColor = Color.Black;
                    Olke_Box.ForeColor = Color.Black;
                    Seher_Box.ForeColor = Color.Black;
                    Telefon_BOx.ForeColor = Color.Black;
                    Ad_Box.Text = obj.Ad;
                    Soyad_Box.Text = obj.Soyad;
                    Ata_Box.Text = obj.AtaAdi;
                    Olke_Box.Text = obj.Olke;
                    Seher_Box.Text = obj.Seher;
                    Telefon_BOx.Text = obj.Telefon;
                    dateTimePicker1.Text = obj.Time.ToString();
                    if(obj.Cins=="Kisi")
                    {
                        Kisi.Checked = true;
                    }
                    else
                    {
                        Qadin.Checked = true;
                    }
                }
                else
                {
                    Find_Box.BackColor = Color.White;
                    Find_Box.Text = "Find";
                    MessageBox.Show("Not Found!");
                }
            }
            else
            {
                Find_Box.BackColor = Color.Red;
            }
        } 
        private void Ad_Box_MouseHover(object sender, EventArgs e)
        {
            if (Ad_Box.Text == "Name")
            {
                Ad_Box.Text = string.Empty;
                Ad_Box.BackColor = Color.White;
                Ad_Box.ForeColor = Color.Black;
            }
        }
        private void Ad_Box_MouseLeave(object sender, EventArgs e)
        {
            if(Ad_Box.Text==string.Empty)
            {
                Ad_Box.ForeColor = Color.Gray;
                Ad_Box.Text = "Name";
            }
        }
        private void Soyad_Box_MouseHover(object sender, EventArgs e)
        {
            if (Soyad_Box.Text == "Soyad")
            {
                Soyad_Box.BackColor = Color.White;
                Soyad_Box.ForeColor = Color.Black;
                Soyad_Box.Text = string.Empty;
            }
        }

        private void Soyad_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Soyad_Box.Text == string.Empty)
            {
                Soyad_Box.ForeColor = Color.Gray;
                Soyad_Box.Text = "Soyad";
            }
        }
        private void Ata_Box_MouseHover(object sender, EventArgs e)
        {
            if (Ata_Box.Text == "AtaAdi")
            {
                Ata_Box.BackColor = Color.White;
                Ata_Box.ForeColor = Color.Black;
               Ata_Box.Text = string.Empty;
            }
        }
        private void Ata_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Ata_Box.Text == string.Empty)
            {
                Ata_Box.ForeColor = Color.Gray;
                Ata_Box.Text = "AtaAdi";
            }
        }
        private void Olke_Box_MouseHover(object sender, EventArgs e)
        {
            if (Olke_Box.Text == "Olke")
            {
                Olke_Box.BackColor = Color.White;
                Olke_Box.ForeColor = Color.Black;
               Olke_Box.Text= string.Empty;
            }
        }
        private void Olke_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Olke_Box.Text == string.Empty)
            {
                Olke_Box.ForeColor = Color.Gray;
                Olke_Box.Text = "Olke";
            }
        }
        private void Seher_Box_MouseHover(object sender, EventArgs e)
        {
            if (Seher_Box.Text == "Seher")
            {
                Seher_Box.BackColor = Color.White;
                Seher_Box.ForeColor = Color.Black;

                Seher_Box.Text = string.Empty;
            }
        }
        private void Seher_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Seher_Box.Text == string.Empty)
            {
                Seher_Box.ForeColor = Color.Gray;
                Seher_Box.Text = "Seher";
            }
        }
        private void Telefon_BOx_MouseHover(object sender, EventArgs e)
        {
            if (Telefon_BOx.Text == "Telefon")
            {
                Telefon_BOx.BackColor = Color.White;
                Telefon_BOx.ForeColor = Color.Black;
                Telefon_BOx.Text = string.Empty;
            }
        }
        private void Telefon_BOx_MouseLeave(object sender, EventArgs e)
        {
            if (Telefon_BOx.Text == string.Empty)
            {
                Telefon_BOx.ForeColor = Color.Gray;
                Telefon_BOx.Text = "Telefon";
            }
        }
        private void Find_Box_MouseHover(object sender, EventArgs e)
        {
            if (Find_Box.Text == "Find")
            {
                Find_Box.BackColor = Color.White;
                Find_Box.ForeColor = Color.Black;
               Find_Box.Text = string.Empty;
            }
        }
        private void Find_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Find_Box.Text == string.Empty)
            {
                Find_Box.ForeColor = Color.Gray;
               Find_Box.Text = "Find";
            }
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
        public  DateTime Time  { get; set; }
        public string Cins { get; set; }
    }
}
