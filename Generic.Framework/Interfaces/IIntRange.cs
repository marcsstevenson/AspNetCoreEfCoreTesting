using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Framework.Interfaces
{
    public interface IIntRange
    {
        int? StartValue { get; set; }
        int? EndValue { get; set; }
    }
}
