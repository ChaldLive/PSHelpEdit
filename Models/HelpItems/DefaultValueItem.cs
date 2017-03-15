using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PSHelpEdit.Attributes;
using System.Xml.Linq;

namespace PSHelpEdit.Models
{

    [XmlTagType("defaultValue", HelpItemTypes.defaultValue)]
    public class DefaultValueItem : HelpItemBase
    {
        //
        #region ♦  Constructors ♦
        public DefaultValueItem()
        {

        }
        public DefaultValueItem(string name)
            : base(name)
        {

        }
        public DefaultValueItem(string name, object value)
            : base(name, value)
        {

        }
        #endregion
        //
        #region ♦ Public properties ♦
        #endregion
        //
        #region ♦ Base overridden methods ♦
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
