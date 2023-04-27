// 100% Helpful https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Location == "Chile");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Use LINQ to find the first eruption that is in Chile and print the result.
IEnumerable<Eruption> Chile = eruptions.Where(c => c.Location == "Chile" ).Take(1);
PrintEach(Chile);


// Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Eruption  ? HawiianE = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is" );
if(HawiianE == null)
{
    System.Console.WriteLine("No Hawaiian Is Eruption found.");
}
else
{
    System.Console.WriteLine(HawiianE);
}

// Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
Eruption  ? Greenland = eruptions.FirstOrDefault(c => c.Location == "Greenland" );
if(Greenland == null)
{
    System.Console.WriteLine("No Greenland Eruption found.");
}
else
{
    System.Console.WriteLine(Greenland);
}

// Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
IEnumerable<Eruption> New_Zealand = eruptions.Where(c => c.Location == "New Zealand" || c.Year >1900);
PrintEach(New_Zealand);


// Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> Volcano = eruptions.Where(c => c.ElevationInMeters > 2000 );
PrintEach(Volcano);

// Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
IEnumerable<Eruption> VolcanoL = eruptions.Where(c => c.Volcano == ("L") );
PrintEach(VolcanoL);

// Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int max = eruptions.Max(c => c.ElevationInMeters);
System.Console.WriteLine(max);

// Use the highest elevation variable to find and print the name of the Volcano with that elevation.
Eruption  ? HEN = eruptions.FirstOrDefault(c => c.ElevationInMeters == max );
System.Console.WriteLine(HEN!.Volcano);

// Print all Volcano names alphabetically
var orderby = from e in eruptions orderby e.Volcano descending select e;

// Print the sum of all the elevations of the volcanoes combined.
int SUM = eruptions.Sum(c => c.ElevationInMeters);
System.Console.WriteLine(SUM);

// Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
bool of2000 = eruptions.Any(c => c.Year == 2000);
if(of2000)
{
    System.Console.WriteLine("ye");
}
else
{
    System.Console.WriteLine("naw");
}












// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
