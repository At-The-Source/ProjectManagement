using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Exceptions
{
    // Used when not found, e.g. when doing an update operation.
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} & {key} was not found.")
        {

        }
    }
}
