// ***********************************************************************
// Assembly         : PSHelpEdit
// Author           : Chald
// Created          : 06-19-2015
//
// Last Modified By : Chald
// Last Modified On : 06-23-2015
// ***********************************************************************
// <copyright file="CommandItem.cs" company="FACILIA f.m.b.a">
//     
//
// </copyright>
// <summary>
// 
// </summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit;
using PSHelpEdit.Attributes;
using System.Xml.Linq;
using PSHelpEdit.Utils;
using System.Runtime.CompilerServices;

namespace PSHelpEdit.Models
{
    /// <summary>
    /// Class CommandItem.
    /// </summary>
    [XmlTagType("command",HelpItemTypes.command)]
    public class CommandItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        private List<string> _verbs;
        private SyntaxItem _syntaxItem;
        private bool _editMode;
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItem" /> class.
        /// </summary>
        /// <remarks>Class file documentation please get here soon</remarks>
        public CommandItem()
        {
            Copyright = Defines.CopyrigthValue;
            IsExpanded = true;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItem" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public CommandItem(string name)
            :base(name)
        {
            Copyright = Defines.CopyrigthValue;
            IsExpanded = true;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandItem" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public CommandItem(string name, object value)
            :base(name, value)
        {
            Copyright = Defines.CopyrigthValue;
            IsExpanded = true;
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        public override string NameValue
        {
            get
            {
                return Get_CommandName();
            }
            set
            {
                OnPropertyChanging();
                base.NameValue = value;
                Set_CommandName(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets the verbs.
        /// </summary>
        /// <value>
        ///  The verbs.
        /// </value>
        public List<string> Verbs
        {
            get
            {
                if (_verbs == null)
                {
                    _verbs = new List<string>();
                    _verbs.AddRange(Defines.CommandVerbNames);
                }
                return _verbs;
            }
        }
        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        /// <value>
        ///  The name of the command.
        /// </value>
        public string CommandName
        {
            get { return Get_CommandName(); }
            set 
            {
                OnPropertyChanging();
                Set_CommandName(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        ///  The description.
        /// </value>
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
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        /// <value>
        ///  The copyright.
        /// </value>
        public string Copyright
        {
            get 
            {
                return Get_Copyright(); 
            }
            set 
            {
                OnPropertyChanging();
                Set_Copyright(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the verb.
        /// </summary>
        /// <value>
        ///  The verb.
        /// </value>
        public string Verb
        {
            get { return Get_Verb(); }
            set 
            {
                OnPropertyChanging();
                Set_Verb(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the noun.
        /// </summary>
        /// <value>
        ///  The noun.
        /// </value>
        public string Noun
        {
            get { return Get_Noun(); }
            set 
            {
                OnPropertyChanging();
                Set_Noun(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        ///  The version.
        /// </value>
        public string Version
        {
            get { return Get_Version(); }
            set 
            {
                OnPropertyChanging();
                Set_Version(value); 
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the type of the input.
        /// </summary>
        /// <value>
        ///  The type of the input.
        /// </value>
        public string InputType
        {
            get { return Get_InputType(); }
            set 
            {
                OnPropertyChanging();
                Set_InputType(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the input type URI.
        /// </summary>
        /// <value>
        ///  The input type URI.
        /// </value>
        public string InputTypeUri
        {
            get { return Get_InputTypeUri(); }
            set
            {
                OnPropertyChanging();
                Set_InputTypeUri(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the input type description.
        /// </summary>
        /// <value>
        ///  The input type description.
        /// </value>
        public string InputTypeDescription
        {
            get { return Get_InputTypeDescription(); }
            set
            {
                OnPropertyChanging();
                Set_InputTypeDescription(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the type of the return.
        /// </summary>
        /// <value>
        ///  The type of the return.
        /// </value>
        public string ReturnType
        {
            get { return Get_ReturnType(); }
            set 
            {
                OnPropertyChanging();
                Set_ReturnType(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the return type description.
        /// </summary>
        /// <value>
        ///  The return type description.
        /// </value>
        public string ReturnTypeDescription
        {
            get { return Get_ReturnTypeDescription(); }
            set
            {
                OnPropertyChanging();
                Set_ReturnTypeDescription(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the return type URI.
        /// </summary>
        /// <value>
        ///  The return type URI.
        /// </value>
        public string ReturnTypeUri
        {
            get { return Get_ReturnTypeUri(); }
            set
            {
                OnPropertyChanging();
                Set_ReturnTypeUri(value);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the syntax item.
        /// </summary>
        /// <value>
        ///  The syntax item.
        /// </value>
        public SyntaxItem SyntaxItem
        {
            get { return _syntaxItem; }
            set { _syntaxItem = value; }
        }

        /// <summary>
        /// Gets or sets the edit mode.
        /// </summary>
        /// <value>The edit mode.</value>
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
        public ParameterItem AddParameter(string paramName)
        {
            ParamUtil.IsNull(paramName, "string paramName", "Parameteren er ikke korrekt initialiseret i kaldet til AddParameter metoden.");
            Parameters parameters = GetChildWidthName<Parameters>(HelpItemTypes.parameters.ToString());
            if (parameters == null)
            {
                parameters = new Parameters(HelpItemTypes.parameters.ToString());
                this.AddChild(parameters);
            }
            ParameterItem newParam = new ParameterItem(paramName);
            parameters.AddChild(newParam);
            return newParam;
        }
        public void RemoveParameter(string paramName)
        {
            ParamUtil.IsNull(paramName, "string paramName", "Parameteren er ikke korrekt initialiseret i kaldet til AddParameter RemoveParameter.");

        }
        #endregion
        //
        #region ♦ Overridden methods. ♦
        /// <summary>
        /// Called when [property notify changed].
        /// </summary>
        /// <param name="propertyName">
        /// </param>
        protected override void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            //
            if (PersistState == PersistState.IsLoading || PersistState == PersistState.IsSaving)
                return;
            switch(propertyName)
            {
                case "Verb":
                    OnVerbChanged(Verb);
                    break;
                case "Noun":
                    OnNounChanged(Noun);
                    break;

            }
        }
        /// <summary>
        /// Loads the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        public override void Load(XElement e)
        {
            base.Load(e);
            PersistState = PersistState.IsLoading;
            // Få model elementet til at passe til et 
            // Relativt fornuftigt layout.
            RemapLayoutValues();
            //
            PersistState = PersistState.IsNeutral;
        }
        /// <summary>
        /// Saves the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
        //
        #region ♦ Property changed event handlers. ♦
        private void OnVerbChanged(string newVerbName)
        {
            string commandName = CommandName;
            string[] commandSplits = commandName.Split('-');
            if (commandSplits.Length > 0)
            {
                CommandName = string.Format("{0}-{1}", newVerbName, commandSplits[1]);
                NameValue = CommandName;
            }
        }

        private void OnNounChanged(string newNounName)
        {
            string commandName = CommandName;
            string[] commandSplits = commandName.Split('-');
            if (commandSplits.Length > 0)
            {
                CommandName = string.Format("{0}-{1}", commandSplits[0],newNounName);
                NameValue = CommandName;
            }
        }
        private void OnCommandNameChanged(string newCommandName)
        {
            string commandName = CommandName;
            string[] commandSplits = commandName.Split('-');
            if (commandSplits.Length > 0)
            {
                Noun = commandSplits[0];
                Verb = commandSplits[1];
            }
        }
        #endregion
        //
        #region ♦ Private load helpers. ♦
        #endregion
        //
        #region ♦ Protected property getters and setters helpers ♦

        protected string Get_ReturnTypeUri()
        {
            string result = string.Empty;
            ReturnValuesItem returnValues = GetChildWidthName<ReturnValuesItem>(HelpItemTypes.returnValues);
            if (returnValues != null)
            {
                ReturnValueItem returnValue = returnValues.GetChildWidthName<ReturnValueItem>(HelpItemTypes.returnValue);
                if (returnValue != null)
                {
                    TypeItem typeItem = returnValue.GetChildWidthName<TypeItem>(HelpItemTypes.type);
                    if (typeItem != null)
                    {
                        UriItem uri = typeItem.GetChildWidthName<UriItem>(HelpItemTypes.uri);
                        if (uri != null)
                        {
                            result = uri.Value.ToString();
                        }
                    }
                }
            }
            return result;
        }

        protected void Set_ReturnTypeUri(string value)
        {
            ReturnValuesItem returnValues = GetChildWidthName<ReturnValuesItem>(HelpItemTypes.returnValues);
            if (returnValues != null)
            {
                ReturnValueItem returnValue = returnValues.GetChildWidthName<ReturnValueItem>(HelpItemTypes.returnValue);
                if (returnValue != null)
                {
                    TypeItem typeItem = returnValue.GetChildWidthName<TypeItem>(HelpItemTypes.type);
                    if (typeItem != null)
                    {
                        UriItem uri = typeItem.GetChildWidthName<UriItem>(HelpItemTypes.uri);
                        if (uri != null)
                        {
                            uri.Value = value;
                        }
                    }
                }
            }
        }

        protected string Get_ReturnTypeDescription()
        {
            string result = string.Empty;
            ReturnValuesItem returnValues = GetChildWidthName<ReturnValuesItem>(HelpItemTypes.returnValues);
            if (returnValues != null)
            {
                ReturnValueItem returnValue = returnValues.GetChildWidthName<ReturnValueItem>(HelpItemTypes.returnValue);
                if (returnValue != null)
                {
                    DescriptionItem description = returnValue.GetChildWidthName<DescriptionItem>(HelpItemTypes.description);
                    if (description != null)
                    {
                        ParaItem para = description.GetChildWidthName<ParaItem>(HelpItemTypes.para);
                        if (para != null)
                        {
                            result = para.Value.ToString();
                        }
                    }
                }
            }
            return result;
        }

        protected void Set_ReturnTypeDescription(string value)
        {
            ReturnValuesItem returnValues = GetChildWidthName<ReturnValuesItem>(HelpItemTypes.returnValues);
            if (returnValues != null)
            {
                ReturnValueItem returnValue = returnValues.GetChildWidthName<ReturnValueItem>(HelpItemTypes.returnValue);
                if (returnValue != null)
                {
                    DescriptionItem description = returnValue.GetChildWidthName<DescriptionItem>(HelpItemTypes.description);
                    if (description != null)
                    {
                        ParaItem para = description.GetChildWidthName<ParaItem>(HelpItemTypes.para);
                        if (para != null)
                        {
                            para.Value = value;
                        }
                    }
                }
            }
        }


        protected string Get_ReturnType()
        {
            string result = string.Empty;
            ReturnValuesItem returnValues = GetChildWidthName<ReturnValuesItem>(HelpItemTypes.returnValues);
            if (returnValues != null)
            {
                ReturnValueItem returnValue = returnValues.GetChildWidthName<ReturnValueItem>(HelpItemTypes.returnValue);
                if (returnValue != null)
                {
                    TypeItem typeItem = returnValue.GetChildWidthName<TypeItem>(HelpItemTypes.type);
                    if (typeItem != null)
                    {
                        NameItem nameItem = typeItem.GetChildWidthName<NameItem>(HelpItemTypes.name);
                        if (nameItem != null)
                        {
                            result = nameItem.Value.ToString();
                        }
                    }
                }
            }
            return result;
        }

        protected void Set_ReturnType(string value)
        {
            ReturnValuesItem returnValues = GetChildWidthName<ReturnValuesItem>(HelpItemTypes.returnValues);
            if (returnValues != null)
            {
                ReturnValueItem returnValue = returnValues.GetChildWidthName<ReturnValueItem>(HelpItemTypes.returnValue);
                if (returnValue != null)
                {
                    TypeItem typeItem = returnValue.GetChildWidthName<TypeItem>(HelpItemTypes.type);
                    if (typeItem != null)
                    {
                        NameItem nameItem = typeItem.GetChildWidthName<NameItem>(HelpItemTypes.name);
                        if (nameItem != null)
                        {
                            nameItem.Value = value;
                        }
                    }
                }
            }
        }

        protected string Get_InputType()
        {
            string result = string.Empty;
            InputTypesItem inputTypes = GetChildWidthName<InputTypesItem>(HelpItemTypes.inputTypes.ToString());
            if(inputTypes != null)
            {
                InputTypeItem inputType = inputTypes.GetChildWidthName<InputTypeItem>(HelpItemTypes.inputType.ToString());
                if(inputType != null)
                {
                    TypeItem type = inputType.GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
                    if(type != null)
                    {
                        NameItem name = type.GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
                        if(name != null)
                        {
                            result = name.Value.ToString();
                        }
                    }
                }
            }
            return result;
        }

        protected void Set_InputType(string value)
        {
            InputTypesItem inputTypes = GetChildWidthName<InputTypesItem>(HelpItemTypes.inputTypes.ToString());
            if (inputTypes != null)
            {
                InputTypeItem inputType = inputTypes.GetChildWidthName<InputTypeItem>(HelpItemTypes.inputType.ToString());
                if (inputType != null)
                {
                    TypeItem type = inputType.GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
                    if (type != null)
                    {
                        NameItem name = type.GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
                        if (name != null)
                        {
                            name.Value = value;
                        }
                    }
                }
            }
        }


        protected string Get_InputTypeUri()
        {
            string result = string.Empty;
            InputTypesItem inputTypes = GetChildWidthName<InputTypesItem>(HelpItemTypes.inputTypes.ToString());
            if (inputTypes != null)
            {
                InputTypeItem inputType = inputTypes.GetChildWidthName<InputTypeItem>(HelpItemTypes.inputType.ToString());
                if (inputType != null)
                {
                    TypeItem type = inputType.GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
                    if (type != null)
                    {
                        UriItem uri = type.GetChildWidthName<UriItem>(HelpItemTypes.uri.ToString());
                        if (uri != null)
                        {
                            result = uri.Value.ToString();
                        }
                    }
                }
            }
            return result;
        }

        protected void Set_InputTypeUri(string value)
        {
            InputTypesItem inputTypes = GetChildWidthName<InputTypesItem>(HelpItemTypes.inputTypes.ToString());
            if (inputTypes != null)
            {
                InputTypeItem inputType = inputTypes.GetChildWidthName<InputTypeItem>(HelpItemTypes.inputType.ToString());
                if (inputType != null)
                {
                    TypeItem type = inputType.GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
                    if (type != null)
                    {
                        UriItem uri = type.GetChildWidthName<UriItem>(HelpItemTypes.uri.ToString());
                        if (uri != null)
                        {
                            uri.Value = value;
                        }
                    }
                }
            }
        }

        protected string Get_InputTypeDescription()
        {
            string result = string.Empty;
            InputTypesItem inputTypes = GetChildWidthName<InputTypesItem>(HelpItemTypes.inputTypes.ToString());
            if (inputTypes != null)
            {
                InputTypeItem inputType = inputTypes.GetChildWidthName<InputTypeItem>(HelpItemTypes.inputType.ToString());
                if (inputType != null)
                {
                    DescriptionItem description = inputType.GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
                    if (description != null)
                    {
                        IEnumerable<ParaItem> paras = description.GetChildrenWithName<ParaItem>(HelpItemTypes.para.ToString());
                        foreach (ParaItem para in paras)
                        {
                            if(para.Value != null)
                            {
                                result += para.Value + "\r\n";
                            }
                        }
                    }
                }
            }
            return result;
        }

        protected void Set_InputTypeDescription(string value)
        {
            InputTypesItem inputTypes = GetChildWidthName<InputTypesItem>(HelpItemTypes.inputTypes.ToString());
            if (inputTypes != null)
            {
                InputTypeItem inputType = inputTypes.GetChildWidthName<InputTypeItem>(HelpItemTypes.inputType.ToString());
                if (inputType != null)
                {
                    TypeItem type = inputType.GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
                    if (type != null)
                    {
                        DescriptionItem description = type.GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
                        if (description != null)
                        {
                            description.Value = value;
                        }
                    }
                }
            }
        }

        protected string Get_DevTypeUri()
        {
            string result = string.Empty;
            TypeItem devTypeItem = GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
            if (devTypeItem != null)
            {
                UriItem uri = devTypeItem.GetChildWidthName<UriItem>(HelpItemTypes.uri.ToString());
                if (uri != null)
                {
                    result = uri.Value.ToString();
                }
            }
            return result;
        }

        protected void Set_DevTypeUri(string value)
        {
            TypeItem devTypeItem = GetChildWidthName<TypeItem>(HelpItemTypes.type.ToString());
            if (devTypeItem != null)
            {
                UriItem uri = devTypeItem.GetChildWidthName<UriItem>(HelpItemTypes.uri.ToString());
                if (uri != null)
                {
                    uri.Value = value;
                }
            }
        }

        protected string Get_CommandName()
        {
            string result = string.Empty;
            HelpItemBase detailsItem = GetChildWithName(Defines.details);
            if (detailsItem != null)
            {
                NameItem nameItem = detailsItem.GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
                if (nameItem != null)
                {
                    result = nameItem.Value.ToString() ?? string.Empty;
                    result = result.Trim();
                }
            }
            return result;
        }
        protected void Set_CommandName(string value)
        {
            HelpItemBase detailsItem = GetChildWithName(Defines.details);
            if (detailsItem != null)
            {
                NameItem nameItem = detailsItem.GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
                if (nameItem != null)
                {
                    nameItem.Value = value;
                }
            }
        }

        protected string Get_Description()
        {
            string result = string.Empty;
            HelpItemBase detailsItem = GetChildWithName(Defines.description);
            if (detailsItem != null)
            {
                DescriptionItem dsc = detailsItem.GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
                if (dsc != null)
                {
                    result = dsc.ParaValue;
                }
            }
            return result;
        }

        protected void Set_Description(string value)
        {
            HelpItemBase detailsItem = GetChildWithName(Defines.details);
            if (detailsItem != null)
            {
                DescriptionItem dsc = detailsItem.GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
                if (dsc != null)
                {
                    dsc.ParaValue = value;
                }
            }
        }

        protected string Get_Copyright()
        {
            string result = string.Empty;
            HelpItemBase detailsItem = GetChildWithName(Defines.details);
            if (detailsItem != null)
            {
                CopyrightItem cprItem = detailsItem.GetChildWidthName<CopyrightItem>(HelpItemTypes.copyright.ToString());
                if (cprItem != null)
                {
                    ParaItem para = cprItem.GetChildWidthName<ParaItem>(HelpItemTypes.para.ToString());
                    if (para != null)
                    {
                        if (para.Value != null)
                        {
                            result = para.Value.ToString();
                        }
                    }
                }
            }
            return result;
        }

        protected void Set_Copyright(string value)
        {
            HelpItemBase detailsItem = GetChildWithName(Defines.details);
            if (detailsItem != null)
            {
                CopyrightItem cprItem = detailsItem.GetChildWidthName<CopyrightItem>(HelpItemTypes.copyright.ToString());
                if (cprItem != null)
                {
                    ParaItem para = cprItem.GetChildWidthName<ParaItem>(HelpItemTypes.para.ToString());
                    if (para != null)
                    {
                        if (para.Value != null)
                        {
                            para.Value = value;
                        }
                    }
                }
            }
        }

        protected string Get_Verb()
        {
            string result = string.Empty;
            HelpItemBase detailsItem = GetChildWithName(Defines.details);
            if (detailsItem != null)
            {
                VerbItem verb = detailsItem.GetChildWidthName<VerbItem>(HelpItemTypes.verb.ToString());
                if (verb != null)
                {
                    result = verb.Value.ToString();
                }
            }
            return result;
        }

        protected void Set_Verb(string value)
        {
            DetailsItem detailsItem = GetChildWidthName<DetailsItem>(HelpItemTypes.details.ToString());
            if (detailsItem != null)
            {
                VerbItem verb = detailsItem.GetChildWidthName<VerbItem>(HelpItemTypes.verb.ToString());
                if (verb != null)
                {
                    verb.Value = value;
                }
                detailsItem.AddVerbItem(value);
            }
        }

        protected string Get_Noun()
        {
            string result = string.Empty;
            DetailsItem detailsItem = GetChildWidthName<DetailsItem>(HelpItemTypes.details.ToString());
            if (detailsItem != null)
            {
                NounItem noun = detailsItem.GetChildWidthName<NounItem>(HelpItemTypes.noun.ToString());
                if (noun != null)
                {
                    result = noun.Value.ToString();
                }
                else if (!string.IsNullOrEmpty(CommandName))
                {
                    result = GetNounFromCommandName(CommandName);
                    detailsItem.AddNoun(result);
                }
            }
            return result;
        }

        protected void Set_Noun(string value)
        {
            DetailsItem detailsItem = GetChildWidthName<DetailsItem>(HelpItemTypes.details.ToString());
            if (detailsItem != null)
            {
                NounItem noun = detailsItem.GetChildWidthName<NounItem>(HelpItemTypes.noun.ToString());
                if (noun != null)
                {
                    noun.Value = value;
                }
                else
                {
                    detailsItem.AddNoun(value);
                }
            }
        }

        private string Get_Version()
        {
            string result = string.Empty;
            DetailsItem detailsItem = GetChildWidthName<DetailsItem>(HelpItemTypes.details.ToString());
            if (detailsItem != null)
            {
                VersionItem version = GetChildWidthName<VersionItem>(HelpItemTypes.version.ToString());
                if (version != null)
                {
                    result = version.Value.ToString();
                }
                else
                {
                    detailsItem.AddVersion(Defines.DefaultVersionValue);
                }
                result = Defines.DefaultVersionValue;
            }
            return result;
        }

        private void Set_Version(string value)
        {
            DetailsItem detailsItem = GetChildWidthName<DetailsItem>(HelpItemTypes.details.ToString());
            if (detailsItem != null)
            {
                detailsItem.AddVersion(value);
            }
        }
        #endregion
        //
        #region ♦ Remap values private helpers ♦
        private void RemapLayoutValues()
        {
            HelpItemBase detailsItem = GetChildWithName(Defines.details);
            if (detailsItem != null)
            {
                RemapVerbsList();
                // Remap subitems to the best of it.
                RemapSyntaxItem(this);
            }
        }

        private void RemapSyntaxItem(HelpItemBase parent)
        {
            ParamUtil.IsNull(parent, "HelpItemBase parent", "Parameteren er ikke korrekt initialiseret i kaldet til RemapSyntaxItem(HelpItemBase parent)");
            if (SyntaxItem == null)
            {
                HelpItemBase childSyntaxItem = parent.GetChildWidthName(this, Defines.syntaxItem);
                if (childSyntaxItem != null)
                {
                    SyntaxItem = childSyntaxItem as SyntaxItem;
                }
            }
        }
        /// <summary>
        /// Remaps the verbs list.
        /// </summary>
        private void RemapVerbsList()
        {
            foreach (string verbName in Defines.CommandVerbNames)
            {
                Verbs.Add(verbName);
            }
        }
        #endregion
    }
}
