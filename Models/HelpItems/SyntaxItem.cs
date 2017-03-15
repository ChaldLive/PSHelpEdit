using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;

using System.Xml.Linq;

namespace PSHelpEdit.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("syntaxItem", HelpItemTypes.syntaxItem)]
    public class SyntaxItem : HelpItemBase
    {
        #region ♦ Private fields ♦
        private string _syntaxName;
        private List<ParameterItem> _parameters;
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxItem"/> class.
        /// </summary>
        /// <remarks>Class file documentation please get here soon</remarks>
        public SyntaxItem()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public SyntaxItem(string name)
            :base(name)
        {
        }
        public SyntaxItem(string name, object value)
            : base(name)
        {
        }
        #endregion
        //
        #region ♦ Public properties. ♦
        /// <summary>
        /// Gets or sets the name of the syntax.
        /// </summary>
        /// <value>
        ///  The name of the syntax.
        /// </value>
        public string SyntaxName
        {
            get { return _syntaxName; }
            set { _syntaxName = value; }
        }
        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>
        ///  The parameters.
        /// </value>
        public List<ParameterItem> Parameters
        {
            get 
            {
                if (_parameters == null)
                    _parameters = new List<ParameterItem>();
                return _parameters; 
            }
        }
        #endregion
        //
        #region ♦ Public Methods. ♦
        public override void Load(XElement e)
        {
            base.Load(e);
            MapProperties();
        }
        public override void Save(XElement e)
        {
            base.Save(e);
        }
        #endregion
        //
        #region ♦ Protected Methods. ♦
        protected void MapProperties()
        {
            MapSyntaxNameProperty();
        }
        #endregion
        //
        #region ♦ Private Methods. ♦
        private void MapSyntaxNameProperty()
        {
            HelpItemBase nameItemBase = GetChildWithName(HelpItemTypes.name.ToString());
            if (nameItemBase != null)
            {
                NameItem nameItem = nameItemBase as NameItem;
                if (nameItem != null)
                {
                    SyntaxName = nameItem.Value.ToString();
                }
            }
            ParameterItem nextParam = null;
            IEnumerable<HelpItemBase> parameters = GetChildrenWithName(HelpItemTypes.parameter.ToString());
            foreach(HelpItemBase param in parameters)
            {
                nextParam = param as ParameterItem;
                if (nextParam != null)
                {
                    Parameters.Add(nextParam);
                }
            }
        }
        #endregion
        //
        #region ♦ Abstract virtual methods. ♦
        #endregion
    }
      
}
