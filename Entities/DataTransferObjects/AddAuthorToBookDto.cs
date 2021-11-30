using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AddAuthorToBookDto
    {
        public Guid Id { get; set; }
        public List<Guid> AuthorsIds { get; set; }
    }
}
