﻿// Copyright (C) 2018 Darkmet98
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
using Yarhl.IO;
using Yarhl.FileFormat;
using Yarhl.Media.Text;

namespace Carto_chan
{
    class PO
    {
        private static bool Isimport = true;
        public static void Import(string file)
        {
            //Reading file
            Console.WriteLine("Importing " + file + "...");
            Po po = new BinaryFormat(new DataStream(file, FileOpenMode.Read)).ConvertTo<Po>(); //Flan code
            file = file.Remove(file.Length - 3);
            //Write file
            Yarhl.IO.TextWriter writer = new Yarhl.IO.TextWriter(new DataStream(file + ".txt", FileOpenMode.Write));
            writer.NewLine = "\r\n";
            writer.WriteLine("//GAME NAME:\t\t" + po.Header.ProjectIdVersion);
            foreach (var entry in po.Entries)
            {
                string potext = string.IsNullOrEmpty(entry.Translated) ?
                    entry.Original : entry.Translated;
                potext = potext.Replace("\n", "\\n");
                if (File.Exists("Dictionary.txt"))
                potext = Common.Replace(potext, Isimport);
                entry.Reference = entry.Reference.Replace("|", "\r\n\r\n//");
                writer.WriteLine("\r\n//" + entry.Reference + "\r\n");
                writer.WriteLine(potext + "\r\n");
            }
        }

    }
}