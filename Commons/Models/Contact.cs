using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<ContactNumber> ContactNumbers { get; set; }


    }
}
