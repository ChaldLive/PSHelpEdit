using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PSHelpEdit.Attributes;

namespace PSHelpEdit.Models
{

    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("copyright", HelpItemTypes.copyright)]
    public class CopyrightItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        #endregion
        //
        #region ♦ Constructors ♦
        public CopyrightItem()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CopyrightItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public CopyrightItem(string name)
            :base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CopyrightItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public CopyrightItem(string name, object value)
            : base(name,value)
        {
        }
        #endregion
        //
        #region ♦ Public properties. ♦

        public string ParaValue
        {
            get 
            { 
                return Get_ParaValue(); 
            }
            set 
            {
                Set_ParaValue(value);
            }
        }

        #endregion
        //
        #region ♦ Public Methods. ♦
        public void AddPara(string value)
        {
            ParaItem para = GetChildWidthName<ParaItem>(HelpItemTypes.para.ToString());
            if (para != null)
            {
                para.Value = value;
            }
            else
            {
                ParaItem newPara = new ParaItem(HelpItemTypes.para.ToString(), value);
                newPara.Value = value;
            }                
        }
        #endregion
        //
        #region ♦ Protected Methods. ♦
        protected string Get_ParaValue()
        {
            string result = string.Empty;
            ParaItem para = GetChildWidthName<ParaItem>(HelpItemTypes.para.ToString());
            if (para != null)
            {
                if (para.Value != null)
                    result = para.Value.ToString();
            }
            return result;
        }
        protected void Set_ParaValue(string value)
        {
            AddPara(value);
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
