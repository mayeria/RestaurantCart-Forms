using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace listview
{
    [Serializable] [XmlType("danie")]
    public class Danie 
    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public decimal Ilość { get; set; }
        public string Wegetarianizm { get; set; }
        public string Dodatki { get; set; }
        public string Data { get; set; }
        public string Ulica { get; set; }
        public string Alergie_uwagi { get; set; }

        public Danie()
        {
           
        }
    }
}
