using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PSHelpEdit.Attributes;


namespace PSHelpEdit.Models
{
    [XmlTagType("relatedLinks", HelpItemTypes.relatedLinks)]
    public class RelatedLinksItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// 
        /// </summary>
        public RelatedLinksItem()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueItem"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public RelatedLinksItem(string name)
            :base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueItem"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public RelatedLinksItem(string name, object value)
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
        #region ♦ Base overridden. ♦
        public override void Load(XElement e)
        {
            base.Load(e);
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
        //
        #region ♦ Private Methods. ♦
        #endregion
        //
        #region ♦ Abstract virtual methods. ♦
        #endregion
    }
}
