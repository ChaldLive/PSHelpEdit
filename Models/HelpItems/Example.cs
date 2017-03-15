using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;

using System.Xml.Linq;

namespace PSHelpEdit.Models
{
    [XmlTagType("example", HelpItemTypes.example)]
    public class Example : HelpItemBase
    {
        //
        #region ♦ Constructors ♦
        public Example(string name)
            : base(name)
        {

        }
        public Example(string name, object value)
            : base(name, value)
        {

        }
        #endregion
        //
        #region ♦ Public properties ♦
        #endregion
        //
        #region ♦ Public methods ♦
        #endregion
        //
        #region ♦ base overridden methods. ♦
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
