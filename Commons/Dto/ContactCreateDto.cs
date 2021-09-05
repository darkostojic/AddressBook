using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Dto
{
    public class ContactCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> ContactNumbers { get; set; }
    }
}
