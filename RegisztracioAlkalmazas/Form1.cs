using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBoxHobby.Items.Add("Úszás");
            listBoxHobby.Items.Add("Horgászat");
            listBoxHobby.Items.Add("Futás");

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            DateTime time = dateTimePicker.Value;
            string ido = time.ToString();
            string nem = "Gendersemleges";
            if (radioButtonFemale.Checked == true) {
                nem = "nő";
            }
            else
            {
                nem = "ffi";
            }

            string favHobby = listBoxHobby.Text;
            /*if (listBoxHobby.SelectedItem.ToString() == NULL)
            {
                Console.WriteLine("Nem jelöltél ki kedvenc hobbit!");
            }*/
            try {
                string kivalasztottListBoxElem = listBoxHobby.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Nem jelöltél ki kedvenc hobbit!");
            }
            string path = @"C:\Users\Diak\Desktop\kimenet/adatok.txt";
            List<string> createText = new List<string>();
            createText.Add(name);
            createText.Add(nem);
            createText.Add(favHobby);
            createText.Add(ido);
            foreach (var item in listBoxHobby.Items)
            {
                createText.Add(item.ToString());
            }
            File.WriteAllLines(path, createText, Encoding.UTF8);
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string s in readText)
            {
                MessageBox.Show(s);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string newHobby = textBoxNewHobby.Text;
            listBoxHobby.Items.Add(newHobby);
            //System.Windows.Forms.MessageBox.Show(newHobby);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Diak\Desktop\kimenet/adatok.txt";
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string s in readText)
            {
                MessageBox.Show(s);
            }
            listBoxHobby.Items.Clear();
            textBoxName.Text = readText[0];
            if (readText[1] == "ffi")
            {
                radioButtonMale.Checked = true;
            }
            else {
                radioButtonFemale.Checked = true;
            }

            dateTimePicker.Value = DateTime.Parse(readText[3]);
            listBoxHobby.Items.Add("Úszás");
            listBoxHobby.Items.Add("Horgászat");
            listBoxHobby.Items.Add("Futás");
            //listBoxHobby.Items.Add(readText[7]);
            //listBoxHobby.Items.Add(readText[8]);
            //listBoxHobby.Items.Add(readText[9]);
            //listBoxHobby.Items.Add(readText[0]);
            //ListBoxHobby.Items.Add(readText[1]);
            //listBoxHobby.Items.Add(readText[2]);
            int hossz = readText.Length;
            for (int i = 7; i < hossz; i++)
            {
                listBoxHobby.Items.Add(readText[i]);
            }
        }
    }
}
