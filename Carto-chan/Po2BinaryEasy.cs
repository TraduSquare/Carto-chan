using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.FileFormat;
using Yarhl.IO;
using Yarhl.Media.Text;

namespace Carto_chan
{
    public class Po2BinaryEasy : IConverter<BinaryFormat, Po>
    {
        public Po PoPassed { get; set; }
        public Po Convert(BinaryFormat source)
        {
            return PoPassed;
        }
    }
}
