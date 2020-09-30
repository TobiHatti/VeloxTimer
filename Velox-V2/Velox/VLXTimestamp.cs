using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velox
{
    class VLXTimestamp
    {
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        public TimeSpan TimeSpan 
        {
            get => EndTime - StartTime;
        }
    }
}
