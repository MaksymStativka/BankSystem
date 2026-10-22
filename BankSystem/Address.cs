using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Address
    {
        public string Country { get; private set; }
        public string? Region { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string BuildingNumber { get; private set; }
        public string? ApartmentNumber { get; private set; }
        public string PostalCode { get; private set; }

        public Address(string country, string city, string street, string buildingNumber,
            string postalCode, string? region = null, string? apartmentNumber = null)
        {
            Country = ValidateRequired(country);
            City = ValidateRequired(city);
            Street = ValidateRequired(street);
            BuildingNumber = ValidateRequired(buildingNumber);
            PostalCode = ValidateRequired(postalCode);
            Region = ValidateOptional(region);
            ApartmentNumber = ValidateOptional(apartmentNumber);
        }

        private static string ValidateRequired(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value can't be empty");
            }

            return value.Trim();
        }

        private static string? ValidateOptional(string? value)
        {
            if (value is null) return null;

            value = value.Trim();

            return value.Length == 0 ? null : value;
        }

    }
}