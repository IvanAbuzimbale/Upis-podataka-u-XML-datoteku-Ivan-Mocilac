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
using System.Xml;
using System.Xml.Linq;

namespace PosudbaKnjigaIvanMočilac20122012
{
    public partial class NovaKnjiga : Form
    {
        public NovaKnjiga()
        {
            InitializeComponent();
        }

        private void btnUnesiKnjigu_Click(object sender, EventArgs e)
        {
            List<Knjige> knjiga = new List<Knjige>();

            if (Regex.IsMatch(txtISBN.Text, @"^\d+$") & txtISBN.TextLength < 14)
            {
                XDocument doc = new XDocument(
                new XElement("Knjige",
                    new XAttribute("ISBN", txtISBN.Text),
                    new XAttribute("Naziv", txtNaziv.Text),
                    new XAttribute("Autor", txtAutor.Text)
                )
            );
            doc.Save("Knjige.xml");
                string poruka = "Želite li dodati novu knjigu?";
                string naslov = "Upit";

                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon ikona = MessageBoxIcon.Information;
                DialogResult rez = MessageBox.Show(poruka, naslov, buttons, ikona);
            }
            else
            {
                string poruka = "Molimo da upišete pravilan ISBN.";
                string naslov = "Greška";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon ikona = MessageBoxIcon.Error;
                DialogResult rez = MessageBox.Show(poruka, naslov, buttons, ikona);
            }
            
        }
    }
}
