using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Framework.Interfaces
{
    public interface ILongId
    {
        [Key]
        long Id { get; set; }
    }
}
