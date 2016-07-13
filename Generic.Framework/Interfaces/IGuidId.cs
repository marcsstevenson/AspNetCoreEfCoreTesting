using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Framework.Interfaces
{
    public interface IGuidId
    {
        [Key]
        Guid Id { get; set; }
    }
}
