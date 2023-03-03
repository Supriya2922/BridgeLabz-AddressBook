using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
   
    public class AddressBook
    {

        //list to create multiple contacts
        public List<Contact> addressBook= new List<Contact>();

        public static Dictionary<string, List<Contact>> addressBookCollection = new Dictionary<string, List<Contact>>();

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

            Contact newContact = new Contact(firstName, lastName, address, city, state, pincode, phone, email);
          
                if(!addressBook.Any(contact => contact.Equals(newContact)))
                {
                    addressBook.Add(newContact);
                }
                else
                {
                    Console.WriteLine("Contact already exists with the same name");
                }
            
        }
       
        public void displayContacts()
        {
            foreach(Contact contact in addressBook)
            {
                Console.WriteLine(contact.firstName);
            }
        }
        public void EditContact(string firstname, string lastname)
        {


            foreach (Contact contact in addressBook)
            {
                if (contact.firstName == firstname && contact.lastName == lastname)
                {
                    Console.WriteLine("Choose a field which you want to edit");
                    Console.WriteLine("1.Name \n2.Address \n3.Phone Number \n4.Email");
                    int editField = Convert.ToInt32(Console.ReadLine());
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
        public void DeleteContact(string firstname, string lastname)
        {

            foreach (Contact contact in addressBook)
            {
                if (contact.firstName == firstname && contact.lastName == lastname)
                {
                    addressBook.Remove(contact);
                    Console.WriteLine("Deleted successfully");
                    break;
                }
            }
            
        }
        public void askUser()
        {
            Console.WriteLine("Select an option");
            Console.WriteLine("1.Add Contact");
            Console.WriteLine("2.Edit Contact");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.Display ");
            Console.WriteLine("5.Exit");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:

                    this.AddContact();
                    askUser();
                    break;
                case 2:
                    Console.WriteLine("Enter the first name and last name of the contact to edit");
                    string firstname = Console.ReadLine();
                    string lastname = Console.ReadLine();
                    this.EditContact(firstname, lastname);
                    this.askUser();
                    break;
                case 3:
                    Console.WriteLine("Enter the first name and last name of the contact to delete");
                    string fname = Console.ReadLine();
                    string lname = Console.ReadLine();
                    this.DeleteContact(fname, lname);
                    this.askUser();
                    break;
                case 4:
                    this.displayContacts();
                    this.askUser();
                    break;
                default:
                    break;
            }
        }

        public static void addMultipleAddressBooks(AddressBook book)
        {
            Console.WriteLine("Enter the name of the Address Book");

            string name = Console.ReadLine();

            book.askUser();
            if (!addressBookCollection.ContainsKey(name))
            {
                addressBookCollection.Add(name, book.addressBook);
            }

        }



    }
    
}
