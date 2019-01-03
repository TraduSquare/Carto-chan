// Copyright (C) 2018 Darkmet98
//
// This file is part of Carto-chan.
//
// Carto-chan is free software: you can redistribute it and/or modify
// it under the terms of the GNU General public static License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Carto-chan is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General public static License for more details.
//
// You should have received a copy of the GNU General public static License
// along with Carto-chan. If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.IO;

namespace Carto_chan
{
    class Common
    {
        public static Dictionary<string, string> Dictionary = new Dictionary<string, string>();

        public static string Replace (string text, bool import)
        {
            if (Dictionary.Count == 0)
            {
                Generatedictionary("Dictionary.txt");
            }
            string finished = text;
            if (import)
            {
                foreach (var kvp in Dictionary)
                    finished = finished.Replace(kvp.Value, kvp.Key);
            }
            else
            {
                foreach (var kvp in Dictionary)
                    finished = finished.Replace(kvp.Key, kvp.Value);
            }
            

            return finished;
        }

        //Generate the character dictionary for the importing text
        private static void Generatedictionary(string dictionary_file)
        {
            if (File.Exists(dictionary_file))
            {
                try
                {
                    string[] dictionary = System.IO.File.ReadAllLines(dictionary_file);
                    foreach (string line in dictionary)
                    {
                        string[] lineFields = line.Split('=');
                        Dictionary.Add(lineFields[0], lineFields[1]);
                    }
                    return;
                }
                catch
                {
                    Console.WriteLine("The dictionary is wrong, please, check the readme and fix it.");
                    System.Environment.Exit(-1);
                }
            }
        }

    }
}
