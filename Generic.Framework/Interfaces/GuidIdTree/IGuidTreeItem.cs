using System;
using System.Collections.Generic;

namespace Generic.Framework.Interfaces.GuidIdTree
{
    public interface IGuidTreeItem : IGuidId
    {
        IGuidTreeItem Parent { get; set; }
        ICollection<IGuidTreeItem> Children { get; set; }
        string Ancestry { get; set; }
        //bool PendingDeletion { get; set; }
    }
}