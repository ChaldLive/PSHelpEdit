using System;
using System.Collections.Generic;

namespace PSHelpEdit.Interfaces
{
    public interface IHelpItem : IXSerialize
    {
        string Name { get; set; }
        object Value { get; set; }
        bool IsExpanded { get; set; }
        IHelpItem Parent { get; set; }
        PersistState PersistState { get; set; }
        //ItemState ItemState { get; set; }
        IEnumerable<IHelpItem> Children { get; }
        IEnumerable<IHelpItemAttribute> Attributes { get; }
        void AddChild(IHelpItem newChild);
        void RemoveChild(IHelpItem childToRemove);
    }
}
