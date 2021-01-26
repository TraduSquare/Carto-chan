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
using System.Reflection;
using System.Text;

namespace Carto_chan
{
    class Map
    {
        private static Dictionary<string, string> dictionary = new Dictionary<string, string>();

        private static string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                  Path.DirectorySeparatorChar;

        public static string Token;
        public static string EndDelimitator;
        public static string Language;
        public static string Flags;
        public static Encoding EncodingText;

        public static string Replace (string text, bool import)
        {
            string finished = text;
            if (import)
            {
                foreach (var kvp in dictionary)
                    finished = finished.Replace(kvp.Value, kvp.Key);
            }
            else
            {
                foreach (var kvp in dictionary)
                    finished = finished.Replace(kvp.Key, kvp.Value);
            }
            

            return finished;
        }

        // Generate the character dictionary for the importing text
        public static void Generatedictionary()
        {
            var file = $"{dir}Settings.ini";

            if (!File.Exists(file))
                return;

            try
            {
                var dictionary = File.ReadAllLines(file);

                // Make sure that the shift-jis encoding is initialized in
                // .NET Core
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                Token = dictionary[3].Substring(6);
                EndDelimitator = dictionary[6].Substring(4);
                Language = dictionary[9].Substring(9);
                EncodingText = Encoding.GetEncoding(Convert.ToInt32(dictionary[12].Substring(9)));
                Flags = dictionary[15].Substring(6);

                for (int i = 20; i < dictionary.Length; i++)
                {
                    var line = dictionary[i];
                    
                    if (string.IsNullOrWhiteSpace(line) || line[0] == '#')
                        continue;

                    var lineFields = line.Split('=');
                    Map.dictionary.Add(lineFields[0].Replace("\\n", "\n"), lineFields[1].Replace("\\n", "\n"));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"The dictionary is wrong, please, check the readme and fix it.\n{e.Message}");
                System.Environment.Exit(-1);
            }
        }

    }
}
