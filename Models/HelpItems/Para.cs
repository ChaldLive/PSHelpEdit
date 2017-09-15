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
    [XmlTagType("para", HelpItemTypes.para)]
    public class ParaItem : HelpItemBase
    {
        #region Private fields
        #endregion
        //
        #region Constructors
        public ParaItem()
        {
        }
        public ParaItem(string name)
            :base(name)
        {
        }
        public ParaItem(string name,object value)
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
