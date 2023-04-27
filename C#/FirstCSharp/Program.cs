// 1. Iterate and print values
static void PrintList(List<string> MyList)
{
for (int i = 0; i< MyList.Count; i++)

{
    System.Console.WriteLine(MyList[i]);
}
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);

// 2. Print Sum
static void SumOfNumbers(List<int> IntList)
{
    int total = 0;
    for(var i = 0; i < IntList.Count; i++)
    {
        total = total + IntList[i];
    }
    System.Console.WriteLine(total);
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);

//3. Find Max
static int FindMax(List<int> IntList)
{
    int Biggest = IntList[0];
    for(var i = 0; i < IntList.Count; i++)
    {
        if(IntList[i] > Biggest)
        {
            Biggest = IntList[i];
        }
    }
    return Biggest;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example
FindMax(TestIntList2);


//4. Square the Values
static List<int> SquareValues(List<int> IntList)
{
    for(var i = 0; i < IntList.Count; i++)
    {
        int res = IntList[i];
        IntList[i] = (int)Math.Pow(res, 2);
    }
    return IntList;
}
List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
// You should get back [1,4,9,16,25], think about how you will show that this worked
SquareValues(TestIntList3);


//5. Replace Negative Numbers with 0

static int[] NonNegatives(int[] IntArray)
{
    for(var i = 0; i < IntArray.Length; i++)
    if(IntArray[i] < 0)
    {
        IntArray[i] = 0;
    }
    return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
NonNegatives(TestIntArray);


//6. Print Dictionary

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach (var item in MyDictionary)
    {
        System.Console.WriteLine(item);
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

//7. Find Key

static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    if(MyDictionary.ContainsKey(SearchTerm))
    {
        return true;
    }
    else{
        return false;
    }
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));


//8. Generate a Dictionary

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string,int> randomDict = new Dictionary<string, int>();
    
    for(int i = 0; i < Names.Count; i++)
    {
        randomDict.Add(Names[i],Numbers[i]);
    }
    return randomDict;
}
List<string>Names = new List<string>(){"Frank","Bob","Ricky"};
List<int>Numbers = new List<int>(){1, 2, 3};
System.Console.WriteLine(string.Join(",",GenerateDictionary(Names,Numbers)));
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here

