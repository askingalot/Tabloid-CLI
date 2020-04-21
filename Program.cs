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
                Console.WriteLine("3) Delete a Journal Entry");
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
                        foreach (Entry anEntry in entries)
                        {
                            Console.WriteLine($"{anEntry.Title}");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("What is the title? ");
                        string title = Console.ReadLine();
                        Entry newEntry = new Entry()
                        {
                            Title = title,
                            CreateDateTime = DateTime.Now,
                            Content = "...Enter your content here..."
                        };
                        repo.Add(newEntry);
                        editor.Start(newEntry);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Which entry would you like to delete?");
                        List<Entry> deleteableEntries = repo.GetAll();
                        for (int i = 1; i <= deleteableEntries.Count; i++)
                        {
                            Console.WriteLine($"{i}) {deleteableEntries[i - 1].Title}");
                        }
                        Console.Write("> ");
                        string deleteChoice = Console.ReadLine();
                        if (int.TryParse(deleteChoice, out int index) && index > 0 && index <= deleteableEntries.Count)
                        {
                            repo.Remove(deleteableEntries[index - 1]);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }
}
