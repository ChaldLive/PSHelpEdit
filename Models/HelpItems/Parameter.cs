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
    [XmlTagType("parameter", HelpItemTypes.parameter)]
    public class ParameterItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        private ParameterValueGroupItem _valueGroup;
        private bool _editMode;
        #endregion
        //
        #region ♦ Constructors ♦
        public ParameterItem()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ParameterItem(string name)
            :base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public ParameterItem(string name, object value)
            :base(name, value)
        {
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        public override string NameValue
        {
            get
            {
                return Get_NameValue();
            }
            set
            {
                OnPropertyChanging();
                base.NameValue = value;
                Set_NameValue(value);
                OnPropertyChanged();
            }
        }
        public string NameText
        {
            get { return Get_NameText(); }
            set 
            { 
                OnPropertyChanging();
                Set_NameText(value);
                OnPropertyChanged();
            }
        }
        public bool VariableLenght
        {
            get { return Get_VariableLength(); }
            set 
            {
                OnPropertyChanging();
                Set_VariableLength(value);
                OnPropertyChanged();
            }
        }

        public bool Required
        {
            get { return Get_Required(); }
            set 
            {
                OnPropertyChanging();
                Set_Required(value);
                OnPropertyChanged();
            }
        }

        public bool Globbing
        {
            get { return Get_Globbing(); }
            set 
            {
                OnPropertyChanging();
                Set_Globbing(value);
                OnPropertyChanged();
            }
        }

        public bool PipelineInput
        {
            get { return Get_PipelineInput(); }
            set 
            {
                OnPropertyChanging();
                Set_PipelineInput(value);
                OnPropertyChanged();
            }
        }

        public string Possition
        {
            get { return Get_Possition(); }
            set 
            {
                OnPropertyChanging();
                Set_Possition(value);
                OnPropertyChanged();
            }
        }

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
        public ParameterValueGroupItem ValueGroup
        {
            get { return _valueGroup; }
            set 
            {
                OnPropertyChanging();
                _valueGroup = value;
                OnPropertyChanged();
            }
        }
        public string ParameterTypeValue
        {
            get { return Get_TypeItemValue(); }
            set 
            {
                OnPropertyChanging();
                Set_TypeItemValue(value);
                OnPropertyChanged();
            }
        }
        public TypeItem ParameterType
        {
            get { return Get_TypeItem(); }
            set 
            {
                OnPropertyChanging();
                Set_TypeItem(value);
                OnPropertyChanged();
            }
        }
        public string TypeUri
        {
            get { return Get_TypeUri(); }
            set 
            {
                OnPropertyChanging();
                Set_TypeUri(value);
                OnPropertyChanged();
            }
        }
        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                OnPropertyChanging();
                _editMode = value;
                OnPropertyChanged();
            }
        }

        #endregion
        //
        #region ♦ Public Methods. ♦
        public override void Load(XElement e)
        {
            base.Load(e);
            RemapHorizontallyAndVertically();
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
        //
        public static implicit operator ParameterItem(ParameterShadowItem shadow)
        {
            ParameterItem pi = shadow.PItem;
            pi.NameValue          = shadow.NameValue;
            pi.NameText           = shadow.NameText;
            pi.VariableLenght     = shadow.VariableLenght;
            pi.Required           = shadow.Required;
            pi.Globbing           = shadow.Globbing;
            pi.PipelineInput      = shadow.PipelineInput;
            pi.ValueGroup         = new ParameterValueGroupItem(pi.ValueGroup);
            pi.ParameterTypeValue = shadow.ParameterTypeValue;

            return shadow.PItem;
        }

        //
        #region ♦ Property Getter and setter methods aiding the problem of values in sub items in the XML tree structure. ♦
        //
        #region ♦ TypeItemValue getter and setter ♦
        protected string Get_TypeItemValue()
        {
            string result = string.Empty;
            TypeItem type = Get_TypeItem();
            if (type != null)
            {
                if (type.NameItem != null && type.NameItem.Value != null)
                    result = type.NameItem.Value.ToString();
            }
            return result;
        }
        protected void Set_TypeItemValue(string value)
        {
            TypeItem type = Get_TypeItem();
            if (type != null)
            {
                if (type.NameItem != null)
                    type.NameItem.Value = value;
            }
        }
        #endregion                
        //
        #region ♦  TypeItem getter and setter♦
        protected TypeItem Get_TypeItem()
        {
            TypeItem type = GetChildWidthNameRecursive<TypeItem>(HelpItemTypes.type.ToString());
            return type;
        }
        protected void Set_TypeItem(TypeItem value)
        {
            TypeItem type = GetChildWidthNameRecursive<TypeItem>(HelpItemTypes.type.ToString());
            if (type != null)
            {
                RemoveChild(type);
            }
            AddChild(value);
        }
        #endregion
        //
        #region ♦ VariableLength setter and getter ♦
        protected bool Get_VariableLength()
        {
            bool result = false;
            HelpItemAttribute variableLength = GetHelpItemAttributeWithName(Defines.variableLength);
            if (variableLength != null)
            {
                result = Convert.ToBoolean(variableLength.Value);
            }
            return result;
        }
        protected void Set_VariableLength(bool value)
        {
            HelpItemAttribute variableLength = GetHelpItemAttributeWithName(Defines.variableLength);
            if (variableLength != null)
            {
                variableLength.Value = value;
            }
        }
        #endregion
        //
        #region ♦ Required getter and setter ♦
        protected bool Get_Required()
        {
            bool result = false;
            HelpItemAttribute required = GetHelpItemAttributeWithName(Defines.required);
            if (required != null)
            {
                result = Convert.ToBoolean(required.Value);
            }
            return result;
        }
        protected void Set_Required(bool value)
        {
            HelpItemAttribute required = GetHelpItemAttributeWithName(Defines.required);
            if (required != null)
            {
                required.Value = value;
            }
        }
        #endregion
        //
        #region ♦ Globbing getter and setter ♦
        protected bool Get_Globbing()
        {
            bool result = false;
            HelpItemAttribute globbing = GetHelpItemAttributeWithName(Defines.globbing);
            if (globbing != null)
            {
                result = Convert.ToBoolean(globbing.Value);
            }
            return result;
        }
        protected void Set_Globbing(bool value)
        {
            HelpItemAttribute globbing = GetHelpItemAttributeWithName(Defines.globbing);
            if (globbing != null)
            {
                globbing.Value = value;
            }
        }
        #endregion
        //
        #region ♦  PipelineInput getter and setter ♦
        protected bool Get_PipelineInput()
        {
            bool result = false;
            HelpItemAttribute pipelineInput = GetHelpItemAttributeWithName(Defines.globbing);
            if (pipelineInput != null)
            {
                result = Convert.ToBoolean(pipelineInput.Value);
            }
            return result;
        }
        protected void Set_PipelineInput(bool value)
        {
            HelpItemAttribute pipelineInput = GetHelpItemAttributeWithName(Defines.globbing);
            if (pipelineInput != null)
            {
                pipelineInput.Value = value;
            }
        }
        #endregion
        //
        #region ♦  Possition getter and setter ♦
        protected string Get_Possition()
        {
            string result = string.Empty;
            HelpItemAttribute possition = GetHelpItemAttributeWithName(Defines.position);
            if (possition != null)
            {
                result = possition.ValueText;
            }
            return result;
        }
        protected void Set_Possition(string value)
        {
            HelpItemAttribute possition = GetHelpItemAttributeWithName(Defines.position);
            if (possition != null)
            {
                possition.Value = value;
            }
        }
        #endregion
        //
        #region ♦  NameText getter and setter ♦
        protected void Set_NameText(string value)
        {
            HelpItemBase nameItem = GetChildWithName(HelpItemTypes.name.ToString());
            if (nameItem != null)
            {
                nameItem.Value = value;
            }
        }
        protected string Get_NameText()
        {
            string result = string.Empty;
            HelpItemBase nameItem = GetChildWithName(HelpItemTypes.name.ToString());
            if (nameItem != null)
            {
                result = nameItem.Value.ToString();
            }
            return result;
        }
        #endregion
        //
        #region ♦ NameValue getter and setter ♦
        protected string Get_NameValue()
        {
            string result = string.Empty;
            HelpItemBase nameItem = GetChildWithName(HelpItemTypes.name.ToString());
            if (nameItem != null)
            {
                result = nameItem.Value.ToString();
            }
            return result;
        }
        protected void Set_NameValue(string value)
        {
            HelpItemBase nameItem = GetChildWithName(HelpItemTypes.name.ToString());
            if (nameItem != null)
            {
                nameItem.Value = value;
            }
        }
        #endregion
        //
        #region ♦ Description getter and setter ♦
        protected void Set_Description(string value)
        {
            DescriptionItem description = GetChildWidthName<DescriptionItem>(Defines.description);
            if (description != null)
            {
                description.ParaValue = value;
            }
        }
        protected string Get_Description()
        {
            string result = string.Empty;
            DescriptionItem description = GetChildWidthName<DescriptionItem>(Defines.description);
            if (description != null)
            {
                result = description.ParaValue;
            }
            return result;
        }
        #endregion
        //
        #region ♦ Type Uri Getter and setter ♦
        protected string Get_TypeUri()
        {
            string result = string.Empty;
            TypeItem type = GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
            if (type != null)
            {
                UriItem uri = type.GetChildWidthName<UriItem>(HelpItemTypes.uri.ToString());
                if (uri != null)
                {
                    result = uri.Value.ToString();
                }
            }
            return result;    
        }
        protected void Set_TypeUri(string value)
        {
            TypeItem type = GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
            if (type != null)
            {
                UriItem uri = type.GetChildWidthName<UriItem>(HelpItemTypes.uri.ToString());
                if (uri != null)
                {
                    uri.Value = value;
                }
            }
        }
        #endregion
        #endregion
        //
        #region ♦ Protected Methods. ♦
        private void RemapHorizontallyAndVertically()
        {
            RemapParameterValueGroup();
        }
        private void RemapParameterValueGroup()
        {
            IEnumerable<ParameterValueGroupItem> groups = GetChildrenWithName<ParameterValueGroupItem>(HelpItemTypes.parameterValueGroup.ToString());
            if (groups.Count() > 0)
            {
                ValueGroup = groups.ElementAt(0);
            }
        }
        #endregion
    }
}
