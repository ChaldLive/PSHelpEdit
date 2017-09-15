using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;

using System.Xml.Linq;

namespace PSHelpEdit.Models
{

    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("description", HelpItemTypes.description)]
    public class DescriptionItem : HelpItemBase
    {
        #region Private fields
        #endregion
        //
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionItem"/> class.
        /// </summary>
        /// <remarks>Class file documentation please get here soon</remarks>
        public DescriptionItem()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public DescriptionItem(string name)
            :base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public DescriptionItem(string name, object value)
            :base(name, value)
        {
        }
        #endregion
        //
        #region Public properties.
        public string ParaValue
        {
            get { return Get_ParaValue(); }
            set 
            {
                OnPropertyChanging();
                Set_ParaValue(value);
                OnPropertyChanged();
            }
        }
        #endregion
        //
        #region Public Methods.
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
        #region Protected Methods.

        protected string Get_ParaValue()
        {
            string result = string.Empty;
            HelpItemBase para = GetChildWithName(Defines.para);
            if (para != null)
            {
                result = para.Value.ToString();
            }
            return result;
        }
        protected void Set_ParaValue(string value)
        {
            HelpItemBase para = GetChildWithName(Defines.para);
            if (para != null)
            {
                para.Value = value;
            }
        }
        #endregion
        //
        #region Private Methods.
        #endregion
        //
        #region Abstract virtual methods.
        #endregion
    }
      
}
