using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighlightSearchedTextInListview
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
   
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string firstname,string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }
    }
}
