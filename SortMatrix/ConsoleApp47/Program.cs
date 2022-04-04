using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp47
{
    public class SortAlgotithm
    {
        private Func<int[,], Dictionary<int, int>> algorithm;

        public SortAlgotithm()
        {
            this.algorithm = BySumElements.Sort;
        }

        public SortAlgotithm(Func<int[,], Dictionary<int, int>> al)
        {
            this.algorithm = al;
        }

        public void SetAlgotithm(Func<int[,], Dictionary<int, int>> al)
        {
            this.algorithm = al;
        }

        public int[,] SortMatrix(int[,] matrix, bool asc = true)
        {
            Dictionary<int, int> dict = this.algorithm.Invoke(matrix);
            int[,] res = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[] order;
            if (asc)
                order = dict.OrderBy(p => p.Value).Select(s => s.Key).ToArray();
            else
                order = dict.OrderBy(p => -p.Value).Select(s => s.Key).ToArray();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res[i, j] = matrix[order[i], j];
                }
            }
            return res;
        }
    }

    public class BySumElements
    {
        public static Dictionary<int, int> Sort(int[,] data)
        {
            int sum;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    sum += data[i, j];
                }
                dict.Add(i, sum);
            }
            return dict;
        }
    }

    public class ByMaxElement
    {
        public static Dictionary<int, int> Sort(int[,] data)
        {
            int maxEl;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                maxEl = data[i, 0];
                for (int j = 1; j < data.GetLength(1); j++)
                {
                    if (data[i, j] > maxEl)
                    {
                        maxEl = data[i, j];
                    }
                }
                dict.Add(i, maxEl);
            }
            return dict;
        }
    }
    public class ByMinElement
    {
        public static Dictionary<int, int> Sort(int[,] data)
        {
            int minEl;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                minEl = data[i, 0];
                for (int j = 1; j < data.GetLength(1); j++)
                {
                    if (data[i, j] < minEl)
                    {
                        minEl = data[i, j];
                    }
                }
                dict.Add(i, minEl);
            }
            return dict;
        }
    }

    class Program
    {
        public static void Print(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            var sortAl = new SortAlgotithm();
            int[,] m = new int[,] { { 6, 2, 10 }, { 8, 7, 5 }, { 1, 9, 6 }, { 7, 3, 4 } };
            Console.WriteLine("Демонстрационная матрица:");
            Print(m);

            sortAl.SetAlgotithm(BySumElements.Sort);
            m = sortAl.SortMatrix(m);
            Console.WriteLine("В порядке возрастания сумм элементов строк матрицы:");
            Print(m);

            m = sortAl.SortMatrix(m, false);
            Console.WriteLine("В порядке убывания сумм элементов строк матрицы:");
            Print(m);

            sortAl.SetAlgotithm(ByMaxElement.Sort);
            m = sortAl.SortMatrix(m);
            Console.WriteLine("По возрастанию максимального элемента в строке матрицы:");
            Print(m);

            m = sortAl.SortMatrix(m, false);
            Console.WriteLine("По убыванию максимального элемента в строке матрицы:");
            Print(m);

            sortAl.SetAlgotithm(ByMinElement.Sort);
            m = sortAl.SortMatrix(m);
            Console.WriteLine("В порядке возрастания минимального элемента в строке матрицы:");
            Print(m);

            m = sortAl.SortMatrix(m,false);
            Console.WriteLine("В порядке убывания минимального элемента в строке матрицы:");
            Print(m);
        }
    }
}
