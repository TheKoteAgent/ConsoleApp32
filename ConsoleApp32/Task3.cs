using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PoetryCollectionApp
{
    public static class Task3
    {
        public static void GenerateAdditionalReports(PoetryCollection collection)
        {
            GenerateReportByWord(collection, "вірш");
            GenerateReportByYear(collection);
            GenerateReportByLength(collection);
        }

        private static void GenerateReportByWord(PoetryCollection collection, string word)
        {
            var poems = collection.SearchPoems(p => p.Text.Contains(word));
            PrintReport($"Звіт за словом '{word}' у тексті вірша", poems);
            SaveReport("ReportByWord.txt", poems);
        }

        private static void GenerateReportByYear(PoetryCollection collection)
        {
            var poems = collection.SearchPoems(p => true);
            poems = poems.OrderBy(p => p.Year).ToList();
            PrintReport("Звіт за роком написання вірша", poems);
            SaveReport("ReportByYear.txt", poems);
        }

        private static void GenerateReportByLength(PoetryCollection collection)
        {
            var poems = collection.SearchPoems(p => true);
            poems = poems.OrderBy(p => p.Text.Length).ToList();
            PrintReport("Звіт за довжиною вірша", poems);
            SaveReport("ReportByLength.txt", poems);
        }

        private static void PrintReport(string title, List<Poem> poems)
        {
            Console.WriteLine(title);
            foreach (var poem in poems)
            {
                Console.WriteLine($"{poem.Title}, {poem.Author}, {poem.Year}, {poem.Text.Length} символів");
            }
            Console.WriteLine();
        }

        private static void SaveReport(string filePath, List<Poem> poems)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var poem in poems)
                {
                    writer.WriteLine($"{poem.Title}, {poem.Author}, {poem.Year}, {poem.Text.Length} символів");
                }
            }
        }
    }
}
