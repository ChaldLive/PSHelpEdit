using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Interfaces;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using PSHelpEdit.Utils;

using System.ComponentModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace PSHelpEdit.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HelpItemBase : ModelBase, IHelpItem, INotifyPropertyChanged, INotifyPropertyChanging
    {
        //
        #region Private fields
        private string _name;
        private object _value;
        private string _nameValue;
        private ObservableCollection<IHelpItem> _children;
        private ObservableCollection<IHelpItemAttribute> _attributes;
        //private ItemState _itemState;
        private PersistState _persistState;
        private bool _isExpanded;
        private IHelpItem _parent;

        #endregion
        //
        #region Constructors
        public HelpItemBase()
        {
            _isExpanded = false;
        }
        /// <summary>
        /// 
        /// </summary>
        public HelpItemBase(string name)
        {
            _name = name;
            _isExpanded = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpItemBase"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public HelpItemBase(string name, object value)
            :this(name)
        {
            _value = value;
            _isExpanded = false;
        }
        ///// <summary>
        ///// Initializes a new instance of the <see cref="HelpItemBase"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="value">The value.</param>
        ///// <param name="initialState">The initial state.</param>
        ///// <remarks>Class file documentation please get here soon</remarks>
        //public HelpItemBase(string name, object value, ItemState initialState)
        //    : this(name,value)
        //{
        //    _itemState = initialState;
        //    _isExpanded = false;
        //}

        #endregion
        //
        #region Public properties.
        public virtual IHelpItem Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        ///  The name.
        /// </value>
        public virtual string Name
        {
            get{return _name;}
            set{_name = value;}
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        ///  The value.
        /// </value>
        public virtual object Value
        {
            get{return _value;}
            set{_value = value;}
        }
        /// <summary>
        /// Gets or sets the name value.
        /// </summary>
        /// <value>
        ///  The name value.
        /// </value>
        public virtual string NameValue
        {
            get { return _nameValue; }
            set { _nameValue = value; }
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>
        ///  The children.
        /// </value>
        public virtual IEnumerable<IHelpItem> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new ObservableCollection<IHelpItem>();
                    _children.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ChildrenCollectionChanged);   

                }
                return _children;
            }
        }
        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <value>
        ///  The attributes.
        /// </value>
        public virtual IEnumerable<IHelpItemAttribute> Attributes
        {
            get
            {
                if (_attributes == null)
                    _attributes = new ObservableCollection<IHelpItemAttribute>();
                return _attributes;
            }
        }
        ///// <summary>
        ///// Gets or sets the state of the item.
        ///// </summary>
        ///// <value>
        /////  The state of the item.
        ///// </value>
        //public virtual ItemState ItemState
        //{
        //    get { return _itemState; }
        //    set { _itemState = value; }
        //}
        /// <summary>
        /// Gets or sets the is expanded.
        /// </summary>
        /// <value>
        ///  The is expanded.
        /// </value>
        public virtual bool IsExpanded 
        {
            get { return _isExpanded; }
            set { _isExpanded = value; }  
        }

        #endregion
        //
        #region public ATT GetAttributeValue<ATT>(string attrName)
        public ATT GetAttributeValue<ATT>(string attrName)
        {
            ATT result = default(ATT);
            IHelpItemAttribute foundAttr = Attributes.Where(x => x.Name == attrName).FirstOrDefault();
            if (foundAttr == null)
            {
                return result;
            }
            if (foundAttr.Value != null)
            {
                result = (ATT)Convert.ChangeType(foundAttr.Value,typeof(ATT));
            }
            return result;
        }
        #endregion
        //
        #region public HelpItemAttribute GetHelpItemAttributeWithName(string name)

        public HelpItemAttribute GetHelpItemAttributeWithName(string name)
        {
            HelpItemAttribute result = null;
            result = Attributes.Where(x => x.Name == name).FirstOrDefault() as HelpItemAttribute;
            return result;
        }
        #endregion
        //
        #region public IEnumerable<IT> GetChildrenWithName<IT>(string name, HelpItemBase currentParent = null) where IT: class
        public IEnumerable<IT> GetChildrenWithName<IT>(string name, HelpItemBase currentParent = null) where IT: class
        {
            List<IT> foundItems = new List<IT>();
            PrivateGetChildrenWidthName<IT>(name, ref foundItems, currentParent);
            return foundItems;
        }
        #endregion
        //
        #region public IEnumerable<HelpItemBase> GetChildrenWithName(string name, HelpItemBase currentParent = null)
        public IEnumerable<HelpItemBase> GetChildrenWithName(string name, HelpItemBase currentParent = null)
        {
            List<HelpItemBase> foundItems = new List<HelpItemBase>();
            PrivateGetChildrenWidthName(name, ref foundItems, currentParent);
            return foundItems;
        }
        #endregion
        //
        #region public HelpItemBase GetChildWidthName(HelpItemBase root, string name)
        /// <summary>
        /// Gets the name of the child with.
        /// </summary>
        /// <param name="root">
        /// </param>
        /// <param name="name">
        /// </param>
        /// <returns>
        ///  PSHelpEdit.Interfaces.IHelpItem.
        /// </returns>
        public HelpItemBase GetChildWidthName(HelpItemBase root, string name)
        {
            HelpItemBase result = null;
            foreach (HelpItemBase child in root.Children)
            {
                if (child.Name == name)
                {
                    result = child;
                    break;
                }
                if (result == null)
                    result = GetChildWidthName(child, name);
            }
            return result;
        }
        #endregion
        //
        #region  public HIT GetChildWidthName<HIT>(HelpItemTypes helpItemType) where HIT: class
        /// <summary>
        /// Gets the name of the child width.
        /// </summary>
        /// <typeparam name="HIT">
        /// </typeparam>
        /// <param name="helpItemType">
        /// </param>
        /// <returns>
        ///  HIT.
        /// </returns>
        public HIT GetChildWidthName<HIT>(HelpItemTypes helpItemType) where HIT: class
        {
            return GetChildWidthName<HIT>(helpItemType.ToString());
        }
        #endregion
        //
        #region public HIT GetChildWidthName<HIT>(string name) where HIT: class
        /// <summary>
        /// Gets the name of the child width.
        /// </summary>
        /// <typeparam name="HIT">
        /// </typeparam>
        /// <param name="name">
        /// </param>
        /// <returns>
        ///  HIT.
        /// </returns>
        public HIT GetChildWidthName<HIT>(string name) where HIT: class
        {
            HIT result = default(HIT);
            IHelpItem tmpResult = null;
            //
            foreach (IHelpItem child in Children)
            {
                if (child.Name == name)
                {
                    tmpResult = child;
                    break;
                }
            }
            result = tmpResult as HIT;
            return result;
        }
        #endregion
        //
        #region public HIT GetChildWidthNameRecursive<HIT>(string name) where HIT : class
        /// <summary>
        /// Gets the child width name recursive.
        /// </summary>
        /// <typeparam name="HIT">
        /// </typeparam>
        /// <param name="name">
        /// </param>
        /// <returns>
        ///  HIT.
        /// </returns>
        public HIT GetChildWidthNameRecursive<HIT>(string name) where HIT : class
        {
            HIT result = default(HIT);
            HIT tmpResult = null;
            //
            foreach (IHelpItem child in Children)
            {
                if (child.Name == name)
                {
                    tmpResult = child as HIT;
                    break;
                }
                if (tmpResult == null)
                {
                    HelpItemBase baseChildItem = child as HelpItemBase;
                    if(baseChildItem != null)
                        tmpResult = baseChildItem.GetChildWidthNameRecursive<HIT>(name);
                }
            }
            result = tmpResult as HIT;
            return result;
        }
        #endregion
        //
        #region public HelpItemBase GetChildWithName(string name)
        /// <summary>
        /// Gets the name of the child with.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        ///  PSHelpEdit.Interfaces.IHelpItem.
        /// </returns>
        public HelpItemBase GetChildWithName(string name)
        {
            ParamUtil.IsNull(name, "string name", "Parameteren er ikke korrekt udfyldt i kaldet til metoden GetChildWithName");
            IHelpItem result = null;
            //
            foreach (IHelpItem child in Children)
            {
                if (child.Name == name)
                {
                    result = child;
                    break;
                }
            }
            return result as HelpItemBase;
        }
        #endregion
        //
        #region public virtual void AddChild(IHelpItem newChild)
        /// <summary>
        /// Adds the child.
        /// </summary>
        /// <param name="newChild">
        /// </param>
        public virtual void AddChild(IHelpItem newChild)
        {
            ParamUtil.IsNull(newChild, "IHelpItem newChild", "Parameteren er ikke korrekt initialiseret i kaldet til AddChild(IHelpItem newChild)");
            if (!Children.Contains(newChild))
            {
                newChild.Parent = this;
                _children.Add(newChild);
            }
        }
        #endregion
        //
        #region public virtual void RemoveChild(IHelpItem childToRemove)
        /// <summary>
        /// Removes the child.
        /// </summary>
        /// <param name="childToRemove">
        /// </param>
        public virtual void RemoveChild(IHelpItem childToRemove)
        {
            ParamUtil.IsNull(childToRemove, "IHelpItem childToRemove", "Parameteren er ikke korrekt initialiseret i kaldet til RemoveChild(IHelpItem childToRemove)");
            if (_children == null)
                return;
            if (_children.Contains(childToRemove))
            {
                childToRemove.Parent = null;
                _children.Remove(childToRemove);
            }
        }
        #endregion
        //
        #region public virtual void RemoveAttribute(IHelpItemAttribute attr)
        /// <summary>
        /// Removes the attribute.
        /// </summary>
        /// <param name="attr">
        /// </param>
        public virtual void RemoveAttribute(IHelpItemAttribute attr)
        {
            ParamUtil.IsNull(attr, "IHelpItemAttribute attr", "Parameteren er ikke korrekt initialiseret i kaldet til RemoveAttribute(IHelpItemAttribute attr)");

        }
        #endregion
        //
        #region public virtual void AddAttribute(IHelpItemAttribute attr)
        /// <summary>
        /// Adds the attribute.
        /// </summary>
        /// <param name="attr">
        /// </param>
        public virtual void AddAttribute(IHelpItemAttribute attr)
        {
            ParamUtil.IsNull(attr, "IHelpItemAttribute attr", "Parameteren er ikke korrekt initialiseret i kaldet til AddAttribute(IHelpItemAttribute attr)");
            if (!Attributes.Contains(attr))
            {
                _attributes.Add(attr);
            }
        }
        #endregion
        //
        #region protected virtual void LoadChildren(XElement e)
        /// <summary>
        /// Loads the children.
        /// </summary>
        /// <param name="e">
        /// </param>
        protected virtual void LoadChildren(XElement e)
        {
            ParamUtil.IsNull(e, "XElement e", "Parameteren er ikke korrekt initialiseret i kaldet til protected virtual void LoadChildren(XElement e)");
            Name = e.Name.LocalName;
            if (e.HasElements)
            {
                IHelpItem childItem = null;
                foreach (XElement child in e.Elements())
                {
                    childItem = HelpItemFactory.Instance.CreateItemFromXElement(child);
                    if (childItem != null)
                    {
                        childItem.Parent = this;
                        AddChild(childItem);
                        childItem.Load(child);
                    }
                }
            }
            else
            {
                Value = e.Value;
            }
        }
        #endregion
        //
        #region protected virtual void LoadAttributes(XElement e)
        /// <summary>
        /// Loads the attributes.
        /// </summary>
        /// <param name="e">
        /// </param>
        protected virtual void LoadAttributes(XElement e)
        {
            if (e.Attributes().Count() > 0)
            {
                foreach (XAttribute attr in e.Attributes())
                {
                    IHelpItemAttribute nextAttr = HelpItemFactory.Instance.CreateAttributeItem(attr);
                    AddAttribute(nextAttr);
                }
            }
        }
        #endregion
        //
        #region protected string SplitStringGetting(char[] splitterChars, string stringToSplit, int numberOfSplits, int indexToReturn)
        protected string SplitStringGetting(char[] splitterChars, string stringToSplit, int numberOfSplits, int indexToReturn)
        {
            ParamUtil.IsNull(splitterChars, "char[] splitterChars", "Parameteren er ikke korrekt initialiseret.");
            ParamUtil.IsNull(splitterChars, "string stringToSplit", "Parameteren er ikke korrekt initialiseret.");
            ParamUtil.IsTrue(numberOfSplits <= 0, "int numberOfSplits", "Parameteren er ikke korrekt initialiseret. Værdien skal være større end 0 aktuelle værdi er:[{}]", numberOfSplits);
            ParamUtil.IsTrue(indexToReturn <= 0, "int indexToReturn", "Parameteren er ikke korrekt initialiseret. Værdien skal være større end 0 aktuelle værdi er:[{}]", indexToReturn);
            //
            string result = string.Empty;
            if (string.IsNullOrEmpty(stringToSplit))
                return result;
            //
            string[] splittetStrings = stringToSplit.Split(splitterChars, numberOfSplits, StringSplitOptions.None);
            //            
            if (splittetStrings.Length > indexToReturn)
            {
                result = splittetStrings[indexToReturn];
            }
            return result;
        }
        #endregion
        //
        #region protected string GetVerbFromCommandName(string commandName)
        protected string GetVerbFromCommandName(string commandName)
        {
            return SplitStringGetting(Defines.CommandNameSplitterChar1,commandName,2,0);
        }
        #endregion
        //
        #region protected string GetNounFromCommandName(string commandName)
        protected string GetNounFromCommandName(string commandName)
        {
            return SplitStringGetting(Defines.CommandNameSplitterChar1, commandName, 2, 1);
        }
        #endregion
        //
        #region IXSerialize Members 
        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <value>
        ///  The name of the element.
        /// </value>
        public string ElementName
        {
            get { return _name; }
        }
        /// <summary>
        /// Gets or sets the state of the persist.
        /// </summary>
        /// <value>
        ///  The state of the persist.
        /// </value>
        public virtual PersistState PersistState 
        {
            get{return _persistState;}
            set{_persistState = value;} 
        }

        /// <summary>
        /// Saves the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        public virtual void Save(XElement e)
        {
            PersistState = PersistState.IsSaving;
            //
            // Persist logic in this place.
            //
            PersistState = PersistState.IsSaved;
            //
            // Post persist logic in this place.
            //
            PersistState = PersistState.IsNeutral;

        }

        /// <summary>
        /// Loads the specified e.
        /// </summary>
        /// <param name="e">
        /// </param>
        public virtual void Load(XElement e)
        {
            PersistState = PersistState.IsLoading;
            LoadChildren(e);
            LoadAttributes(e);
            PersistState = PersistState.IsNeutral;

        }
        #endregion
        //
        #region private void ChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)

        private void ChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add 
                || e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove
                || e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                || e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                IHelpItem nextNewChild = null;
                foreach (object newChild in e.NewItems)
                {
                    if ((nextNewChild = newChild as IHelpItem) != null)
                    {
                        nextNewChild.Parent = this;
                    }
                }
            }
            OnPropertyChanged("Children");
        }
        #endregion
        //
        #region private void PrivateGetChildrenWidthName<IT>(string name, ref List<IT> foundItems, HelpItemBase currentParent = null) where IT: class
        private void PrivateGetChildrenWidthName<IT>(string name, ref List<IT> foundItems, HelpItemBase currentParent = null) where IT: class
        {
            if (currentParent == null)
                currentParent = this;
            //
            IT foundResult = null;
            foreach (HelpItemBase child in currentParent.Children)
            {
                if (child.Name == name)
                {
                    foundResult = child as IT;
                }
                if (foundResult != null)
                {
                    foundItems.Add(foundResult);
                }
                PrivateGetChildrenWidthName(name, ref foundItems, child);
            }
        }
        #endregion
        //
        #region private void PrivateGetChildrenWidthName(string name, ref List<HelpItemBase> foundItems, HelpItemBase currentParent = null)
        private void PrivateGetChildrenWidthName(string name, ref List<HelpItemBase> foundItems, HelpItemBase currentParent = null)
        {
            if (currentParent == null)
                currentParent = this;
            //
            HelpItemBase foundResult = null;
            foreach (HelpItemBase child in currentParent.Children)
            {
                if (child.Name == name)
                {
                    foundResult = child;
                }
                if (foundResult != null)
                {
                    foundItems.Add(foundResult);
                }
                PrivateGetChildrenWidthName(name, ref foundItems, child);
            }
        }
        #endregion

    }
}
