using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class BookForCreationDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<Guid> AuthorsIds { get; set; }
    }
}
