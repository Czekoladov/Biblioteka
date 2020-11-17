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
using System.Windows.Shapes;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Laby4
{
    /// <summary>
    /// Logika interakcji dla klasy FormularzDodawaniaUzytkownika.xaml
    /// </summary>
    public partial class FormularzDodawaniaUzytkownika : Window
    {
        private string nameField;
        private string surnameField;
        private string peselField;
        private string phoneField;
        private string adressField;
        private string cityField;

        public FormularzDodawaniaUzytkownika()
        {
            InitializeComponent();
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            nameField = textBoxImie.Text;
            surnameField = textBoxNazwisko.Text;
            peselField = textBoxPesel.Text;
            phoneField = textBoxNumer.Text;
            adressField = textBoxAdress.Text;
            cityField = textBoxMiasto.Text;

            try
            {
                MainWindow.PersonList.Add(new MainWindow.Person() { Firstname = nameField, Lastname = surnameField, City = cityField });
            }
            catch (Exception blad)
            {
                MessageBox.Show(blad.Message);
            }
        }
    }


}
