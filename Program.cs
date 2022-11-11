using AssetTracker;

List<Asset> assetList = new List<Asset>();

// Test List for fast testing testing
// List<Asset> assetList = new List<Asset>()
//             {
//                 new Desktop("Desktop", "HP", "Elitebook", "Germany", 8423, Convert.ToDateTime("2022-05-01")),
//                 new Phone("Phone", "iPhone", "11", "Germany", 3990, Convert.ToDateTime("2022-04-25")),
//                 new Desktop("Desktop", "Lenovo", "Yoga 730", "USA", 9835, Convert.ToDateTime("2020-09-28")),
//                 new Phone("Phone", "Samsung", "20", "Sweden", 6245, Convert.ToDateTime("2020-03-25")),
//                 new Laptop("Laptop", "HP", "Elitebook", "Sweden", 9588, Convert.ToDateTime("2020-10-07")),
//                 new Desktop("Desktop", "Asus", "W234", "USA", 10200, Convert.ToDateTime("2020-07-21")),
//                 new Phone("Phone", "iPhone", "8", "Germany", 1970, Convert.ToDateTime("2019-11-05")),
//                 new Laptop("Laptop", "Acer", "Aspire", "USA", 6030, Convert.ToDateTime("2019-11-21")),
//                 new Phone("Phone", "Motorola", "Razr", "Sweden", 970, Convert.ToDateTime("2020-03-06"))
//             };

Console.WriteLine("Please enter a number to choose an option:");
Console.WriteLine("[1]: To add a new asset Press 1:");
Console.WriteLine("[2]: To display a list of your current assets Press 2");
Console.WriteLine("[3]: To quit the program Press 3");

string userInput = (Console.ReadLine() ?? "").Trim().ToLower();

while(true)
{
    switch(userInput)
    {
        case "1":   //Starts program, creates class & adds to list
            // Adds Type
            Console.WriteLine("Please enter asset type - (D)esktop, (L)aptop or (P)hone:");
            string userEntry = (Console.ReadLine() ?? "").Trim().ToLower();
            string firstChar = userEntry.Substring(0,1);
            string type = "";
            bool isCorrect = false;
            do{
                if(firstChar == "d")
                {
                    type = "Desktop";
                    isCorrect = true;
                }
                else if(firstChar == "l")
                {
                    type = "Laptop";
                    isCorrect = true;
                }
                else if(firstChar == "p")
                {
                    type = "Phone";
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option - (D)esktop, (L)aptop or (P)hone:");
                    userEntry = (Console.ReadLine() ?? "").Trim().ToLower();
                    firstChar = userEntry.Substring(0,1);
                }
            }
            while(!isCorrect);
            // Adds Brand
            Console.WriteLine("Please enter the assets brand:");
            string brand = (Console.ReadLine() ?? "").Trim().ToLower();
            // Adds Model
            Console.WriteLine("Please enter the assets model name:");
            string model = (Console.ReadLine() ?? "").Trim().ToLower();
            // Adds Office
            Console.WriteLine("Please enter which office the asset was purchased for (USA, Germany, Sweden):");
            userEntry = (Console.ReadLine() ?? "").Trim().ToLower();
            firstChar = userEntry.Substring(0,1);
            string office = "";
            isCorrect = false;
            do{
                if(firstChar == "u")
                {
                    office = "USA";
                    isCorrect = true;
                }
                else if(firstChar == "g")
                {
                    office = "Germany";
                    isCorrect = true;
                }
                else if(firstChar == "s")
                {
                    office = "Sweden";
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option - (U)sa, (G)ermany or (S)weden:");
                    userEntry = (Console.ReadLine() ?? "").Trim().ToLower();
                    firstChar = userEntry.Substring(0,1);
                }
            }
            while(!isCorrect);
            // Adds Price
            Console.WriteLine("Please enter the assets cost in USD:");
            bool isInt = false;
            string userPrice = "";
            int price = 0;
            while(!isInt) //Checks input is int32
            { 
                userPrice = (Console.ReadLine() ?? "").Trim().ToLower();
                if(int.TryParse(userPrice, out price))
                { 
                    isInt = true;
                } 
                else
                {
                    Console.WriteLine("Please use a number for this entry.");
                }
            }
            // Adds purchase date
            Console.WriteLine("Please enter the assets purchase date (YYYY-MM-DD):");
            isCorrect = false;
            string userTime = "";
            DateTime purchaseDate = new DateTime();
            while(!isCorrect) //Checks input is DateTime
            {
                userTime = (Console.ReadLine() ?? "").Trim().ToLower();
                if (DateTime.TryParse(userTime, out purchaseDate))
                {
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Invalid Date");
                }
            }
            // Adds asset to list of assets
            if(type == "Desktop")
            {
                assetList.Add(new Desktop(type, brand, model, office, price, purchaseDate));
            }
            if(type == "Laptop")
            {
                assetList.Add(new Laptop(type, brand, model, office, price, purchaseDate));
            }
            if(type == "Phone")
            {
                assetList.Add(new Phone(type, brand, model, office, price, purchaseDate));
            }
            break;
        case "2":   //Displays current list
                DisplayAllAssets();
            break;
        case "3":   //Quits program
            return;
        default:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Operation Complete");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please press '1' to add another asset, '2' to display the current assets or '3' to Quit");
            userInput = (Console.ReadLine() ?? "").Trim().ToLower();
            break;
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Operation Complete");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Please press '1' to add another asset, '2' to display the current assets or '3' to Quit");
    userInput = (Console.ReadLine() ?? "").Trim().ToLower();
}

// Creates a current DateTime & compares it to the exporation date, changes console color @ 90 days remaining and 180 days remaining
void dateExpire(Asset asset)
{
    DateTime currentDate = new DateTime();
    currentDate = DateTime.Now;
    DateTime expirationDate = asset.PurchaseDate.AddYears(3);
    TimeSpan timeRemaining = expirationDate - currentDate;
    if(timeRemaining.TotalDays < 90)
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    else if(timeRemaining.TotalDays < 180)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
}

// Adds the currency and localPrice to individual list items
void DisplayAssetInfo(Asset asset)
    {
        string currency = asset.getCurrency();
        double localPrice = asset.covertCurrency();
        dateExpire(asset);
        Console.WriteLine(
            $"{asset.Type.PadRight(10)} {asset.Brand.PadRight(10)} {asset.Model.PadRight(12)} {asset.Office.PadRight(10)} {asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(14)} {asset.Price.ToString().PadRight(8)} {currency.PadRight(6)} {localPrice.ToString("0.00")}");
    }

// Displays the list in the console
void DisplayAllAssets()
    {
        List<Asset> orderedAssets = assetList.OrderBy(item => item.Office).ThenBy(item => item.PurchaseDate).ToList(); //Orders list correctly
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Type".PadRight(11) + "Brand".PadRight(11) + "Model".PadRight(13) + "Office".PadRight(14) + "Date".PadRight(12) + "Price".PadRight(8) + "$/€/£".PadRight(7) + "Local Price");
        Console.WriteLine("---------------------------------------------------------------------------------------");
        foreach (var asset in orderedAssets)
        {
            DisplayAssetInfo(asset);
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("---------------------------------------------------------------------------------------");
    }


