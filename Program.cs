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
                Console.WriteLine("1) View Journal Entries");
                Console.WriteLine("2) New Journal Entry");
                Console.WriteLine("3) Edit a Journal Entry");
                Console.WriteLine("4) Delete a Journal Entry");
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
                        Console.WriteLine("Which entry would you like to edit?");
                        List<Entry> entries = repo.GetAll();
                        for (int i = 1; i <= entries.Count; i++)
                        {
                            Console.WriteLine($"{i}) {entries[i - 1].Title}");
                        }
                        Console.Write("> ");
                        string viewChoice = Console.ReadLine();
                        if (int.TryParse(viewChoice, out int index) && index > 0 && index <= entries.Count)
                        {
                            Console.WriteLine();
                            Console.WriteLine("--------------------------");
                            Console.WriteLine(entries[index - 1].Title);
                            Console.WriteLine(entries[index - 1].CreateDateTime);
                            Console.WriteLine();
                            Console.WriteLine(entries[index - 1].Content);
                            Console.WriteLine("--------------------------");
                            Console.WriteLine();
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
                        editor.Open(newEntry);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Which entry would you like to edit?");
                        List<Entry> editableEntries = repo.GetAll();
                        for (int i = 1; i <= editableEntries.Count; i++)
                        {
                            Console.WriteLine($"{i}) {editableEntries[i - 1].Title}");
                        }
                        Console.Write("> ");
                        string editChoice = Console.ReadLine();
                        if (int.TryParse(editChoice, out index) && index > 0 && index <= editableEntries.Count)
                        {
                            editor.Open(editableEntries[index - 1]);
                        }
                         break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Which entry would you like to delete?");
                        List<Entry> deleteableEntries = repo.GetAll();
                        for (int i = 1; i <= deleteableEntries.Count; i++)
                        {
                            Console.WriteLine($"{i}) {deleteableEntries[i - 1].Title}");
                        }
                        Console.Write("> ");
                        string deleteChoice = Console.ReadLine();
                        if (int.TryParse(deleteChoice, out index) && index > 0 && index <= deleteableEntries.Count)
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
