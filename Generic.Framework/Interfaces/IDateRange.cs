using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Framework.Interfaces
{
    public interface IDateRange
    {
        DateTime StartDate { get; set; }
        
        DateTime EndDate { get; set; }
    }
}
