namespace fourth_task
{
    using System;

    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }
        public SavingsAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            this.InterestRate = interestRate;
        }
    }
    public class CheckingAccount : Account
    {
        public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0) : base(name, balance)
        {

        }
        
        public override bool Withdraw(double amount)
        {
            double fee = 1.5;
            return base.Withdraw(amount + fee);
        }
        
                
    }
    public class TrustAccount  : Account
    {
        public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0) : base(name, balance)
        {

        }
        public override bool Deposit(double amount)
        {
            if (amount > 5000)
                return base.Deposit(amount + 50);
            else
                return base.Deposit(amount);
        }
        public override bool Withdraw(double amount)
        {
            if ( amount > Balance * 0.2)
                return false;
            else
                return base.Withdraw(amount);
        }

    }
    public class AccountUtil
    {
        // Utility helper functions for Account class
        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        // Helper functions for SavingsAccount

        public static void DepositSavings(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Savings Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void WithdrawSavings(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Savings Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        // Helper functions for CheckingAccount
        public static void DepositChecking(List<CheckingAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Checking Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void WithdrawChecking(List<CheckingAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Checking Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        // Helper functions for TrustAccount
        public static void DepositTrust(List<TrustAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Trust Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void WithdrawTrust(List<TrustAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Trust Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<SavingsAccount>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.DepositSavings(savAccounts, 1000);
            AccountUtil.WithdrawSavings(savAccounts, 2000);

            // Checking
            var checAccounts = new List<CheckingAccount>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.DepositChecking(checAccounts, 1000);
            AccountUtil.WithdrawChecking(checAccounts, 2000);
            AccountUtil.WithdrawChecking(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<TrustAccount>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000));

            AccountUtil.DepositTrust(trustAccounts, 1000);
            AccountUtil.DepositTrust(trustAccounts, 6000);
            AccountUtil.WithdrawTrust(trustAccounts, 2000);
            AccountUtil.WithdrawTrust(trustAccounts, 3000);
            AccountUtil.WithdrawTrust(trustAccounts, 500);

            Console.WriteLine();

        }
    }

}
//namespace fourth_online_secion
//{
//    public class Instructor
//    {
        
//        public int InstructorId { get; set; }
//        public string Name { get; set; }
//        public string specialization { get; set; }
//        public Instructor(int instructorId=1000, string name="no name", string specialization="no data")
//        {
//            InstructorId = instructorId;
//            Name = name;
//            this.specialization = specialization;
//        }

       
//        public string PrintDetaills()
//        {
//            return $" instructor id : {InstructorId},Name: {Name}, specialization: {specialization}";
//        }
//    }
//    public class Course
//    {
//        public Course(int courseId=2000, string title="no title", Instructor? instructor=null)// هنا بنستخدم ال nullable type علشان نقدر نستقبل null value في حالة عدم وجود instructor
//        {
//            CourseId = courseId;
//            Title = title;
//            Instructor = instructor ?? new Instructor();// if instructor is null, create a new Instructor object with default values
//            //if (instructor != null)
//            //Instructor = instructor;
//            //else
//            //    Instructor =  new Instructor();
//        }

//        public int CourseId { get; set; }
//        public string Title { get; set; }
//        public Instructor Instructor { get; set; } 

//        public string PrintDetaills()
//        {
//            return $"Course ID: {CourseId}, Title: {Title} , Instructor :\n {Instructor.PrintDetaills}";
            
//        }

//    }
//    public class Student
//    {
//        public int StudentId { get; set; }
//        public string Name { get; set; }
//        public int Age { get; set; }
//        public string Grade { get; set; }
//        public Student(string name, int age, string grade)
//        {
//            Name = name;
//            Age = age;
//            Grade = grade;
//        }
//        public string DisplayInfo()
//        {
//            return$"Name: {Name}, Age: {Age}, Grade: {Grade}";
//        }
        
//    }
//    internal class School
//    {
//        public School()
//        {
//            Students = new List<Student>();
//            Courses = new List<Course>();
//            Instructors = new List<Instructor>();
//        }

//        List<Student> Students { get; set; }
//        List<Course> Courses { get; set; }
//        List<Instructor> Instructors { get; set; }

//        public bool AddStudent(Student std)
//        {
//            if (Students.Contains(std)) return false;

//            Students.Add(std);
//            return true;
//        }

//        public Student? FindStudent(int stdId)
//        {
//            for (int i = 0; i < Students.Count; i++)
//            {
//                if (Students[i].StudentId == stdId)
//                {
//                    return Students[i];
//                }
//            }
//            return null;
//        }


//        public Course? FindCourse(int crsId)
//        {
//            for (int i = 0; i < Courses.Count; i++)
//            {
//                if (Courses[i].CourseId == crsId)
//                {
//                    return Courses[i];
//                }
//            }
//            return null;
//        }

//        public bool AddCourse(Course crs)
//        {
//            if (Courses.Contains(crs)) return false;

//            Courses.Add(crs);
//            return true;
//        }

//        public bool AddInstructor(Instructor ins)
//        {
//            if (Instructors.Contains(ins)) return false;

//            Instructors.Add(ins);
//            return true;
//        }




//        public Instructor? FindInstructor(int insId)
//        {
//            for (int i = 0; i < Instructors.Count; i++)
//            {
//                if (Instructors[i].InstructorId == insId)
//                {
//                    return Instructors[i];
//                }
//            }
//            return null;
//        }


//        public bool EnrollStdeuntAndCourse(int stdId, int crsId)
//        {
//            Student? std = FindStudent(stdId);
//            Course? crs = FindCourse(crsId);
//            if (std != null && crs != null)
//            {
//                AddCourse(crs);
//                AddStudent(std);
//                return true;
//            }
//            return false;

//        }
//        public void ShowAllStudents()
//        {
//            for (int i = 0; i < Students.Count; i++)
//            {
//                Console.WriteLine(Students[i].DisplayInfo());
//            }
//        }
//        public void ShowAllInstructors()
//        {
//            for (int i = 0; i < Instructors.Count; i++)
//            {
//                Console.WriteLine(Instructors[i].PrintDetaills());
//            }
//        }
//        public void ShowAllCourses()
//        {
//            for (int i = 0; i < Courses.Count; i++)
//            {
//                Console.WriteLine(Courses[i].PrintDetaills());
//            }
//        }
//        public Student? FindStudentByIdOrName( int id ,string name)
//        {
//            for (int i = 0; i < Students.Count; i++)
//            {
//                if (Students[i].StudentId == id || Students[i].Name == name )
//                {
//                    return Students[i];
//                }
//            }
//            return null;
//        }
//        public Course? FindCourseByIdOrName(int id, string name)
//        {
//            for (int i = 0; i < Courses.Count; i++)
//            {
//                if (Courses[i].CourseId == id || Courses[i].Title == name)
//                {
//                    return Courses[i];
//                }
//            }
//            return null;
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            School school = new School();
//            int op = 0;
//            while (op != 10) 
//            {
//                Console.WriteLine( " student management\n\n");
//                Console.WriteLine("1. Add Student");
//                Console.WriteLine("2. Add Instructor");
//                Console.WriteLine("3. Add Course");
//                Console.WriteLine("4. Enroll Student in Course");
//                Console.WriteLine("5. Show All Students");
//                Console.WriteLine("6. Show All Instructors");
//                Console.WriteLine("7. Show All Courses");
//                Console.WriteLine("8. Find Student By ID Or Name");
//                Console.WriteLine("9. Find Course By ID Or Name");
//                Console.WriteLine("10. Exit\n");
//                Console.Write("Enter your choice: ");
//                op =Convert .ToInt32(Console.ReadLine());
//                switch (op)
//                {
//                    case 1:
//                        Console.WriteLine( school.AddStudent(new Student("John Doe", 20, "A")));
//                        break;
//                    case 2:
//                        Console.WriteLine(school.AddInstructor(new Instructor(1001, "Dr. Smith", "Mathematics")));
//                        break;
//                    case 3:
//                        Console.WriteLine(school.AddCourse(new Course(2001, "Calculus", new Instructor(1001, "Dr. Smith", "Mathematics"))));
//                        break;
//                    case 4:
//                        Console.WriteLine(school.EnrollStdeuntAndCourse(1000, 2000));
//                        break;
//                    case 5:
//                        school.ShowAllStudents();
//                        break;
//                    case 6:
//                        school.ShowAllInstructors();
//                        break;
//                    case 7:
//                        school.ShowAllCourses();
//                        break;
//                    case 8:
//                        Console.Write("Enter Student ID or Name: ");
//                        string input = Console.ReadLine();
//                        Console.WriteLine(school.FindStudentByIdOrName(20, input)); // Assuming 0 is a placeholder for ID
//                        break;
//                    case 9:
//                        Console.Write("Enter Course ID or Name: ");
//                        string courseInput = Console.ReadLine();
//                        Console.WriteLine(school.FindCourseByIdOrName(2000, courseInput)); // Assuming 0 is a placeholder for ID
//                        break;
//                        case 10:
//                        Console.WriteLine( "Exiting...");
//                        break;
//                        default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;

//                }
//            }
//        }
//    }
//}
