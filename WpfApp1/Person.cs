using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(string firstname, string lastname, int age)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
        }
        public Person()
        {
        }
        public static void WriteXML(List<Person> person)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (FileStream stream = new FileStream("Personen.xml", FileMode.Create))
            {
                serializer.Serialize(stream, person);
            }
        }
        public static List<Person> ReadXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            using (StreamReader sr = new StreamReader("Personen.xml"))
            {
                return (List<Person>)serializer.Deserialize(sr);
            }


        }
        public static string returnString(Person p)
        {
            string output = p.FirstName + " " + p.LastName + " " + p.Age.ToString();

            
            return output;
        }
    }
}
