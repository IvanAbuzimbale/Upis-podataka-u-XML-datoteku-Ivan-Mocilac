using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PosudbaKnjigaIvanMočilac20122012
{
    public partial class UpisKorisnika : Form
    {
        public UpisKorisnika()
        {
            InitializeComponent();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            List<Korisnici> listaKorisnika = new List<Korisnici>();
            Korisnici korisnik = new Korisnici(txtOIB.Text, txtIme.Text, txtPrezime.Text);
            if (Regex.IsMatch(txtOIB.Text, @"^\d+$") & txtOIB.TextLength < 12)
            {
                XDocument doc = new XDocument(
                new XElement("Korisnik",
                    new XAttribute("OIB", korisnik.Id),
                    new XAttribute("Ime", korisnik.Ime),
                    new XAttribute("Prezime", korisnik.Prezime)
                )
            );
                string poruka = "Želite li dodati novog korisnika?";
                string naslov = "Upit";

                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon ikona = MessageBoxIcon.Information;
                DialogResult rez = MessageBox.Show(poruka, naslov, buttons, ikona);
                if (rez == DialogResult.Yes)
                {
                    listaKorisnika.Add(korisnik);
                    XDocument a = new XDocument(
                new XElement("Korisnik",
                    new XAttribute("OIB", korisnik.Id),
                    new XAttribute("Ime", korisnik.Ime),
                    new XAttribute("Prezime", korisnik.Prezime)
                ));
                }
                else if (rez == DialogResult.No)
                {
                    doc.Save("Korisnici.xml");
                    this.Close();
                }
                
            }
            else
            {
                string poruka = "Molimo da upišete pravilan OIB.";
                string naslov = "Greška";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon ikona = MessageBoxIcon.Error;
                DialogResult rez = MessageBox.Show(poruka, naslov, buttons, ikona);
            }
        }
    }
}
