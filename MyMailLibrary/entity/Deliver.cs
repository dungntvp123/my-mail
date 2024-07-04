using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.entity
{
    public class Deliver
    {
        public int Id { get; set; }
        public int Mail { get; set; }
        public int To { get; set; }
        public int ReadStatus { get; set; }
    }
}
