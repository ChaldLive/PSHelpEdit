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
    [XmlTagType("navigationLink", HelpItemTypes.navigationLink)]
    public class NavigationLinkItem : HelpItemBase
    {
        #region Private fields
        #endregion
        //
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public NavigationLinkItem()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public NavigationLinkItem(string name)
            : base(name)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public NavigationLinkItem(string name, object value)
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
        #region Base overridden Methods.
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
