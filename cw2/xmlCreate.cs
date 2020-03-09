using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace cw2
{
    public class xmlCreate
    {
        public void createFile(List<Person> list)
        {
            XmlTextWriter writer = new XmlTextWriter("product.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("uczelnia \n" +
                "createdAt= \"" +DateTime.Today.ToString() + "\"\n" +
                "author=\"Bartłomiej Stocki\"");
            writer.WriteStartElement("Studenci");
            foreach (Person person in list)
            {
                createNode(person.index, person.firstName, person.lastName, person.birth, person.email, person.mother, person.father, person.studies, person.mode, writer);
            }
            //writer.WriteEndElement();
            //writer.WriteStartElement("activeStudies");
            //writer.WriteStartElement("studies name = C numberOfStudents= 999");
            //writer.WriteStartElement("studies name = D numberOfStudents= 555");
            //writer.WriteEndElement();

            writer.WriteFullEndElement();

            writer.Close();

            Console.WriteLine("XML File Created!");
        }

        private void createNode(string index, string name, string lastName, DateTime birth, string email, string mother, string father, string studies, string mode, XmlTextWriter writer)
        {
            writer.WriteStartElement("student indexNumber=\"s" + index.ToString() + "\"");
            writer.WriteStartElement("fname");
            writer.WriteString(name);
            writer.WriteEndElement();

            writer.WriteStartElement("lname");
            writer.WriteString(lastName);
            writer.WriteEndElement();

            writer.WriteStartElement("birthdate");
            writer.WriteString(birth.Date.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("email");
            writer.WriteString(email);
            writer.WriteEndElement();

            writer.WriteStartElement("mothersname");
            writer.WriteString(mother);
            writer.WriteEndElement();

            writer.WriteStartElement("fathersname");
            writer.WriteString(father);
            writer.WriteEndElement();

            writer.WriteStartElement("studies");
            writer.WriteStartElement("name");
            writer.WriteString(studies.Replace(" dzienne", ""));
            writer.WriteEndElement();

            writer.WriteStartElement("mode");
            writer.WriteString(mode);
            writer.WriteEndElement();

            writer.WriteEndElement();        
            writer.WriteFullEndElement();        
        }
    }
}
