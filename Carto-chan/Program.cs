// Copyright (C) 2019 Pedro Garau Martínez
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

namespace Carto_chan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carto-chan 1.2 - A simple converter for Cartographer (And Atlas) TXT format to Po by Darkmet98.");
            Console.WriteLine("This program is under GPL V3 license.");
            if (args.Length != 1 && args.Length != 2 && args.Length != 3)
            {
                Console.WriteLine("USAGE: Carto-chan <-txt/-po/credits> \"file\" \"Language\"");
                Console.WriteLine("If you don't specify the translation's language, the default will be \"es\".");
                Console.WriteLine("Convert TXT to Po: Carto-chan -txt lb_script_001.txt en");
                Console.WriteLine("Convert Po to TXT: Carto-chan -po lb_script_001.po");
                Console.WriteLine("Show the credits: Carto-chan credits");
                Environment.Exit(-1);
            }
            switch (args[0])
            {
                case "-txt":
                    if (args.Length == 2 && File.Exists(args[1]))
                        TXT.Export(args[1], "es");
                    else if (args.Length == 3 && File.Exists(args[1]))
                        TXT.Export(args[1], args[2]);
                    else
                        Console.WriteLine("Error, the file doesn't exist");
                    break;
                case "-po":
                    if (args.Length == 2 && File.Exists(args[1]))
                        PO.Import(args[1]);
                    else
                        Console.WriteLine("Error, the file doesn't exist");
                    break;
                case "credits":
                    Console.WriteLine("Thanks to Pleonex for Yarhl libraries.");
                    Console.WriteLine("This logo has been originally created in its entirety by JohnSu and thus all rights belong to him.");
                    Console.WriteLine("https://www.deviantart.com/johnsu/art/Global-Cartographer-Atlyss-560955860");
                    break;
            }

        }
    }
}
