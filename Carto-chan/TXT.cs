﻿// Copyright (C) 2019 Pedro Garau Martínez
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
using System.IO;
using System.Collections.Generic;
using Yarhl.FileFormat;
using Yarhl.Media.Text;

namespace Carto_chan
{

    class TXT
    {
        private static bool Import = false;
        private static string Block = "";
        private static List<string> Pointers = new List<string>();
        private static List<string> Text = new List<string>();

        public static void Export(string file, string language)
        {
            Console.WriteLine("Exporting " + file + "...");
            string[] textfile = System.IO.File.ReadAllLines(file);
            //Gamename = textfile[0].Substring(14);
            foreach (string line in textfile)
            {
                if (line != "")
                {
                    string value = line.Substring(0, 1);
                    switch (value)
                    {
                        case "/":
                            Block = Block + "|" + line;
                            break;
                        case "#":
                            Block = Block + "|" + line;
                            break;
                        /*case "<":
                            Block = Block + "|" + line;
                            break;*/
                        default:
                            Pointers.Add(Block);
                            Block = "";

                            if (File.Exists("Dictionary.txt"))
                                Text.Add(Common.Replace(line, Import));
                            else
                                Text.Add(line);
                            break;
                    }
                }
            }
            ToPo(file, language);


        }

        private static void ToPo (string file, string language)
        {
            Po po = new Po
            {
                Header = new PoHeader("Game", "fiction@email.com", language)
                {
                    LanguageTeam = "Fiction",
                }
            };

            for (int i = 0; i < Text.Count; i++)
            {
                PoEntry entry = new PoEntry();

                entry.Context = i.ToString();
                entry.Original = Text[i];
                entry.Reference = Pointers[i];
                po.Add(entry);
            }
            file = file.Remove(file.Length - 3);
            po.ConvertTo<BinaryFormat>().Stream.WriteTo(file + "po");
        }
    }
}
