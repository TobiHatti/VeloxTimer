using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velox
{
    static class VLXLib
    {
        public static string ConfigFileName { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Endev", "Velox", "timestamps.db");

    }
}
