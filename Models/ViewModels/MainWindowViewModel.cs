using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PSHelpEdit.Commands;
using PSHelpEdit.Interfaces;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Models
{
    public class MainWindowViewModel : ModelBase, IXSerialize
    {
        //
        #region ♦ Private fields  
        private IHelpItem _rootItem;
        private CommandItem _selectedItem;
        private List<CommandItem> _commandItems;
        #endregion
        //
        #region ♦ Commands definitions ♦
        private RelayCommand _onCmdLoaded;
        private RelayCommand _onAddCmdCommand;
        private RelayCommand _onRemoveCmdCommand;
        private RelayCommand<CommandItem> _onItemSelectionChanged;
        #endregion
        //
        #region ♦ Constructors ♦
        #endregion
        //
        #region ♦ Commands getters and setters. ♦
        public ICommand OnCmdLoaded
        {
            get
            {
                if (_onCmdLoaded == null)
                    _onCmdLoaded = new RelayCommand(OnCommandLoaded);
                return _onCmdLoaded;
            }
        }
        public ICommand OnItemSelectionChanged
        {
            get
            {
                if (_onItemSelectionChanged == null)
                    _onItemSelectionChanged = new RelayCommand<CommandItem>(OnCommandItemSelectionChanged);
                return _onItemSelectionChanged;
            }
        }
        public ICommand OnAddCmdCommand
        {
            get
            {
                if (_onAddCmdCommand == null)
                    _onAddCmdCommand = new RelayCommand(OnAddCmdCommandHandler);
                return _onAddCmdCommand;
            }
        }

        public ICommand OnRemoveCmdCommand
        {
            get
            {
                if (_onRemoveCmdCommand == null)
                    _onRemoveCmdCommand = new RelayCommand(OnRemoveCmdCommandHandler);
                return _onRemoveCmdCommand;
            }
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        /// <summary>
        /// Gets or sets the root item.
        /// </summary>
        /// <value>
        ///  The root item.
        /// </value>
        public IHelpItem RootItem
        {
            get { return _rootItem; }
            set { _rootItem = value; }
        }
        /// <summary>
        /// Gets or sets the command items.
        /// </summary>
        /// <value>
        ///  The command items.
        /// </value>
        public List<CommandItem> CommandItems
        {
            get
            {
                if (_commandItems == null)
                    _commandItems = new List<CommandItem>();
                return _commandItems;
            }
        }
        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        ///  The selected item.
        /// </value>
        public CommandItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                OnPropertyChanging();
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        #endregion
        //
        #region ♦ Public methods  ♦
        public void LoadFromFile(string fileName)
        {
            ParamUtil.IsFile(fileName, "string fileName", "Parameteren er ikke korrekt initialiseret i kaldet til: LoadFromFile(string fileName)");
            ParamUtil.IsFile(fileName, "string fileName", "Filen med navnet :[{0}] findes ikke", fileName);
            //
            try
            {
                XSerializer serializer = new XSerializer();
                serializer.Load(fileName, this);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        //
        #region ♦ Private commands handlers ♦
        private void OnAddCmdCommandHandler(object data)
        {

        }
        private void OnRemoveCmdCommandHandler(object data)
        {

        }

        private void OnCommandLoaded(object data)
        {

        }
        private void OnCommandItemSelectionChanged(CommandItem data)
        {
            if (data == null)
                return;
            MapCommandItemAndSubItem(data);
        }

        #endregion
        //
        #region ♦ Private helpers ♦
        private void MapCommandItemAndSubItem(CommandItem cmdItem)
        {
            if (cmdItem == null)
                return;
            //
            //CommandItemViewModel.SelectedItem = cmdItem;
        }
        #endregion
        //
        #region IXSerialize Members
        public string ElementName
        {
            get { return "MainWindowViewModel"; }
        }

        public void Save(System.Xml.Linq.XElement e)
        {
        }

        public void Load(System.Xml.Linq.XElement e)
        {
            if (RootItem != null)
            {
                RootItem = null;
            }
            RootItem = new HelpItems("helpItems");
            RootItem.Load(e);
            foreach (IHelpItem item in RootItem.Children)
            {
                CommandItem cmdItem = item as CommandItem;
                if (cmdItem != null)
                {
                    CommandItems.Add(cmdItem);
                }
            }
        }
        #endregion
    }
}
