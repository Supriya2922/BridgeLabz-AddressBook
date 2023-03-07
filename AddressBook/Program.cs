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
                Console.WriteLine("12.Display Contacts from the database");
                Console.WriteLine("13.Exit");
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
                        book.searchPersonAcrossMultipleAddressBooks();
                        break;
                    case 3:
                        book.ViewPersonByStateOrCity();
                        break;
                    case 4:
                        book.CountByCityOrState();
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
                        
                       book.JsonFileIO(); break;
                    case 10:
                        book.RetrieveContactFromDataBaseAddedInParticularDate();
                        
                        break;
                    case 11:
                        book.CountOfContactsByCity();
                        book.CountOfContactsByState();
                        break;
                    case 12:
                        book.DisplayContactsFromDatabase();
                        break;
                    case 13:
                        Environment.Exit(0);
                        break;
                }
            }
           
        }
        }
    }
