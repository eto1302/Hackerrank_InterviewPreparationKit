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

    // Complete the substrCount function below.
    static long substrCount(int n, string s)
    {
        long result = s.Length;

        for (int i = 0; i < s.Length; i++)
        {
            var startChar = s[i];
            int diffCharIdx = -1;
            for (int j = i + 1; j < s.Length; j++)
            {
                var currChar = s[j];
                if (startChar == currChar)
                {
                    if ((diffCharIdx == -1) ||
                        (j - diffCharIdx) == (diffCharIdx - i))
                        result++;
                }
                else
                {
                    if (diffCharIdx == -1)
                        diffCharIdx = j;
                    else
                        break;
                }
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}