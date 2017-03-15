using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using PSHelpEdit.General;

namespace PSHelpEdit.Utils
{
    public class MruHandler
    {
        #region Public events
        public event MruEventHandler MruEvent;
        #endregion
        //
        #region Private fields
        private string _currentMruListFile;
        private ObservableCollection<MruItem> _mruList;
        private string _fileName;
        private static MruHandler _instance;
        #endregion
        //
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        protected MruHandler(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("public MruHandler(string fileName)", "Parameter: fileName er ikke korrekt initialiseret i kaldet til denne constructor.");
            _fileName = fileName;
            Initialize();
        }
        #endregion
        //
        #region Public properties.
        public static MruHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MruHandler(Defines.MruListFileName);
                    _instance.Load();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            private set { _fileName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<MruItem> MruList
        {
            get
            {
                if (_mruList == null)
                    _mruList = new ObservableCollection<MruItem>();
                return _mruList;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CurrentMruListFile
        {
            get { return _currentMruListFile; }
            private set { _currentMruListFile = value; }
        }
        #endregion
        //
        #region public void AddFileToMruList(string fileName, string description, string title = "")
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="description"></param>
        /// <param name="title"></param>
        public void AddFileToMruList(string fileName, string description, string title = "")
        {
            if (!ContainsFile(fileName))
            {
                MruItem newMruItem = new MruItem();
                newMruItem.SourceDir = System.IO.Path.GetDirectoryName(fileName);
                newMruItem.Name = System.IO.Path.GetFileName(fileName);
                newMruItem.Description = description;
                MruList.Add(newMruItem);
                OnEvent("Fil tilføjet mru list", MruHandlerEventArg.MruHandlerEventKodes.evtFileAdded);
                Save();
            }
        }
        #endregion
        //
        #region public void Load()
        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {
            OnEvent("Loader mrulist", MruHandlerEventArg.MruHandlerEventKodes.evtLoding);
            LoadMruFile();
            OnEvent("Mrulist er loaded", MruHandlerEventArg.MruHandlerEventKodes.evtLoaded);
        }
        #endregion
        //
        #region public void Save()
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            OnEvent("Gemmer mrulist", MruHandlerEventArg.MruHandlerEventKodes.evtSaving);
            SaveMruFile();
            OnEvent("Mrulist gemt", MruHandlerEventArg.MruHandlerEventKodes.evtSaved);
        }
        #endregion
        //
        #region protected void Initialize()
        /// <summary>
        /// 
        /// </summary>
        protected void Initialize()
        {
            InitMruFileName();
            LoadMruFile();
        }
        #endregion
        //
        #region private bool ContainsFile(string fileName)

        private bool ContainsFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;
            foreach (MruItem mi in MruList)
            {
                if (mi.Compare(fileName))
                    return true;
            }
            return false;
        }
        #endregion
        //
        #region private void LoadMruFile()
        private void LoadMruFile()
        {
            if (!File.Exists(CurrentMruListFile))
                return;
            try
            {
                XDocument doc = XDocument.Load(CurrentMruListFile);
                if (doc != null)
                {
                    MruList.Clear();
                    var mruItems = doc.Root.Descendants("MruItem");
                    foreach (XElement mruItem in mruItems)
                    {
                        MruItem nextItem = MruItem.Create(mruItem);
                        MruList.Add(nextItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
        #endregion
        //
        #region private void SaveMruFile()

        private void SaveMruFile()
        {
            XDocument doc = null;
            try
            {
                if (!File.Exists(CurrentMruListFile))
                {
                    doc = new XDocument(new XElement("MruItems"));
                    foreach (MruItem mi in MruList)
                    {
                        XElement newMruItem = new XElement("MruItem");
                        mi.Save(newMruItem);
                        doc.Root.Add(newMruItem);
                    }
                    doc.Save(CurrentMruListFile);
                }
                else
                {
                    doc = XDocument.Load(CurrentMruListFile);
                    if (doc != null)
                    {
                        doc.Root.RemoveAll();
                        foreach (MruItem mruItem in MruList)
                        {
                            XElement nextMruItem = new XElement("MruItem");
                            mruItem.Save(nextMruItem);
                            doc.Root.Add(nextMruItem);
                        }
                        doc.Save(CurrentMruListFile);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region private void InitMruFileName()
        private void InitMruFileName()
        {
            string fullPath = Assembly.GetExecutingAssembly().Location;
            string result = string.Format(@"{0}\{1}", System.IO.Path.GetDirectoryName(fullPath), "CacheFiles");
            if (!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            CurrentMruListFile = string.Format(@"{0}\{1}\{2}", System.IO.Path.GetDirectoryName(fullPath), "CacheFiles", FileName);
        }
        #endregion
        //
        #region public void InitializeMen(Menu mainMnu)
        public void InitializeMenu(MenuItem recentFilesItem, RoutedEventHandler mnuEventHandler)
        {
            if (recentFilesItem == null)
                return;
            //
            foreach (MruItem item in MruList )
            {
                MenuItem mnuItem = new MenuItem();
                mnuItem.Header = item.Name;
                mnuItem.Click += new RoutedEventHandler(mnuEventHandler);
                mnuItem.Tag = item;
                recentFilesItem.Items.Add(mnuItem);
            }
        }
        #endregion
        //
        #region MyRegion
        protected void OnEvent(string info, MruHandlerEventArg.MruHandlerEventKodes kode)
        {
            MruEvent?.Invoke(new MruHandlerEventArg(info, kode));
        }
        #endregion
    }
}
