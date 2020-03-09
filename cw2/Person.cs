using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    public class Person
    {
        public string index { get; set; }
        public string firstName { get; set; }
        public string  lastName { get; set; }
        public DateTime birth { get; set; }
        public string email { get; set; }
        public string mother { get; set; }
        public string father { get; set; }
        public string studies { get; set; }
        public string mode { get; set; }

        public virtual string ToString()
        {
            return "index: " + index
                + " Imie " + firstName
                + " Nazwisko " + lastName 
                + " Data " + birth
                + " mail " + email
                + " mother " + mother
                + " father " + father
                + " studies " + studies
                + " mode " + mode;
        }
    }
}
