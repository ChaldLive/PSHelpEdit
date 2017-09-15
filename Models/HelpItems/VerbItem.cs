using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;


namespace PSHelpEdit.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("verb", HelpItemTypes.verb)]
    public class VerbItem : HelpItemBase
    {
        #region Private fields
        #endregion
        //
        #region Constructors
        public VerbItem()
        {
        }
        public VerbItem(string name)
            :base(name)
        {
        }
        public VerbItem(string name, object value)
            :base(name,value)
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
