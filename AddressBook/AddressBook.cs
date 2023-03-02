using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBook
    {
        public void CreateContact()
        {
            string firstName = "Supriya";
            string lastName = "P";
            string address = "Halasuru";
            string city = "Bangalore";
            string state = "Karnataka";
            long pincode = 560008;
            long phone = 8765423232;
            string email = "ssu@gmail.com";
            Contact contact = new Contact(firstName, lastName, address, city, state, pincode, phone, email);


        }
    }
}
