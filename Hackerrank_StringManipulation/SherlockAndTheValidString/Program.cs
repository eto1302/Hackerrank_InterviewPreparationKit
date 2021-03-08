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

    // Complete the isValid function below.
    static string isValid(string s)
    {
        Dictionary<char, int> occurances = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; ++i)
        {
            if (!occurances.ContainsKey(s[i]))
            {
                occurances.Add(s[i], 1);
            }
            else occurances[s[i]]++;
        }
        int firstNumber = -1, secondNumber = -1;
        foreach (var element in occurances)
        {
            if (firstNumber == -1) firstNumber = element.Value;
            else
            {
                if (firstNumber != element.Value)
                {
                    if (secondNumber != -1) return "NO";
                    secondNumber = element.Value;
                }
            }
        }
        return "YES";

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}