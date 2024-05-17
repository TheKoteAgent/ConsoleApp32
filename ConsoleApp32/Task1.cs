using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PoetryCollectionApp
{
    public class Poem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string Theme { get; set; }

        public Poem(string title, string author, int year, string text, string theme)
        {
            Title = title;
            Author = author;
            Year = year;
            Text = text;
            Theme = theme;
        }
    }

    public class PoetryCollection
    {
        private List<Poem> poems = new List<Poem>();

        public void AddPoem(Poem poem)
        {
            poems.Add(poem);
        }

        public void RemovePoem(string title)
        {
            poems.RemoveAll(p => p.Title == title);
        }

        public void UpdatePoem(string title, Poem updatedPoem)
        {
            for (int i = 0; i < poems.Count; i++)
            {
                if (poems[i].Title == title)
                {
                    poems[i] = updatedPoem;
                    break;
                }
            }
        }

        public List<Poem> SearchPoems(Func<Poem, bool> predicate)
        {
            return poems.Where(predicate).ToList();
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var poem in poems)
                {
                    writer.WriteLine($"{poem.Title}|{poem.Author}|{poem.Year}|{poem.Text}|{poem.Theme}");
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                poems.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 5)
                        {
                            var poem = new Poem(parts[0], parts[1], int.Parse(parts[2]), parts[3], parts[4]);
                            poems.Add(poem);
                        }
                    }
                }
            }
        }
    }
}
