using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PSHelpEdit.Attributes;
using System.Xml.Linq;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Models
{
    [XmlTagType("returnValue", HelpItemTypes.returnValue)]
    public class ReturnValueItem : HelpItemBase
    {
        //
        #region Private fields
        private List<string> _returnDevTypes;
        private string _selctedDevReturnType;
        #endregion
        //
        #region Constructors
        public ReturnValueItem()
        {

        }
        public ReturnValueItem(string name)
            : base(name)
        {

        }
        public ReturnValueItem(string name, object value)
            : base(name, value)
        {

        }
        #endregion
        //
        #region Base overridden methods.
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
        #region Public properties.
        public List<string> ReturnDevTypes
        {
            get
            {
                if (_returnDevTypes == null)
                    _returnDevTypes = new List<string>();
                return _returnDevTypes;
            }
        }

        public string SelctedDevReturnType
        {
            get { return _selctedDevReturnType; }
            set 
            {
                OnPropertyChanging();
                _selctedDevReturnType = value;
                OnPropertyChanged();
            }
        }

        public string ReturnTypeName
        {
            get { return GetReturnTypeName(); }
            set 
            {
                OnPropertyChanging();
                SetReturnTypeName(value);
                OnPropertyChanged();
            }
        }

        public string ReturnTypeDescription
        {
            get { return GetReturnDescription(); }
            set 
            {
                OnPropertyChanging();
                SetReturnDescription(value);
                OnPropertyChanged();
            }
        }
        #endregion
        //
        #region Private helpers
        private void LoadInputTypesIntoMemory()
        {
            if (ReturnDevTypes.Count > 0)
                ReturnDevTypes.Clear();
            ReturnDevTypes.AddRange(TypeInfoUtil.Instance.TypeInfoNames);
        }

        private string GetReturnTypeName()
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
        private void SetReturnTypeName(string newValue)
        {
            TypeItem typeItem = GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
            if (typeItem != null)
            {
                NameItem nameItem = GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
                if (nameItem != null)
                {
                    nameItem.Value = newValue;
                }
            }
        }
        private string GetReturnDescription()
        {
            string result = string.Empty;
            DescriptionItem description = GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
            if (description != null)
            {
                ParaItem para = description.GetChildWidthName<ParaItem>(HelpItemTypes.para.ToString());
                if (para != null)
                {
                    result = para.Value.ToString();
                }
            }
            return result;
        }
        private void SetReturnDescription(string newValue)
        {
            DescriptionItem description = GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
            if (description != null)
            {
                ParaItem para = description.GetChildWidthName<ParaItem>(HelpItemTypes.para.ToString());
                if (para != null)
                {
                    para.Value = newValue;
                }
            }
        }
        #endregion
    }
}
