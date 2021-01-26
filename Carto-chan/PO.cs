using System;
using System.IO;
using System.Text;
using Yarhl.IO;
using Yarhl.FileFormat;
using Yarhl.FileSystem;
using Yarhl.Media.Text;

namespace Carto_chan
{
    class PO
    {
        public static void Import(string file)
        {
            Console.WriteLine("Importing " + file + "...");
            var po = NodeFactory.FromFile(file).TransformWith(new Binary2Po()).GetFormatAs<Po>();
            var sb = new StringBuilder();
            Map.Generatedictionary();

            foreach (var poEntry in po.Entries)
            {
                var junk = poEntry.ExtractedComments.Replace("<LINE>\n", "\n");
                var text = poEntry.Text == "<!empty>" ? string.Empty : poEntry.Text;
                sb.Append(junk);
                sb.Append(Map.Replace(text, true) + Map.EndDelimitator);
            }
            File.WriteAllText(Path.GetFileNameWithoutExtension(file)+"_new.txt", sb.ToString(), Map.EncodingText);
        }
    }
}
