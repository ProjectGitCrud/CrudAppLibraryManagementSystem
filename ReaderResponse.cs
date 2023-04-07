using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAppLibraryManagementSystem.Models
{
    public class ReaderResponse
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public Reader Reader { get; set; }

        public List<Reader> ListReaders { get; set; }
    }
}
