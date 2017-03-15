using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PSHelpEdit.Keys
{
    public static partial class ResourceKeys
    {
        #region ResourceKeyNames
        public static string ListboxItemEditControlTemplateName      = "ListboxItemEditControlTemplateName";
        public static string ListboxItemStdControlTemplateName       = "ListboxItemStdControlTemplateName";
        public static string ListboxItemParamEditControlTemplateName = "ListboxItemParamEditControlTemplateName";
        public static string ListboxItemParamStdControlTemplateName  = "ListboxItemParamStdControlTemplateName";
        public static string ListBoxItemMouseOverBackground          = "Item.MouseOver.Background";
        public static string ListBoxItemMouseOverBorder              = "Item.MouseOver.Border";
        public static string ListBoxSelectedInactiveBackground       = "Item.SelectedInactive.Background";
        public static string ListBoxItemSelectedInactiveBorder       = "Item.SelectedInactive.Border";
        public static string ListBoxItemSelectedActiveBackground     = "Item.SelectedActive.Background";
        public static string ListBoxSelectedActiveBorder             = "Item.SelectedActive.Border";
        #endregion
        //
        #region Private resourcekey instances, sparce memory.
        private static ComponentResourceKey _listboxItemParamEditControlTemplateKey;
        private static ComponentResourceKey _listboxItemParamStdControlTemplateKey;
        private static ComponentResourceKey _listboxItemEditControlTemplateKey;
        private static ComponentResourceKey _listboxItemStdControlTemplateKey;
        private static ComponentResourceKey _listBoxItemMouseOverBackgroundKey;
        private static ComponentResourceKey _listBoxItemMouseOverBorderKey;
        private static ComponentResourceKey _listBoxSelectedInactiveBackgroundKey;
        private static ComponentResourceKey _listBoxItemSelectedInactiveBorderKey;
        private static ComponentResourceKey _listBoxItemSelectedActiveBackgroundKey;
        private static ComponentResourceKey _listBoxSelectedActiveBorderKey;
        #endregion
        //
        #region ListBoxItemParam keys
        public static ComponentResourceKey ListboxItemParamEditControlTemplateKey
        {
            get{return _listboxItemParamEditControlTemplateKey ?? (_listboxItemParamEditControlTemplateKey = CreateInstanceEx(ListboxItemEditControlTemplateName));}
        }
        public static ComponentResourceKey ListboxItemParamStdControlTemplateKey
        {
            get{return _listboxItemParamStdControlTemplateKey ?? (_listboxItemParamStdControlTemplateKey = CreateInstanceEx(ListboxItemParamStdControlTemplateName));}
        }
        #endregion
        //
        #region ListBoxItem Template key instances
        public static ComponentResourceKey ListboxItemEditControlTemplateKey
        {
            get{return _listboxItemEditControlTemplateKey ?? (_listboxItemEditControlTemplateKey = CreateInstanceEx(ListboxItemEditControlTemplateName));}
        }
        public static ComponentResourceKey ListboxItemStdControlTemplateKey
        {
            get{return _listboxItemStdControlTemplateKey ?? (_listboxItemStdControlTemplateKey = CreateInstanceEx(ListboxItemStdControlTemplateName));}
        }
        #endregion
        //
        #region ListBoxItem Color keys
        public static ComponentResourceKey ListBoxItemMouseOverBackgroundKey
        {
            get{return _listBoxItemMouseOverBackgroundKey ?? (_listBoxItemMouseOverBackgroundKey = CreateInstanceEx(ListBoxItemMouseOverBackground));}
        }
        public static ComponentResourceKey ListBoxItemMouseOverBorderKey
        {
            get{return _listBoxItemMouseOverBorderKey ?? (_listBoxItemMouseOverBorderKey = CreateInstanceEx(ListBoxItemMouseOverBorder));}
        }
        public static ComponentResourceKey ListBoxSelectedInactiveBackgroundKey
        {
            get{return _listBoxSelectedInactiveBackgroundKey ?? (_listBoxSelectedInactiveBackgroundKey = CreateInstanceEx(ListBoxSelectedInactiveBackground));}
        }
        public static ComponentResourceKey ListBoxItemSelectedInactiveBorderKey
        {
            get{return _listBoxItemSelectedInactiveBorderKey ?? (_listBoxItemSelectedInactiveBorderKey = CreateInstanceEx(ListBoxItemSelectedInactiveBorder));}
        }
        public static ComponentResourceKey ListBoxItemSelectedActiveBackgroundKey
        {
            get{return _listBoxItemSelectedActiveBackgroundKey ?? (_listBoxItemSelectedActiveBackgroundKey = CreateInstanceEx(ListBoxItemSelectedActiveBackground));}
        }
        public static ComponentResourceKey ListBoxSelectedActiveBorderKey
        {
            get{return _listBoxSelectedActiveBorderKey ?? (_listBoxSelectedActiveBorderKey = CreateInstanceEx(ListBoxSelectedActiveBorder));}
        }
        #endregion
    }
}
