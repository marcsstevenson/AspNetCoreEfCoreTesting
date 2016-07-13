using System;
using System.Collections.Generic;

namespace Generic.Framework.Interfaces.GuidIdTree
{
    public interface IGuidTreeItemGeneric<T> : IGuidId
    {
        IGuidTreeItemGeneric<T> Parent { get; set; }
        ICollection<T> Children { get; set; }
        string Ancestry { get; set; }
    }
}