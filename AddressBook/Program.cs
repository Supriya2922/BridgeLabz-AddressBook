namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook1 = new AddressBook();
            AddressBook addressBook2 = new AddressBook();
           
            AddressBook.addMultipleAddressBooks(addressBook1);
            AddressBook.addMultipleAddressBooks(addressBook2);
           
        }
        }
    }
