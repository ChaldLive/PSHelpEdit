using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSHelpEdit.Attributes;


namespace PSHelpEdit.Models
{

    /// <summary>
    /// 
    /// </summary>
    [XmlTagType("details", HelpItemTypes.details)]
    public class DetailsItem : HelpItemBase
    {
        #region Private fields
        #endregion
        //
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsItem"/> class.
        /// </summary>
        public DetailsItem()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public DetailsItem(string name)
            :base(name)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public DetailsItem(string name, object value)
            :base(name, value)
        {
        }
        #endregion
        //
        #region Public properties.
        public void AddVerbItem(string verb)
        {
            VerbItem verbItem = GetChildWidthName<VerbItem>(HelpItemTypes.verb.ToString());
            if (verbItem != null)
            {
                verbItem.Value = verb;
            }
            else
            {
                VerbItem newVerbItem = new VerbItem(HelpItemTypes.verb.ToString(), verb);
                AddChild(newVerbItem);
            }
        }
        public NounItem AddNoun(string nounValue)
        {
            NounItem result = null;
            result = GetChildWidthName<NounItem>(HelpItemTypes.noun.ToString());
            if (result != null)
            {
                result.Value = nounValue;
            }
            else
            {
                result = new NounItem(HelpItemTypes.noun.ToString(), nounValue);
                AddChild(result);
            }
            return result;

        }
        public void AddName(string value)
        {
            NameItem nameItem = GetChildWidthName<NameItem>(HelpItemTypes.name.ToString());
            if (nameItem != null)
            {
                nameItem.Value = value;
            }
            else
            {
                NameItem newNameItem = new NameItem(HelpItemTypes.name.ToString(), value);
                AddChild(newNameItem);
            }
        }
        public void AddDescription(string value)
        {
            DescriptionItem dsc = GetChildWidthName<DescriptionItem>(HelpItemTypes.description.ToString());
            if (dsc != null)
            {
                dsc.ParaValue = value;
            }
            else
            {
                DescriptionItem newDsc = new DescriptionItem(HelpItemTypes.description.ToString(), value);
                AddChild(newDsc);
            }
        }
        public void AddVersion(string value)
        {
            VersionItem version = GetChildWidthName<VersionItem>(HelpItemTypes.version.ToString());
            if (version != null)
            {
                version.Value = value;
            }
            else
            {
                VersionItem newVersion = new VersionItem(HelpItemTypes.version.ToString(), value);
                AddChild(newVersion);
            }
        }
        #endregion
        //
        #region Public Methods.
        #endregion
        //
        #region Protected Methods.
        #endregion
        //
        #region Private Methods.
        #endregion
        //
        #region Abstract virtual methods.
        #endregion
    }
      
}
;