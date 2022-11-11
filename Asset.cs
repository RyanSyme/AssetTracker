using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracker
{
    // Parent class for asset creation
    internal class Asset
    {
        public Asset(string type, string brand, string model, string office, int price, DateTime purchaseDate)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Office = office;
            Price = price;
            PurchaseDate = purchaseDate;

        }

        // Matches list items office to a currency
        public string getCurrency()
        {
            if(Office == "Germany")
            {
                return "EUR";
            }
            else if(Office == "sweden")
            {
                return "SEK";
            }
            else 
            {
                return "USD";
            }
        }

        // Converts USD to Local currency
        public double covertCurrency()
        {
            double localCurrency;
            if(Office == "Germany")
            {
                localCurrency = Price * 1.02;
                return localCurrency;
            }
            else if(Office == "Sweden")
            {
                localCurrency = Price * 10.81;
                return localCurrency;
            }
            else 
            {
                localCurrency = Price;
                return localCurrency;
            }
        }


        public string Type {get; set;}
        public string Brand {get; set;}
        public string Model {get; set;}
        public string Office {get; set;}
        public double Price {get; set;}
        public DateTime PurchaseDate {get; set;}
    }

    // Child class for asset creation
    internal class Desktop : Asset
    {
        public Desktop(string type, string brand, string model, string office, int price, DateTime purchaseDate) 
            : base(type, brand, model, office, price, purchaseDate)
        {}
    }

    // Child class for asset creation
    internal class Laptop : Asset
    {
        public Laptop(string type, string brand, string model, string office, int price, DateTime purchaseDate) 
            : base(type, brand, model, office, price, purchaseDate)
        {}
    }

    // Child class for asset creation
    internal class Phone : Asset
    {
        public Phone(string type, string brand, string model, string office, int price, DateTime purchaseDate) 
            : base(type, brand, model, office, price, purchaseDate)
        {}
    }
}