using System.ComponentModel.DataAnnotations;

namespace Generic.Framework.Interfaces
{
    public interface IName
    {
        [Required]
        [StringLength(128)]
        string Name { get; set; }
    }
}
