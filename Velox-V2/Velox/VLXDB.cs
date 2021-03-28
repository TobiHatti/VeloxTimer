using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velox
{
    static class VLXDB
    {

        public static class Category
        {
            public static string Self { get => "category"; }

            public const string ID = "ID";
            public const string Name = "CategoryName";
            public const string Description = "CategoryDescription";
            public const string Color = "CategoryColor";
        }

        public static class Timestamps
        {
            public static string Self { get => "timestamps"; }

            public const string ID = "ID";
            public const string CategoryID = "CategoryID";
            public const string StartTime = "StartTime";
            public const string EndTime = "EndTime";
        }
    }
}
