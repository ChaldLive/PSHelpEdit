using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;


namespace PSHelpEdit.Models
{

    [XmlTagType("noun", HelpItemTypes.noun)]
    public class NounItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// Initializes a new instance of the <see cref="NameItem"/> class.
        /// </summary>
        public NounItem()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="NameItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public NounItem(string name)
            :base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="NameItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public NounItem(string name, object value)
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
