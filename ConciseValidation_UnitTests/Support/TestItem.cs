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
        public double TestDouble{ get; set; }
        public double? TestNullableDouble { get; set; }
    }
}
