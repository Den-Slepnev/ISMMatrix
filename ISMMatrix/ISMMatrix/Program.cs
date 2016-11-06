using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISMMatrix
{
    class Program
    {
        static int CountOfLinesWithoutZero(double[,] matrix, int n, int m)
        {
            int count = n;
            for(int i=0;i< n;i++)
                for(int j=0;j< m;j++)
                    if (matrix[i,j]==0)
                    {
                        count--;
                        break;
                    }
            return count;
        }
        static double MaxElem(double[,] matrix, int n, int m)
        {
            double[] arr = new double[n*m];
            int index = -1;
            bool g = false;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    bool a = false;
                    for (int ik = 0; ik < n; ik++)
                    {
                        for (int jk = 0; jk < m; jk++)
                            if (matrix[i, j] == matrix[ik, jk] && i != ik)
                            {
                                index++;
                                arr[index] = matrix[i, j];
                                g = true;
                                a = true;
                                break;
                            }
                        if (a) break;
                    }
                }
            double max = 0;
            if(g)
            {
                max = arr[0];
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] >= max) max = arr[i];
            }
            return max;           
        }
        static bool f(char[] arr, int j)
        {
            for(int i=0;i<arr.Length;i++)
            {
                if (j == arr[i])
                    return false;
            }
            return true;
        }
        static int CountOfColWithZero(double[,] matrix, int n, int m)
        {
            
            char[] arr = new char[m];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = 'a';
            int count = 0, index=-1;
            for(int i =0;i< n;i++)
                for(int j=0;j< m;j++)
                    if(matrix[i,j]==0 && f(arr, j))
                    {
                        index++;
                        arr[index] = Convert.ToChar(j);
                        count++;
                    }
            return count;
        }
        static int MaxSeriesElem(double[,] matrix, int n, int m)
        {
            int max = 0, count=0, index=0;
            for(int i=0;i< n;i++)
            {
                for(int j=0;j< m;j++)
                {
                    for (int k = j + 1; k < m; k++)
                        if (matrix[i, j] == matrix[i, k])
                            count++;
                    if (max < count) { max = count; index = i; }
                    count = 0;
                }
            }
            return max;
        }
        static double DodPositive(double[] arr)
        {
            double dob = 1.0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] < 0)
                    return 1.0;
                else
                    dob *= arr[i];
                return dob;
        }
        static double DobElemRowWithoutNegative(double[,] matrix, int n, int m)
        {
            double dob=1.0;
            double[] arr = new double[m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    arr[j] = matrix[i, j];
                dob *= DodPositive(arr);
            }
            return dob;
        }
        static double MaxSumDiag(double[,] matrix, int n, int m)
        {
            double[] arr = new double[n + m - 2];
            double sum = 0;
            int index = -1;
            for(int j=0;j<m;j++)
            {
                int h = 0;
                for (int k= j;k!=m-1 && h !=n;k++)
                {
                    sum += matrix[h, k + 1];
                    h++;
                }
                arr[++index] = sum;
                sum = 0;
                if (index == m - 1)
                    goto m;
            }
        m:
            for(int i=1;i< n;i++)
            {
                int h = i, j=0;
                for(;h!=n;)
                {
                    sum += matrix[h, j];
                    h++;
                    j++;
                }
                arr[index++] = sum;
                sum = 0;
            }
            double max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max) max = arr[i];
            return max; 
        }
        static double SumPositive(double[] arr)
        {
            double sum = 0;
            for(int i=0;i<arr.Length;i++)
            {
                if (arr[i] < 0)
                    return 0;
                else
                    sum += arr[i];
            }
            return sum;
        }
        static bool Negative(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] < 0)
                    return true;
            return false;
        } 
        static double SumNegative(double[] arr)
        {
            double sum = 0;
            if(Negative(arr))
                for (int i = 0; i < arr.Length; i++)
                    sum += arr[i];
            return sum;
        }
        static double SumElemColWithoutNegative(double[,] matrix, int n, int m)
        {
            double sum = 0;
            double[] arr = new double[n];
            for(int j=0;j< m;j++)
            {
                for (int i = 0; i < n; i++)
                {
                    arr[i] = matrix[i, j];
                }
                sum += SumPositive(arr);
            }
            return sum;
        }
        static double SumElemColWithNegative(double[,] matrix, int n, int m)
        {
            double sum = 0;
            double[] arr = new double[n];
            for(int j=0;j< m;j++)
            {
                for (int i = 0; i < n; i++)
                {
                    arr[i] = matrix[i, j];
                }
                sum += SumNegative(arr);
            }
            return sum;
        }
        static double f1(double[,] matrix, int n, int m)
        {
            return matrix[n, m];
        }
        static void TransMatrix(double[,] matrix, int n, int m)
        {
            double[,] NewMatrix = new double[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    NewMatrix[i, j] = f1(matrix, j, i);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(NewMatrix[i, j] + " ");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк: "); int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов: "); int m = int.Parse(Console.ReadLine());
            if (n == 0 || m == 0) throw new SystemException("Одно из значений равно нулю");
            double[,] matrix = new double[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Enter: [{0}, {1}]", i, j);
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            Console.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Количество строк которые не имеют нулевых элементов: {0}",CountOfLinesWithoutZero(matrix, n, m));
            Console.WriteLine("Максимальный элемент который встречается больше одного раза: {0}", MaxElem(matrix, n, m));
            Console.WriteLine("Количество столбцов которые имеют нулевой элементов: {0}",CountOfColWithZero(matrix, n, m));
            Console.WriteLine("Номер строки в которой нахоится самая длинная серия одинаковых элементов: {0}", MaxSeriesElem(matrix, n, m));
            Console.WriteLine("Производное элементов в тех строках которые не имеют отрицательных элементов: {0}", DobElemRowWithoutNegative(matrix, n, m));
            Console.WriteLine("Максимальная сума диагоналей паралельных главной диагонале: {0}", MaxSumDiag(matrix, n, m));
            Console.WriteLine("Сума элементов столбцов в которых нет отрицательных элементов: {0}", SumElemColWithoutNegative(matrix, n, m));
            Console.WriteLine("Сума элементов столбцов в которых есть отрицательный элемент: {0}", SumElemColWithNegative(matrix, n, m));
            TransMatrix(matrix, n, m);
        }
    }
}
