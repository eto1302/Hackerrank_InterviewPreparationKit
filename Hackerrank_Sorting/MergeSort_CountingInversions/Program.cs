using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the countInversions function below.
    static long countInversions(int[] arr)
    {
        long array_size = arr.Length;
        int[] temp = new int[array_size];
        return mergeSort(arr, temp, 0, array_size - 1);
    }
    static long mergeSort(int[] arr, int[] temp, long left,
                          long right)
    {
        long mid, inv_count = 0;
        if (right > left)
        {
            mid = (right + left) / 2;

            inv_count += mergeSort(arr, temp, left, mid);
            inv_count
                += mergeSort(arr, temp, mid + 1, right);

            inv_count
                += merge(arr, temp, left, mid + 1, right);
        }
        return inv_count;
    }

    static long merge(int[] arr, int[] temp, long left,
                     long mid, long right)
    {
        long i, j, k;
        long inv_count = 0;

        i = left;
        j = mid;
        k = left;
        while ((i <= mid - 1) && (j <= right))
        {
            if (arr[i] <= arr[j])
            {
                temp[k++] = arr[i++];
            }
            else
            {
                temp[k++] = arr[j++];

                inv_count = inv_count + (mid - i);
            }
        }

        while (i <= mid - 1)
            temp[k++] = arr[i++];

        while (j <= right)
            temp[k++] = arr[j++];
        for (i = left; i <= right; i++)
            arr[i] = temp[i];

        return inv_count;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            long result = countInversions(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
