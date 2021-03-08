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

    // Complete the makeAnagram function below.
    static int makeAnagram(string a, string b)
    {
        int result = 0;
        Dictionary<char, int> aOcc = new Dictionary<char, int>();
        Dictionary<char, int> bOcc = new Dictionary<char, int>();
        for (char c = 'a'; c <= 'z'; c++)
        {
            aOcc.Add(c, 0);
            bOcc.Add(c, 0);
        }
        for (int i = 0; i < a.Length; ++i)
        {
            aOcc[a[i]]++;
        }
        for (int i = 0; i < b.Length; ++i)
        {
            bOcc[b[i]]++;
        }
        for (char c = 'a'; c <= 'z'; ++c)
        {
            result += Math.Abs(aOcc[c] - bOcc[c]);
        }
        return result;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = makeAnagram(a, b);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}