 هو اني بعمل معالجة لاي خطا ممكن يحصل اثناء تنفيذ البرنامج بسبب ان اليوزر يدخل بيانات خطا زي القسمه علي صفر او انه يطلع خارج حدود الاراي فبستخدم  try-catch

using System.Threading.Channels;

namespace search_task_exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
        //  هنا الكود اللي ممكن تحصله مشكله 
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
            //هنا بعالج الخطا باني اظهر رساله بالخطا يفهمها اليوزر فالبرنامج ميقفلش واليوزر يدخل بيانات تاني
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
        }
    }
}
