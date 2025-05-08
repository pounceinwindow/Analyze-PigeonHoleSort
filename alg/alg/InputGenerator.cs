using System;
using System.IO;

/// Класс для генерации входных файлов с наборами случайных данных.
public static class InputGenerator
{
    /// Генерирует заданное число файлов в папке "data",

    public static void GenerateFiles(
        int sets = 100,
        int minSize = 100,
        int maxSize = 10000,
        int minValue = 0,
        int maxValue = 100000)
    {
        Random rand = new Random();
        Directory.CreateDirectory("data");

        for (int i = 0; i < sets; i++)
        {
            int size = rand.Next(minSize, maxSize + 1);
            string path = Path.Combine("data", $"input_{i}.txt");

            using StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(size);
            for (int j = 0; j < size; j++)
            {
                sw.Write(rand.Next(minValue, maxValue + 1));
                if (j < size - 1)
                    sw.Write(' ');
            }
        }

        Console.WriteLine($"Generated {sets} files in 'data' directory.");
    }
}
