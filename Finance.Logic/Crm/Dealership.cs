using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Crm
{
    public class Dealership : Entity, IIsEnabled, IName
    {
        [Required]
        public bool IsEnabled { get; set; } = true;

        [Required]
        public string Name { get; set; }
    }
}
