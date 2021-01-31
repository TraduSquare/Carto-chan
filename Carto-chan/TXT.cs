using System;
using System.Collections.Generic;
using Yarhl.FileSystem;
using Yarhl.IO;
using Yarhl.Media.Text;

namespace Carto_chan
{

    class TXT
    {
        private static List<string> pointers = new();
        private static List<string> texts = new();

        public static void Export(string file)
        {
            Console.WriteLine("Exporting " + file + "...");
            Map.Generatedictionary();
            var textReader = new TextReader(DataStreamFactory.FromFile(file, FileOpenMode.Read), Map.EncodingText)
            {
                NewLine = "\r\n",
                AutoNewLine = true
            };

            do
            {
                var junk = string.Empty;
                if (textReader.Stream.Length == textReader.Stream.Position + 2)
                    break;
                
                do
                {
                    junk += textReader.ReadToToken(Map.Token);
                    junk += Map.Token + textReader.ReadToToken(")") + ")";
                    textReader.ReadLine();
                    junk += "\n";
                    var next = textReader.Peek(Map.Token.Length);
                    if (new string(next) != Map.Token)
                        break;


                } while (true);
                
                
                var text = textReader.ReadToToken(Map.EndDelimitator);

                pointers.Add(junk);
                texts.Add(Map.Replace(text, false));

            } while (!textReader.Stream.EndOfStream);

            ToPo(file);


        }

        private static void ToPo (string file)
        {
            var po = new Po
            {
                Header = new PoHeader("Game", "fiction@email.com", Map.Language)
                {
                    LanguageTeam = "Fiction",
                }
            };

            for (int i = 0; i < texts.Count; i++)
            {
                var text = string.IsNullOrWhiteSpace(texts[i]) ? "<!empty>" : texts[i];
                po.Add(new PoEntry(text)
                {
                    Context = i.ToString(),
                    ExtractedComments = (pointers[i]).Replace("\n", "<LINE>\n"),
                    Flags = Map.Flags
                });
            }
            file = file.Remove(file.Length - 3);
            var node = NodeFactory.FromMemory("node");
            node.TransformWith(new Po2BinaryEasy()
            {
                PoPassed = po
            }).TransformWith(new Po2Binary()).Stream.WriteTo(file + "po");
        }
    }
}
