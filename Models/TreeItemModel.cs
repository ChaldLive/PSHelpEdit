using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSHelpEdit.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class TreeItemModel : ModelBase
    {
        #region Private fields
        private ObservableCollection<TreeItemModel> _children;
        private ObservableCollection<TreeItemModel> _attributes;
        private string _itemTitle;
        private string _itemValue;
        #endregion
        //
        #region public TreeItemModel()
        /// <summary>
        /// 
        /// </summary>
        public TreeItemModel()
        {
        }

        #endregion
        //
        #region public TreeItemModel(string itemTitle)
        public TreeItemModel(string itemTitle)
        {
            ItemTitle = itemTitle;
        }

        #endregion
        //
        #region public TreeItemModel(string itemTitle, string itemValue)
        public TreeItemModel(string itemTitle, string itemValue)
            : this(itemTitle)
        {
            ItemValue = itemValue;
        }

        #endregion
        //
        #region Public properties.
        public ObservableCollection<TreeItemModel> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new ObservableCollection<TreeItemModel>();
                    _children.CollectionChanged += ChildrenCollectionChangedEvent;
                }
                return _children;
            }
        }

        public ObservableCollection<TreeItemModel> Attributes
        {
            get
            {
                if (_attributes == null)
                {
                    _attributes = new ObservableCollection<TreeItemModel>();
                    _attributes.CollectionChanged += AttributesCollectionChangedEvent;
                }
                return _attributes;
            }
        }

        public string ItemTitle
        {
            get { return _itemTitle; }
            set
            {
                OnPropertyChanging();
                _itemTitle = value;
                OnPropertyChanged();
            }
        }

        public string ItemValue
        {
            get { return _itemValue; }
            set
            {
                OnPropertyChanging();
                _itemValue = value;
                OnPropertyChanged();
            }
        }
        #endregion
        //
        #region private void ChildrenCollectionChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        private void ChildrenCollectionChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems.Count > 0)
                    {
                        foreach (object o in e.NewItems)
                        {
                            TreeItemModel item = o as TreeItemModel;
                            if (item != null)
                            {
                                OnChildItemAdded(item);
                            }
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (e.OldItems.Count > 0)
                    {
                        foreach (object o in e.OldItems)
                        {
                            TreeItemModel item = o as TreeItemModel;
                            if (item != null)
                            {
                                OnChildItemRemoved(item);
                            }
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    if (e.OldItems.Count > 0
                        && e.NewItems.Count > 0
                        && e.NewItems.Count == e.OldItems.Count)
                    {
                        for (int i = 0; i < e.NewItems.Count; i++)
                        {
                            TreeItemModel newItem = e.NewItems[i] as TreeItemModel;
                            TreeItemModel oldItem = e.OldItems[i] as TreeItemModel;
                            OnChildItemReplaced(oldItem, newItem);
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    OnChildrenRemoved();
                    break;
            }
        }
        #endregion
        //
        #region private void AttributesCollectionChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)

        private void AttributesCollectionChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems.Count > 0)
                    {
                        foreach (object o in e.NewItems)
                        {
                            TreeItemModel item = o as TreeItemModel;
                            if (item != null)
                            {
                                OnAttributeAdded(item);
                            }
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (e.OldItems.Count > 0)
                    {
                        foreach (object o in e.OldItems)
                        {
                            TreeItemModel item = o as TreeItemModel;
                            if (item != null)
                            {
                                OnAttributeRemoved(item);
                            }
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    if (e.OldItems.Count > 0
                        && e.NewItems.Count > 0
                        && e.NewItems.Count == e.OldItems.Count)
                    {
                        for (int i = 0; i < e.NewItems.Count; i++)
                        {
                            TreeItemModel newItem = e.NewItems[i] as TreeItemModel;
                            TreeItemModel oldItem = e.OldItems[i] as TreeItemModel;
                            OnChildItemReplaced(oldItem, newItem);
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    OnAttributesRemoved();
                    break;
            }
        }
        #endregion
        //
        #region protected virtual void OnChildItemAdded(TreeItemModel item) {/**/}
        protected virtual void OnChildItemAdded(TreeItemModel item) {/**/}
        #endregion

        #region protected virtual void OnChildItemRemoved(TreeItemModel item) {/**/}
        protected virtual void OnChildItemRemoved(TreeItemModel item) {/**/}
        #endregion

        #region protected virtual void OnChildItemReplaced(TreeItemModel itemOld, TreeItemModel itemNew) {/**/}
        protected virtual void OnChildItemReplaced(TreeItemModel itemOld, TreeItemModel itemNew) {/**/}
        #endregion

        #region protected virtual void OnChildrenRemoved() {/**/}
        protected virtual void OnChildrenRemoved() {/**/}
        #endregion
        //
        #region protected virtual void OnAttributeAdded(TreeItemModel attribute) {/**/}
        protected virtual void OnAttributeAdded(TreeItemModel attribute) {/**/}
        #endregion

        #region protected virtual void OnAttributeRemoved(TreeItemModel attribute) {/**/}
        protected virtual void OnAttributeRemoved(TreeItemModel attribute) {/**/}
        #endregion

        #region protected virtual void OnAttributeReplaced(TreeItemModel attributeOld, TreeItemModel attributeNew) {/**/}
        protected virtual void OnAttributeReplaced(TreeItemModel attributeOld, TreeItemModel attributeNew) {/**/}
        #endregion

        #region protected virtual void OnAttributesRemoved() {/**/}
        protected virtual void OnAttributesRemoved() {/**/}
        #endregion
        //
    }
}
