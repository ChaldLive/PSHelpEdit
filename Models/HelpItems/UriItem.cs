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
    [XmlTagType("uri", HelpItemTypes.uri)]
    public class UriItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// 
        /// </summary>
        public UriItem()
        {
        }
        public UriItem(string name)
            :base(name)
        {
        }
        public UriItem(string name, object value)
            :base(name, value)
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
        #region ♦ Base overridden Methods. ♦
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
