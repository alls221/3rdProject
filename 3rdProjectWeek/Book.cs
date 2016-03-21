using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3rdProjectWeek
{
    class Book : Resource
    {
        public override void CheckOut(Dictionary<string, List<string>> students, string Title) // changes status to "checked out" and generates a due date
        {
            if (Title.Equals(this.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                StreamWriter checkedOut = new StreamWriter("checkedout.txt");
                Console.WriteLine("Enter the Name of the student");
                string name = Console.ReadLine();
                if (students.ContainsKey(name))
                {
                    string fileName = name.ToUpper() + ".txt";
                    StreamWriter studentFiler = new StreamWriter(fileName);
                    if (Status == "Available")
                    {

                        Status = "Checked Out";
                        students[name].Add(Title);
                        DateTime checkoutDate = new DateTime();
                        checkoutDate = DateTime.Today;
                        DateTime dueDate = checkoutDate.AddDays(5);
                        Console.WriteLine(Title + " is " + Status + " and needs to be returned on " + dueDate + ".");
                        using (checkedOut)
                        {
                            checkedOut.WriteLine(Title + " is " + Status + " and needs to be returned on " + dueDate + ".");
                        }
                        using (studentFiler)
                        {
                            studentFiler.WriteLine(Title + " is " + Status + " and needs to be returned on " + dueDate + ".");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Resource is already checked out.");
                    }
                }
                else
                {
                    Console.WriteLine("Student does not exist");
                }
            }
        }
        public override void checkStatus()
        {
            if (Status == "Available")
            {
                Console.WriteLine(Title + " (book)");
            }
        }
        public override void EditResource(string toEdit)
        {
            if (toEdit.Equals(this.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine("1- Title\n 2-ISBN\n 3-Number of Pages");
                string choice = Console.ReadLine();
                int num;
                if (int.TryParse(choice, out num) == true)
                {
                    switch (num)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter the new title");
                                string newTitle = Console.ReadLine();
                                Title = newTitle;
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter the new ISBN");
                                string newIsbn = Console.ReadLine();
                                Isbn = newIsbn;
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter the new number of pages");
                                int newLength = int.Parse(Console.ReadLine());
                                Length = newLength;
                                break;
                            }
                    }
                }

            }
        }

    }
}
