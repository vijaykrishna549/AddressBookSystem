using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contact
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Contact(string name, string address, string zip, string city, string state, string phone)
        {
            Name = name;
            Address = address;
            Zip = zip;
            City = city;
            State = state;
            Phone = Phone;
            Email = Email;
        }

        public Contact(string name, string address, string zip, string city, string state, string phone, string email) : this(name, address, zip, city, state, phone)
        {
        }
    }
}
    
