using System;
using System.Collections.Generic;
using System.Linq;

/// Класс для сортировки Pigeonhole Sort и подсчёта итераций.
public class PigeonholeSort
{
    /// Считает общее число операций (итераций) внутри алгоритма.
    public int Iterations { get; private set; }

    public void Sort(int[] array)
    {
        Iterations = 0;
        if (array.Length == 0)
            return;

        int min = array.Min();
        int max = array.Max();
        int range = max - min + 1;

        List<int>[] holes = new List<int>[range];
        for (int i = 0; i < range; i++)
            holes[i] = new List<int>();

        // Распределение по норкам
        foreach (int number in array)
        {
            holes[number - min].Add(number);
            Iterations++;
        }

        int idx = 0;
        for (int i = 0; i < range; i++)
        {
            foreach (int number in holes[i])
            {
                array[idx++] = number;
                Iterations++;
            }
        }
    }
}
