using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PSHelpEdit.Attributes;
using System.Xml.Linq;

namespace PSHelpEdit.Models
{
    [XmlTagType("returnValues", HelpItemTypes.returnValues)]
    public class ReturnValuesItem : HelpItemBase
    {
        //
        #region Constructors
        public ReturnValuesItem()
        {

        }
        public ReturnValuesItem(string name)
            : base(name)
        {

        }
        public ReturnValuesItem(string name, object value)
            : base(name, value)
        {

        }
        #endregion
        //
        #region Base overridden methods.
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
