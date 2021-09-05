using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Dto
{
    public class ContactGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
