using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.entity
{
    public class Mail
    {
        public int Id { get; set; }
        public int From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }

    }
}
