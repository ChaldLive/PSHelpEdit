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
    [XmlTagType("commandLine", HelpItemTypes.commandLine)]
    public class CommandLineItem : HelpItemBase
    {
        #region Private fields
        #endregion
        //
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public CommandLineItem()
        {
        }
        public CommandLineItem(string name)
            : base(name)
        {
        }
        public CommandLineItem(string name, object value)
            :base(name, value)
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
        #region Protected Methods.
        #endregion
        //
        #region Private Methods.
        #endregion
        //
        #region Abstract virtual methods.
        #endregion
    }
      
}
