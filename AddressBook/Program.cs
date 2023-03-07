using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
          
          
            //Command object
            
            while (true)
            {
                Console.WriteLine("\nSelect option:");
                Console.WriteLine("1.Add address book");
                Console.WriteLine("2.Search for contact across multiple address books");
                Console.WriteLine("3.View Contacts by city or state");
                Console.WriteLine("4.Count by city or state");
                Console.WriteLine("5.Sort entries alphbetically");
                Console.WriteLine("6.Sort entries according to zip,state,city");
                Console.WriteLine("7.Read or Write Contacts using File IO");
                Console.WriteLine("8.Read or Write Contacts using CSV Helper");
                Console.WriteLine("9.Read or Write Contacts using JSON");
                Console.WriteLine("10.Retrieve Contacts on particular date");
                Console.WriteLine("11.Retrieve Count of contacts by city or state from database");

                AddressBookClass book= new AddressBookClass();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter the number of address books that you want to add.");
                        int n = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            AddressBookClass addressBook = new AddressBookClass();
                            AddressBookClass.addMultipleAddressBooks(addressBook);
                        }
                        break;
                    case 2:
                        AddressBookClass.searchPersonAcrossMultipleAddressBooks();
                        break;
                    case 3:
                        AddressBookClass.ViewPersonByStateOrCity();
                        break;
                    case 4:
                        AddressBookClass.CountByCityOrState();
                        break;
                    case 5:
                        AddressBookClass.SortByName();
                        break;
                    case 6:
                        AddressBookClass.SortByCityStateZip();
                        break;
                    case 7:
                       
                        book.TextFileIO();
                        break;
                    case 8:
                        book.CSVFileIO();
                        break;
                    case 9:
                        AddressBookClass addressBook1 = new AddressBookClass();
                        addressBook1.JsonFileIO(); break;
                    case 10:
                        AddressBookClass.RetrieveContactFromDataBaseAddedInParticularDate();
                        
                        break;
                    case 11:
                        AddressBookClass.CountOfContactsByCity();
                        AddressBookClass.CountOfContactsByState();
                        break;
                    case 12:
                        Environment.Exit(0);
                        break;
                }
            }
           
        }
        }
    }
