using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation_UnitTests.Support
{
    public class TestItem
    {
        public string TestString { get; set; }
        public DateTime TestDateTime { get; set; }
        public DateTime? TestNullableDateTime { get; set;}
        public int? TestNullableInt { get; set; }
        public int TestInt { get; set; }
        public long TestLong { get; set; }
        public long? TestNullableLong { get; set; }
    }
}
