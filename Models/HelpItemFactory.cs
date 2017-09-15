using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PSHelpEdit.Attributes;
using PSHelpEdit.Interfaces;
using PSHelpEdit.Utils;

namespace PSHelpEdit.Models
{
    public class HelpItemFactory
    {
        //
        #region Private items
        private static HelpItemFactory _instance;
        private Dictionary<HelpItemTypes, Type> _iemTypes;
        #endregion
        //
        #region Constructors
        protected HelpItemFactory()
        {
            ParseHelpitemTypes();
        }
        #endregion
        //
        #region  Public properties
        /// <summary>
        /// Gets the help item types.
        /// </summary>
        /// <value>
        ///  The help item types.
        /// </value>
        public Dictionary<HelpItemTypes, Type> ItemTypes
        {
            get
            {
                if (_iemTypes == null)
                    _iemTypes = new Dictionary<HelpItemTypes, Type>();
                return _iemTypes;
            }
        }

        /// <summary>
        /// Gets the help item factory1.
        /// </summary>
        /// <value>
        ///  The help item factory1.
        /// </value>
        public static HelpItemFactory Instance
        {
            get
            {
                if (HelpItemFactory._instance == null)
                    HelpItemFactory._instance = new HelpItemFactory();
                return HelpItemFactory._instance;
            }
        }
        #endregion
        //
        #region Public methods
        /// <summary>
        /// Creates the attribute item.
        /// </summary>
        /// <param name="a">
        /// </param>
        /// <returns>
        ///  FaciliaPSHlpEdit.Interffaces.IHelpItemAttribute.
        /// </returns>
        public IHelpItemAttribute CreateAttributeItem(XAttribute a)
        {
            ParamUtil.IsNull(a, "XAttribute a", "Parametern er ikke korrekt initialiseret i kaldet til .CreateAttributeItem(XAttribute a)");
            IHelpItemAttribute result = new HelpItemAttribute(a.Name.LocalName, a.Value);
            return result;
        }

        /// <summary>
        /// Creats the help item.
        /// </summary>
        /// <param name="helpItemType">
        /// </param>
        /// <returns>
        ///  FaciliaPSHlpEdit.Interffaces.IHelpItem.
        /// </returns>
        public IHelpItem CreateHelpItem(HelpItemTypes helpItemType)
        {
            IHelpItem result = null;
            Assembly ass = Assembly.GetExecutingAssembly();
            //
            if (helpItemType == HelpItemTypes.notAHelpItem)
                return result;
            //
            Type tCreate = ItemTypes[helpItemType];
            result = ass.CreateInstance(tCreate.FullName) as IHelpItem;
            return result;
        }
        /// <summary>
        /// Creates the item from x element.
        /// </summary>
        /// <param name="e">
        /// </param>
        /// <returns>
        ///  FaciliaPSHlpEdit.Interffaces.IHelpItem.
        /// </returns>
        public IHelpItem CreateItemFromXElement(XElement e)
        {
            ParamUtil.IsNull(e, "XElement e", "Parameteren er ikke korrekt initialiseret i kaldet til public static IHelpItem CreateItemFromXElement(XElement e)");
            //
            IHelpItem result = null;
            HelpItemTypes helptItemType = HelpItemTypes.notAHelpItem;
            //
            if (!XDocumentHelpers.GetHelpItemTypeFromElement(e, out helptItemType))
                return result;
            //
            switch (helptItemType)
            {
                case HelpItemTypes.alert:
                    result = new AlertItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.alertSet:
                    result = new AlertSetItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.helpItems:
                    result = new HelpItems(e.Name.LocalName);
                    break;
                case HelpItemTypes.command:
                    result = new CommandItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.details:
                    result = new DetailsItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.description:
                    result = new DescriptionItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.para:
                    result = new ParaItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.copyright:
                    result = new CopyrightItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.syntax:
                    result = new SyntaxItems(e.Name.LocalName);
                    break;
                case HelpItemTypes.syntaxItem:
                    result = new SyntaxItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.name:
                    result = new NameItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.parameter:
                    result = new ParameterItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.parameters:
                    result = new Parameters(e.Name.LocalName);
                    break;
                case HelpItemTypes.verb:
                    result = new VerbItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.version:
                    result = new VersionItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.examples:
                    result = new Examples(e.Name.LocalName);
                    break;
                case HelpItemTypes.example:
                    result = new Example(e.Name.LocalName);
                    break;
                case HelpItemTypes.title:
                    result = new TitleItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.code:
                    result = new CodeItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.parameterValue:
                    result = new ParameterValueItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.inputTypes:
                    result = new InputTypesItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.inputType:
                    result = new InputTypeItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.type:
                    result = new TypeItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.navigationLink:
                    result = new NavigationLinkItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.relatedLinks:
                    result = new RelatedLinksItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.linkText:
                    result = new LinkTextItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.uri:
                    result = new UriItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.introduction:
                    result = new IntroductionItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.commandLines:
                    result = new CommandLinesItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.commandLine:
                    result = new CommandLineItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.commandText:
                    result = new CommandTextItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.parameterValueGroup:
                    result = new ParameterValueGroupItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.nonTerminatingErrors:
                    result = new NonTerminatingErrorsItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.terminatingErrors:
                    result = new TerminatingErrorsItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.noun:
                    result = new NounItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.defaultValue:
                    result = new DefaultValueItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.returnValues:
                    result = new ReturnValuesItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.returnValue:
                    result = new ReturnValueItem(e.Name.LocalName);
                    break;
                case HelpItemTypes.notAHelpItem:
                    result = null;
                    break;
            }
            return result;
        }
        #endregion
        //
        #region Private methods
        private void ParseHelpitemTypes()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            IEnumerable<Type> exportedTypes = GetTypesWithXmlTagAttribute(ass);
            //
            HelpItemTypes currentType = HelpItemTypes.notAHelpItem;
            foreach (Type t in exportedTypes)
            {
                currentType = GetHelpItemTypeFromType(t);
                if (ItemTypes.Keys.Contains(currentType))
                {
                    throw new InvalidOperationException(string.Format("Der er allerede tilføjet en type med en key der passer til den funde, det må der ikke være key value er:[{0}]", currentType));
                }
                else
                {
                    ItemTypes[currentType] = t;
                }
            }
        }


        private IEnumerable<Type> GetTypesWithXmlTagAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(XmlTagTypeAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
        private HelpItemTypes GetHelpItemTypeFromType(Type t)
        {
            ParamUtil.IsNull(t, "Type t", "Parameteren er ikke korrekt initialseret i kaldet til metoden:GetHelpItemTypeFromType(Type t)");
            HelpItemTypes result = HelpItemTypes.notAHelpItem;
            object[] attrTypes = t.GetCustomAttributes(typeof(XmlTagTypeAttribute), false);
            if (attrTypes.Length > 0)
            {
                XmlTagTypeAttribute tmpValue = attrTypes[0] as XmlTagTypeAttribute;
                if (tmpValue != null)
                {
                    result = tmpValue.HelpItemItype;
                }
            }
            return result;
        }
        #endregion
    }
}
