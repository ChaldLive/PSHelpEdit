using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSHelpEdit.Interfaces
{
    public interface IHelpItemAttribute
    {
        string Name { get; set; }
        object Value { get; set; }
        string ValueText { get; }
    }
}
