using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit;
using PSHelpEdit.Attributes;
using System.Xml.Linq;

namespace PSHelpEdit.Models
{
    [XmlTagType("alertSet", HelpItemTypes.alertSet)]
    public class AlertSetItem : HelpItemBase
    {
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertSetItem"/> class.
        /// </summary>
        public AlertSetItem()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertSetItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public AlertSetItem(string name)
            : base(name)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertSetItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public AlertSetItem(string name, object value)
            : base(name,value)
        {

        }
        #endregion
        //
        #region ♦ Base overridden methods ♦
        public override void Load(XElement e)
        {
            base.Load(e);
            IEnumerable<AlertItem> alerts = GetChildrenWithName<AlertItem>(HelpItemTypes.alert.ToString());
            int nCounter = 0;
            foreach (AlertItem alert in alerts)
            {
                alert.NameValue = string.Format("Alert-({0})", nCounter++);
            }
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
    }
}
