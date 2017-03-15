using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PSHelpEdit.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class XSerialise : TreeItemModel
    {
        #region ♦ Private fields ♦
        private string _elementName;
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// 
        /// </summary>
        public XSerialise()
        {
        }
        public XSerialise(string itemTitle)
            :base(itemTitle)
        {
        }
        public XSerialise(string itemTitle, string itemValue)
            :base(itemTitle,itemValue)
        {
        }

        #endregion
        //
        #region ♦ Public properties. ♦
        public virtual string ElementName
        {
            get{return _elementName;}
            set{_elementName = value;}
        }
        #endregion
        //
        #region ♦ Public abstract Methods. ♦
        public virtual void Load(XElement e)
        {

        }
        public virtual void Save(XElement e)
        {

        }
        #endregion
        //
        #region ♦ Protected Methods. ♦
        #endregion
        //
        #region ♦ Private Methods. ♦
        #endregion
        //
        #region ♦ Abstract virtual methods. ♦
        #endregion
    }

}
