using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAppLibraryManagementSystem.Models
{
    public class Reader
    {
        //Attributes of table Reader in CrudAppLibraryManagementSystem database. 
        public int ReaderId { get; set; }

        public string ReaderName { get; set; }

        public string ReaderAddress { get; set; }

        public string ReaderContactNumber { get; set; }
    }
}
