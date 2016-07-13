using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Framework.Interfaces
{
    /// <summary>
    /// Describes a volumn in cubic centimeters (cm3)
    /// </summary>
    public interface IVolumeCc
    {
        decimal VolumeCc { get; set; }
    }
}
