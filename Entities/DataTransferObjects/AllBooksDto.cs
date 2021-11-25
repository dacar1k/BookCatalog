using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public  class AllBooksDto
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
    }
}
