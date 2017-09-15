using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using PSHelpEdit.Attributes;
//

namespace PSHelpEdit.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("type", HelpItemTypes.type)]
    public class TypeItem : HelpItemBase
    {
        #region Private fields
        private NameItem _nameItem;
        private UriItem _uriItem;
        #endregion
        //
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public TypeItem()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public TypeItem(string name)
            : base(name)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public TypeItem(string name, object value)
            : base(name, value)
        {
        }
        #endregion
        //
        #region Public properties.
        public NameItem NameItem
        {
            get { return _nameItem; }
            set 
            {
                OnPropertyChanging();
                _nameItem = value;
                OnPropertyChanged();
            }
        }
        public UriItem UriItem
        {
            get { return _uriItem; }
            set 
            {
                OnPropertyChanging();
                _uriItem = value;
                OnPropertyChanged();
            }
        }

        #endregion
        //
        #region Public Methods.
        #endregion
        //
        #region Base overridden Methods.
        public override void Load(XElement e)
        {
            base.Load(e);
            Remap_Properties();
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
        //
        #region Private helper methods.
        private void Remap_Properties()
        {
            RempaProperty_Name();
            RemapProperty_Uri();
        }
        private void RempaProperty_Name()
        {
            NameItem nameItem = GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
            if (nameItem != null)
                NameItem = nameItem;
        }
        private void RemapProperty_Uri()
        {
            UriItem uriItem = GetChildWidthName<UriItem>(HelpItemTypes.uri.ToString());
            if (uriItem != null)
                UriItem = uriItem;
        }
        #endregion
    }
}
