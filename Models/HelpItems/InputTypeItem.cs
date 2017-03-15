using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using PSHelpEdit.Attributes;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Models
{
    
    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("inputType", HelpItemTypes.inputType)]
    public class InputTypeItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        private List<string> _inputDevTypes;
        private string _selctedDevInputType;
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// 
        /// </summary>
        public InputTypeItem()
        {
        }
        public InputTypeItem(string name)
            :base(name)
        {
        }
        public InputTypeItem(string name, object value)
            : base(name,value)
        {
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        /// <summary>
        /// Gets the input dev types.
        /// </summary>
        /// <value>
        ///  The input dev types.
        /// </value>
        public List<string> InputDevTypes
        {
            get
            {
                if (_inputDevTypes == null)
                    _inputDevTypes = new List<string>();
                return _inputDevTypes;
            }
        }
        public string SelctedDevInputType
        {
            get { return _selctedDevInputType; }
            set
            {
                OnPropertyChanged();
                _selctedDevInputType = value;
                OnPropertyChanged();
            }
        }

        public string DevType
        {
            get { return GetDevTypeValue(); }
            set 
            {
                OnPropertyChanging();
                SetDevTypeValue(value);
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return GetDescriptionValue(); }
            set 
            {
                OnPropertyChanging();
                SetDescriptionValue(value);
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
            LoadInputTypesIntoMemory();
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
        //
        #region ♦ Private helper methods. ♦
        private void RemapSubitemValues()
        {
            GetDescriptionValue();
            GetDevTypeValue();
        }
        
        private void LoadInputTypesIntoMemory()
        {
            if (InputDevTypes.Count > 0)
                InputDevTypes.Clear();
            InputDevTypes.AddRange(TypeInfoUtil.Instance.TypeInfoNames);
        }
        private string GetDescriptionValue()
        {
            string result = string.Empty;
            DescriptionItem descriptionItem = GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
            if (descriptionItem != null)
            {
                ParaItem paraItem = descriptionItem.GetChildWidthName<ParaItem>(HelpItemTypes.para.ToString());
                if (paraItem != null)
                {
                    result = paraItem.Value.ToString();
                }
            }
            return result;
        }
        private void SetDescriptionValue(string newValue)
        {
            DescriptionItem descriptionItem = GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
            if (descriptionItem != null)
            {
                ParaItem paraItem = descriptionItem.GetChildWidthName<ParaItem>(HelpItemTypes.para.ToString());
                if (paraItem != null)
                {
                    paraItem.Value = newValue;
                }
            }
        }

        private string GetDevTypeValue()
        {
            string result = string.Empty;
            TypeItem typeItem = GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
            if (typeItem != null)
            {
                NameItem nameItem = typeItem.GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
                if (nameItem != null)
                {
                    result = nameItem.Value.ToString();
                }
            }
            return result;
        }
        private void SetDevTypeValue(string newValue)
        {
            TypeItem typeItem = GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
            if (typeItem != null)
            {
                NameItem nameItem = typeItem.GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
                if (nameItem != null)
                {
                    nameItem.Value = newValue;
                }
            }
        }
        #endregion
    }
}
