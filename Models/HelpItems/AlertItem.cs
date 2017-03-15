using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;
using PSHelpEdit;
using PSHelpEdit.Attributes;

namespace PSHelpEdit.Models
{
    [XmlTagType("alert", HelpItemTypes.alert)]
    public class AlertItem : HelpItemBase
    {
        //
        #region ♦ Private fields ♦
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertItem"/> class.
        /// </summary>
        public AlertItem()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public AlertItem(string name)
            : base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public AlertItem(string name, object value)
            : base(name, value)
        {

        }
        #endregion
        //
        #region ♦ Public properties ♦

        public string Description
        {
            get { return Get_Description(); }
            set 
            {
                OnPropertyChanging();
                Set_Description(value); 
                OnPropertyChanged();
            }
        }


        #endregion
        //
        #region ♦ Private helper methods ♦
        protected string Get_Description()
        {
            string result = string.Empty;
            ParaItem para = GetChildWidthName<ParaItem>(HelpItemTypes.para);
            if (para != null)
            {
                result = para.Value.ToString();
            }
            return result;
        }
        protected void Set_Description(string value)
        {
            ParaItem para = GetChildWidthName<ParaItem>(HelpItemTypes.para);
            if (para != null)
            {
                para.Value = value;
            }
        }
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
