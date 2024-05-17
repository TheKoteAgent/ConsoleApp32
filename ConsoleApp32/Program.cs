using System;
using System.Threading.Tasks;

namespace PoetryCollectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PoetryCollection poetryCollection = new PoetryCollection();


            poetryCollection.AddPoem(new Poem("Вірш 1", "Автор 1", 2000, "Текст вірша 1", "Тема 1"));
            poetryCollection.AddPoem(new Poem("Вірш 2", "Автор 2", 2010, "Текст вірша 2", "Тема 2"));
            poetryCollection.AddPoem(new Poem("Вірш 3", "Автор 3", 2020, "Текст вірша 3", "Тема 1"));


            Task2.GenerateReports(poetryCollection);
            Task3.GenerateAdditionalReports(poetryCollection);

            Console.ReadKey();
        }
    }
}
