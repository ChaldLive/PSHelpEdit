using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;

using System.Xml.Linq;

namespace PSHelpEdit.Models
{
    /// <summary>
    /// Class VersionItem.
    /// </summary>
    [XmlTagType("version", HelpItemTypes.version)]
    public class VersionItem : HelpItemBase
    {
        //
        #region ♦  Constructor ♦
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public VersionItem(string name)
            :base(name)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public VersionItem(string name, object value)
            : base(name,value)
        {

        }
        #endregion
        //
        #region ♦ Public properties ♦
        #endregion
        //
        #region ♦ Public methods. ♦
        #endregion
        //
        #region ♦  Base overridden methods. ♦
        /// <summary>
        /// Loads the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        public override void Load(XElement e)
        {
            base.Load(e);
        }
        /// <summary>
        /// Saves the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion

    }
}
