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
    [XmlTagType("commandText", HelpItemTypes.commandText)]
    public class CommandTextItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// 
        /// </summary>
        public CommandTextItem()
        {
        }
        public CommandTextItem(string name)
            : base(name)
        {
        }
        public CommandTextItem(string name, object value)
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
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        public override void Load(XElement e)
        {
            base.Load(e);
        }
        #endregion
        //
    }
}
