using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBook
    {

        public static List<Contact> addressBook = new List<Contact>();
        public void AddContact()
        {
            Console.WriteLine("Enter first name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter last name :");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter address :");
            string address = Console.ReadLine();

            Console.WriteLine("Enter city :");
            string city = Console.ReadLine();

            Console.WriteLine("Enter state :");
            string state = Console.ReadLine();

            Console.WriteLine("Enter pincode :");
            long pincode = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter phone number :");
            long phone = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter email : ");
            string email = Console.ReadLine();

             Contact newCcontact = new Contact(firstName, lastName, address, city, state, pincode, phone, email);
            addressBook.Add(newCcontact);

        }
        public void EditContact(string firstname,string lastname)
        {
            
              
            foreach(Contact contact in addressBook)
            {
                if(contact.firstName==firstname && contact.lastName==lastname)
                {
                    Console.WriteLine("Choose a field which you want to edit");
                    Console.WriteLine("1.Name \n2.Address \n3.Phone Number \n4.Email");
                    int editField=Convert.ToInt32(Console.ReadLine());
                    switch (editField)
                    {
                        case 1:
                            Console.WriteLine("Enter first name :");
                            contact.firstName = Console.ReadLine();

                            Console.WriteLine("Enter last name :");
                            contact.lastName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter address :");
                            contact.address = Console.ReadLine();
                            Console.WriteLine("Enter city :");
                            contact.city = Console.ReadLine();
                            Console.WriteLine("Enter state :");
                            contact.state = Console.ReadLine();
                            Console.WriteLine("Enter pincode :");
                            contact.zipcode = Convert.ToInt64(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter updated Phone number :");
                            contact.phone = Convert.ToInt64(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter new email id :");
                            contact.email = Console.ReadLine();
                            break;

                    }
                    Console.WriteLine("Contact updated successfully!");
                }
            }
        }
    }
}
