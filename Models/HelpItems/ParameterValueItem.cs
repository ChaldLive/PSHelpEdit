using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PSHelpEdit.Attributes;

using PSHelpEdit.Interfaces;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Models
{

    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("parameterValue", HelpItemTypes.parameterValue)]
    public class ParameterValueItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        private bool _required;
        private bool _variableLength;
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// 
        /// </summary>
        public ParameterValueItem()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueItem"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public ParameterValueItem(string name)
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
        public ParameterValueItem(string name, object value)
            : base(name,value)
        {
        }
        public ParameterValueItem(ParameterValueItem other)
        {
            CpyValues(other);
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        public bool Required
        {
            get { return _required; }
            set 
            {
                OnPropertyChanging();
                _required = value;
                OnPropertyChanged();
            }
        }

        public bool VariableLength
        {
            get { return _variableLength; }
            set 
            {
                OnPropertyChanging();
                _variableLength = value;
                OnPropertyChanged();
            }
        }

        #endregion
        //
        #region ♦ Public Methods. ♦
        #endregion
        //
        #region ♦ Base overridden. ♦
        public override void Load(XElement e)
        {
            base.Load(e);
            NameValue = e.Value;
            Required = GetAttributeValue<bool>(Defines.ParameterAttributeNames.required);
            VariableLength = GetAttributeValue<bool>(Defines.ParameterAttributeNames.variableLength);
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
        //
        #region ♦ Private Methods. ♦
        private void RemapAttributes()
        {
            //IEnumerable<HelpItemAttribute> attributes = GetChildrenWithName<HelpItemAttribute>("")
            //foreach(HelpItemAttribute in Attributes
        }
        #endregion
        //
        #region ♦ Abstract virtual methods. ♦
        #endregion
        //
        #region MyRegion
        private void CpyValues(ParameterValueItem other)
        {
            ParamUtil.IsNull(other, "ParameterValueItem other", "Parameteren er ikke korrekt initialiseret i kaldet til: {0}", "public static implicit ParameterValueItem(ParameterValueItem other)");
            Required = other.Required;
            VariableLength = other.VariableLength;
        }
        #endregion
    }

}
