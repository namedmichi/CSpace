using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;
using WpfApp1;

namespace WpfApp1
{

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var Person = new Person();

        }
        static Person[] refresh()
        {
            List<Person> personenn = Person.ReadXML();
            Person p1 = personenn[0];
            Person[] People = new Person[personenn.Count ];
            int c = 0;
            foreach( Person p in personenn)
            {
                People[c] = p;
                c++;
            }
            return People;
            
        }

        public void Anzeigen_Click(object sender, RoutedEventArgs e)
        {

            Person[] People = refresh();
            contactsList.Items.Clear();
            foreach ( Person p in People)
            {
                contactsList.Items.Add(Person.returnString(p));
            }
        }

        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            List<Person> personenn = Person.ReadXML();
            try
            {
                Person tempPerson = new Person(newFirst.Text, newLast.Text, int.Parse(newAge.Text));
                personenn.Add(tempPerson);
                Person.WriteXML(personenn);
                refresh();
                Anzeigen_Click(null ,null);

            }
            catch
            {
                MessageBox.Show("Bitte die Daten richtig eingeben");
            }
        }

        private void contactsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                try
                {
                    string tempstring = contactsList.SelectedItem.ToString();
                    string[] selectedText = tempstring.Split(" ".ToCharArray()[0]);
                    string vor = selectedText[0];
                    string nach = selectedText[1];
                    string age = selectedText[2];
                    txtFirst.Text = vor;
                    txtLast.Text = nach;
                    txtAge.Text = age;
                }
                catch(NullReferenceException ex)
                {
                    return;
                }
                catch
                {
                     return;
                }
                
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<Person> personenn = Person.ReadXML();
            int tempint = contactsList.Items.Count;
            ;
            personenn.RemoveAt(tempint - 1);
            Person.WriteXML(personenn);
            refresh();
            Anzeigen_Click(null, null);

        }
    }
}
