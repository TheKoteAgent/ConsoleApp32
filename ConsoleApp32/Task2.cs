using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PoetryCollectionApp
{
    public static class Task2
    {
        public static void GenerateReports(PoetryCollection collection)
        {
            GenerateReportByTitle(collection);
            GenerateReportByAuthor(collection);
            GenerateReportByTheme(collection);
        }

        private static void GenerateReportByTitle(PoetryCollection collection)
        {
            var poems = collection.SearchPoems(p => true);
            poems = poems.OrderBy(p => p.Title).ToList();
            PrintReport("Звіт за назвою вірша", poems);
            SaveReport("ReportByTitle.txt", poems);
        }

        private static void GenerateReportByAuthor(PoetryCollection collection)
        {
            var poems = collection.SearchPoems(p => true);
            poems = poems.OrderBy(p => p.Author).ToList();
            PrintReport("Звіт за ПІБ автора", poems);
            SaveReport("ReportByAuthor.txt", poems);
        }

        private static void GenerateReportByTheme(PoetryCollection collection)
        {
            var poems = collection.SearchPoems(p => true);
            poems = poems.OrderBy(p => p.Theme).ToList();
            PrintReport("Звіт за темою вірша", poems);
            SaveReport("ReportByTheme.txt", poems);
        }

        private static void PrintReport(string title, List<Poem> poems)
        {
            Console.WriteLine(title);
            foreach (var poem in poems)
            {
                Console.WriteLine($"{poem.Title}, {poem.Author}, {poem.Year}, {poem.Theme}");
            }
            Console.WriteLine();
        }

        private static void SaveReport(string filePath, List<Poem> poems)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var poem in poems)
                {
                    writer.WriteLine($"{poem.Title}, {poem.Author}, {poem.Year}, {poem.Theme}");
                }
            }
        }
    }
}
