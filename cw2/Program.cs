using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace cw2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //lokalizacja pliku csv
            var csvFile = @"C:\Users\Steking\Desktop\dane.csv";
            //var xmlFile = args[1];

            //lokalizacja pliku logFile
            var logFile = @"C:\Users\Steking\Desktop\log.txt";

            var lines = File.ReadLines(csvFile);

            //listy do wypisywania osob w log i xml
            List<Person> personList = new List<Person>();
            List<Person> errorList = new List<Person>();
            var counter = 0;
            var tmp2 = new Person();

            Hashtable std = new Hashtable();
            int numOfStudents = 0;

            int[] counterOfStudents = new int[2]; 

            foreach (var line in lines)
            {
                counter = 0;
                var readed = line.Split(",");


                //sprawdzenie czy jest 9 kolumn
                for (int i = 0; i < readed.Length; i++)
                {
                    if (!(readed[i].Length == 0))
                    {
                        counter++;
                    }

                }

                Person tmp = new Person
                {
                    firstName = readed[0],
                    lastName = Regex.Replace(readed[1], @"[\d-]", ""),
                    studies = readed[2],
                    mode = readed[3],
                    index = readed[4],
                    birth = DateTime.Parse(readed[5]),
                    email = readed[6],
                    mother = readed[7],
                    father = readed[8]
                };

                if (tmp2.index == readed[4] && counter != 0)
                {
                    //Console.WriteLine("Kopia");
                    errorList.Add(tmp);
                }
                else
                {
                    if (counter == 9)
                    {
                        personList.Add(tmp);
                    }
                    else
                    {
                        errorList.Add(tmp);
                    }
                }

                tmp2 = tmp;
            }

            //zapis bledow do pliku
            using (StreamWriter sw = new StreamWriter(logFile))
            {
                foreach (Person person in errorList)
                {
                    sw.WriteLine(person.ToString());
                }
            }

            foreach (Person person in personList)
            {
                if (!std.ContainsKey(person.studies))
                {
                    foreach (Person tmpP in personList)
                    {
                        if (tmpP.studies == person.studies)
                        {
                            numOfStudents++;
                        }
                    }
                    std.Add(person.studies, numOfStudents);
                }
            }

            xmlCreate tmpX = new xmlCreate();
            tmpX.createFile(personList, std);

        }
    }
}
