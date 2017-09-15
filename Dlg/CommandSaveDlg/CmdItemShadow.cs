using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSHelpEdit.Models;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Dlg.CommandSaveDlg
{
    public class CmdItemShadow : ModelBase
    {

        #region Private fields
        private string _nameValue;
        private List<string> _verbs;
        private string _commandName;
        private string _description;
        private string _copyRight;
        private string _verb;
        private string _noun;
        private string _version;
        private string _inputType;
        private string _inputTypeUri;
        private string _inputTypeDescription;
        private string _returnType;
        private string _returnTypeDescription;
        private string _returnTypeUri;
        private bool _editMode;
        #endregion
        //
        #region Public properties.
        public string NameValue
        {
            get
            {
                return _nameValue;
            }
            set
            {
                OnPropertyChanging();
                _nameValue = value;
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
            get { return _commandName; }
            set
            {
                OnPropertyChanging();
                _commandName = value;
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
            get { return _description; }
            set
            {
                OnPropertyChanging();
                _description = value;
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
                return _copyRight;
            }
            set
            {
                OnPropertyChanging();
                _copyRight = value;
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
            get { return _verb; }
            set
            {
                OnPropertyChanging();
                _verb = value;
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
            get { return _noun; }
            set
            {
                OnPropertyChanging();
                _noun = value;
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
            get { return _version; }
            set
            {
                OnPropertyChanging();
                _version = value;
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
            get { return _inputType; }
            set
            {
                OnPropertyChanging();
                _inputType = value;
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
            get { return _inputTypeUri; }
            set
            {
                OnPropertyChanging();
                _inputTypeUri = value;
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
            get { return _inputTypeDescription; }
            set
            {
                OnPropertyChanging();
                _inputTypeDescription = value;
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
            get { return _returnType; }
            set
            {
                OnPropertyChanging();
                _returnType = value;
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
            get { return _returnTypeDescription; }
            set
            {
                OnPropertyChanging();
                _returnTypeDescription = value;
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
            get { return _returnTypeUri; }
            set
            {
                OnPropertyChanging();
                _returnTypeUri = value;
                OnPropertyChanged();
            }
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
        #region public void Set(CommandItem source)

        public void Set(CommandItem source)
        {
            if (source == null)
                ParamUtil.IsNull(source, "CommandItem source", "Parameteren er ikke korrekt initialiseret i kaldet til metoden, public void Set(CommandItem source)");

            NameValue             = source.NameValue;
            CommandName           = source.CommandName;
            Description           = source.Description;
            Copyright             = source.Copyright;
            Verb                  = source.Verb;
            Noun                  = source.Noun;
            Version               = source.Version;
            InputType             = source.InputType;
            InputTypeUri          = source.InputTypeUri;
            InputTypeDescription  = source.InputTypeDescription;
            ReturnType            = source.ReturnType;
            ReturnTypeDescription = source.ReturnTypeDescription;
            ReturnTypeUri         = source.ReturnTypeUri;
            EditMode              = source.EditMode;
        }
        #endregion

        public CommandItem Get(CommandItem dest)
        {
            if (dest == null)
                ParamUtil.IsNull(dest, "CommandItem dest", "Parameteren er ikke korrekt initialiseret i kaldet til metoden, public void Set(CommandItem source)");

            dest.NameValue             = NameValue;
            dest.CommandName           = CommandName;
            dest.Description           = Description;
            dest.Copyright             = Copyright;
            dest.Verb                  = Verb;
            dest.Noun                  = Noun;
            dest.Version               = Version;
            dest.InputType             = InputType;
            dest.InputTypeUri          = InputTypeUri;
            dest.InputTypeDescription  = InputTypeDescription;
            dest.ReturnType            = ReturnType;
            dest.ReturnTypeDescription = ReturnTypeDescription;
            dest.ReturnTypeUri         = ReturnTypeUri;
            dest.EditMode              = EditMode;

            return dest;
        }
    }
}
