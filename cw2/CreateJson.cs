using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace cw2
{
    class CreateJson
    {
        public Uczelnia uczelnia { get; set; }
        public void CreateFile(List<Student> person, Hashtable std, string jsonPath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            CreateJson tmp = new CreateJson
            {
                uczelnia = new Uczelnia()
                {
                    createdAt = DateTime.Today.Date.ToString("d"),
                    author = "Bartłomiej Stocki",
                    studenci = person,
                    activeStudies = std

                }
            };

            var jsonString = JsonSerializer.Serialize(tmp, options);

            File.WriteAllText(jsonPath + @"\result.json", jsonString);

            Console.WriteLine("JSON file created!");
        }
    }
}
