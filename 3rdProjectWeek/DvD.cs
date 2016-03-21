using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdProjectWeek
{
    class DvD: Resource
    {
        public override void ViewTitle()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("ISBN: " + Isbn);
            Console.WriteLine(Length + " minutes long");
            Console.WriteLine(Status);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public override void checkStatus()
        {
            if (Status == "Available")
            {
                Console.WriteLine(Title + " (dvd)");
            }
        }
        public override void EditResource(string toEdit)
        {
            if (this.Title == toEdit)
            {
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine("1- Title\n 2-ISBN\n 3-Length in minutes");
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
                                Console.WriteLine("Enter the new length in minutes");
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
