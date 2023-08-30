using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snegir.Core.Entities
{
    public class Storage
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public List<Content> Contents { get; set; } = new();
    }
}
