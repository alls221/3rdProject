using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3rdProjectWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            Book bookA = new Book();
            Book bookB = new Book();
            Book bookC = new Book();
            bookA.Title = "Visual C#";
            bookA.Isbn = "123A456B";
            bookA.Length = 1232;
            bookA.Status = "Available";
            bookB.Title = "Javascript For Kids";
            bookB.Isbn = "456D789E";
            bookB.Length = 9004;
            bookB.Status = "Available";
            bookC.Title = "Programming for Dummies";
            bookC.Isbn = "789F456G";
            bookC.Length = 123;
            bookC.Status = "Available";
            Magazine magA = new Magazine();
            Magazine magB = new Magazine();
            Magazine magC = new Magazine();
            magA.Title = "Sports Illustrated";
            magA.Isbn = "MAG1234";
            magA.Length = 103;
            magA.Status = "Available";
            magB.Title = "Time";
            magB.Isbn = "MAG2345";
            magB.Length = 107;
            magB.Status = "Available";
            magC.Title = "Gun World";
            magC.Isbn = "MAG4567";
            magC.Length = 212;
            magC.Status = "Available";
            DvD dvdA = new DvD();
            DvD dvdB = new DvD();
            DvD dvdC = new DvD();
            dvdA.Title = "Top Gun";
            dvdA.Isbn = "D123456";
            dvdA.Length = 110;
            dvdA.Status = "Available";
            dvdB.Title = "SWAT";
            dvdB.Isbn = "D23456";
            dvdB.Length = 117;
            dvdB.Status = "Available";
            dvdC.Title = "Need For Speed";
            dvdC.Isbn = "D34567";
            dvdC.Status = "Available";
            string breaker = "true";
            while (breaker != "false")
            {

                StreamWriter resourceFile = new StreamWriter("resources.txt");
                StreamWriter bookFile = new StreamWriter("books.txt");
                StreamWriter magazineFile = new StreamWriter("magazines.txt");
                StreamWriter dvdFile = new StreamWriter("dvds.txt");
                using (resourceFile)
                {
                    using (bookFile)
                    {
                        resourceFile.WriteLine("Books\n\n");
                        resourceFile.WriteLine("Title: " + bookA.Title + "(book)");
                        resourceFile.WriteLine("ISBN: " + bookA.Isbn);
                        resourceFile.WriteLine("Length: " + bookA.Length + " pages");
                        resourceFile.WriteLine("Status: " + bookA.Status);
                        resourceFile.WriteLine("\n\n");
                        resourceFile.WriteLine("Title: " + bookB.Title + "(book)");
                        resourceFile.WriteLine("ISBN: " + bookB.Isbn);
                        resourceFile.WriteLine("Length: " + bookB.Length + " pages");
                        resourceFile.WriteLine("Status: " + bookB.Status);
                        resourceFile.WriteLine("\n\n");
                        resourceFile.WriteLine("Title: " + bookC.Title + "(book)");
                        resourceFile.WriteLine("ISBN: " + bookC.Isbn);
                        resourceFile.WriteLine("Length: " + bookC.Length + " pages");
                        resourceFile.WriteLine("Status: " + bookC.Status);
                        resourceFile.WriteLine("\n\n");
                    }
                    using (magazineFile)
                    {
                        resourceFile.WriteLine("Magazines\n\n");
                        resourceFile.WriteLine("Title: " + magA.Title + "(magazine)");
                        resourceFile.WriteLine("ISBN: " + magA.Isbn);
                        resourceFile.WriteLine("Length: " + magA.Length + " pages");
                        resourceFile.WriteLine("Status: " + magA.Status);
                        resourceFile.WriteLine("\n\n");
                        resourceFile.WriteLine("Title: " + magB.Title + "(magazine)");
                        resourceFile.WriteLine("ISBN: " + magB.Isbn);
                        resourceFile.WriteLine("Length: " + magB.Length + " pages");
                        resourceFile.WriteLine("Status: " + magB.Status);
                        resourceFile.WriteLine("\n\n");
                        resourceFile.WriteLine("Title: " + magC.Title + "(magazine)");
                        resourceFile.WriteLine("ISBN: " + magC.Isbn);
                        resourceFile.WriteLine("Length: " + magC.Length + " pages");
                        resourceFile.WriteLine("Status: " + magC.Status);
                        resourceFile.WriteLine("\n\n");
                    }
                    using (dvdFile)
                    {
                        resourceFile.WriteLine("DVDs\n\n");
                        resourceFile.WriteLine("Title: " + dvdA.Title + "(dvd)");
                        resourceFile.WriteLine("ISBN: " + dvdA.Isbn);
                        resourceFile.WriteLine("Length: " + dvdA.Length + " minutes");
                        resourceFile.WriteLine("Status: " + dvdA.Status);
                        resourceFile.WriteLine("\n\n");
                        resourceFile.WriteLine("Title: " + dvdB.Title + "(dvd)");
                        resourceFile.WriteLine("ISBN: " + dvdB.Isbn);
                        resourceFile.WriteLine("Length: " + dvdB.Length + " minutes");
                        resourceFile.WriteLine("Status: " + dvdB.Status);
                        resourceFile.WriteLine("\n\n");
                        resourceFile.WriteLine("Title: " + dvdC.Title + "(dvd)");
                        resourceFile.WriteLine("ISBN: " + dvdC.Isbn);
                        resourceFile.WriteLine("Length: " + dvdC.Length + " minutes");
                        resourceFile.WriteLine("Status: " + dvdC.Status);
                        resourceFile.WriteLine("\n\n");
                    }
                }
                Dictionary<string, List<string>> students = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
                {
                    { "Ashley",  new List<string> () },
                    { "Krista", new List<string> () },
                    { "Imari", new List <string>() },
                    { "Lawrence", new List <string>() },
                    { "Jacob", new List<string>() }
                };
                StreamWriter studentFile = new StreamWriter("students.txt");
                using (studentFile)
                {
                    foreach (string key in students.Keys)
                    {
                        studentFile.WriteLine(key);
                    }
                }
                    Title();
                Menu();
                switch (GetMenuInput())
                {
                    case 1: // view all resources
                        {
                            StreamReader resourceReader = new StreamReader("resources.txt");
                            using (resourceReader)
                            {
                                Console.Clear();
                                Title();
                                string resources = resourceReader.ReadToEnd();
                                Console.WriteLine(resources);
                            }
                            ReturnToMain();
                            break;
                        }
                    case 2: // view availble resources
                        {
                            Console.Clear();
                            Title();
                            bookA.checkStatus();
                            bookB.checkStatus();
                            bookC.checkStatus();
                            magA.checkStatus();
                            magB.checkStatus();
                            magC.checkStatus();
                            dvdA.checkStatus();
                            dvdB.checkStatus();
                            dvdC.checkStatus();
                            ReturnToMain();
                            break;
                        }
                    case 3: // edit resource
                        Console.Clear();
                        Title();
                        Console.WriteLine("Select a resource type to edit");
                        SubMenu();
                        switch (GetMenuInput())
                        {
                            case 1:
                                {
                                    Console.WriteLine("What book would you like to edit?");
                                    string toEdit = Console.ReadLine();
                                    bookA.EditResource(toEdit);
                                    bookB.EditResource(toEdit);
                                    bookC.EditResource(toEdit);
                                    ReturnToMain();
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("What dvd would you like to edit?");
                                    string toEdit = Console.ReadLine();
                                    dvdA.EditResource(toEdit);
                                    dvdB.EditResource(toEdit);
                                    dvdC.EditResource(toEdit);
                                    ReturnToMain();
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("What magazine would you like to edit?");
                                    string toEdit = Console.ReadLine();
                                    magA.EditResource(toEdit);
                                    magB.EditResource(toEdit);
                                    magC.EditResource(toEdit);
                                    ReturnToMain();
                                    break;
                                }
                        }

                        break;
                    case 4: // View student accounts
                        {
                            Console.Clear();
                            Title();
                            Console.WriteLine("What student account would you like to view?");
                            string name = Console.ReadLine();
                           try
                            {
                                string fileName = name.ToUpper() + ".txt";
                                StreamReader studentAccount = new StreamReader(fileName);
                                using (studentAccount)
                                {
                                    string thisAccount = studentAccount.ReadToEnd();
                                    Console.WriteLine(thisAccount);
                                }
                            }
                            catch (System.IO.FileNotFoundException)
                            {
                              Console.WriteLine("{0} has nothing checked out",name);
                            }

                            break;
                        }
                    case 5: // view all students
                        {
                            listStudents();
                            ReturnToMain();
                            break;
                        }
                    case 6:// check out
                        {
                            Console.Clear();
                            Title();
                            Console.WriteLine("Select the resource type to check out:");
                            SubMenu();
                            switch (GetMenuInput())
                            {
                                case 1: //book
                                    {
                                        Console.WriteLine("Enter the book to check out");
                                        string coTitle = Console.ReadLine();
                                        bookA.CheckOut(students, coTitle);
                                        bookB.CheckOut(students, coTitle);
                                        bookC.CheckOut(students, coTitle);
                                        ReturnToMain();
                                        break;
                                    }
                                case 2: // dvd
                                    {
                                        Console.WriteLine("Enter the dvd to check out");
                                        string coTitle = Console.ReadLine();
                                        dvdA.CheckOut(students, coTitle);
                                        dvdB.CheckOut(students, coTitle);
                                        dvdC.CheckOut(students, coTitle);
                                        ReturnToMain();
                                        break;
                                    }
                                case 3: // magazine
                                    {
                                        Console.WriteLine("Enter the magazine to check out");
                                        string coTitle = Console.ReadLine();
                                        magA.CheckOut(students, coTitle);
                                        magB.CheckOut(students, coTitle);
                                        magC.CheckOut(students, coTitle);
                                        ReturnToMain();
                                        break;
                                    }

                            }
                            break;
                        }
                    case 7:// return
                        {
                            Console.Clear();
                            Title();
                            Console.WriteLine("Select the resource type to return:");
                            SubMenu();
                            switch (GetMenuInput())
                            {
                                case 1: //book
                                    {
                                        Console.WriteLine("Enter the book to check in");
                                        string coTitle = Console.ReadLine();
                                        bookA.CheckIn(students, coTitle);
                                        bookB.CheckIn(students, coTitle);
                                        bookC.CheckIn(students, coTitle);
                                        ReturnToMain();
                                        break;
                                    }
                                case 2: // dvd
                                    {
                                        Console.WriteLine("Enter the dvd to check in");
                                        string coTitle = Console.ReadLine();
                                        dvdA.CheckIn(students, coTitle);
                                        dvdB.CheckIn(students, coTitle);
                                        dvdC.CheckIn(students, coTitle);
                                        ReturnToMain();
                                        break;
                                    }
                                case 3: // magazine
                                    {
                                        Console.WriteLine("Enter the magazine to check in");
                                        string coTitle = Console.ReadLine();
                                        magA.CheckIn(students, coTitle);
                                        magB.CheckIn(students, coTitle);
                                        magC.CheckIn(students, coTitle);
                                        ReturnToMain();
                                        break;
                                    }
                            }
                            break;
                        }
                    case 8:// Exits the program
                        {
                            breaker = "false";
                            Console.WriteLine("Press Any key to close");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
        static void Menu() //method to print the menu
        {
            List<string> menu = new List<string>() { "1-View all Resources", "2-View Available Resources", "3-Edit Resource", "4-View Student Accounts", "5- View all students", "6-Checkout Item", "7-Return Item", "8-Exit" };
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(menu[i]);
            }
        }
        static void Title() // method to print the title
        {
            StringBuilder title = new StringBuilder();
            title.Append("WCCI ");
            title.Append("Bootcamp ");
            title.Append("Resources ");
            title.Append("Checkout ");
            title.Append("System.");
            Console.WriteLine(title + "\n\n\n");
        }
        static void SubMenu() // method to print the submenu
        {
            Console.WriteLine("1- Book");
            Console.WriteLine("2-Dvd");
            Console.WriteLine("3-Magazine");
        }
        static int GetMenuInput() // check that the menu input is an integer
        {
            while (true)
            {
                Console.WriteLine("Select a menu option by number");
                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice) == true)
                {
                    return choice;
                }
                else
                {
                    continue;
                }
            }
        }
        static void listStudents() // prints a list of students 
        {
            StreamReader listStu = new StreamReader("students.txt");
            using (listStu)
            {
                string list = listStu.ReadToEnd();
                Console.WriteLine(list);
            }
        }
        static void ReturnToMain() // clears the screen before returning to the main menu
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Press ");
            sb.Append("any ");
            sb.Append("key ");
            sb.Append("to ");
            sb.Append("return ");
            sb.Append("to ");
            sb.Append("the ");
            sb.Append("main ");
            sb.Append("menu.");


            Console.WriteLine("\n" + sb);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
