using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSHelpEdit.Attributes
{
    /// <summary>
    /// Definerer en klasse, der er dekoreret med denne attribut
    /// som en klasse, der kan håndtere cmdlet xml dokumenterings elementer.    
    /// Klassen skal kunne indlæse og gemme XMLD dokumenterings elementer
    /// i det rigtige format.
    /// </summary>
    public class XmlTagTypeAttribute : Attribute
    {
        //
        #region  Private fields
        private HelpItemTypes _helpItemItype;
        private string _tagName;
        #endregion
        //
        #region  Constructors
        /// <summary>
        /// Definerer en klasse, der er dekoreret med denne attribut
        /// som en klasse, der kan håndtere cmdlet xml dokumenterings elementer<see cref="XmlTagType"/> class.
        /// </summary>
        /// <param name="tagName">Navnet på det tag element, klassen skal kunne håndtere.</param>
        /// <param name="type">Type på de xmlElement, klassen skal kunne håndtere, både load og save.</param>
        public XmlTagTypeAttribute(string tagName, HelpItemTypes type)
        {
            _tagName = tagName;
            _helpItemItype = type;
        }
        #endregion
        //
        #region Public properties
        /// <summary>
        /// Gets the help item itype.
        /// </summary>
        /// <value>
        ///  The help item itype.
        /// </value>
        public HelpItemTypes HelpItemItype
        {
            get { return _helpItemItype; }
        }
        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        /// <value>
        ///  The name of the tag.
        /// </value>
        public string TagName
        {
            get { return _tagName; }
        }
        #endregion
    }
}
