using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;

using System.Xml.Linq;

namespace PSHelpEdit.Models
{
    [XmlTagType("terminatingErrors", HelpItemTypes.terminatingErrors)]
    public class TerminatingErrorsItem : HelpItemBase
    {
        //
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertItem"/> class.
        /// </summary>
        public TerminatingErrorsItem()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public TerminatingErrorsItem(string name)
            : base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public TerminatingErrorsItem(string name, object value)
            : base(name, value)
        {

        }
        #endregion
        //
        #region Base overridden methods
        public override void Load(XElement e)
        {
            base.Load(e);
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
    }
}
