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
using Microsoft.Win32;

namespace Laby4
{
    /// <summary>
    /// Logika interakcji dla klasy Modyfikacja.xaml
    /// </summary>
    public partial class Modyfikacja : Window
    {
        public Modyfikacja(int item)
        {
            int klucz = item;
            InitializeComponent();
            textBoxPesel.Text = MainWindow.PersonList[klucz].Pesel;
            textBoxNazwisko.Text = MainWindow.PersonList[klucz].Lastname;
            textBoxImie.Text = MainWindow.PersonList[klucz].Firstname;
            textBoxNumer.Text = MainWindow.PersonList[klucz].Phone;
            textBoxAdress.Text = MainWindow.PersonList[klucz].Adress;
            textBoxMiasto.Text = MainWindow.PersonList[klucz].City;
            x.Content = klucz;
            imgDynamic.Source = MainWindow.PersonList[klucz].Image;
        }

        private void Modify(object sender, RoutedEventArgs e)
        {
            MainWindow.PersonList[Convert.ToInt32(x.Content)].Pesel = textBoxPesel.Text;
            MainWindow.PersonList[Convert.ToInt32(x.Content)].Lastname = textBoxNazwisko.Text;
            MainWindow.PersonList[Convert.ToInt32(x.Content)].Firstname = textBoxImie.Text;
            MainWindow.PersonList[Convert.ToInt32(x.Content)].Phone = textBoxNumer.Text;
            MainWindow.PersonList[Convert.ToInt32(x.Content)].Adress = textBoxAdress.Text;
            MainWindow.PersonList[Convert.ToInt32(x.Content)].City = textBoxMiasto.Text;
            MainWindow.PersonList[Convert.ToInt32(x.Content)].Image = (BitmapImage)imgDynamic.Source;
            this.Close();
        }

        private void ImageLoad(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                string filePath;
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog.Filter = "PNG Image | *.png";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == true)
                {

                    filePath = openFileDialog.FileName;
                    Uri uri = new Uri(filePath);
                    imgDynamic.Source = new BitmapImage(uri);

                }
            }
        }

    }
}
