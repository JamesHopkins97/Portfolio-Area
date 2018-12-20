using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class FileHandler  {


    public static List<string> readLines(string filePath)
    {
        List<string> list = new List<string>();
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;

                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                    list.Add(line);
                    }
                }
            }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        return list;
    }

    public static void writeLines(string filepath, List<string> args)
    {
        using (StreamWriter sw = new StreamWriter(filepath))
        {
            foreach (string s in args)
            {
                sw.WriteLine(s);
            }
        }
    }
}
