using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Task_6
{
    internal class Program
    {
        static void Main()
        {


            var writet = new XmlTextWriter("books.xml", null);

            writet.Formatting = Formatting.Indented;
            writet.IndentChar = '\t';
            writet.Indentation = 1;
            writet.QuoteChar = '\'';



            writet.WriteStartDocument();
            writet.WriteStartElement("MyContacts");
            writet.WriteStartElement("Contact");
            writet.WriteStartAttribute("TelephoneNumber");
            writet.WriteString("+380971763849");
            writet.WriteEndAttribute();
            writet.WriteString("Valera");
            writet.WriteEndElement();
            writet.WriteEndElement();

            writet.Close();

            Console.WriteLine("В файл все записанно!");

            var xmlFile = new XmlDocument();
            xmlFile.Load("books.xml");
            XPathNavigator nav = xmlFile.CreateNavigator();
            nav.MoveToChild("MyContacts", "");
            nav.AppendChild("<Contact TelephoneNumber='+3809345632849'>Jonson</Contact>");
            xmlFile.Save("books.xml");

            Console.WriteLine("В файл отредактированно!");

            Console.ReadKey();

        }
    }
}
