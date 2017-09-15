using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using PSHelpEdit.Attributes;

namespace PSHelpEdit.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("inputTypes", HelpItemTypes.inputTypes)]
    public class InputTypesItem : HelpItemBase
    {
        #region Private fields
        #endregion
        //
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public InputTypesItem()
        {
        }
        public InputTypesItem(string name)
            :base(name)
        {
        }
        public InputTypesItem(string name,object value)
            : base(name, value)
        {
        }
        #endregion
        //
        #region Public properties.
        #endregion
        //
        #region Public Methods.
        #endregion
        //
        #region Baee overridden Methods.
        #endregion
    }
}
