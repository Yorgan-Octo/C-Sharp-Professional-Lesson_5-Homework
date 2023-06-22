using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task_3
{
    internal class Program
    {
        static void Main()
        {

            var contact = new XmlDocument();
            contact.Load("books.xml");


            XmlNode xmlNode = contact.DocumentElement;


            foreach (XmlNode con in xmlNode.ChildNodes)
            {

                foreach (XmlNode namber in con.Attributes)
                {
                    Console.WriteLine("Номер телефона: " + namber.InnerText);
                }
            }


            Console.ReadKey();


        }
    }
}
