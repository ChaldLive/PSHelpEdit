using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Models
{
    public class ParameterShadowItem
    {
        #region Private fields
        private string _nameValue;
        private string _nameText;
        private bool _variableLenght;
        private bool _required;
        private bool _globbing;
        private bool _pipelineInput;
        private string _possition;
        private string _description;
        private ParameterValueGroupItem _parameterValueGroup;
        private string _parameterTypeValue;
        private TypeItem _typeItem;
        private string _typeUri;
        private ParameterItem _pItem;
        #endregion
        //
        #region Public initialisation
        public ParameterShadowItem(ParameterItem pItem)
        {
            SetItem(pItem);
        }
        #endregion
        //
        #region Private / protected initialisation
        protected ParameterShadowItem()
        {

        }
        #endregion
        //
        #region Public properties

        public string NameValue
        {
            get{return _nameValue;}
            set{_nameValue = value;}
        }
        public string NameText
        {
            get { return _nameText; }
            set { _nameText = value; }
        }
        public bool VariableLenght
        {
            get { return _variableLenght; }
            set { _variableLenght = value; }
        }

        public bool Required
        {
            get { return _required; }
            set { _required = value; }
        }

        public bool Globbing
        {
            get { return _globbing; }
            set { _globbing = value; }
        }

        public bool PipelineInput
        {
            get { return _pipelineInput; }
            set { _pipelineInput = value; }
        }

        public string Possition
        {
            get { return _possition; }
            set { _possition = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ParameterValueGroupItem ValueGroup
        {
            get { return _parameterValueGroup; }
            set{_parameterValueGroup = value;}
        }
        public string ParameterTypeValue
        {
            get { return _parameterTypeValue; }
            set { _parameterTypeValue = value; }
        }
        public TypeItem ParameterType
        {
            get { return _typeItem; }
            set { _typeItem = value; }
        }
        public string TypeUri
        {
            get { return _typeUri; }
            set{ _typeUri = value; }
        }

        public ParameterItem PItem
        {
            get{return _pItem;}
            set{_pItem = value;}
        }
        #endregion
        //
        #region private void SetItem(ParameterItem pItem)
        private ParameterShadowItem SetItem(ParameterItem pItem)
        {
            ParamUtil.IsNull(pItem, "ParameterItem pItem", "Parameteren er ikke korrekt initialiseret i kaldet til denne metode: {0}", "private ParameterShadowItem SetItem(ParameterItem pItem)");
            ParameterShadowItem result = new ParameterShadowItem();

            NameValue          = pItem.NameValue;
            NameText           = pItem.NameText;
            VariableLenght     = pItem.VariableLenght;
            Required           = pItem.Required;
            Globbing           = pItem.Globbing;
            PipelineInput      = pItem.PipelineInput;
            ValueGroup         = new ParameterValueGroupItem(pItem.ValueGroup);
            ParameterTypeValue = pItem.ParameterTypeValue;
            PItem = pItem;

            if (pItem.ParameterType != null)
                ParameterType = new TypeItem(pItem.ParameterType.Name, pItem.ParameterType.Value);
            return result;
        }
        #endregion

        #region 
        public static implicit operator ParameterShadowItem(ParameterItem pItem)
        {
            return new ParameterShadowItem(pItem);
        }
        #endregion
    }
}
