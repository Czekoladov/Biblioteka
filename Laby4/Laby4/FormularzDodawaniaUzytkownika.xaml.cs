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
        public FormularzDodawaniaUzytkownika()
        {
            InitializeComponent();
        }
        public static void SerializePerson(Person per)
        {
            string filename = "Person.xml";

            var serializer = new XmlSerializer(typeof(Person));

            using (var stream = File.Open(filename, FileMode.Create))
            {
                serializer.Serialize(stream, per);
            }
        }

        public void ButtonSave_Click(object sender, EventArgs e)
        {
            //using (StreamWriter ksiazka += new StreamWriter("D:\\Archiwa\\"+textBoxAutor.Text+".txt"))
            //   {
            //       ksiazka.WriteLine("Data Archiwizacji");
            //       ksiazka.WriteLine(DateTime.Now.ToString());
            //       ksiazka.WriteLine("");
            //       ksiazka.WriteLine("Autor:"+textBoxAutor.Text);



            //   }
            Person osoba1 = (new Person("Monika", "Malec", "1952-04-02"));

            SerializePerson(osoba1);
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Pesel { get; set; }


        public Person()
        {

        }

        public Person(string firstname, string lastname, string pesel)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Pesel = pesel;
        }
        
    }

}
