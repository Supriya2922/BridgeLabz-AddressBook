using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using System.Text;

using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace AddressBook
{

    public class AddressBookClass
    {
        public static string file = @"D:\BridgeLabz_AddressBook\BridgeLabz-AddressBook\AddressBook\EmployeeDetails.txt";
      
        //list to create multiple contacts
        public List<Contact> addressBook = new List<Contact>();
        public static Dictionary<string, List<Contact>> addressBookCollection = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> cityDict = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> stateDict = new Dictionary<string, List<Contact>>();
        public static string connString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
        public  bool AddContactTest(Contact newContact,string name="Home")
        {

          //  string connectionString = "Data Source=SUPRIYA-ENG;Initial Catalog=AddressBookSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAddContact";
           
            if (!addressBook.Any(contact => contact.Equals(newContact)))
            {
                addressBook.Add(newContact);
               cmd.Parameters.Add(new SqlParameter("@fname", newContact.firstName));
                cmd.Parameters.Add(new SqlParameter("@lname", newContact.lastName));
                cmd.Parameters.Add(new SqlParameter("@address", newContact.address));
                cmd.Parameters.Add(new SqlParameter("@city", newContact.city));
                cmd.Parameters.Add(new SqlParameter("@state", newContact.state));
                cmd.Parameters.Add(new SqlParameter("@zipcode", newContact.zipcode));
                cmd.Parameters.Add(new SqlParameter("@phone", newContact.phone));
                cmd.Parameters.Add(new SqlParameter("@email", newContact.email));
                cmd.Parameters.Add(new SqlParameter("@category", name));
                int rows = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            else
            {
                Console.WriteLine("Contact already exists with the same name");
            }
            
            return false;
        }
        public void AddContact(string addressbookname)
        {
            
            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = sqlConnection;
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

            sqlConnection.Open();
           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAddContact";
            cmd.Parameters.Add(new SqlParameter("@fname", firstName));
            cmd.Parameters.Add(new SqlParameter("@lname", lastName));
            cmd.Parameters.Add(new SqlParameter("@address", address));
            cmd.Parameters.Add(new SqlParameter("@city", city));
            cmd.Parameters.Add(new SqlParameter("@state", state));
            cmd.Parameters.Add(new SqlParameter("@zipcode", pincode));
            cmd.Parameters.Add(new SqlParameter("@phone", phone));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@category", addressbookname));
            //@fname,@lname,@address,@city,@state,@zipcode,@phone,@email,@category

            if (!addressBook.Any(contact => contact.Equals(newContact)))
            {
                addressBook.Add(newContact);
                string text = $" \nFirst Name: {newContact.firstName}\n Last Name:{newContact.lastName}\nAdress:{newContact.address}\nCity:{newContact.city}\nState:{newContact.state}\nZipCode:{newContact.zipcode}\nPhone number:{newContact.phone}\nEmail:{newContact.email}\n\n";
                File.AppendAllText(file, text ,Encoding.UTF8);
                int rows = cmd.ExecuteNonQuery();

            }
            else
            {
                Console.WriteLine("Contact already exists with the same name");
            }
            sqlConnection.Close();
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
        public bool EditContactTest(string firstname, string lastname)
        {
            foreach (Contact contact in addressBook)
            {
                if (contact.firstName == firstname && contact.lastName == lastname)
                {
                    return true;
                }
            }
            return false;
        }
        public void EditContact(string firstname, string lastname)
        {

            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = sqlConnection;

            foreach (Contact contact in addressBook)
            {
                if (contact.firstName == firstname && contact.lastName == lastname)
                {

                            Console.WriteLine("Enter first name :");
                            contact.firstName = Console.ReadLine();

                            Console.WriteLine("Enter last name :");
                            contact.lastName = Console.ReadLine();

                            Console.WriteLine("Enter address :");
                            contact.address = Console.ReadLine();
                            Console.WriteLine("Enter city :");
                            contact.city = Console.ReadLine();
                            Console.WriteLine("Enter state :");
                            contact.state = Console.ReadLine();
                            Console.WriteLine("Enter pincode :");
                            contact.zipcode = Convert.ToInt64(Console.ReadLine());

                            Console.WriteLine("Enter updated Phone number :");
                            contact.phone = Convert.ToInt64(Console.ReadLine());

                            Console.WriteLine("Enter new email id :");
                            contact.email = Console.ReadLine();
                    sqlConnection.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdateContact";
                    cmd.Parameters.Add(new SqlParameter("@fname", contact.firstName));
                    cmd.Parameters.Add(new SqlParameter("@lname", contact.lastName));
                    cmd.Parameters.Add(new SqlParameter("@address", contact.address));
                    cmd.Parameters.Add(new SqlParameter("@city", contact.city));
                    cmd.Parameters.Add(new SqlParameter("@state", contact.state));
                    cmd.Parameters.Add(new SqlParameter("@zipcode",contact.zipcode));
                    cmd.Parameters.Add(new SqlParameter("@phone", contact.phone));
                    cmd.Parameters.Add(new SqlParameter("@email", contact.email));
                    int rows = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if(rows>0)
                    {
                        Console.WriteLine("Contact updated successfully");
                    }
                    else
                        Console.WriteLine("Contact was not updated ");
                }

              
                foreach (string book in addressBookCollection.Keys)
                {
                    var contacts = addressBookCollection[book];
                    foreach (var c in contacts)
                    {
                       
                            foreach(var con in addressBook)
                            {
                            if (c.firstName == firstname && c.lastName == lastname && con.firstName == firstname && con.lastName == lastname)
                            {
                                addressBookCollection[book].Add(con);
                            }
                            
                            }
                    }

                }

            }
               
            
           
        }
        public bool DeleteContact(string firstname, string lastname)
        {

            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "delete from Contacts where FirstName=@fname and LastName=@lname";
            cmd.Parameters.AddWithValue("@fname", firstname);
            cmd.Parameters.AddWithValue("@lname", lastname);
            sqlConnection.Open();
            foreach (Contact contact in addressBook)
            {
                if (contact.firstName.ToLower() == firstname.ToLower() && contact.lastName.ToLower() == lastname.ToLower())
                {
                    addressBook.Remove(contact);
                    Console.WriteLine("Deleted successfully");
                    int r = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("Contact not found");
                }
            }
            return false;

        }
        public void ContactOperations(string name)
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

                    this.AddContact(name);
                    ContactOperations(name);
                    break;
                case 2:
                    Console.WriteLine("Enter the first name and last name of the contact to edit");
                    string firstname = Console.ReadLine();
                    string lastname = Console.ReadLine();
                    this.EditContact(firstname, lastname);
                    this.ContactOperations(name);
                    break;
                case 3:
                    Console.WriteLine("Enter the first name and last name of the contact to delete");
                    string fname = Console.ReadLine();
                    string lname = Console.ReadLine();
                    this.DeleteContact(fname, lname);
                    this.ContactOperations(name);
                    break;
                case 4:
                    this.displayContacts();
                    this.ContactOperations(name);
                    break;
                default:
                    break;
            }
        }

        public static void addMultipleAddressBooks(AddressBookClass book)
        {
            Console.WriteLine("Enter the name of the Address Book");
            string name = Console.ReadLine();
            string text = $"Address Book : {name}";
            File.AppendAllText(file, text, Encoding.UTF8);
            book.ContactOperations(name);
            if (!addressBookCollection.ContainsKey(name))
            {
                addressBookCollection.Add(name, book.addressBook);
            }

        }
        public bool searchPersonTest(string city,string state)
        {
            List<List<Contact>> contacts = new List<List<Contact>>();
            foreach (string book in addressBookCollection.Keys)
            {
                var contact = addressBookCollection[book];
                contacts.Add(contact);

            }
            

            foreach (var contact in contacts)
            {

                var personlist = contact.Where(x => x.city == city && x.state == state);
                var names = personlist.Select(x => x.firstName).ToList();
                if (names.Count == 0)
                {
                    return false;
                }
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
            return true;
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
            Console.WriteLine("\n1.City\n2.State\n3.Zip\n");
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
                    
                    this.AddContact("Office");
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
                    this.AddContact(name);
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
        public static bool RetrieveContactFromDataBase(string fname, string lname)
        {
          
            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "select * from Contacts where FirstName=@fname and LastName=@lname";
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            sqlConnection.Open();
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool RetrieveContactFromDataBaseAddedInParticularDate()
        {
           
            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "select * from Contacts where Created_at=CAST(GETDATE() AS DATE) ";


            sqlConnection.Open();
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                foreach (DataRow ro in tb.Rows)
                {
                    Console.WriteLine($"{ro[0]}  {ro[1]}  {ro[2]}  {ro[3]}   {ro[4]}  {ro[5]} {ro[6]} {ro[7]} {ro[8]} {ro[9]}  ");
                }
                return true;
            }
            return false;
        }


    }
}
        

    
    

