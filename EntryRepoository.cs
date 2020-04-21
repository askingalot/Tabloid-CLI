using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tabloid
{
    public class EntryRepository
    {
        private static readonly string ROOT_DIRECTORY =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".tabloid");

        public EntryRepository()
        {
            if (!Directory.Exists(ROOT_DIRECTORY))
            {
                Directory.CreateDirectory(ROOT_DIRECTORY);
            }
        }

        public List<Entry> GetAll()
        {
            IEnumerable<string> filePaths =
                Directory.EnumerateFiles(ROOT_DIRECTORY, "*.txt");

            IEnumerable<Entry> entries = filePaths.Select(path =>
            {
                string name = Path.GetFileName(path);
                Guid id = Guid.Parse(name.Substring(0, name.Length - 4)); // remove ".txt" extension

                string[] lines = File.ReadAllLines(path);

                DateTime createDate = DateTime.Parse(lines[0]);

                string title = lines[1];

                IEnumerable<string> contentLines = lines.Skip(2);
                string content = string.Join("\n", contentLines);

                return new Entry()
                {
                    Id = id,
                    Path = path,
                    CreateDateTime = createDate,
                    Title = title,
                    Content = content
                };
            });

            return entries.ToList();
        }

        public Entry Add(Entry entry)
        {
            Guid newId = Guid.NewGuid();
            string path = Path.Combine(ROOT_DIRECTORY, $"{newId}.txt");
            string fileContents = $@"{entry.CreateDateTime}
{entry.Title}
{entry.Content}";

            File.WriteAllText(path, fileContents);

            entry.Id = newId;
            entry.Path = path;
            return entry;
        }

        public void Remove(Entry entry)
        {
            File.Delete(entry.Path);
        }
    }
}