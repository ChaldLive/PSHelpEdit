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
    [XmlTagType("parameters", HelpItemTypes.parameters)]
    public class Parameters : HelpItemBase
    {
        #region ♦ Private fields ♦
        #endregion
        //
        #region ♦ Constructors ♦
        public Parameters(string name)
            :base(name)
        {
        }
        public Parameters(string name, object value)
            : base(name,value)
        {
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        #endregion
        //
        #region ♦ Public Methods. ♦
        #endregion
        //
        #region ♦ Protected Methods. ♦
        #endregion
        //
        #region ♦ Private Methods. ♦
        #endregion
        //
        #region ♦ Abstract virtual methods. ♦
        #endregion
    }
      
}
