using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PSHelpEdit;
using PSHelpEdit.Attributes;

namespace PSHelpEdit.Models
{

    [XmlTagType("code", HelpItemTypes.code)]
    public class CodeItem : HelpItemBase
    {
        //
        #region ♦ Constructors  ♦
        public CodeItem(string name)
            :base(name)
        {

        }
        public CodeItem(string name, object value)
            : base(name, value)
        {

        }
        #endregion
        //
        #region ♦ Public properties ♦
        #endregion
        //
        #region ♦ Public methods ♦
        #endregion
        //
        #region ♦ Base overridden ♦
        /// <summary>
        /// Saves the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        /// <summary>
        /// Loads the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        public override void Load(XElement e)
        {
                base.Load(e);
        }
        #endregion
    }
}
