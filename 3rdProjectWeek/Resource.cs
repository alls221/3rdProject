using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3rdProjectWeek
{
    abstract class Resource
    {
        private string title;
        private string isbn;
        private int length;
        private string status;

        public string Title { get; set; }
        public string Isbn { get; set; }
        public int Length { get; set; }
        public string Status { get; set; }

        public virtual void ViewTitle()// method that prints out the title, isbn, length and status of object
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("ISBN: " + Isbn);
            Console.WriteLine("Number of pages" + Length);
            Console.WriteLine(Status);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public virtual void CheckOut(Dictionary<string, List<string>> students, string Title) // changes status to "checked out" and generates a due date
        {
            if (Title.Equals(this.Title,StringComparison.CurrentCultureIgnoreCase))
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
                        DateTime dueDate = checkoutDate.AddDays(3);
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
        public virtual void CheckIn(Dictionary<string, List<string>> students, string Title) // changes status to "Available"- this is not currently work
        {
            if (Title.Equals(this.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Enter the Name of the student");
                string name = Console.ReadLine();
                if (students.ContainsKey(name))
                {
                    if (Status == "Checked Out")
                    {
                        Status = "Available";
                        students[name].Remove(title);
                        Console.WriteLine("{0} has retuned {1}", name, Title);
                        string fileName = name.ToUpper() + ".txt";
                        StreamWriter studentFiler = new StreamWriter(fileName);
                        using (studentFiler)
                        {
                            studentFiler.WriteLine(" ");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Resource is not checked out");
                    }
                }
                else
                {
                    Console.WriteLine("Resource does not exist");
                }
            }
        }
        public virtual void EditResource(string toEdit)
        {

            if (toEdit.Equals(this.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine("1- Title\n 2-ISBN\n 3-Length");
                string choice = Console.ReadLine();
                int num;
                if (int.TryParse(choice, out num) == true)
                {
                    switch (num)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter the new title.");
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
                                Console.WriteLine("Enter the new length");
                                int newLength = int.Parse(Console.ReadLine());
                                Length = newLength;
                                break;
                            }
                    }
                }

            }

        }
        public virtual void checkStatus()
        {
            if (Status == "Available")
            {
                Console.WriteLine(Title);
            }
        }
    }
}
