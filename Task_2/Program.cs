using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task_2
{
    internal class Program
    {
        static void Main()
        {

            var doc = new XmlDocument();
            doc.Load("books.xml");


            XmlNode node = doc.DocumentElement;



            Console.WriteLine(node.LocalName);
            Console.WriteLine(new String('=', 50));

            foreach (XmlNode item in node.ChildNodes)
            {
                Console.WriteLine(item.Name + ": " + item.InnerText);

                if (item.Attributes.Count != 0)
                {
                    foreach (XmlNode atr in item.Attributes)
                    {
                        Console.WriteLine("\tТелефон: " + atr.InnerText);
                    }
                }
                Console.WriteLine(new String('-',50));
            }









            Console.ReadKey();

        }
    }
}
