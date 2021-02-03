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

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note)
    {
        Dictionary<string, int> occurances = new Dictionary<string, int>();
        foreach (var word in magazine)
        {
            if (!occurances.ContainsKey(word))
            {
                occurances.Add(word, 1);
            }
            else
            {
                occurances[word]++;
            }
        }
        foreach (var word in note)
        {
            if (!occurances.ContainsKey(word) || occurances[word] == 0)
            {
                Console.WriteLine("No");
                return;
            }
            occurances[word]--;
        }
        Console.WriteLine("Yes");
        return;

    }

    static void Main(string[] args)
    {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}