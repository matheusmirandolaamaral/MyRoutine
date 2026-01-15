using MyRoutine.Models.Enums;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace MyRoutine.Models
{
     class Record
    {
        public string  Description  { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public TypeRecord Type { get; set; }

    }
}
