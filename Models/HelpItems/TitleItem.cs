using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PSHelpEdit.Attributes;


namespace PSHelpEdit.Models
{

    [XmlTagType("title", HelpItemTypes.title)]
    public class TitleItem : HelpItemBase
    {
        //
        #region ♦ Constructors ♦
        public TitleItem(string name)
            :base(name)
        {

        }
        public TitleItem(string name, object value)
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
        #region ♦ Base overridden ♦
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
