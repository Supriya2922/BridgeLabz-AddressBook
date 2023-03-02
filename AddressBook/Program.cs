namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            while (true)
            {
                Console.WriteLine("Select an option");
                Console.WriteLine("1.Add Contact");
                Console.WriteLine("2.Edit Contact");
                Console.WriteLine("3.Delete");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        addressBook.AddContact();
                        break;
                    case 2:
                        Console.WriteLine("Enter the first name and last name of the contact to edit");
                        string firstname=Console.ReadLine();
                        string lastname=Console.ReadLine();
                        addressBook.EditContact(firstname, lastname);
                        break;
                    case 3:
                        Console.WriteLine("Enter the first name and last name of the contact to delete");
                        string fname = Console.ReadLine();
                        string lname = Console.ReadLine();
                        addressBook.DeleteContact(fname, lname);
                        break;
                }
            }
        }
    }
}