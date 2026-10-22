using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;


namespace BankSystem
{
    public enum DocumentType
    {
        Passport = 0,
        IdCard = 1
    }

    public class Document
    {
        public DocumentType CurrentDocumentType { get; private set; }
        public bool IsValid => ExpDate.Date >= DateTime.Today;
        private DateTime dateRegistrationDocument;
        private TimeSpan periodUpdate;
        private string? documentSeries;
        private string documentNumber;
        private DateTime expDate;
        private string? info;

        public Document(DocumentType currentDocumentType, DateTime dateRegistrationDocument, TimeSpan periodUpdate,
            string documentNumber, DateTime expDate, string? documentSeries = null, string? info = null)
        {
            CurrentDocumentType = currentDocumentType;
            RegistrationDate = dateRegistrationDocument;
            PeriodUpdate = periodUpdate;
            DocumentSeries = documentSeries;
            DocumentNumber = documentNumber;
            ExpDate = expDate;
            Info = info;
        }

        public DateTime RegistrationDate
        {
            get => dateRegistrationDocument;
            private set => dateRegistrationDocument = value.Date > DateTime.Today ? DateTime.Today : value.Date;
        }

        public TimeSpan PeriodUpdate
        {
            get => periodUpdate;
            private set
            {
                if (value < TimeSpan.Zero) throw new ArgumentException("Period can't be negative");
                periodUpdate = value;
            }
        }

        public string? DocumentSeries
        {
            get => documentSeries;
            private set => documentSeries = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        public string DocumentNumber
        {
            get => documentNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Value can't be empty");
                documentNumber = value.Trim();
            }
        }

        public DateTime ExpDate
        {
            get => expDate;
            private set => expDate = value.Date;
        }

        public string? Info
        {
            get => info;
            private set => info = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
    }
}

