using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PSHelpEdit.Attributes;

using PSHelpEdit.Interfaces;
using PSHelpEdit;

namespace PSHelpEdit.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("helpItems", HelpItemTypes.helpItems)]
    public class HelpItems : HelpItemBase
    {
        #region  Private fields 
        #endregion
        //
        #region  Constructors 
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpItems"/> class.
        /// </summary>
        public HelpItems()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public HelpItems(string name)
            :base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpItems"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public HelpItems(string name, object value)
            : base(name)
        {
        }
        #endregion
        //
        #region  Public properties. 
        #endregion
        //
        #region  Public Methods. 
        public CommandItem AddNewCommandItem(string verb, string noun)
        {
            CommandItem result = new CommandItem();
            result.Verb = verb;
            result.Noun = noun;
            result.Name = $"{verb}-{noun}";
            AddChild(result);
            return result;
        }
        #endregion
        //
        #region  Protected Methods. 
        public override void Load(XElement e)
        {
            PersistState = PersistState.IsLoading;
            string localName = e.Name.LocalName;
            IHelpItem ICmdItem = null;
            foreach (XElement child in e.Elements())
            {
                localName             = child.Name.LocalName;
                ICmdItem              = new CommandItem(localName);
                ICmdItem.PersistState = PersistState.IsLoading;
                AddChild(ICmdItem);
                ICmdItem.Load(child);
            }
            PersistState = PersistState.IsNeutral;
        }
        #endregion
        //
        #region  Private Methods. 
        #endregion
        //
        #region  Abstract virtual methods. 
        #endregion
    }
}
