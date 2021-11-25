using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public  class AuthorBooksDto
    {
        public List<Guid> Id { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
