using System;
using System.IO;

/// <summary>
/// Класс для генерации входных файлов с наборами случайных данных.
/// </summary>
public static class InputGenerator
{
    /// <summary>
    /// Генерирует заданное число файлов в папке "data",
    /// каждый файл содержит в первой строке размер массива,
    /// а во второй — случайные целые числа в указанном диапазоне.
    /// </summary>
    /// <param name="sets">Количество файлов.</param>
    /// <param name="minSize">Минимальный размер массива.</param>
    /// <param name="maxSize">Максимальный размер массива.</param>
    /// <param name="minValue">Минимальное значение элемента.</param>
    /// <param name="maxValue">Максимальное значение элемента.</param>
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
