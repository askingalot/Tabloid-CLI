using System;
using System.Collections.Generic;

namespace Tabloid
{
    class Program
    {
        static void Main(string[] args)
        {
            EntryRepository repo = new EntryRepository();
            EditorManager editor = new EditorManager();

            Console.Clear();
            Console.WriteLine("Welcome to Tabloid!");
            Console.WriteLine("-------------------");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1) List Journal Entries");
                Console.WriteLine("2) New Journal Entry");
                Console.WriteLine("0) Exit");
                Console.Write("> ");

                string option = Console.ReadLine().Trim();
                switch (option)
                {
                    case "0":
                        Console.WriteLine();
                        Console.WriteLine("Goodbye");
                        System.Environment.Exit(0);
                        break;
                    case "1":
                        Console.Clear();
                        List<Entry> entries = repo.GetAll();
                        foreach (Entry anEntry in entries) {
                            Console.WriteLine($"{anEntry.Title}");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("What is the title? ");
                        string title = Console.ReadLine();
                        Entry newEntry = new Entry() {
                            Title = title,
                            CreateDateTime = DateTime.Now,
                            Content = "...Enter your content here..."
                        };
                        repo.Add(newEntry);
                        editor.Start(newEntry);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }
}
