
using System;
using System.Linq;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        private readonly IList<Address> _addresses;
        public Customer(
            Name name,
            Document document,
            Email email,
            string phone)
        {
            Name = name;
            document = Document;
            email = Email;
            phone = Phone;
            _addresses = new List<Address>();
        }
        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}