using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

/// Основной класс программы для генерации данных, чтения, сортировки
/// Pigeonhole Sort и логирования результатов.

class Program
{
    static void Main()
    {
        // Генерация файлов с входными данными
        InputGenerator.GenerateFiles(sets: 100, minSize: 100, maxSize: 10000);

        // Получаем список файлов
        string[] files = Directory.GetFiles("data", "input_*.txt");

        using StreamWriter log = new StreamWriter("results.csv");
        log.WriteLine("Size,Time(ms),Iterations");

        foreach (var file in files)
        {
            int[] data = ReadData(file);
            int size = data.Length;

            PigeonholeSort sorter = new PigeonholeSort();
            Stopwatch sw = Stopwatch.StartNew();
            sorter.Sort(data);
            sw.Stop();

            log.WriteLine($"{size},{sw.Elapsed.TotalMilliseconds:F4},{sorter.Iterations}");
        }

        Console.WriteLine("Done. Results saved to results.csv.");
    }

    /// Читает данные из файла формата:
    /// первая строка - размер массива,
    /// вторая строка - элементы через пробел.

    static int[] ReadData(string path)
    {
        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2)
            throw new InvalidDataException($"File '{path}' does not contain expected two lines.");

        string[] parts = lines[1]
            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int[] result = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            if (!int.TryParse(parts[i], out result[i]))
                throw new FormatException($"Cannot parse '{parts[i]}' in file '{path}'.");
        }

        return result;
    }
}
