using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Interfaces;
using System.IO;
using System.Xml.Linq;
using PSHelpEdit.Models;

namespace PSHelpEdit.Utils
{
    /// <summary>
    /// Class XSerializer.
    /// </summary>
    public class XSerializer : IDisposable
    {
        #region Private fields
        private XDocument _document;
        #endregion
        //
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="XSerializer"/> class.
        /// </summary>
        /// <remarks>Class file documentation please get here soon</remarks>
        public XSerializer()
        {
        }
        #endregion
        //
        #region Public properties.
        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <value>The document.</value>
        public XDocument Document
        {
            get { return _document; }
            private set { _document = value; }
        }
        #endregion
        //
        #region Public Methods.
        /// <summary>
        /// Saves the specified file name.
        /// </summary>
        /// <param name="fileName">
        /// </param>
        /// <param name="root">
        /// </param>
        public void Save(string fileName, IXSerialize root)
        {
            ParamUtil.IsNull(root, "IXSerialize root", "Parameteren er ikke korrekt initialiseret i kaldet til metode, Save");
            ParamUtil.IsNull(root.ElementName, "IXSerialize root", "Parameteren er ikke korrekt initialiseret i kaldet til metode, Save root.ElementName skal have en værdi");
            //
            try
            {
                Document = new XDocument();
                XElement newRoot = new XElement(root.ElementName);
                root.Save(newRoot);
                Document.Add(newRoot);
                Document.Save(fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Loads the specified file name.
        /// </summary>
        /// <param name="fileName">
        /// </param>
        /// <param name="root">
        /// </param>
        public void Load(string fileName, IXSerialize root)
        {
            ParamUtil.IsNull(root, "IXSerialize root", "Parameteren er ikke korrekt initialiseret i kaldet til metode, Save");
            ParamUtil.IsNull(root.ElementName, "IXSerialize root", "Parameteren er ikke korrekt initialiseret i kaldet til metode, Save root.ElementName skal have en værdi");
            //
            try
            {
                //
                if (File.Exists(fileName))
                {
                    Document = XDocument.Load(fileName);
                    XElement xRoot = Document.Root;
                    root.Load(xRoot);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Loads the specified file name.
        /// </summary>
        /// <param name="fileName">
        /// </param>
        public void Load(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    Document = XDocument.Load(fileName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        //
        #region IDisposable Members
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// Metode, der udfører applikations specifikke opgaver associeret med frigøre, slippe eller resette ikke
        /// håndterede resourcer, så som billeder og andet media stads.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Lukker den sidste del ned af klassen<see cref="EIndkomstFil" />
        /// </summary>
        ~XSerializer()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        /// <summary>
        /// Overskriv denne metode i nedarvede klasser, hvis de skal frigøre resourcer af mere specifik art..
        /// </summary>
        /// <param name="disposing">
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.
        }
        #endregion

    }
}
