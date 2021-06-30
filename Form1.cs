using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace listview
{
    public partial class Form1 : Form
    {
        bool klik1, klik2, klik3, klik4;
        string wege = null;
        string data, dodatki, nazwa, menu, json;
        int cena;
        double kwota;
        Stream stream = File.OpenWrite("zamowienie_binary.dat");
        List<Danie> lista = new List<Danie>();

        public Form1()
        {
            InitializeComponent();
            label13.Click += new EventHandler(label13_Click);
            label14.Click += new EventHandler(label14_Click);
            label15.Click += new EventHandler(label15_Click);
            label16.Click += new EventHandler(label16_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[0];
            pictureBox2.Image = imageList1.Images[1];
            pictureBox3.Image = imageList1.Images[2];
            pictureBox4.Image = imageList1.Images[3];
            label11.Text = "";
            listView1.SmallImageList = imageList1;

            label13.Text = "Pizza Capricciosa (33 cm)   - 25 zł\n\n" +
                "Rodzaj pizzy w kuchni włoskiej. Składniki: ser mozzarella,\n pieczona szynka, grzyby, karczochy i pomidory\n\n" +
                "Kliknij aby dodać do koszyka";
            label14.Text = "Hamburger amerykański   - 17 zł\n\n" +
                "Klasyczne amerykańskie danie. Składniki: mielona wołowina,\n bekon, cebula, pomidory, ser, sałata lodowa\n\n" +
                "Kliknij aby dodać do koszyka";
            label15.Text = "Spaghetti Bolognese   - 13 zł\n\n" +
                "Podstawa kuchni włoskiej. Składniki: wieprzowina, boczek,\n sos bolognese (pomidorowy), cebula\n\n" +
                "Kliknij aby dodać do koszyka";
            label16.Text = "Maki sushi kalifornijskie (10 kawałków)   - 25 zł\n\n" +
                "Rolka ryżu zawinięta ryżem na zewnątrz. Składniki: łosoś,\n paluszek krabowy, majonez, rzodkiew daikon, ogórek\n\n" +
                "Kliknij aby dodać do koszyka";

            List<string> dania = new List<string>();
            menu += "--Polecane dania dnia--\n";
            dania.Add("Pizza Capricciosa (33 cm) - 25 zł");
            dania.Add("Hamburger Amerykański - 17 zł");
            dania.Add("Spaghetti Bolognese - 13 zł");
            dania.Add("Maki sushi kalifornijskie (10 kawałków) - 25 zł");

            var path = "menu.txt";
            foreach (string s in dania)
                menu += s + "\n";
            File.WriteAllTextAsync(path, menu);
        }

        void label13_Click(object sender, EventArgs e)
        {
            if (klik1 == true)
            {
                panel1.Visible = false;
                klik1 = false;
                cena = 0;
                checkedListBox1.Items.Clear();
            }
            else
            {
                panel1.Location = new Point(39, 127);
                panel1.Visible = true;
                klik1 = true;
                nazwa = "Pizza Capricciosa";
                cena = 25;
                checkedListBox1.Items.Add("Bekon", 0);
                checkedListBox1.Items.Add("Mozzarella", 0);
                checkedListBox1.Items.Add("Frytki", 0);
                checkedListBox1.Items.Add("Pepsi 500ml", 0);
            }
        }

        void label14_Click(object sender, EventArgs e)
        {
            if (klik2 == true)
            {
                panel1.Visible = false;
                klik2 = false;
                cena = 0;
                checkedListBox1.Items.Clear();
            }
            else
            {
                panel1.Location = new Point(39, 239);
                panel1.Visible = true;
                klik2 = true;
                nazwa = "Hamburger amerykański";
                cena = 17;
                checkedListBox1.Items.Add("Ogórek kiszony", 0);
                checkedListBox1.Items.Add("Dodatkowy ser", 0);
                checkedListBox1.Items.Add("Frytki", 0);
                checkedListBox1.Items.Add("Pepsi 500ml", 0);
            }
        }

        void label15_Click(object sender, EventArgs e)
        {
            if (klik3 == true)
            {
                panel1.Visible = false;
                klik3 = false;
                cena = 0;
                checkedListBox1.Items.Clear();
            }
            else
            {
                panel1.Location = new Point(39, 15);
                panel1.Visible = true;
                klik3 = true;
                nazwa = "Spaghetti Bolognese";
                cena = 13;
                checkedListBox1.Items.Add("Pepsi 500ml", 0);
                checkedListBox1.Items.Add("Mirinda 500ml", 0);
                checkedListBox1.Items.Add("Woda gazowana", 0);
            }
        }

        void label16_Click(object sender, EventArgs e)
        {
            if (klik4 == true)
            {
                panel1.Visible = false;
                klik4 = false;
                cena = 0;
                checkedListBox1.Items.Clear();
            }
            else
            {
                panel1.Location = new Point(39, 127);
                panel1.Visible = true;
                klik4 = true;
                nazwa = "Maki sushi kalifornijskie";
                cena = 25;
                checkedListBox1.Items.Add("Pepsi 500ml", 0);
                checkedListBox1.Items.Add("Mirinda 500ml", 0);
                checkedListBox1.Items.Add("Dodatkowe wasabi", 0);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        } 

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            listView1.View = View.SmallIcon;
            listView1.CheckBoxes = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            listView1.View = View.LargeIcon;
            listView1.CheckBoxes = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            listView1.View = View.List;
            listView1.CheckBoxes = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            listView1.CheckBoxes = false;
            listView1.View = View.Tile;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox6.Text = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kwota = 0;
            foreach (ListViewItem item in listView1.Items)
                kwota += double.Parse(item.SubItems[2].Text);
            label11.Text = kwota.ToString() + " zł";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemchecked in listView1.CheckedItems)
            {
                foreach (Danie item in lista.ToList())
                    if (item.Cena == Convert.ToInt32(itemchecked.SubItems[2].Text) && item.Ilość == Convert.ToInt32(itemchecked.SubItems[1].Text))
                        lista.Remove(item);
                 listView1.Items.Remove(itemchecked);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (object itemChecked in checkedListBox1.CheckedItems)
                dodatki += itemChecked.ToString() + " ";
            data = dateTimePicker1.Value.ToShortDateString() + " " + maskedTextBox2.Text;
            if (checkBox1.Checked == true)
                wege = "Wegetariańskie";
            if (checkBox1.Checked == false)
                wege = null;
            
            lista.Add(new Danie
            {
                Nazwa = nazwa,
                Ilość = numericUpDown1.Value,
                Cena = cena,
                Wegetarianizm = wege,
                Dodatki = dodatki,
                Data = data,
                Ulica = textBox5.Text,
                Alergie_uwagi = richTextBox1.Text
            });

            Danie danie = new Danie()
            {
                Nazwa = nazwa,
                Ilość = numericUpDown1.Value,
                Cena = cena,
                Wegetarianizm = wege,
                Dodatki = dodatki,
                Data = data,
                Ulica = textBox5.Text,
                Alergie_uwagi = richTextBox1.Text
            };

            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(stream, danie);

            string[] wiersz = { danie.Nazwa, danie.Ilość.ToString(), danie.Cena.ToString(), danie.Wegetarianizm, danie.Dodatki, danie.Data, danie.Ulica, danie.Alergie_uwagi };

            var listViewElement = new ListViewItem(wiersz);
            listView1.Items.Add(listViewElement);

            kwota += cena * Convert.ToInt32(numericUpDown1.Value);
            label11.Text = kwota.ToString() + " zł";

            wege = null; dodatki = null; data = null; textBox5.Text = null; richTextBox1.Text = null; nazwa = null; cena = 0;
            textBox5.Clear(); richTextBox1.Clear(); maskedTextBox2.Clear();
            checkBox1.Checked = false; numericUpDown1.Value = 1;
            checkedListBox1.Items.Clear();
            panel1.Visible = false; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stream.Flush();
            stream.Close();
            stream.Dispose();

            if (textBox6.Text != null)
                textBox6.Text = null;
            textBox6.Text = "Podsumowanie zamówienia\r\n-----------------------\r\n";
            foreach (ListViewItem item in listView1.Items)
            {
                for (int i = 0; i < 6; i++)
                    textBox6.Text += item.SubItems[i].Text + ", ";
                textBox6.Text += item.SubItems[7].Text + "\r\n";
            }
            textBox6.Text += "-----------------------\r\nKwota do zapłacenia: " + kwota + " zł";

            using (var writer = new FileStream("zamowienie_xml.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Danie>),
                    new XmlRootAttribute("danie_list"));
                ser.Serialize(writer, lista);
            }

            var path = "zamowienie_json.txt";
            json = JsonConvert.SerializeObject(lista, Formatting.Indented);
            File.WriteAllTextAsync(path, json);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Danie> zamowienie_wybrane = new List<Danie>();
            foreach (ListViewItem itemchecked in listView1.CheckedItems)
            {
                foreach (Danie item in lista.ToList())
                    if (item.Cena == Convert.ToInt32(itemchecked.SubItems[2].Text) && item.Ilość == Convert.ToInt32(itemchecked.SubItems[1].Text))
                        zamowienie_wybrane.Add(item);
            }

            using (var writer = new FileStream("zamowienie_xml.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Danie>),
                    new XmlRootAttribute("danie_list"));
                ser.Serialize(writer, zamowienie_wybrane);
            }

            var path = "zamowienie_json.txt";
            json = JsonConvert.SerializeObject(zamowienie_wybrane, Formatting.Indented);
            File.WriteAllTextAsync(path, json);

            if (textBox6.Text != null)
                textBox6.Text = null;
            textBox6.Text = "Podsumowanie zamówienia\r\n-----------------------\r\n";
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                for (int i = 0; i < 6; i++)
                    textBox6.Text += item.SubItems[i].Text + ", ";
                textBox6.Text += item.SubItems[7].Text + "\r\n";
            }
            textBox6.Text += "-----------------------\r\nKwota do zapłacenia: " + kwota + " zł";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Danie> wczytaj_zamowienie = JsonConvert.DeserializeObject<List<Danie>>(json);
            foreach (Danie item in wczytaj_zamowienie)
            {
                string[] wiersz = { item.Nazwa, item.Ilość.ToString(), item.Cena.ToString(), item.Wegetarianizm, item.Dodatki, item.Data, item.Ulica, item.Alergie_uwagi };
                var listViewElement = new ListViewItem(wiersz);
                listView1.Items.Add(listViewElement);
            }    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Danie> dania;
            using (var reader = new StreamReader("zamowienie_xml.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Danie>),
                    new XmlRootAttribute("danie_list"));
                dania = (List<Danie>)deserializer.Deserialize(reader);
            }
            foreach (Danie item in dania)
            {
                string[] wiersz = { item.Nazwa, item.Ilość.ToString(), item.Cena.ToString(), item.Wegetarianizm, item.Dodatki, item.Data, item.Ulica, item.Alergie_uwagi };
                var listViewElement = new ListViewItem(wiersz);
                listView1.Items.Add(listViewElement);
            }
        }
    }
}
