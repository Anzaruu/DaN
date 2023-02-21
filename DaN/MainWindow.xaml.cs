using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DaN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Note zametka = new Note();
        DS files = new DS();
        string[] items;

        public MainWindow()
        {
            InitializeComponent();
            Dat.DisplayDate = DateTime.Now;
        }

        public void Appd()
        {
            ListB.Items.Clear();
            var notes = DS.Des<List<Note>>();
            foreach (Note note in notes)
            {
                if (note.Date == Dat.DisplayDate)
                {
                    ListB.Items.Add(note);
                }
            }
        }

        private void Btt_Click(object sender, RoutedEventArgs e)
        {
            var notes = DS.Des<List<Note>>();
            zametka.Name = NamesOf.Text;
            zametka.Description = Describe.Text;
            zametka.Date = Convert.ToDateTime(Dat.Text);
            if ((sender as Button).Name == "Save")
            {
                foreach (Note note in notes)
                {
                    if (((note.Name == zametka.Name) || (note.Description == zametka.Description)) && (note.Date == zametka.Date))
                    {
                        note.Date = Convert.ToDateTime(Dat.DataContext);
                        note.Description = Describe.Text;
                        note.Name = zametka.Name;
                    }
                }
            }
            else if ((sender as Button).Name == "Creat")
            {
                notes.Add(zametka);
            }
            else if ((sender as Button).Name == "Delet")
            {
                foreach (Note note in notes)
                {
                    if ((note.Name == zametka.Name) && (note.Description == zametka.Description) && (note.Date == zametka.Date))
                    {
                        notes.Remove(note);
                    }
                }
            }
            files.Ser(notes);
            Appd();
        }

        private void ListB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = ListB.SelectedItem.ToString();
            var notes = DS.Des<List<Note>>();
            foreach ( Note note in notes)
            {
                if (selected == note.Name)
                {
                    NamesOf.Text = note.Name;
                    Describe.Text = note.Description;
                }
            }
            Appd();
        }

        private void Dat_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Appd();
        }
    }
}
