namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select option:");
                Console.WriteLine("1.Add address book");
                Console.WriteLine("2.Search for contact across multiple address books");
                Console.WriteLine("3.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of address books that you want to add.");
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
                        Environment.Exit(0);
                        break;
                }
            }
           
        }
        }
    }
