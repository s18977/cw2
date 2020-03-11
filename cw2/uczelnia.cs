using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    class Uczelnia
    {
        public string createdAt { get; set; }
        public string author { get; set; }
        public List<Person> studenci { get; set; }
        public Hashtable activeStudies { get; set; }
    }
}
