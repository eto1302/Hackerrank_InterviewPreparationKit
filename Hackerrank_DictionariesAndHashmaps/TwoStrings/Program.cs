﻿using System.CodeDom.Compiler;
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

    static string twoStrings(string s1, string s2)
    {
        Dictionary<char, bool> occurances = new Dictionary<char, bool>();
        for (int i = 0; i < s1.Length; ++i)
        {
            if (!occurances.ContainsKey(s1[i]))
            {
                occurances.Add(s1[i], true);
            }
        }
        for (int i = 0; i < s2.Length; ++i)
        {
            if (occurances.ContainsKey(s2[i]))
            {
                return "YES";
            }
        }
        return "NO";

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = twoStrings(s1, s2);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}