using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PSHelpEdit
{
    #region TreeViewItem state definitions
    public enum ItemState : int
    {
        IsNoState,
        IsRootItem,
        IsCommandItem,
        IsSyntaxItem,
        IsSyntaxItems,
        IsParameterItem,
        IsInputItem,
        IsReturnValueItem,
        IsAlertItem,
        IsExampleItem,
        IsNavigationLinkItem,
    }
    #endregion
    //
    #region Helpitem types
    public enum HelpItemTypes : int
    {
        alertSet,
        alert,
        notAHelpItem,
        helpItems,
        command,
        name,
        description,
        copyright,
        verb,
        version,
        syntax,
        syntaxItem,
        parameter,
        parameterValue,
        parameterValueGroup,
        parameters,
        examples,
        example,
        title,
        code,
        remarks,
        para,
        details,
        inputTypes,
        inputType,
        type,
        navigationLink,
        linkText,
        uri,
        introduction,
        commandLines,
        commandLine,
        commandText,
        terminatingErrors,
        nonTerminatingErrors,
        noun,
        defaultValue,
        returnValues,
        returnValue,
        relatedLinks,
    }
    #endregion
    //
    #region HelpItem state enums
    /// <summary>
    /// Enum PersistState
    /// </summary>
    public enum PersistState : int
    {
        IsNeutral,
        IsSaving,
        IsLoading,
        IsDirty,
        IsLoaded,
        IsSaved,
    }
    #endregion
    /// <summary>
    /// Class Defines.
    /// </summary>
    public static class Defines
    {
        //
        #region Private fields
        private static string[] _parameterValueTypes;
        #endregion
        //
        #region Standard string defines.
        public static string CopyrigthValue = "Copyright ©  2015 FACILIA f.m.b.a";
        public static string DefaultVersionValue = "Version 1.0";
        public static char[] CommandNameSplitterChar1 = new char[] { '-' };
        public static readonly string PART_CommandHeaderText = "PART_CommandHeaderText";
        public static readonly string PART_ParamHeaderText = "PART_ParamHeaderText";
        #endregion
        //
        #region Static initialisation 
        static Defines()
        {

        }
        #endregion
        //
        #region Public properties
        public static string[] CommandVerbNames
        {
            get
            {
                return InitCommandVerbs();
            }
        }

        public static string[] ParameterValueTypes
        {
            get
            {
                if (Defines._parameterValueTypes == null)
                    Defines.InitParameterValueTypes();
                return Defines._parameterValueTypes;
            }
        }

        #endregion
        //
        #region XDocument defines declarations.
        public static string XVersion       = "";
        public static string XEncodingUTF8  = "UTF-8";
        public static string XStandaloneNo  = "No";
        public static string XStandaloneYes = "Yes";
        #endregion
        //
        #region Maml help definition namespaces-
        public static XNamespace HelpItemsUri        = "http://msh";
        public static string SchemaName              = "maml";
        public static XNamespace DevNameSpaceUri     = "http://schemas.microsoft.com/maml/dev/2004/10";
        public static XNamespace MamlNameSpaceUri    = "http://schemas.microsoft.com/maml/2004/10";
        public static XNamespace CommandNameSpaceUri = "http://schemas.microsoft.com/maml/dev/command/2004/10";
        public static string SchemaNameSpaceName     = "schema";
        public static string DevNameSpaceName        = "dev";
        public static string MamlNameSpaceName       = "maml";
        public static string CommandNameSpaceName    = "command";
        public static string XmlNsNameSpaceName      = "xmlns";
        #endregion
        //
        #region Private methods
        private static void InitParameterValueTypes()
        {
            _parameterValueTypes = new string[]
            {
                "object",
                "object[]",
                "string",
                "string[]",
                "int",
                "int[]",
                "guid",
                "guid[]",
                "long",
                "long[]",
                "decimal",
                "decimal[]",
                "float",
                "float[]",
                "double",
                "double[]",
                "enum",
            };
        }
        #endregion
        //
        #region Std schema element names version 2
        public const string alertSet             = "alertSet";
        public const string alert                = "alert";
        public const string notAHelpItem         = "notAHelpItem";
        public const string helpItems            = "helpItems";
        public const string command              = "command";
        public const string name                 = "name";
        public const string description          = "description";
        public const string copyright            = "copyright";
        public const string verb                 = "verb";
        public const string version              = "version";
        public const string syntax               = "syntax";
        public const string syntaxItem           = "syntaxItem";
        public const string parameter            = "parameter";
        public const string parameterValue       = "parameterValue";
        public const string parameterValueGroup  = "parameterValueGroup";
        public const string parameters           = "parameters";
        public const string examples             = "examples";
        public const string example              = "example";
        public const string title                = "title";
        public const string code                 = "code";
        public const string remarks              = "remarks";
        public const string para                 = "para";
        public const string details              = "details";
        public const string inputTypes           = "inputTypes";
        public const string inputType            = "inputType";
        public const string type                 = "type";
        public const string navigationLink       = "navigationLink";
        public const string linkText             = "linkText";
        public const string uri                  = "uri";
        public const string introduction         = "introduction";
        public const string commandLines         = "commandLines";
        public const string commandLine          = "commandLine";
        public const string commandText          = "commandText";
        public const string terminatingErrors    = "terminatingErrors";
        public const string nonTerminatingErrors = "nonTerminatingErrors";
        public const string noun                 = "noun";
        #endregion
        //
        #region Helpitem attribute names declared here.
        public static string required            = "required";
        public static string variableLength      = "variableLength";
        public static string globbing            = "globbing";
        public static string pipelineInput       = "pipelineInput";
        public static string position            = "position";
        #endregion
        //
        #region command parameter attribute names
        public static class ParameterAttributeNames
        {
            public static string required       = "required";
            public static string variableLength = "variableLength";
            public static string globbing       = "globbing";
            public static string pipelineInput  = "pipelineInput";
            public static string position       = "position";
        }
        #endregion
        //
        #region Standard file names declared here
        public static string DotNetTypesFileName = "stdtypes.xml";
        #endregion
        //
        #region Standard system types names.
        public static string UnknownSystemTypeName = "Unknown";
        #endregion
        //
        #region Test fileNames 
        public static string TestFile_2 = @"C:\Facilia\Klienter\FaciliaPS\FaciliaPS\Help\FaciliaPS.dll-help.xml";
        public static string TestFile_3 = @"C:\Program Files\IIS\Microsoft Web Deploy V3\Microsoft.Web.Deployment.PowerShell.dll-Help.xml";
        public static string TestFile_4 = @"C:\Program Files\Microsoft SDKs\Azure\.NET SDK\v2.8\bin\plugins\RemoteAccess\Microsoft.WindowsAzure.ServiceRuntime.Commands.dll-Help.xml";
        public static string TestFile_5 = @"C:\Program Files\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\RemoteAccess\Microsoft.WindowsAzure.ServiceRuntime.Commands.dll-Help.xml";
        public static string TestFile_6 = @"C:\Program Files\PowerGadgets\PowerGadgets.Commands.dll-Help.xml";
        public static string TestFile_7 = @"C:\Program Files (x86)\Facilia\FaciliaPS\FaciliaPS.dll-help.xml";
        public static string TestFile_8 = @"C:\Users\cha.FACILIA\.vscode\extensions\ms-vscode.PowerShell-0.8.0\modules\Plaster\en-US\Plaster-help.xml";
        public static string TestFile_9 = @"C:\Users\cha.FACILIA\.vscode\extensions\ms-vscode.PowerShell-0.8.0\modules\PSScriptAnalyzer\en-US\Microsoft.Windows.PowerShell.ScriptAnalyzer.dll-Help.xml";
        public static string TestFile_10 = @"C:\Users\cha.FACILIA\Documents\WindowsPowerShell\Modules\PSReadline\en-US\PSReadline.dll-help.xml";
        public static string TestFile_11 = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\en-US\Microsoft.PowerShell.Utility.psm1-help.xml";
        public static string TestFile_12 = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\Modules\CimCmdlets\en-US\Microsoft.Management.Infrastructure.CimCmdlets.dll-help.xml";
        public static string TestFile_13 = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\Modules\ISE\en-US\ISE.psm1-help.xml";
        public static string TestFile_14 = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\Modules\PSScheduledJob\en-US\Microsoft.PowerShell.ScheduledJob.dll-help.xml";
        #endregion
        //
        #region Standard file names O.A.
        public static string MruListFileName = "MruFileList.xml";
        #endregion
        //
        #region public static string HelpItemTypeName(HelpItemTypes t)
        /// <summary>
        /// Helps the name of the item type.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>System.String.</returns>
        public static string HelpItemTypeName(HelpItemTypes t)
        {
            return t.ToString();
        }
        #endregion
        //
        #region public static string[] InitCommandVerbs()
        public static string[] InitCommandVerbs()
        {
            string[] result = new string[]
            {
                "Add",
                "Clear",
                "Close",
                "Copy",
                "Enter",
                "Exit",
                "Find",
                "Format",
                "Get",
                "Hide",
                "Join",
                "Lock",
                "Move",
                "New",
                "Open",
                "Pop",
                "Push",
                "Redo",
                "Remove",
                "Rename",
                "Reset",
                "Search",
                "Select",
                "Set",
                "Show",
                "Skip",
                "Split",
                "Step",
                "Switch",
                "Undo",
                "Unlock",
                "Watch",
                "Connect",
                "Disconnect",
                "Read",
                "Receive",
                "Send",
                "Write",
                "Disable",
                "Enable",
                "Debug",
                "Convert",
                "Complete",
                "Limit",
                "Invoke",
                "Register",
                "Resolve",
                "Restart",
                "Restore",
                "Resume",
                "Suspend",
                "Stop",
                "Start",
                "Use",
                "Test",
                "Wait",
                "Backup",
                "Checkpoint",
                "Compare",
                "Compress",
                "ConvertFrom",
                "ConvertTo",
                "Dismount",
                "Edit",
                "Expand",
                "Export",
                "Group",
                "Import",
                "Initialize",
                "Merge",
                "Mount",
                "Out",
                "Publish",
                "Save",
                "Sync",
                "Unpublish",
                "Update",
                "invoke",
                "out"
            };
            return result;
        }
        #endregion
        //
        #region Cmdlet Communication verbs
        #endregion

    }
}
