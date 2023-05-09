using System;
using System.Windows.Forms;

namespace Lab2.TehnologiiWeb
{
    public partial class Form1 : Form
    {
        private Biblioteca biblioteca;
        private Carte carteSelectata;
        private bool inModulEditare = false;

        public Form1()
        {
            InitializeComponent();
            biblioteca = new Biblioteca();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            ActualizeazaVizibilitateButoane();
        }

        private void ActualizeazaVizibilitateButoane()
        {
            btnAdauga.Visible = !inModulEditare;
            btnEditeaza.Visible = inModulEditare;
        }


        private void ActualizeazaListaCarti()
        {
            listBox1.Items.Clear();
            foreach (Carte carte in biblioteca)
            {
                listBox1.Items.Add(carte);
            }
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            inModulEditare = false;
            ActualizeazaVizibilitateButoane();
            // Crează o carte nouă și adaug-o în bibliotecă
            Carte carteNoua = new Carte(txtTitlu.Text, txtAutor.Text, int.Parse(txtAnPublicare.Text), txtEditura.Text, txtISBN.Text);
            biblioteca.AdaugaCarte(carteNoua);

            ReseteazaFormularul();

            ActualizeazaListaCarti();
        }

        private void ReseteazaFormularul()
        {
            txtTitlu.Text = "";
            txtAutor.Text = "";
            txtAnPublicare.Text = "";
            txtEditura.Text = "";
            txtISBN.Text = "";
        }

        private void btnEditeaza_Click(object sender, EventArgs e)
        {
            if (carteSelectata == null)
            {
                MessageBox.Show("Selectează o carte pentru a o edita.");
                return;
            }

            inModulEditare = false;
            ActualizeazaVizibilitateButoane();

            // Actualizează proprietățile cărții selectate și actualizează lista
            carteSelectata.Titlu = txtTitlu.Text;
            carteSelectata.Autor = txtAutor.Text;
            carteSelectata.AnPublicare = int.Parse(txtAnPublicare.Text);
            carteSelectata.Editura = txtEditura.Text;
            carteSelectata.ISBN = txtISBN.Text;
            ReseteazaFormularul();

            ActualizeazaListaCarti();

        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            inModulEditare = false;
            ActualizeazaVizibilitateButoane();
            if (carteSelectata == null)
            {
                MessageBox.Show("Selectează o carte pentru a o șterge.");
                return;
            }

            // Șterge cartea selectată din bibliotecă și actualizează lista
            biblioteca.StergeCarte(carteSelectata);
            ReseteazaFormularul();

            ActualizeazaListaCarti();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Când un element din listBox1 este selectat, actualizează câmpurile textuale
            // cu informațiile despre cartea selectată
            carteSelectata = listBox1.SelectedItem as Carte;

            if (listBox1.SelectedIndex != -1)
            {
                inModulEditare = true;
            }
            else
            {
                inModulEditare = false;
            }

            if (carteSelectata != null)
            {
                txtTitlu.Text = carteSelectata.Titlu;
                txtAutor.Text = carteSelectata.Autor;
                txtAnPublicare.Text = carteSelectata.AnPublicare.ToString();
                txtEditura.Text = carteSelectata.Editura;
                txtISBN.Text = carteSelectata.ISBN;
            }

            ActualizeazaVizibilitateButoane();
        }
    }
}
