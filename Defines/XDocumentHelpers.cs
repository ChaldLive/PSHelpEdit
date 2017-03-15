using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PSHelpEdit.Utils;

namespace PSHelpEdit
{
    public static class XDocumentHelpers
    {
        //
        #region public static HelpItemTypes ElementTypeFromString(this HelpItemTypes elementType, string s)
        /// <summary>
        /// Froms the string.
        /// </summary>
        /// <param name="s">
        /// </param>
        /// <returns>
        ///  FaciliaPSHlpEdit.Definitions.HelpItemTypes.
        /// </returns>
        public static HelpItemTypes ElementTypeFromString(this HelpItemTypes elementType, string s)
        {
            switch (s)
            {
                case Defines.alertSet:
                    return HelpItemTypes.alertSet;
                case Defines.alert:
                    return HelpItemTypes.alert;
                case Defines.notAHelpItem:
                    return HelpItemTypes.notAHelpItem;
                case Defines.helpItems:
                    return HelpItemTypes.helpItems;
                case Defines.command:
                    return HelpItemTypes.command;
                case Defines.name:
                    return HelpItemTypes.name;
                case Defines.description:
                    return HelpItemTypes.description;
                case Defines.copyright:
                    return HelpItemTypes.copyright;
                case Defines.verb:
                    return HelpItemTypes.verb;
                case Defines.version:
                    return HelpItemTypes.version;
                case Defines.syntax:
                    return HelpItemTypes.syntax;
                case Defines.syntaxItem:
                    return HelpItemTypes.syntaxItem;
                case Defines.parameter:
                    return HelpItemTypes.parameter;
                case Defines.parameterValue:
                    return HelpItemTypes.parameterValue;
                case Defines.parameterValueGroup:
                    return HelpItemTypes.parameterValueGroup;
                case Defines.parameters:
                    return HelpItemTypes.parameters;
                case Defines.examples:
                    return HelpItemTypes.examples;
                case Defines.example:
                    return HelpItemTypes.example;
                case Defines.title:
                    return HelpItemTypes.title;
                case Defines.code:
                    return HelpItemTypes.code;
                case Defines.remarks:
                    return HelpItemTypes.remarks;
                case Defines.para:
                    return HelpItemTypes.para;
                case Defines.details:
                    return HelpItemTypes.details;
                case Defines.inputTypes:
                    return HelpItemTypes.inputTypes;
                case Defines.inputType:
                    return HelpItemTypes.inputType;
                case Defines.type:
                    return HelpItemTypes.type;
                case Defines.navigationLink:
                    return HelpItemTypes.navigationLink;
                case Defines.linkText:
                    return HelpItemTypes.linkText;
                case Defines.uri:
                    return HelpItemTypes.uri;
                case Defines.introduction:
                    return HelpItemTypes.introduction;
                case Defines.commandLines:
                    return HelpItemTypes.commandLines;
                case Defines.commandLine:
                    return HelpItemTypes.commandLine;
                case Defines.commandText:
                    return HelpItemTypes.commandText;
                case Defines.terminatingErrors:
                    return HelpItemTypes.terminatingErrors;
                case Defines.nonTerminatingErrors:
                    return HelpItemTypes.nonTerminatingErrors;
                default:
                    return HelpItemTypes.notAHelpItem;
            }
        }
        #endregion
        //
        #region public static string ElementNameFromType(this HelpItemTypes elementType, HelpItemTypes type)
        /// <summary>
        /// Froms the type.
        /// </summary>
        /// <param name="type">
        /// </param>
        /// <returns>
        ///  System.String.
        /// </returns>
        public static string ElementNameFromType(this HelpItemTypes elementType, HelpItemTypes type)
        {
            return type.ToString();
        }
        #endregion
        //
        #region public static bool GetHelpItemTypeFromElement(XElement e, out HelpItemTypes linkType)
        /// <summary>
        /// Gets the help item type from element.
        /// </summary>
        /// <param name="e">
        /// </param>
        /// <returns>
        ///  FaciliaPSHlpEdit.Definitions.HelpItemTypes.
        /// </returns>
        public static bool GetHelpItemTypeFromElement(XElement e, out HelpItemTypes linkType)
        {
            ParamUtil.IsNull(e, "XElement e", "Parameteren er ikke korrekt initialiseret i kaldet til GetHelpTypeFromElement(XElement e)");
            bool result = false;
            string localName = e.Name.LocalName;
            //
            result = Enum.TryParse<HelpItemTypes>(localName, out linkType);
            return result;
        }
        #endregion
    }
}
