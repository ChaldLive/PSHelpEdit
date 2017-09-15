using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PSHelpEdit.Utils
{
    public class MruItem
    {
        #region Private fields
        private string _name;
        private string _title;
        private string _description;
        private string _fileName;
        private string _sourceDir;
        private DateTime _createdDateTime;
        private bool _isSticky;
        #endregion
        //
        #region public MruItem()
        /// <summary>
        /// 
        /// </summary>
        public MruItem()
        {
            _name = string.Empty;
            _title = string.Empty;
            _description = string.Empty;
            _fileName = string.Empty;
            _sourceDir = string.Empty;
            _isSticky = false;
            _createdDateTime = DateTime.Now;
        }
        #endregion
        //
        #region Public properties.
        /// <summary>
        /// 
        /// </summary>
        public bool IsSticky
        {
            get { return _isSticky; }
            set { _isSticky = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceDir
        {
            get { return _sourceDir; }
            set { _sourceDir = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedDateTime
        {
            get { return _createdDateTime; }
            set { _createdDateTime = value; }
        }
        #endregion
        //
        #region public string FullFileName()
        public string FullFileName()
        {
            return System.IO.Path.Combine(SourceDir, Name);
        }
        #endregion

        //
        #region public bool Compare(string fileName)
        public bool Compare(string fileName)
        {
            string dir = System.IO.Path.GetDirectoryName(fileName);
            string file = System.IO.Path.GetFileName(fileName);
            //                                
            if (dir == SourceDir && file == Name)
                return true;
            return false;
        }

        #endregion        /// <summary>
        //
        #region public static MruItem Create(XElement parent)
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static MruItem Create(XElement parent)
        {
            if (parent == null)
                throw new ArgumentNullException("public static MruItem Create(XElement parent)", "Parameter: parent er ikke korrekt initialiseret i kaldet til denne metode.");
            //
            MruItem result = new MruItem();
            result.Load(parent);
            return result;
        }
        #endregion
        //
        #region public void Load(XElement parent)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public void Load(XElement parent)
        {
            if (parent == null)
                throw new ArgumentNullException("public void Load(XElement parent)", "Parameter: parent er ikke korrekt initialiseret i kaldet til denne metode.");
            LoadName(parent);
            LoadTitle(parent);
            LoadDescription(parent);
            LoadFileName(parent);
            LoadSourceDir(parent);
            LoadCreatedDateTime(parent);
            LoadIsSticky(parent);
        }
        #endregion
        //
        #region public void Save(XElement parent)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public void Save(XElement parent)
        {
            if (parent == null)
                throw new ArgumentNullException("public void Save(XElement parent)", "Parameter: parent er ikke korrekt initialiseret i kaldet til denne metode.");
            SaveName(parent);
            SaveTitle(parent);
            SaveDescription(parent);
            SaveFileName(parent);
            SaveSourceDir(parent);
            SaveCreatedDateTime(parent);
            SaveIsSticky(parent);
        }
        #endregion        
        //
        #region Protected Methods.
        #endregion
        //
        #region Private Methods.
        //
        #region Load item helpers
        private void LoadName(XElement parent)
        {
            XElement nameElement = parent.Descendants("Name").FirstOrDefault();
            if (nameElement != null)
            {
                Name = nameElement.Value;
            }

        }
        private void LoadTitle(XElement parent)
        {
            XElement titleElement = parent.Descendants("Title").FirstOrDefault();
            if (titleElement != null)
            {
                Title = titleElement.Value;
            }
        }
        private void LoadDescription(XElement parent)
        {
            XElement descriptionElement = parent.Descendants("Description").FirstOrDefault();
            if (descriptionElement != null)
            {
                Description = descriptionElement.Value;
            }
        }
        private void LoadFileName(XElement parent)
        {
            XElement fileNameElement = parent.Descendants("FileName").FirstOrDefault();
            if (fileNameElement != null)
            {
                FileName = fileNameElement.Value;
            }
        }
        private void LoadSourceDir(XElement parent)
        {
            XElement sourceDirElement = parent.Descendants("SourceDir").FirstOrDefault();
            if (sourceDirElement != null)
            {
                SourceDir = sourceDirElement.Value;
            }
        }
        private void LoadCreatedDateTime(XElement parent)
        {
            XElement createdDateTime = parent.Descendants("CreatedDateTime").FirstOrDefault();
            if (createdDateTime != null)
            {
                string parseDateTime = createdDateTime.Value;
                CreatedDateTime = DateTime.Parse(parseDateTime);
            }
        }
        private void LoadIsSticky(XElement parent)
        {
            XElement isStickyElement = parent.Descendants("IsSticky").FirstOrDefault();
            if (isStickyElement != null)
            {
                string parseString = isStickyElement.Value;
                IsSticky = Boolean.Parse(parseString);
            }
        }
        #endregion
        //
        #region Save item helpers
        private void SaveName(XElement parent)
        {
            XElement nameElement = parent.Descendants("Name").FirstOrDefault();
            if (nameElement != null)
            {
                nameElement.Value = Name;
            }
            else
            {
                nameElement = new XElement("Name");
                nameElement.Value = Name;
                parent.Add(nameElement);
            }
        }

        private void SaveTitle(XElement parent)
        {
            XElement titleElement = parent.Descendants("Title").FirstOrDefault();
            if (titleElement != null)
            {
                titleElement.Value = Title;
            }
            else
            {
                titleElement = new XElement("Title");
                titleElement.Value = Title;
                parent.Add(titleElement);
            }
        }

        private void SaveDescription(XElement parent)
        {
            XElement descriptionElement = parent.Descendants("Description").FirstOrDefault();
            if (descriptionElement != null)
            {
                descriptionElement.Value = Description;
            }
            else
            {
                descriptionElement = new XElement("Description");
                descriptionElement.Value = Description;
                parent.Add(descriptionElement);
            }
        }
        private void SaveFileName(XElement parent)
        {
            XElement fileNameElement = parent.Descendants("FileName").FirstOrDefault();
            if (fileNameElement != null)
            {
                fileNameElement.Value = FileName;
            }
            else
            {
                fileNameElement = new XElement("FileName");
                fileNameElement.Value = FileName;
                parent.Add(fileNameElement);
            }
        }
        private void SaveSourceDir(XElement parent)
        {
            XElement sourceDirElement = parent.Descendants("SourceDir").FirstOrDefault();
            if (sourceDirElement != null)
            {
                sourceDirElement.Value = SourceDir;
            }
            else
            {
                sourceDirElement = new XElement("SourceDir");
                sourceDirElement.Value = SourceDir;
                parent.Add(sourceDirElement);
            }
        }
        private void SaveCreatedDateTime(XElement parent)
        {
            XElement createdDateTime = parent.Descendants("CreatedDateTime").FirstOrDefault();
            if (createdDateTime != null)
            {
                createdDateTime.Value = CreatedDateTime.ToString("o");
            }
            else
            {
                createdDateTime = new XElement("CreatedDateTime");
                createdDateTime.Value = CreatedDateTime.ToString("o");
                parent.Add(createdDateTime);
            }
        }
        private void SaveIsSticky(XElement parent)
        {
            XElement isStickyElement = parent.Descendants("IsSticky").FirstOrDefault();
            if (isStickyElement != null)
            {
                isStickyElement.Value = IsSticky.ToString();
            }
            else
            {
                isStickyElement = new XElement("IsSticky");
                isStickyElement.Value = IsSticky.ToString();
                parent.Add(isStickyElement);
            }
        }

        #endregion
        //
        #endregion
        //
        #region Abstract virtual methods.

        #endregion
    }
}
