using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PSHelpEdit.Commands;
using PSHelpEdit.ControlExtenders;
using PSHelpEdit.Dlg.CommandSaveDlg;
using PSHelpEdit.Interfaces;
using PSHelpEdit.Models;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Controls
{
    /// <summary>
    /// Class ParametersModel.
    /// </summary>
    /// <seealso cref="PSHelpEdit.Models.ModelBase" />
    public class ParametersModel : ModelBase
    {
        #region Private commands decl
        private RelayCommand _cmdAddParam;
        private RelayCommand _cmdAddSyntaxParam;
        private RelayCommand _cmdEditParam;
        private RelayCommand _cmdEditSyntaxParam;
        private RelayCommand _cmdDeleteParam;
        private RelayCommand _cmdDeleteSyntaxParam;
        #endregion
        //
        #region Private fields
        private ObservableCollection<ParameterItem> _parameterItems;
        private ObservableCollection<ParameterItem> _syntaxParams;
        private ParameterItem _selectedParam;
        private ParameterItem _selectedSyntaxParam;
        private ParameterShadowItem _shadowParam;
        #endregion
        //
        #region Dynamic initialisation
        public ParametersModel()
        {
        }
        #endregion
        // 
        #region Public properties.
        /// <summary>
        /// Gets the parameter items.
        /// </summary>
        /// <value>The parameter items.</value>
        public ObservableCollection<ParameterItem> ParameterItems
        {
            get { return _parameterItems; }
            set
            {
                OnPropertyChanging();
                _parameterItems = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets the syntax parameters.
        /// </summary>
        /// <value>The syntax parameters.</value>
        public ObservableCollection<ParameterItem> SyntaxParams
        {
            get { return _syntaxParams; }
            set
            {
                OnPropertyChanging();
                _syntaxParams = value;
                OnPropertyChanged();
            }
        }
        public ParameterItem SelectedParam
        {
            get{return _selectedParam;}
            set
            {
                OnPropertyChanging();
                _selectedParam = value;
                OnPropertyChanged();
            }
        }

        public ParameterItem SelectedSyntaxParam
        {
            get{return _selectedSyntaxParam;}
            set
            {
                OnPropertyChanging();
                _selectedSyntaxParam = value;
                OnPropertyChanged();
            }
        }
        public ParameterShadowItem ShadowItem
        {
            get { return _shadowParam; }
            set { _shadowParam = value; }
        }
        #endregion
        //
        #region Commands impl
        public ICommand CmdAddParam
        {
            get
            {
                if (_cmdAddParam == null)
                    _cmdAddParam = new RelayCommand(CmdHandler_AddParam);
                return _cmdAddParam;
            }
        }
        public ICommand CmdAddSyntaxParam
        {
            get
            {
                if (_cmdAddSyntaxParam == null)
                    _cmdAddSyntaxParam = new RelayCommand(CmdHandler_AddSyntaxParam);
                return _cmdAddSyntaxParam;
            }
        }

        public ICommand CmdEditParam
        {
            get
            {
                if (_cmdEditParam == null)
                    _cmdEditParam = new RelayCommand(CmdHandler_EditParam);
                return _cmdEditParam;
            }
        }
        public ICommand CmdEditSyntaxParam
        {
            get
            {
                if (_cmdEditSyntaxParam == null)
                    _cmdEditSyntaxParam = new RelayCommand(CmdHandler_EditSyntaxParam);
                return _cmdEditSyntaxParam;
            }
        }

        public ICommand CmdDeleteParam
        {
            get
            {
                if (_cmdDeleteParam == null)
                    _cmdDeleteParam = new RelayCommand(CmdHandler_DeleteParam);
                return _cmdDeleteParam;
            }
        }

        public ICommand CmdDeleteSyntaxParam
        {
            get
            {

                if (_cmdDeleteSyntaxParam == null)
                    _cmdDeleteSyntaxParam = new RelayCommand(CmdHandler_DeleteSyntaxParam);
                return _cmdDeleteSyntaxParam;
            }
        }

        #endregion
        //
        #region public void UpdateData(CommandItem currentCommand)
        public void UpdateData(CommandItem currentCommand)
        {
            ParamUtil.IsNull(currentCommand, "CommandItem currentCommand", "Parameteren er ikke korrekt initialiseret i kaldet til metoden: {0}", "private void ParseCommandParameters(CommandItem currentCommand)");
            Parameters parameters = currentCommand.GetChildWidthName<Parameters>(Defines.HelpItemTypeName(HelpItemTypes.parameters));
            if (parameters != null)
            {
                IEnumerable<ParameterItem> paramItems = parameters.GetChildrenWithName<ParameterItem>(Defines.HelpItemTypeName(HelpItemTypes.parameter));
                InitParameterItem(paramItems);
            }
            //
            SyntaxItem syntaxItem = currentCommand.GetChildWidthNameRecursive<SyntaxItem>(Defines.HelpItemTypeName(HelpItemTypes.syntaxItem));
            if (syntaxItem != null)
            {
                IEnumerable<ParameterItem> syntaxParamItems = syntaxItem.GetChildrenWithName<ParameterItem>(Defines.HelpItemTypeName(HelpItemTypes.parameter));
                InitSyntaxItem(syntaxParamItems);
            }
            UpdateProps();
        }
        #endregion
        //
        #region ParameterItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        private void ParameterItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }
        #endregion
        //
        #region private void SyntaxParams_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        private void SyntaxParams_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }
        #endregion
        //
        #region private void InitSyntaxItem(IEnumerable<ParameterItem> parameters)
        private void InitSyntaxItem(IEnumerable<ParameterItem> parameters)
        {
            _syntaxParams = new ObservableCollection<ParameterItem>(parameters);
            _syntaxParams.CollectionChanged += SyntaxParams_CollectionChanged;
        }
        #endregion
        //
        #region private void InitParameterItem(IEnumerable<ParameterItem> parameters)
        private void InitParameterItem(IEnumerable<ParameterItem> parameters)
        {
            _parameterItems = new ObservableCollection<ParameterItem>(parameters);
            _parameterItems.CollectionChanged += ParameterItems_CollectionChanged;
        }
        #endregion
        //
        #region private void UpdateProps()
        private void UpdateProps()
        {
            OnPropertyChanged("ParameterItems");
            OnPropertyChanged("SyntaxParams");
        }
        #endregion
        //
        #region MyRegion
        public override void OnModelKeyDown(object model, KeyEventArgs e)
        {
            base.OnModelKeyDown(model, e);
            ListViewItem currentListViewItem = e.OriginalSource as ListViewItem;
            if (currentListViewItem == null)
                return;

            ParameterItem currentItem = currentListViewItem.DataContext as ParameterItem;
            if (currentItem != null)
            {
                switch (e.Key)
                {
                    case Key.F2:
                        KeyHandler_SetCurrentParamEditmode(currentItem);
                        e.Handled = true;
                        break;
                    case Key.Escape:
                        KeyHandler_ResetCurrentParamToNormal(e, currentItem);
                        break;
                    case Key.Enter:
                        KeyHandler_SetNewValueBasedOnResponseFromUser(e, currentItem, ShadowItem);
                        break;
                }
            }
        }
        #endregion
        //
        #region  Command handlers implementation
        private void CmdHandler_AddParam(object data)
        {

        }
        private void CmdHandler_AddSyntaxParam(object data)
        {

        }
        private void CmdHandler_EditParam(object data)
        {

        }
        private void CmdHandler_EditSyntaxParam(object data)
        {
            if(SelectedSyntaxParam != null)
            {
                SelectedSyntaxParam.EditMode = true;
            }
        }
        private void CmdHandler_DeleteParam(object data)
        {

        }
        private void CmdHandler_DeleteSyntaxParam(object data)
        {

        }
        #endregion
        private void KeyHandler_SetCurrentParamEditmode(ParameterItem param)
        {
            if(param != null)
            {
                ShadowItem = new ParameterShadowItem(param);
                param.EditMode = true;
            }
        }
        private void KeyHandler_ResetCurrentParamToNormal(KeyEventArgs e,ParameterItem param)
        {
            if (param == null)
                e.Handled = false;
            else
            {
                param.EditMode = false;
                if (ShadowItem != null)
                    param = ShadowItem;

            }
        }

        private void KeyHandler_SetNewValueBasedOnResponseFromUser(KeyEventArgs e,ParameterItem p, ParameterShadowItem shadow)
        {

            ParamUtil.IsNull
            (
                p, 
                "ParameterItem p", 
                "Parameteren er ikke korrekt initialiseret i kaldet til metoden: {0}", 
                "private void KeyHandler_SetNewValueBasedOnResponseFromUser(KeyEventArgs e,ParameterItem p, ParameterShadowItem shadow)"
            );

            CmdSaveWnd saveWnd = CmdSaveWnd.CreateInstance("Parameter name has changed", shadow.NameValue, p.NameValue);
            if(saveWnd.ShowDialog() == false)
            {
                p = shadow;
            }
            //
            p.EditMode = false;
            e.Handled = true;
        }
    }
}
