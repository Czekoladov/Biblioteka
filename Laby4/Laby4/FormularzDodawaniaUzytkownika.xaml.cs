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
using Microsoft.Win32;
using System.Text.RegularExpressions;

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
                MainWindow.PersonList.Add(new MainWindow.Person() { Firstname = nameField, Lastname = surnameField, City = cityField, Pesel=peselField, Phone=phoneField, Adress=adressField});
            }
            catch (Exception blad)
            {
                MessageBox.Show(blad.Message);
            }
        }
        private void ImageLoad(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgDynamic.Source = new BitmapImage(fileUri);
            }

        }
        private void ValiPesel(object sender, TextChangedEventArgs e)
        {
            string input = (sender as TextBox).Text;
            if (textBoxPesel.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^[0-9]{1,11}$"))
                {
                    MessageBox.Show("Wpisany przez Ciebie Pesel musi skladac sie dokladnie z 11 cyfr");
                    textBoxPesel.Text = "";
                }
            }
        }

        private void ValiNazwisko(object sender, TextChangedEventArgs e)
        {
            string input = (sender as TextBox).Text;
            if (textBoxNazwisko.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^[A-Z]{1}[a-z]{1,48}$"))//najdluzsze zanotowane nazwisko liczylo 48 znakow, a najkrotsze 1 
                {

                    MessageBox.Show("Pole Nazwisko ma limit ustawiony na 50 znakow. \nNie moze zawierac znakow specjalnych i cyfr.\nMusi zaczynac sie z duzej litery");
                    textBoxNazwisko.Text = "";
                }
            }
        }
        private void ValiImie(object sender, TextChangedEventArgs e)
        {
            string input = (sender as TextBox).Text;
            if (textBoxImie.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^[A-Z]{1}[a-z]{1,81}$"))//najdluzsze imie liczy 81znakow, najkrotsze 1 znak
                {

                    MessageBox.Show("Pole Imie ma limit ustawiony na 50 znakow. \nNie moze zawierac znakow specjalnych i cyfr.\nMusi zaczynac sie z duzej litery");
                    textBoxImie.Text = "";
                }
            }
        }
        private void ValiNumer(object sender, TextChangedEventArgs e)
        {
            string input = (sender as TextBox).Text;
            if (textBoxNumer.Text.Length > 9)
            {
                if (!Regex.IsMatch(input, @"^[0-9]{9,22}$"))//najdluzszy numer ponoc moze miec 22 znaki
                {
                    MessageBox.Show("Wpisywany przez Ciebie Numer musi skladac sie z 9-22 cyfr.\nNie dopisuj + !\nNie uzywaj spacji!");
                    textBoxNumer.Text = "";
                }
            }
        }
        private void ValiAdress(object sender, TextChangedEventArgs e)
        {
            string input = (sender as TextBox).Text;
            if (textBoxAdress.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^([A-Z]{1}[a-z0-9\s/]{1,81})$"))
                {

                    MessageBox.Show("Pole Adres ma limit ustawiony na 81 znakow. \nNie moze zawierac znakow specjalnych ('/').\nMusi zaczynac sie z duzej litery");
                    textBoxAdress.Text = "";
                }
            }
        }
        private void ValiMiasto(object sender, TextChangedEventArgs e)
        {
            string input = (sender as TextBox).Text;
            if (textBoxMiasto.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^[A-Z]{1}[a-z]{1,85}$"))//najdluzsze nazwa osady liczy sobie 85 znakow , najkrotsza 1
                {

                    MessageBox.Show("Pole Miasto ma limit ustawiony na 85 znakow. \nNie moze zawierac znakow specjalnych i cyfr.\nMusi zaczynac sie z duzej litery");
                    textBoxMiasto.Text = "";
                }
            }
        }
    }


}
