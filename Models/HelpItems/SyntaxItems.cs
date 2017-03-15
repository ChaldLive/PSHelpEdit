using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;

using System.Xml.Linq;

namespace PSHelpEdit.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("syntax", HelpItemTypes.syntax)]
    public class SyntaxItems : HelpItemBase
    {
        #region ♦ Private fields ♦
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxItems"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public SyntaxItems(string name)
            : base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxItems"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public SyntaxItems(string name, object value)
            : base(name,value)
        {
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        #endregion
        //
        #region ♦ Public Methods. ♦
        public override void Load(XElement e)
        {
            base.Load(e);
        }
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
