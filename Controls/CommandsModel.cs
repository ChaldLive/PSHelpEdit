using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using PSHelpEdit.Commands;
using PSHelpEdit.Dlg.CommandSaveDlg;
using PSHelpEdit.Models;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Controls
{
    public class CommandsModel : ModelBase
    {
        #region Private commands fields
        private RelayCommand _cmdCommandItemEdit;
        private RelayCommand _cmdReturnKey;
        private RelayCommand _cmdEscapeKey;
        #endregion
        //
        #region Private fields
        private CommandRootItem _root;
        private CommandItem _selectedCommandItem;
        private CmdItemShadow _shadowCommandItem;
        private CommandDetailsModel _cmdDetails;
        private ParametersModel _parametersModel;
        #endregion
        //
        #region public CommandsModel()
        public CommandsModel()
        {
        }
        #endregion
        //
        #region Relay commands property getters
        public ICommand CmdItemEdit
        {
            get
            {
                if (_cmdCommandItemEdit == null)
                    _cmdCommandItemEdit = new RelayCommand(CmdHandler_SelectedItemEdit);
                return _cmdCommandItemEdit;
            }
        }
        public ICommand CmdReturnKey
        {
            get
            {
                if (_cmdReturnKey == null)
                    _cmdReturnKey = new RelayCommand(CmdHandler_ReturnKey);
                return _cmdReturnKey;
            }
        }
        public ICommand CmdEscapeKey
        {
            get
            {
                if (_cmdEscapeKey == null)
                    _cmdEscapeKey = new RelayCommand(CmdHandler_EscapeKey);
                return _cmdEscapeKey;
            }
        }
        #endregion
        //
        #region CommandsModel(CommandRootItem root)
        public CommandsModel(CommandRootItem root)
        {
            ParamUtil.IsNull(root, "CommandRootItem root", "Parameteren er ikke korrekt initialiseret i kaldet til metoden:{0}", "CommandsModel.CommandsModel(CommandRootItem root)");
            Root = root;
        }
        #endregion
        //            
        #region Public properties
        public CommandRootItem Root
        {
            get{return _root;}
            set
            {
                OnPropertyChanging();
                _root = value;
                OnPropertyChanged();
            }
        }

        public CommandItem SelectedCommandItem
        {
            get{return _selectedCommandItem;}
            set
            {
                OnPropertyChanging();
                if (_selectedCommandItem == null || !_selectedCommandItem.EditMode)
                {
                    _selectedCommandItem = value;
                    CmdDetails.UpdateData(_selectedCommandItem);
                    ParametersModel.UpdateData(_selectedCommandItem);
                }
                else
                {
                    if(HandleCancelOrSaveEditableItem(_selectedCommandItem))
                    {
                        _selectedCommandItem.EditMode = false;
                    }
                    else
                    {
                        RestoreSelectedCommandItemInEditmode();
                    }
                }
                OnPropertyChanged();
            }
        }
        
        internal CmdItemShadow ShadowItem
        {
            get
            {
                if (_shadowCommandItem == null)
                    _shadowCommandItem = new CmdItemShadow();
                return _shadowCommandItem;
            }
            private set { _shadowCommandItem = value; }
        }

        public CommandDetailsModel CmdDetails
        {
            get
            {
                if (_cmdDetails == null)
                    _cmdDetails = new CommandDetailsModel();
                return _cmdDetails;
            }
            private set
            {
                OnPropertyChanging();
                _cmdDetails = value;
                OnPropertyChanged();
            }
        }

        public ParametersModel ParametersModel
        {
            get
            {
                if (_parametersModel == null)
                    _parametersModel = new ParametersModel();
                return _parametersModel;
            }

            set
            {
                OnPropertyChanging();
                _parametersModel = value;
                OnPropertyChanged();
            }
        }
        #endregion
        //
        #region public void Load(string fileName)
        public void Load(string fileName)
        {
            ParamUtil.IsNull(fileName, "CommandRootItem root", "Parameteren er ikke korrekt initialiseret i kaldet til metoden:{0}", "CommandsModel.public void Load(string fileName)");

            CommandRootItem tmp = new CommandRootItem();
            tmp.Load(fileName);
            Root = tmp;
        }
        #endregion
        //
        #region public void Update()
        public void Update()
        {
            OnPropertyChanging("Root");
            OnPropertyChanged("Root");
        }
        #endregion
        //
        #region public bool HandleCanceOrSaveEditableItem(CommandItem currentItem)
        public bool HandleCancelOrSaveEditableItem(CommandItem currentItem)
        {
            if(currentItem == null)
                return false;
            if (currentItem.EditMode == false)
                return false;
            else
            {
                CmdSaveWnd dlg = CmdSaveWnd.CreateInstance("CommandItem name has changed", ShadowItem.NameValue,currentItem.NameValue );
                if(dlg.ShowDialog() == true)
                {
                    currentItem.EditMode = false;
                    return true;
                }
                else
                {
                    if(ShadowItem != null)
                    {
                        ShadowItem.Get(SelectedCommandItem);
                    }
                }
            }
            currentItem.EditMode = false;
            return false;
        }

        #endregion
        //
        #region private void CmdHandler_SelectedItemEdit(object data)
        private void CmdHandler_SelectedItemEdit(object data)
        {
            //SetSelectedCommandItemInEditmode();
        }
        #endregion
        //
        #region private void CmdHandler_ReturnKey(object data)
        private void CmdHandler_ReturnKey(object data)
        {
            //HandleCancelOrSaveEditableItem(SelectedCommandItem);
            //SelectedCommandItem.EditMode = false;
        }
        #endregion
        //
        #region private void CmdHandler_EscapeKey(object data)
        private void CmdHandler_EscapeKey(object data)
        {
            //RestoreSelectedCommandItemInEditmode();
        }
        #endregion
        //
        #region private void SetSelectedCommandItemInEditmode()
        private void SetSelectedCommandItemInEditmode()
        {
            SelectedCommandItem.EditMode = true;
            ShadowItem.Set(SelectedCommandItem);
        }
        #endregion
        //
        #region private void RestoreSelectedCommandItemInEditmode()
        private void RestoreSelectedCommandItemInEditmode()
        {
            if (SelectedCommandItem.EditMode == true)
            {
                ShadowItem.Get(SelectedCommandItem);
                SelectedCommandItem.EditMode = false;
            }
        }
        #endregion

        #region public override void OnModelKeyDown(object model, System.Windows.Forms.KeyEventArgs e)
        public override void OnModelKeyDown(object model, System.Windows.Input.KeyEventArgs e)
        {
            base.OnModelKeyDown(model, e);
            if (CmdDetails != null)
            {
                CmdDetails.OnModelKeyDown(model, e);
            }
            if (!e.Handled && ParametersModel != null)
            {
                ParametersModel.OnModelKeyDown(model, e);
            }
            if (e.Handled == false)
            {
                if(e.Key == System.Windows.Input.Key.Escape)
                {
                    RestoreSelectedCommandItemInEditmode();
                }
                if (e.Key == System.Windows.Input.Key.Return)
                {
                    HandleCancelOrSaveEditableItem(SelectedCommandItem);
                    SelectedCommandItem.EditMode = false;
                }
                if (e.Key == System.Windows.Input.Key.F2)
                {
                    SetSelectedCommandItemInEditmode();
                    e.Handled = true;
                }
            }
        }
        #endregion
    }
}
