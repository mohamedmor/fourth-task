//try
//    {
//        List<int> l1 = new List<int>() ;
//        Console.WriteLine("enter number of elements");
//        int n=Convert.ToInt32(Console.ReadLine());
//        for (int i = 0; i < n; i++)
//        {
//        Console.WriteLine("enter the number");
//        int number =Convert.ToInt32(Console.ReadLine());
//            if (l1.Contains(number))
//            {
//                throw new Exception("Number already exists in the list.");
//            }
//        l1.Add(number);
//        }
//        Console.WriteLine("Number added successfully.")     }
//    catch (Exception ex)  {Console.WriteLine("An error occurred: " + ex.Message);}
Console.WriteLine("Enter a string:");
string input = Console.ReadLine();
try
{
    if (input.Contains('a') || input.Contains('e') || input.Contains('i') || input.Contains('o') || input.Contains('u'))
    {
        Console.WriteLine($"'{input}' contains a vowel.");
    }
    else
    {
        throw new Exception($"'{input}' does not contain a vowel.");
    }
}
catch (Exception ex) {Console.WriteLine("An error occurred: " + ex.Message);}
