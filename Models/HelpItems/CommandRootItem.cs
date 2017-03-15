using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using PSHelpEdit.Attributes;
using PSHelpEdit.Interfaces;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandRootItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        private string _commandName;
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// 
        /// </summary>
        public CommandRootItem()
        {
        }
        public CommandRootItem(string name)
            : base(name)
        {
        }
        public CommandRootItem(string name, object value)
            :base(name,value)
        {
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        public string CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }
        #endregion
        //
        #region ♦ Public Methods. ♦
        #endregion
        //
        #region MyRegion
        public void Load(string fileName)
        {
            ParamUtil.IsNull(fileName, "string fileName", "Parameteren er ikke korrrekt initialiseret i kaldet til metoden : public void CommandRootItem.Load(string fileName)");
            XDocument doc = XDocument.Load(fileName);
            if(doc != null)
            {
                IEnumerable<XElement> commandItems = doc.Root.Elements();
                foreach(XElement element in commandItems)
                {
                    Load(element);
                }
            }
        }
        #endregion
        //
        #region public override void Load(XElement e)
        public override void Load(XElement e)
        {
            IHelpItem ICmdItem    = null;
            PersistState          = PersistState.IsLoading;
            ICmdItem              = HelpItemFactory.Instance.CreateHelpItem(HelpItemTypes.command);
            AddChild(ICmdItem);
            ICmdItem.PersistState = PersistState.IsLoading;
            ICmdItem.Load(e);
            GetCommandNameValue();
            PersistState          = PersistState.IsNeutral;
        }
        #endregion
        //
        #region public override void Save(XElement e)
        public override void Save(XElement e)
        {
        }
        #endregion
        //
        #region ♦ Private helpers ♦
        private void GetCommandNameValue()
        {
            IHelpItem child = GetChildWithName(Defines.command);
            CommandItem cmdItem = null;
            if (child != null)
            {
                cmdItem = child as CommandItem;
                if (cmdItem != null)
                {
                    CommandName = cmdItem.CommandName;
                }
            }
        }
        #endregion
    }

}
