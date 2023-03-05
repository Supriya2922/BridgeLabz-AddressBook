﻿namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                AddressBook book= new AddressBook();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter the number of address books that you want to add.");
                        int n = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            AddressBook addressBook = new AddressBook();
                            AddressBook.addMultipleAddressBooks(addressBook);
                        }
                        break;
                    case 2:
                        AddressBook.searchPersonAcrossMultipleAddressBooks();
                        break;
                    case 3:
                        AddressBook.ViewPersonByStateOrCity();
                        break;
                    case 4:
                        AddressBook.CountByCityOrState();
                        break;
                    case 5:
                        AddressBook.SortByName();
                        break;
                    case 6:
                        AddressBook.SortByCityStateZip();
                        break;
                    case 7:
                       
                        book.TextFileIO();
                        break;
                    case 8:
                        book.CSVFileIO();
                        break;
                    case 9:
                        AddressBook addressBook1 = new AddressBook();
                        addressBook1.JsonFileIO(); break;
                    case 11:
                        Environment.Exit(0);
                        break;
                }
            }
           
        }
        }
    }
