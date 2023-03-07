using AddressBook;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace AddressBookTest
{
    [TestClass]
    public class AddressTest
    {
        AddressBookClass addrbook = new AddressBookClass();
        List<Contact> contacts = new List<Contact>();

        [TestMethod]
        public void GivenContactDetails_ReturnIfEmployeeAdded()
        {
            Contact newContact = new Contact("Jeriin","John","Ulsoor","Bangalore","Karnataka",677654,987654321,"supp@gmail.com");
            bool res=addrbook.AddContactTest(newContact);
            addrbook.addressBook.Add(newContact);
           
             Assert.IsTrue(res);
        }
        [TestMethod]
        public void GivenFirstAndLastName_ReturnIfContactCanBeEdited()
        {
            Contact newContact = new Contact("John", "H", "Ulsoor", "Bangalore", "Karnataka", 677654, 987654321, "supp@gmail.com");
            bool res = addrbook.AddContactTest(newContact);
            addrbook.addressBook.Add(newContact);
            bool result = addrbook.EditContactTest("John", "H");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenFirstAndLastName_ReturnIfContactCanBeDeleted()
        {
            Contact newContact = new Contact("Kate", "Henry", "Ulsoor", "Bangalore", "Karnataka", 677654, 987654321, "supp@gmail.com");
            bool res = addrbook.AddContactTest(newContact);
            bool result = addrbook.DeleteContact("Kate", "Henry");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenStateAndCity_ReturnIfAnyPersonFound()
        {
            List<Contact> addrlist = new List<Contact>() { new Contact("Kate", "James", "Ulsoor", "Bangalore", "Karnataka", 677654, 987654321, "supp@gmail.com"),
            new Contact("Mary", "Henry", "Ulsoor", "Bangalore", "Karnataka", 677654, 987654321, "skk@gmail.com")};
            AddressBookClass.addressBookCollection.Add("Gym", addrlist);
            bool res = addrbook.searchPersonTest("Bangalore", "Karnataka");
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void GivenContact_checkIfSyncWithDatabase()
        {
            bool ans=AddressBookClass.RetrieveContactFromDataBase("John", "H");
            bool res = false;
            foreach(var contact in addrbook.addressBook)
            {
                if (contact.firstName == "John" && contact.lastName == "H")
                    res = true;
            }
            Assert.IsTrue(ans );
        }
        [TestMethod]
        public void GivenDate_ReturnRowsCreatedAtParticularDate()
        {
            bool ans = AddressBookClass.RetrieveContactFromDataBaseAddedInParticularDate();
           
            Assert.IsTrue(ans);
        }
        
    }
}