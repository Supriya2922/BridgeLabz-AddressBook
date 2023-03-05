using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace AddressBook
{

    public class AddressBook
    {
        public static string file = @"D:\BridgeLabz_AddressBook\BridgeLabz-AddressBook\AddressBook\EmployeeDetails.txt";
      
        
        //list to create multiple contacts
        public List<Contact> addressBook = new List<Contact>();
        public static Dictionary<string, List<Contact>> addressBookCollection = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> cityDict = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> stateDict = new Dictionary<string, List<Contact>>();

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

            if (!addressBook.Any(contact => contact.Equals(newContact)))
            {
                addressBook.Add(newContact);
                string text = $" \nFirst Name: {newContact.firstName}\n Last Name:{newContact.lastName}\nAdress:{newContact.address}\nCity:{newContact.city}\nState:{newContact.state}\nZipCode:{newContact.zipcode}\nPhone number:{newContact.phone}\nEmail:{newContact.email}\n\n";
                File.AppendAllText(file, text ,Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("Contact already exists with the same name");
            }

        }

        public void displayContacts()
        {
            foreach (Contact contact in addressBook)
            {
                Console.WriteLine("First Name :" + contact.firstName);
                Console.WriteLine("Last Name :" + contact.lastName);
                Console.WriteLine("Address :" + contact.address);
                Console.WriteLine("City :" + contact.city);
                Console.WriteLine("State :" + contact.state);
                Console.WriteLine("ZipCode :" + contact.zipcode);
                Console.WriteLine("Phone number :" + contact.phone);
                Console.WriteLine("Email:" + contact.email);
                Console.WriteLine("--------------------------------");
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
                if (contact.firstName.ToLower() == firstname.ToLower() && contact.lastName.ToLower() == lastname.ToLower())
                {
                    addressBook.Remove(contact);
                    Console.WriteLine("Deleted successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("Contact not found");
                }
            }

        }
        public void ContactOperations()
        {
            Console.WriteLine("\nSelect an option");
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
                    ContactOperations();
                    break;
                case 2:
                    Console.WriteLine("Enter the first name and last name of the contact to edit");
                    string firstname = Console.ReadLine();
                    string lastname = Console.ReadLine();
                    this.EditContact(firstname, lastname);
                    this.ContactOperations();
                    break;
                case 3:
                    Console.WriteLine("Enter the first name and last name of the contact to delete");
                    string fname = Console.ReadLine();
                    string lname = Console.ReadLine();
                    this.DeleteContact(fname, lname);
                    this.ContactOperations();
                    break;
                case 4:
                    this.displayContacts();
                    this.ContactOperations();
                    break;
                default:
                    break;
            }
        }

        public static void addMultipleAddressBooks(AddressBook book)
        {
            Console.WriteLine("Enter the name of the Address Book");
            string name = Console.ReadLine();
            string text = $"Address Book : {name}";
            File.AppendAllText(file, text, Encoding.UTF8);
            book.ContactOperations();
            if (!addressBookCollection.ContainsKey(name))
            {
                addressBookCollection.Add(name, book.addressBook);
            }

        }
        public static void searchPersonAcrossMultipleAddressBooks()
        {
            Console.WriteLine("Enter the city to be searched in");
            string searchCity = Console.ReadLine();
            Console.WriteLine("Enter the state to be searched in");
            string searchState = Console.ReadLine();
            List<List<Contact>> contacts = new List<List<Contact>>();
            foreach (string book in addressBookCollection.Keys)
            {
                var contact = addressBookCollection[book];
                contacts.Add(contact);

            }
            Console.WriteLine("Contact names present in the city are:");

            foreach (var contact in contacts)
            {

                var personlist = contact.Where(x => x.city == searchCity && x.state == searchState);
                var names = personlist.Select(x => x.firstName).ToList();

                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
        }
        public static void ViewPersonByStateOrCity()
        {
            Console.WriteLine("Select an option(view by state or city)");
            Console.WriteLine("1.View by City");
            Console.WriteLine("2.View by State");
           
            int choice = Convert.ToInt32(Console.ReadLine());
            List<List<Contact>> addressBooks = new List<List<Contact>>();
            foreach (string book in addressBookCollection.Keys)
            {
                var contact = addressBookCollection[book];
                addressBooks.Add(contact);

            }
            switch (choice)
            {
                case 1:
                   foreach(var contact in addressBooks) {

                    foreach(Contact person in contact)
                        {
                            if (!cityDict.ContainsKey(person.city))
                            {
                                cityDict.Add(person.city, new List<Contact>());
                            }
                            cityDict[person.city].Add(person);
                        }

                    }
                   foreach(var (key,val) in cityDict)
                    {
                        Console.WriteLine("\nContacts found in City name " +key+" are :");
                       foreach(var contact in val)
                        {
                            Console.WriteLine("\nName :"+contact.firstName+" "+contact.lastName);
                            Console.WriteLine("Phone number:" + contact.phone);
                            Console.WriteLine("City:" + contact.city);
                        }
                    }
                    break;
                case 2:
                    foreach (var contact in addressBooks)
                    {

                        foreach (Contact person in contact)
                        {
                            if (!stateDict.ContainsKey(person.state))
                            {
                                stateDict.Add(person.state, new List<Contact>());
                            }
                            stateDict[person.state].Add(person);
                        }

                    }
                    foreach (var (key, val) in stateDict)
                    {
                        Console.WriteLine("\nContacts found in State name " + key + " are :");
                        foreach (var contact in val)
                        {
                            Console.WriteLine("\nName :" + contact.firstName + " " + contact.lastName);
                            Console.WriteLine("Phone number:" + contact.phone);
                            Console.WriteLine("State:" + contact.state);
                        }
                    }
                    break;


            }

            
        }
        public static void CountByCityOrState()
        {
            List<Contact> addressBooks = new List<Contact>();
            foreach (string book in addressBookCollection.Keys)
            {
                var contact = addressBookCollection[book];
                foreach (var c in contact)
                    addressBooks.Add(c);

            }

            Console.WriteLine("\nCount of contacts in each city and state are:");
         
                var cityGroup=addressBooks.GroupBy(x=> x.city);
                var stateGroup=addressBooks.GroupBy(x=> x.state);
                Console.WriteLine("\nCity    Count");
                foreach (var group in cityGroup)
                {
                    Console.WriteLine("{0}       {1}", group.Key, group.Count());
                }
                Console.WriteLine("\nState   Count");
                foreach (var group in stateGroup)
                {
                    Console.WriteLine("{0}       {1}", group.Key, group.Count());
                }

            

           

        }
        public static void SortByParameter(string parameter)
        {
            List<Contact> addressBooks = new List<Contact>();
            foreach (string book in addressBookCollection.Keys)
            {
                var contact = addressBookCollection[book];
                foreach (var c in contact)
                    addressBooks.Add(c);

            }
            if (parameter == "city") {
                addressBooks.Sort((person1, person2) => person1.city.CompareTo(person2.city));
            }
            else if(parameter=="state")
            {
                addressBooks.Sort((person1, person2) => person1.state.CompareTo(person2.state));
            }
            else
            {
                addressBooks.Sort((person1, person2) => person1.zipcode.CompareTo(person2.zipcode));
            }
            Console.WriteLine("Contacts sorted  according to "+parameter);
            foreach (var contact in addressBooks)
            {
                Console.WriteLine(contact.ToString());
            }
        }
        public static void SortByName()
        {
            List<Contact> addressBooks = new List<Contact>();
            foreach (string book in addressBookCollection.Keys)
            {
                var contact = addressBookCollection[book];
                foreach(var c in contact)
                    addressBooks.Add(c);

            }
           
                addressBooks.Sort((person1, person2) => person1.firstName.CompareTo(person2.firstName));
            
            
            Console.WriteLine("Contacts sorted alphabetically according to First name");
            
            foreach(var contact in addressBooks)
            {
                Console.WriteLine(contact.ToString());
            }
        }
        public static void SortByCityStateZip()
        {
            Console.WriteLine("Enter the parameter to be ");
            Console.WriteLine("\n1.City\n2.State\n3.Zip\n4.Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    SortByParameter("city");
                    break;
                case 2:
                    SortByParameter("state");
                    break;
                case 3:
                    SortByParameter("zip");
                    break;
            }
        }
        public  void TextFileIO()
        {
            Console.WriteLine("\nDo you want to Read / Write the file?");
            Console.WriteLine("1.Read");
            Console.WriteLine("2.Write");
            int choice=Convert.ToInt32(Console.ReadLine());
           
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Contents of file are:");
                    if (File.Exists(file))
                    {
                        StreamReader Textfile = new StreamReader(file);
                        string line;
                        while ((line = Textfile.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }

                        Textfile.Close();

                    }
                    break;
                    case 2:
                    this.AddContact();
                    break;
            }
           
        }
        public void CSVFileIO()
        {
            Console.WriteLine("\nDo you want to Read / Write the file?");
            Console.WriteLine("1.Read");
            Console.WriteLine("2.Write");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var reader = new StreamReader("D:\\BridgeLabz_AddressBook\\BridgeLabz-AddressBook\\AddressBook\\EmployeeDetails.csv");
                    var csvreader = new CsvReader(reader, CultureInfo.InvariantCulture);
                    var csv = csvreader.GetRecords<Contact>();
                    foreach (var obj in csv)
                    {
                        Console.WriteLine($"Contact \nFirst Name: {obj.firstName}\n Last Name:{obj.lastName}\nAddress:{obj.address} \nCity:{obj.city}\nState:{obj.state}\nZipcode:{obj.zipcode}\nPhone number:{obj.phone}\nEmail:{obj.email}\n\n");
                    }
                    reader.Dispose();
                    csvreader.Dispose();
                    break;

                case 2:
                    var writer = new StreamWriter("D:\\BridgeLabz_AddressBook\\BridgeLabz-AddressBook\\AddressBook\\EmployeeDetails.csv");
                    var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
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
                    addressBook.Add(newContact);
                    csvwriter.WriteRecords(addressBook);
                    csvwriter.Dispose();
                    writer.Dispose();
                    break;
            }

        }
        public void JsonFileIO()
        {
            Console.WriteLine("\nDo you want to Read / Write the file?");
            Console.WriteLine("1.Read");
            Console.WriteLine("2.Write");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var reader = File.ReadAllText("D:\\BridgeLabz_AddressBook\\BridgeLabz-AddressBook\\AddressBook\\EmployeeDetails.json");
                    var dict=JsonConvert.DeserializeObject<Dictionary<string,List<Contact>>>(reader);
                    foreach(var (key,val) in dict)
                    {
                        Console.WriteLine(key);
                        foreach(var v in val)
                        {
                            Console.WriteLine(v.firstName);
                            Console.WriteLine(v.lastName);
                            Console.WriteLine(v.address);
                            Console.WriteLine(v.city);
                            Console.WriteLine(v.state);
                            Console.WriteLine(v.zipcode);
                            Console.WriteLine(v.phone);
                            Console.WriteLine(v.email);
                            Console.WriteLine();
                        }
                    }
                    break;
                    case 2:
                    Console.WriteLine("Enter name of the address book:");
                    string name=Console.ReadLine();
                    string fileloc = "D:\\BridgeLabz_AddressBook\\BridgeLabz-AddressBook\\AddressBook\\EmployeeDetails.json";
                    this.AddContact();
                    if (addressBookCollection.ContainsKey(name))
                    {

                        addressBookCollection[name] = this.addressBook;
                    }
                    else
                    {
                        addressBookCollection.Add(name, this.addressBook);
                    }
                    var json = JsonConvert.SerializeObject(addressBookCollection);
                    File.WriteAllText(fileloc, json);
                    break;
            }
           
           
        }
    }
}
        

    
    

