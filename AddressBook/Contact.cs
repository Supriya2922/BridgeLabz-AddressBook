using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public long zipcode { get; set; }

        public Contact(string firstName, string lastName, string address, string city, string state, long zipcode, long phone, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            this.phone = phone;
            this.email = email;
        }
    }
}
