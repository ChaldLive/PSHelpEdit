using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;
using PSHelpEdit.Commands;
using PSHelpEdit.Controls;
using PSHelpEdit.General;
using PSHelpEdit.Models;
using PSHelpEdit.Utils;

namespace PSHelpEdit
{
    public class MainWindowModel : ModelBase
    {
        #region Public events 
        public event ModelEventHandler ModelEvent;
        #endregion
        //
        #region Private commands definitiosn
        private RelayCommand _cmdLoaded;
        private RelayCommand _cmdFileOpen;
        #endregion
        //
        #region Private fields
        private string _currentLoadedFileName;
        private CommandsModel _commandsModel;
        #endregion
        //
        #region public MainWindowModel()
        public MainWindowModel()
        {
        }
        #endregion
        //
        #region Public properties.
        public CommandsModel CommandsModel
        {
            get{return _commandsModel;}
            set
            {
                OnPropertyChanging();
                _commandsModel = value;
                OnPropertyChanged();
            }
        }
        public string CurrentLoadedFileName
        {
            get { return _currentLoadedFileName; }
            set
            {
                OnPropertyChanging();
                _currentLoadedFileName = value;
                OnPropertyChanged();
            }
        }
        #endregion
        //
        #region Public events impl
        /// <summary>
        /// Gets the command loaded.
        /// </summary>
        /// <value>The command loaded.</value>
        public ICommand CmdLoaded
        {
            get
            {
                if (_cmdLoaded == null)
                    _cmdLoaded = new RelayCommand(CmdHandler_Loaded);
                return _cmdLoaded;
            }
        }
        /// <summary>
        /// Gets the command file open.
        /// </summary>
        /// <value>The command file open.</value>
        public ICommand CmdFileOpen
        {
            get
            {
                if (_cmdFileOpen == null)
                    _cmdFileOpen = new RelayCommand(CmdHandler_FileOpen);
                return _cmdFileOpen;
            }
        }

        #endregion
        //
        #region public void OpenDocumentationFile(string fileName)

        public void OpenDocumentationFile(string fileName)
        {
            if (!File.Exists(fileName))
                return;
            //
            CommandsModel tmp = new CommandsModel();
            tmp.Load(fileName);
            CommandsModel = null;
            CommandsModel = tmp;
            tmp.Update();
            MruHandler.Instance.AddFileToMruList(fileName, "Ikke noget at tilføje her", "Og der er ikke aktuelt behov for en tittel. Med det kommer");
            CurrentLoadedFileName = fileName;
        }
        #endregion
        //
        #region Protected void OnModelEvent
        protected void OnModelEvent(string info, ModelEventArg.EventTypeKode kode)
        {
            ModelEvent?.Invoke(new ModelEventArg(info,kode));
        }
        #endregion
        //
        #region private void CmdHandler_Loaded(object data)
        private void CmdHandler_Loaded(object data)
        {
            OnModelEvent("MainWindow model loaded", ModelEventArg.EventTypeKode.evtLoaded);
        }
        #endregion
        //
        #region private void CmdHandler_FileOpen(object data)
        /// <summary>
        /// Commands the handler_ file open.
        /// </summary>
        /// <param name="data">The data.</param>
        private void CmdHandler_FileOpen(object data)
        {
            string selectedFileName = string.Empty;
            OpenFileDialog ofn = new OpenFileDialog();
            ofn.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (ofn.ShowDialog() == true)
            {
                selectedFileName = ofn.FileName;
                OpenDocumentationFile(selectedFileName);
            }
        }
        #endregion
    }
}