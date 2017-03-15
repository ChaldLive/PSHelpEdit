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
        #region Private fields
        private static string ListViewItemStdControlTemplateName = "ListViewItemStdControlTemplateName";
        private static string ListViewItemEditableControlTemplateName = "ListViewItemEditableControlTemplateName";

        private static string ListItemHoverFillName = "ListItemHoverFillName";
        private static string ListItemSelectedFillName = "ListItemSelectedFillName";
        private static string ListItemSelectedInactiveFillName = "ListItemSelectedInactiveFillName";
        private static string ListItemSelectedHoverFillName = "ListItemSelectedHoverFillName";
        #endregion

        #region Instance members
        private static ComponentResourceKey _listItemHoverFillKey;
        private static ComponentResourceKey _listItemSelectedFillKey;
        private static ComponentResourceKey _listItemSelectedInactiveFillKey;
        private static ComponentResourceKey _listItemSelectedHoverFillKey;
        private static ComponentResourceKey _listViewItemStdControlTemplateKey;
        private static ComponentResourceKey _listViewItemEditableControlTemplateKey;
        #endregion
        //
        #region Public properties
        public static ComponentResourceKey ListItemHoverFillKey
        {
            get
            {
                if (_listItemHoverFillKey == null)
                    _listItemHoverFillKey = CreateInstanceEx(ListItemHoverFillName);
                return _listItemHoverFillKey;
            }
        }

        public static ComponentResourceKey ListItemSelectedFillKey
        {
            get
            {
                if (_listItemSelectedFillKey == null)
                    _listItemSelectedFillKey = CreateInstanceEx(ListItemSelectedFillName);
                return _listItemSelectedFillKey;
            }
        }

        public static ComponentResourceKey ListItemSelectedInactiveFillKey
        {
            get
            {
                if (_listItemSelectedInactiveFillKey == null)
                    _listItemSelectedInactiveFillKey = CreateInstanceEx(ListItemSelectedInactiveFillName);
                return _listItemSelectedInactiveFillKey;
            }
        }

        public static ComponentResourceKey ListItemSelectedHoverFillKey
        {
            get
            {
                if (_listItemSelectedHoverFillKey == null)
                    _listItemSelectedHoverFillKey = CreateInstanceEx(ListItemSelectedHoverFillName);
                return _listItemSelectedHoverFillKey;
            }
        }

        public static ComponentResourceKey ListViewStdControlTemplateKey
        {
            get
            {
                if (_listViewItemStdControlTemplateKey == null)
                    _listViewItemStdControlTemplateKey = CreateInstanceEx(ListViewItemStdControlTemplateName);
                return _listViewItemStdControlTemplateKey;
            }
        }

        public static ComponentResourceKey ListViewEditableControlTemplateKey
        {
            get
            {
                if(_listViewItemEditableControlTemplateKey == null)
                    _listViewItemEditableControlTemplateKey = CreateInstanceEx(ListViewItemEditableControlTemplateName);
                return _listViewItemEditableControlTemplateKey;
            }
        }
        #endregion


    }
}
