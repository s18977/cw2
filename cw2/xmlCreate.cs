﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace cw2
{
    public class xmlCreate
    {  
        public int[] numberOfStudents { get; set; }
        public void createFile(List<Person> list, Hashtable std)
        {
            XmlTextWriter writer = new XmlTextWriter("product.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("uczelnia");
            writer.WriteAttributeString("\ncreatedAt", DateTime.Today.Date.ToString("d"));
            writer.WriteAttributeString("\nauthor", "Bartłomiej Stocki");
            writer.WriteStartElement("Studenci");
            foreach (Person person in list)
            {
                createNode(person.index, person.firstName, person.lastName, person.birth, person.email, person.mother, person.father, person.studies, person.mode, writer);
            }
            writer.WriteEndElement();
            writer.WriteStartElement("studies");

            foreach (DictionaryEntry de in std) {
                writer.WriteStartElement("studies");
                writer.WriteAttributeString("name", de.Key.ToString());
                writer.WriteAttributeString("numberOfStudents", de.Value.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.Close();

            Console.WriteLine("XML File Created!");
        }

        private void createNode(string index, string name, string lastName, DateTime birth, string email, string mother, string father, string studies, string mode, XmlTextWriter writer)
        {
            writer.WriteStartElement("student");
            writer.WriteAttributeString("indexNumber", index.ToString());
            writer.WriteStartElement("fname");
            writer.WriteString(name);
            writer.WriteEndElement();

            writer.WriteStartElement("lname");
            writer.WriteString(lastName);
            writer.WriteEndElement();

            writer.WriteStartElement("birthdate");
            writer.WriteString(birth.Date.ToString("d"));
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
            writer.WriteEndElement();        
        }
    }
}
