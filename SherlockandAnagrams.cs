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

class Solution {

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s) {
        List<string> allSubstrings = new List<string>();
        for(int i =1; i< s.Length; i++)
        {
            for(int j = 0; j <= s.Length - i; j++)
            {
                allSubstrings.Add(s.Substring(j, i));
            }
        }
        int count = 0;

        for(int i = 0; i < allSubstrings.Count(); i++)
        {
            for(int j = i+1; j < allSubstrings.Count(); j++)
            {
                if(isAnagram(allSubstrings[i], allSubstrings[j]))
                {
                    count++;
                }
            }
        }

        return count;
    }

    static bool isAnagram(string s, string t)
    {
        if(s.Length != t.Length)
            return false;

        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach(var x in s)
        {
            if(map.ContainsKey(x))
            {
                map[x]++;
            }
            else
            {
                map[x] = 1;
            }
        }

        foreach(var x in t)
        {
            if(map.ContainsKey(x))
            {
                map[x]--;
                if(map[x] < 0)
                return false;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
