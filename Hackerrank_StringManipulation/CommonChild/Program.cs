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

    // Complete the commonChild function below.

    static int commonChild(string s1, string s2)
    {
        var dpMatrix = new int[5001, 5001];
        int m = s1.Length;
        int n = s2.Length;

        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0 || j == 0)
                {
                    dpMatrix[i, j] = 0;
                }
                else if (s1[i - 1] == s2[j - 1])
                {
                    dpMatrix[i, j] = 1 + dpMatrix[i - 1, j - 1];
                }
                else
                {
                    dpMatrix[i, j] = Math.Max(dpMatrix[i, j - 1], dpMatrix[i - 1, j]);
                }
            }
        }

        return dpMatrix[m, n];

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = commonChild(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}