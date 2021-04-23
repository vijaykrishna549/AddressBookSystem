using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {
        public readonly Contact[] contacts;

        public AddressBook()
        {
            contacts = new Contact[9]; ;
        }

        public bool AddEntry(string name, string address, string zip, string city, string state, string phone, string email)
        {
            if (!ContainsEntry(name))
            {
                name = FormatContact(name);
                address = FormatContact(address);
                zip = FormatContact(zip);
                city = FormatContact(city);
                state = FormatContact(state);
                phone = FormatContact(phone);
                email = FormatContact(email);
                Contact AddContact = new Contact(name, address, zip, city, state, phone, email);
                for (int i = 0; i < contacts.Length; i++)
                {
                    if (contacts[i] == null)
                    {
                        contacts[i] = AddContact;
                        Console.WriteLine("Address Book updated. Name: {0} -- Address: {1} has been added!", name, address);
                        return true;
                    }
                }
                Console.WriteLine($"Cannot add ({name}) to Address Book since it is full!");
                return false;
            }
            else
            {
                Console.WriteLine($"({name}) already exists in Address Book!");
                UpdateContact(name);
            }
            return false;
        }

        public bool UpdateContact(string originalName)
        {
            Console.Write("Are you sure you would you like to update the Contact? -- Type 'Y' or 'N': ");
            string userResponse = Console.ReadLine().ToLower();
            if (userResponse == "y")
            {
                Console.Write($"Would you like to update {originalName}'s name or address? TYPE - 'Name' for name and 'Address' for address: ");
                string contactToUpdate = Console.ReadLine().ToLower();

                Console.Write($"Please enter changes to the {contactToUpdate} here: ");
                string updatedContact = Console.ReadLine().Trim();
                updatedContact = FormatContact(updatedContact);

                int index = GetEntryIndex(originalName);
                switch (contactToUpdate)
                {
                    case "name":
                        contacts[index].Name = updatedContact;
                        Console.WriteLine($"Contact {originalName} updated to {updatedContact}");
                        return true;
                    case "address":
                        contacts[index].Address = updatedContact;
                        Console.WriteLine($"Contact {originalName}'s {contactToUpdate} updated to {updatedContact}");
                        return true;
                    case "zip":
                        contacts[index].Zip = updatedContact;
                        Console.WriteLine($"Contact {originalName}'s {contactToUpdate} updated to {updatedContact}");
                        return true;
                    case "city":
                        contacts[index].City = updatedContact;
                        Console.WriteLine($"Contact {originalName}'s {contactToUpdate} updated to {updatedContact}");
                        return true;
                    case "state":
                        contacts[index].State = updatedContact;
                        Console.WriteLine($"Contact {originalName}'s {contactToUpdate} updated to {updatedContact}");
                        return true;
                    case "phone":
                        contacts[index].Phone = updatedContact;
                        Console.WriteLine($"Contact {originalName}'s {contactToUpdate} updated to {updatedContact}");
                        return true;
                    case "email":
                        contacts[index].Email = updatedContact;
                        Console.WriteLine($"Contact {originalName}'s {contactToUpdate} updated to {updatedContact}");
                        return true;
                }
            }
            return false;
        }

        private string FormatContact(string stringToFormat)
        {
            char[] arr = stringToFormat.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                int num;
                if (i == 0 || arr[i - 1] == ' ' && !(int.TryParse(arr[i].ToString(), out num)))
                {
                    arr[i] = Convert.ToChar(arr[i].ToString().ToUpper());
                }
                else
                {
                    arr[i] = Convert.ToChar(arr[i].ToString().ToLower());
                }
            }
            return String.Concat(arr);
        }

        private int GetEntryIndex(string name)
        {
            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i] != null && contacts[i].Name.ToLower() == name.ToLower())
                    return i;
            }
            return -1;
        }

        private bool ContainsEntry(string name)
        {
            return GetEntryIndex(name) != -1;
        }

        public void RemoveEntry(string name)
        {
            var index = GetEntryIndex(name);
            if (index != -1)
            {
                contacts[index] = null;
                Console.WriteLine("{0} removed from contacts", name);
            }
        }

        public string ViewContactsList()
        {
            string contactList = "";
            foreach (Contact contact in contacts)
            {
                if (contact == null)
                {
                    continue;
                }
                contactList += String.Format("Name: {0} -- Address: {1} -- Zip: {2} -- City: {3} -- State: {4} -- Phone: {5} -- Email: {6}"   + Environment.NewLine, contact.Name, contact.Address);
            }
            return (contactList != String.Empty) ? contactList : "Your Address Book is empty.";
        }
    }
}
    
