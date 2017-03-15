using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;

namespace PSHelpEdit.Interfaces
{
    public interface IXSerialize
    {
        string ElementName { get; }
        /// <summary>
        /// Saves the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        void Save(XElement e);
        /// <summary>
        /// Loads the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        void Load(XElement e);
    }
}
