using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PSHelpEdit.Attributes;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using PSHelpEdit.Interfaces;

namespace PSHelpEdit.Models
{

    [XmlTagType("parameterValueGroup", HelpItemTypes.parameterValueGroup)]
    public class ParameterValueGroupItem : HelpItemBase
    {
        //
        #region Private fields.
        private ObservableCollection<ParameterValueItem> _values;
        #endregion
        //
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueGroupItem"/> class.
        /// </summary>
        /// <remarks>Class file documentation please get here soon</remarks>
        public ParameterValueGroupItem()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueGroupItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public ParameterValueGroupItem(string name)
            : base(name)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueGroupItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public ParameterValueGroupItem(string name, object value)
            :base(name, value)
        {

        }
        public ParameterValueGroupItem(ParameterValueGroupItem other)
        {
            CopyValues(other);
        }
        #endregion
        //
        #region Public properties.
        public ObservableCollection<ParameterValueItem> Values
        {
            get 
            {
                if (_values == null)
                {
                    _values = new ObservableCollection<ParameterValueItem>();
                    _values.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ValuesCollectionChanged);
                }
                return _values; 
            }
        }

        #endregion
        //
        #region Base overridden methods.
        public override void Load(XElement e)
        {
            base.Load(e);
            RemapValues();
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
        //
        #region Private helper methods 
        private void RemapValues()
        {
            IEnumerable<ParameterValueItem> valuesInGroup = GetChildrenWithName<ParameterValueItem>(HelpItemTypes.parameterValue.ToString());
            foreach(ParameterValueItem valueItem in valuesInGroup)
            {
                Values.Add(valueItem);
            }
        }
        private void ValuesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {

            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {

            }
        }
        #endregion
        //
        #region private void CopyValues(ParameterValueGroupItem other)

        private void CopyValues(ParameterValueGroupItem other)
        {
            if (other == null)
                return;
            //
            foreach (IHelpItem iHlpItem in other.Children)
            {
                ParameterValueItem nextDownCastItem = iHlpItem as ParameterValueItem;
                if (nextDownCastItem == null)
                    throw new InvalidOperationException("Der må ikke være andet en child items as typen ParameterValueItem i ParameterValueGroupItem ellers er der noget helt galt.");
                else
                {
                    ParameterValueItem resultCpy = nextDownCastItem;
                    AddChild(resultCpy);
                }
                RemapValues();
            }
        }
        #endregion
    }
}
