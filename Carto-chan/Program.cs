using System;
using System.IO;

namespace Carto_chan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carto-chan 2 - A simple converter for Cartographer (And Atlas) TXT format to Po by Darkmet98.");
            Console.WriteLine("Thanks to Pleonex for Yarhl libraries.");
            Console.WriteLine("This logo has been originally created in its entirety by JohnSu and thus all rights belong to him.");
            Console.WriteLine("https://www.deviantart.com/johnsu/art/Global-Cartographer-Atlyss-560955860");

            if (args.Length != 1)
            {
                Console.WriteLine("\n\nUSAGE: Carto-chan \"file\"");
                Environment.Exit(0);
            }

            var extension = Path.GetExtension(args[0]).ToUpper();

            switch (extension)
            {
                case ".PO":
                    PO.Import(args[0]);
                    break;
                case ".TXT":
                    TXT.Export(args[0]);
                    break;
                default:
                    throw new Exception("That file is not supported.\nCartochan only supports txt and po files.");
            }


            /*if (args.Length != 1 && args.Length != 2 && args.Length != 3)
            {
                
            }
            switch (args[0])
            {
                case "-txt":
                    if (args.Length == 2 && File.Exists(args[1]))
                        TXT.Export(args[1], "es");
                    else if (args.Length == 3 && File.Exists(args[1]))
                        
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
                    
                    break;
            }*/

        }
    }
}
