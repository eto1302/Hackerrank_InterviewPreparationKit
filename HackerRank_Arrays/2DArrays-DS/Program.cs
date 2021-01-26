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

    static int hourglassSum(int[][] arr)
    {
        int maxSum = -64;
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {

                int sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2]
                          + arr[i + 1][j + 1]
                          + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                if (maxSum < sum) maxSum = sum;
            }
        }
        return maxSum;
    }

    static void Main(string[] args)
    {
        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        Console.WriteLine(result);
    }
}