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
using System.Data;
using System.Xml;

namespace Laby4
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //XmlTextReader xmlReader = new XmlTextReader("People.xml");
            //while (xmlReader.Read())
            //{
            //    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Cube"))
            //    {
            //        if (xmlReader.HasAttributes)
            //            Console.WriteLine(xmlReader.GetAttribute("currency") + ": " + xmlReader.GetAttribute("rate"));
            //    }
            //}
            //Console.ReadKey();

            string sampleXmlFile = "People.xml";
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(sampleXmlFile);
            DataView dataView = new DataView(dataSet.Tables[0]);
            DataGrid1.ItemsSource = dataView;
        }
        private void Button_Click(object oSender, RoutedEventArgs eRoutedEventArgs)
        {
            FormularzDodawaniaUzytkownika win2 = new FormularzDodawaniaUzytkownika();
            win2.ShowDialog();
            //this.Close();
        }

        //private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    using (DataSet data = new DataSet()) 
        //    {
        //        data.ReadXml(Server.MapPath("`/Laby4/People.xml"));
        //        DataGrid1.DataSource
            
            
        //    }
        //}
    }
}
